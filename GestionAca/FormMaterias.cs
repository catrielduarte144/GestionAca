using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionAca
{
    public partial class FormMaterias : Form
    {
        public FormMaterias()
        {
            InitializeComponent();
        }

        //metodo cargar datos
        private void CargarMaterias()
        {
            try
            {
                //código para cargar materias en el DataGridView
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                    select
                        m.id_materia,
                        m.nombre AS Materia,
                        c.nombre AS Carrera,
                        p.apellido + ',´' + p.nombre AS Profesor,
                        m.turno,
                        m.estado
                    FROM Materia m
                    LEFT JOIN Carrera c ON m.id_carrera = c.id_carrera
                    LEFT JOIN Profesores p On m.id_profesor = p.id_profesor";

                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvMateria.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar materias: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboBoxes()
        {
            //cargar estados
            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cmbEstado.SelectedIndex = 0; //selecciona activo por defecto

            //cargar turnos
            cmbTurno.Items.Clear();
            cmbTurno.Items.AddRange(new object[] { "Mañana", "Tarde", "Noche" });
            cmbTurno.SelectedIndex = 0; //selecciona mañana por defecto

            try
            {
                //cargar carreras y profesores desde la base de datos
                CargarClaveForanea(cmbCarrera, "Carrera", "nombre", "id_carrera");
                CargarClaveForanea(cmbProfesor, "Profesores", "apellido + ', ' + nombre", "id_profesor");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar comboBoxes: " + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarClaveForanea(ComboBox cmb, string tabla, string displayColumn, string valueColumn)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = $"SELECT {valueColumn}, {displayColumn} AS DisplayValue FROM {tabla}";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmb.DataSource = dt;
                //configura las propiedades de enlace de datos
                cmb.DisplayMember = "DisplayValue"; //lo que ve el usuario
                cmb.ValueMember = valueColumn;
                cmb.SelectedIndex = 0;
            }
        }

        //evento de formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            CargarComboBoxes();
            CargarMaterias();
            txtID.ReadOnly = true;
        }

        //mostrar datos en los cuadros al seleccionar una fila
        private void dgvMateria_selectionChanged(object sender, EventArgs e)
        {
            if (dgvMateria.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvMateria.SelectedRows[0];
                if (row != null)
                {
                    //asignacion de valores
                    txtID.Text = row.Cells["id_materia"].Value?.ToString() ?? string.Empty;
                    txtMateria.Text = row.Cells["Materia"].Value?.ToString() ?? string.Empty;

                    //asignacion a combo por el testo visible
                    cmbEstado.Text = row.Cells["estado"].Value?.ToString() ?? string.Empty;
                    cmbTurno.Text = row.Cells["turno"].Value?.ToString() ?? string.Empty;
                    cmbCarrera.Text = row.Cells["carrera"].Value?.ToString() ?? string.Empty;
                    cmbProfesor.Text = row.Cells["profesor"].Value?.ToString() ?? string.Empty;
                }
            }
        }

        //logica de crud
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtMateria.Text) ||
                cmbCarrera.SelectedValue == null ||
                cmbProfesor.SelectedValue == null ||
                cmbEstado.SelectedValue == null ||
                cmbTurno.SelectedValue == null)
            {
                MessageBox.Show("Porfavor complete el nombre de la materia y seleccione estado, carrera, profesor y turno");
                return false;
            }
            return true;
        }

        //insertar materia
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"
                                INSERT INTO Materia (nombre, id_carrera, id_profesor, turno, estado)
                                VALUES (@nombre, @id_carrera, @id_profesor, @turno, @estado)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nombre", txtMateria.Text.Trim());
                    //se obtiene clave foranea 
                    command.Parameters.AddWithValue("@id_carrera", cmbCarrera.SelectedValue);
                    command.Parameters.AddWithValue("@id_profesor", cmbProfesor.SelectedValue);
                    command.Parameters.AddWithValue("@turno", cmbTurno.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@estado", cmbEstado.SelectedItem.ToString());

                    command.ExecuteNonQuery();
                    MessageBox.Show("Materia insertada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarMaterias();
                    LimpiarCampo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar materia: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //editar materia
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Seleccione una materia para editar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos()) return;

            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        UPDATE Materia SET
                            nombre = @nombre,
                            id_carrera = @id_carrera,
                            id_profesor = @id_profesor,
                            turno = @turno,
                            estado = @estado
                        WHERE id_materia = @id";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nombre", txtMateria.Text.Trim());
                    command.Parameters.AddWithValue("@id_carrera", cmbCarrera.SelectedValue);
                    command.Parameters.AddWithValue("@id_profesor", cmbProfesor.SelectedValue);
                    command.Parameters.AddWithValue("@turno", cmbTurno.SelectedValue);
                    command.Parameters.AddWithValue("@estado", cmbEstado.SelectedValue);
                    //command.Parameters.AddWithValue("@id", txtID);
                    command.Parameters.AddWithValue("@id", txtID.Text.Trim());


                    command.ExecuteNonQuery();
                    MessageBox.Show("Materia modificada correctamente. ");
                    CargarMaterias();
                    LimpiarCampo();

                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Error al modificar materia: " + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //eliminar materia
        private void btnEliminarMateria_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                //MessageBox.Show("Seleccione una materia para dar de baja. ",ex.Messege, "Advertencia" MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("Seleccione una materia para dar de baja.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Materias SET estado = 'inactivo' WHERE id_materia = @id";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", txtID.Text);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Materia dada de baja correctamente. ");
                    CargarMaterias();
                    LimpiarCampo();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error al dar de baja la materia: " + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //limpiar campo de texto
        private void LimpiarCampo()
        {
            txtID.Clear();
            txtMateria.Clear();
            cmbEstado.SelectedIndex = 0; //activo
            cmbCarrera.SelectedIndex = -1;
            cmbProfesor.SelectedIndex = -1;
            cmbTurno.SelectedIndex = 0; //mañana
        }

        //navegacion
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsertar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
