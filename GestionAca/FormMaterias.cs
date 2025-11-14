using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
                        p.apellido + ', ' + p.nombre AS Profesor,
                        m.estado
                    FROM Materias m
                    LEFT JOIN carreras c ON m.id_carrera = c.id_carrera
                    LEFT JOIN Profesores p On m.id_profesor = p.id_profesor";

                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvMateria.DataSource = dt;
                    //para seleccionar toda la fila al hacer clicl en cualquier celda
                    dgvMateria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvMateria.MultiSelect = false;

                    //para autoajustar ancho columna
                    dgvMateria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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

            ////cargar turnos
            //cmbTurno.Items.Clear();
            //cmbTurno.Items.AddRange(new object[] { "Mañana", "Tarde", "Noche" });
            //cmbTurno.SelectedIndex = 0; //selecciona mañana por defecto

            try
            {
                //cargar carreras y profesores desde la base de datos
                CargarClaveForanea(cmbCarrera, "carreras", "nombre", "id_carrera");
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
        private void FormMaterias_Load(object sender, EventArgs e)
        {
            CargarComboBoxes();
            CargarMaterias();
            txtID.ReadOnly = true;

            //asignar valor 1 y 0 a textos Activo e Inactivo de cmbEstado
            cmbEstado.DisplayMember = "Text";
            cmbEstado.ValueMember = "Value";
            cmbEstado.DataSource = new[]
            {
                new { Text = "Activo", Value = 1 },
                new { Text = "Inactivo", Value = 0 }
            }.ToList();

        }

        //mostrar datos en los cuadros al seleccionar una fila
        private void DgvMateria_Click(object sender, EventArgs e)
        {
            //asignacion de valores
            txtID.Text = dgvMateria.SelectedRows[0].Cells["id_materia"].Value.ToString();
            txtMateria.Text = dgvMateria.SelectedRows[0].Cells["Materia"].Value.ToString();

            //asignacion a combo Estado
            var valorEstado = dgvMateria.SelectedRows[0].Cells["estado"].Value?.ToString();
            if (valorEstado == "1")
                cmbEstado.Text = "Activo";
            else if (valorEstado == "0")
                cmbEstado.Text = "Inactivo";
            else
                cmbEstado.SelectedIndex = -1; // si está nulo u otro valor

            //asignacion a combo Profesor y Carrera
            cmbProfesor.Text = dgvMateria.SelectedRows[0].Cells["profesor"].Value?.ToString() ?? string.Empty;
            cmbCarrera.Text = dgvMateria.SelectedRows[0].Cells["carrera"].Value?.ToString() ?? string.Empty;

            //deshabilitar edición de texto celda
            dgvMateria.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        //logica de crud
        private bool ValidarCampos()
        {
            //Debug.WriteLine("Carrera: " + cmbCarrera.SelectedValue);
            //Debug.WriteLine("Profesor: " + cmbProfesor.SelectedValue);
            //Debug.WriteLine("Estado: " + cmbEstado.SelectedValue);

            if (string.IsNullOrWhiteSpace(txtMateria.Text) ||
                cmbCarrera.SelectedValue == null ||
                cmbProfesor.SelectedValue == null ||
                cmbEstado.SelectedItem == null //||
                //cmbTurno.SelectedValue == null
                )
            {
                MessageBox.Show("Porfavor complete el nombre de la materia y seleccione estado, carrera y profesor");
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
                                INSERT INTO Materias (nombre, id_carrera, id_profesor, estado)
                                VALUES (@nombre, @id_carrera, @id_profesor, @estado)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nombre", txtMateria.Text.Trim());
                    //se obtiene clave foranea 
                    command.Parameters.AddWithValue("@id_carrera", cmbCarrera.SelectedValue);
                    command.Parameters.AddWithValue("@id_profesor", cmbProfesor.SelectedValue);
                    // command.Parameters.AddWithValue("@turno", cmbTurno.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@estado", Convert.ToInt32(cmbEstado.SelectedValue));

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
                        UPDATE Materias SET
                            nombre = @nombre,
                            id_carrera = @id_carrera,
                            id_profesor = @id_profesor,
                            estado = @estado
                        WHERE id_materia = @id";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nombre", txtMateria.Text.Trim());
                    command.Parameters.AddWithValue("@id_carrera", cmbCarrera.SelectedValue);
                    command.Parameters.AddWithValue("@id_profesor", cmbProfesor.SelectedValue);
                    //command.Parameters.AddWithValue("@turno", cmbTurno.SelectedValue);
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
                    string query = "delete Materias WHERE id_materia = @id";
                    //delete profesores where id_profesor = @id_profesor

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
            //cmbTurno.SelectedIndex = 0; //mañana
        }

        //navegacion
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
