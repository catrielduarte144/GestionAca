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
    public partial class FormProfesores : Form
    {
        public FormProfesores()
        {
            InitializeComponent();
            CargarProfesores();
            CargarEstado();
            txtID.ReadOnly = true; //el ID no se puede modificar
        }

        private void CargarProfesores()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string consulta = @"
                        SELECT
                            p.id_profesor,
                            p.nombre,
                            p.apellido,
                            p.email,
                            p.telefono,
                            e.estado AS Estado
                        FROM profesor p
                        INNER JOIN Estado e ON p.id_estado = e.Id";

                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, connection);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dgvProfesor.DataSource = tabla;

                    if (dgvProfesor.Columns.Contains("id_profesor"))
                    {
                        dgvProfesor.Columns["id_profesor"].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar profesores: " + ex.Message);
                }
            }
        }

        //cargar ids y nombre a la tabla (Estado)
        private void CargarEstado()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string consulta = "SELECT Id, Estado FROM Estado";
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, connection);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    cmbEstado.DataSource = tabla;
                    cmbEstado.DisplayMember = "Estado";
                    cmbEstado.ValueMember = "Id";
                    cmbEstado.SelectedIndex = -1; //ningun elemento seleccionado por defecto
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar estados: " + ex.Message);
                }
            }
        }

        //cargar datos al seleccionar fila
        private void dgvProfesor_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProfesor.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvProfesor.SelectedRows[0];
                if (!row.IsNewRow)
                {
                    //obtener datos de la fila seleccionada
                    string id = row.Cells["id_profesor"].Value?.ToString() ?? string.Empty;
                    string nombre = row.Cells["nombre"].Value?.ToString() ?? string.Empty;
                    string apellido = row.Cells["apellido"].Value?.ToString() ?? string.Empty;
                    string email = row.Cells["email"].Value?.ToString() ?? string.Empty;
                    string telefono = row.Cells["telefono"].Value?.ToString() ?? string.Empty;
                    string estado = row.Cells["Estado"].Value?.ToString() ?? string.Empty;

                    //asignar datos a los controles del formulario
                    txtID.Text = id;
                    txtNombre.Text = nombre;
                    txtApellido.Text = apellido;
                    txtEmail.Text = email;
                    txtTelefono.Text = telefono;

                    cmbEstado.SelectedIndex = cmbEstado.FindStringExact(estado);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormProfesores_Load(object sender, EventArgs e)
        {
            this.dgvProfesor.SelectionChanged += new System.EventHandler(this.dgvProfesor_SelectionChanged);
        }

        private void btnInsertarProf_Click(object sender, EventArgs e)
        {
            // Lógica para insertar un nuevo profesor
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos antes de grabar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"
                        INSERT INTO profesor (nombre, apellido, email, telefono, id_estado)
                        VALUES (@nombre, @apellido, @email, @telefono, @id_estado)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                    command.Parameters.AddWithValue("@apellido", txtApellido.Text);
                    command.Parameters.AddWithValue("@email", txtEmail.Text);
                    command.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                    command.Parameters.AddWithValue("@id_estado", cmbEstado.SelectedValue);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Profesor agregado correctamente.");
                    CargarProfesores(); //actualizar datagridview
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar profesor: " + ex.Message);
                }
            }
        }

        private void btnEditarProf_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || dgvProfesor.SelectedRows.Count == 0)
            {
                MessageBox.Show("Complete todos los campos", "campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string consulta = "UPDATE profesor  SET nombre = @Nombre, apellido = @Apellido, email = @Email, " +
                                   "telefono = @Telefono, id_estado = @Estado WHERE id_profesor = @Id";
    
                    SqlCommand command = new SqlCommand(consulta, connection);
                    command.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                    command.Parameters.AddWithValue("@Apellido", txtApellido.Text.Trim());
                    command.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    command.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                    command.Parameters.AddWithValue("@Estado", cmbEstado.SelectedValue);
                    command.Parameters.AddWithValue("@Id", txtID.Text);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Profesor actualizado con exito");
                    CargarProfesores();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar profesor" + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminarProf_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || dgvProfesor.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el profesor a dar de baja", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("¿Estas seguro de dar de baja este profesor", "Comfirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int idEstadoInactivo = 2;

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    //cambia el id_estado
                    string consulta = "UPDATE profesor SET id_estado = @EstadoInactivo WHERE id_profesor = @Id";

                    SqlCommand command = new SqlCommand(consulta, connection);
                    command.Parameters.AddWithValue("@EstadoInactivo", idEstadoInactivo);
                    command.Parameters.AddWithValue("@Id", txtID.Text);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Profesor dado de baja correctamente");
                    CargarProfesores();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al dar de baja profesor" + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            cmbEstado.SelectedIndex = -1;
        }
    }
}
