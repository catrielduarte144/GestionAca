using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionAca
{
    public partial class FormAlumnos : Form
    {
        
        public FormAlumnos()
        {
            InitializeComponent();
        }

        //validaciones auxiliares
        bool EsNumero(string text, string campo)
        {
            if (!long.TryParse(text, out _))
            {
                MessageBox.Show($"El campo {campo} debe ser numérico.", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        //operacion   CRUD
        //evento para cargar datos en el datagridview
        private void CargarAlumnos()
        {
            try
            {                
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT id_alumno, apellido, nombre, dni, legajo, estado FROM Alumnos";
                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAlumnos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar alumnos: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //cargar formulario
        private void FormAlumnos_Load(object sender, EventArgs e)
        {
            CargarAlumnos();
            txtID.ReadOnly = true; //el ID no se puede modificar
        }

        //grabar nuevo alumno
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtLegajo.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de grabar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(!EsNumero(txtDni.Text, "DNI") || !EsNumero(txtLegajo.Text, "Legajo"))
            {
                return; //si alguna validacion falla, salir del metodo
            }

            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Alumnos (apellido, nombre, dni, legajo, estado) VALUES (@apellido, @nombre, @dni, @legajo, '1')";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@apellido", txtApellido.Text);
                    command.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    command.Parameters.AddWithValue("@dni", txtDni.Text);
                    command.Parameters.AddWithValue("@legajo", txtLegajo.Text);
                    //command.Parameters.AddWithValue("@email", txtEmail.Text);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Alumno agregado correctamente.");
                    CargarAlumnos(); //actualizar datagridview
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar alumno: " + ex.Message);
            }
        }

        //modificar alumno
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Por favor, seleccione un alumno para modificar.", "Alumno no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtLegajo.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de modificar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!EsNumero(txtDni.Text, "DNI") || !EsNumero(txtLegajo.Text, "Legajo"))
            {
                return; //si alguna validacion falla, salir del metodo
            }

            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Alumnos SET apellido = @apellido, nombre = @nombre, dni = @dni, legajo = @legajo WHERE id_alumno = @id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@apellido", txtApellido.Text);
                    command.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    command.Parameters.AddWithValue("@dni", txtDni.Text);
                    command.Parameters.AddWithValue("@legajo", txtLegajo.Text);
                    //command.Parameters.AddWithValue("@email", txtEmail.Text);
                    command.Parameters.AddWithValue("@id", txtID.Text);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Alumno modificado correctamente.");
                    CargarAlumnos(); //actualizar datagridview
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar alumno: " + ex.Message);
            }
        }

        //dar de baja alumno
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Por favor, seleccione un alumno para dar de baja.", "Alumno no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //confirmar baja
            if (MessageBox.Show("¿Está seguro que desea dar de baja a este alumno?", "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Alumnos SET estado= '0' WHERE id_alumno = @id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", txtID.Text);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Alumno dado de baja correctamente.");
                    CargarAlumnos(); //actualizar datagridview
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar alumno: " + ex.Message);
            }
        }

        //mostrar datos en los cuadros de texto al seleccionar fila del datagridview
        private void dgvAlumnos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAlumnos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvAlumnos.SelectedRows[0];
                if(!row.IsNewRow)
                {  
                    txtID.Text = row.Cells["id_alumno"].Value.ToString() ?? string.Empty;
                    txtApellido.Text = row.Cells["apellido"].Value.ToString() ?? string.Empty;
                    txtNombre.Text = row.Cells["nombre"].Value.ToString() ?? string.Empty;
                    txtDni.Text = row.Cells["dni"].Value.ToString() ?? string.Empty;
                    txtLegajo.Text = row.Cells["legajo"].Value.ToString() ?? string.Empty;
                    //txtEmail.Text = row.Cells["email"].Value.ToString() ?? string.Empty;

                }
                  
            }
        }

        //limpiar campos de texto
        private void LimpiarCampos()
        {
            txtID.Clear();
            txtApellido.Clear();
            txtNombre.Clear();
            txtDni.Clear();
            txtLegajo.Clear();
            //txtEmail.Clear();
        }

        //boton cerrar formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAlumnos_Click(object sender, EventArgs e)
        {
            //cargar datos de la columna clickeada en objetos txt

            txtID.Text = dgvAlumnos.SelectedRows[0].Cells["id_alumno"].Value.ToString();
            txtApellido.Text = dgvAlumnos.SelectedRows[0].Cells["apellido"].Value.ToString();
            txtNombre.Text = dgvAlumnos.SelectedRows[0].Cells["nombre"].Value.ToString();
            txtLegajo.Text = dgvAlumnos.SelectedRows[0].Cells["legajo"].Value.ToString();
            txtDni.Text = dgvAlumnos.SelectedRows[0].Cells["dni"].Value.ToString();

            //deshabilitar edición de texto celda
            dgvAlumnos.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

    }
}
