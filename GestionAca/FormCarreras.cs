using GestionAca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionAca
{
    public partial class FormCarreras : Form
    {
        public FormCarreras()
        {
            InitializeComponent();
        }


        //CRUD
        //Cargar datos en dvgCarrera 
        private void CargarCarreras()
        {
            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT id_carrera, nombre, sede, estado FROM carreras";
                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCarreras.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar carreras: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //cargar formulario
        private void FormCarreras_Load(object sender, EventArgs e)
        {
            CargarCarreras();
            txtIdCarreras.ReadOnly = true; //el ID no se puede modificar
        }

        //grabar nueva carrera
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (//string.IsNullOrWhiteSpace(txtIdCarreras.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtSede.Text) ||
                string.IsNullOrWhiteSpace(txtEstado.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de agregar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //para comprobar que solo haya letras (o no números)
            //if (!EsNumero(txtNombre.Text, "nombre") || !EsNumero(txtSede.Text, "sede") || !EsNumero(txtEstado.Text, "estado"))
            //{
            //    MessageBox.Show("Por favor, solo inserte letras.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return; //para avisar que solo se comopleta con letras 
            //}
            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())// función que llama a la BDque usé en SQL
                {
                    connection.Open();// abre la conexión
                    string query = "INSERT INTO carreras (nombre, sede, estado) VALUES (@nombre, @sede, '1')";
                    SqlCommand command = new SqlCommand(query, connection);
                    //command.Parameters.AddWithValue("@id_carreras", txtIdCarreras.Text);
                    command.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    command.Parameters.AddWithValue("@sede", txtSede.Text);


                    command.ExecuteNonQuery();
                    MessageBox.Show("Carrera agregada correctamente.");
                    CargarCarreras(); //actualiza datagridview
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar carrera: " + ex.Message);
            }
        }
        //limpiar campos de texto
        private void LimpiarCampos()
        {
            txtIdCarreras.Clear();
            txtNombre.Clear();
            txtSede.Clear();
            txtEstado.Clear();
        }
        //modificar carrera
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdCarreras.Text))
            {
                MessageBox.Show("Por favor, seleccione una carrera para modificar.", "Carrera no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtIdCarreras.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtSede.Text) ||
                string.IsNullOrWhiteSpace(txtEstado.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de modificar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //si alguna validacion falla, salir del metodo
            }

            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE carreras SET nombre = @Nombre, sede = @Sede, estado = @Estado WHERE id_carrera = @IdCarreras";
                    SqlCommand command = new SqlCommand(query, connection);
                    //command.Parameters.AddWithValue("@IdCarreras", txtIdCarreras.Text);
                    command.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    command.Parameters.AddWithValue("@Sede", txtSede.Text);
                    command.Parameters.AddWithValue("@Estado", txtEstado.Text);
                    command.Parameters.AddWithValue("@IdCarreras", txtIdCarreras.Text);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Carrera modificada correctamente.");
                    CargarCarreras(); //actualizar datagridview
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar carrera: " + ex.Message);
            }
        }
        //borrar una carrera
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdCarreras.Text))
            {
                MessageBox.Show("Por favor, seleccione una carrera para dar de baja.", "Carrera no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //confirmar baja
            if (MessageBox.Show("¿Está seguro que desea borrar esta carrera?", "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE carreras SET estado= '0' WHERE id_carrera = @IdCarreras";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdCarreras", txtIdCarreras.Text);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Carrera dada de baja correctamente.");
                    CargarCarreras(); //actualizar datagridview
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar carrera: " + ex.Message);
            }
        }

        //mostrar datos en los cuadros de texto al seleccionar fila del datagridview
        //private void dgvCarreras_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dgvCarreras.SelectedRows.Count > 0)
        //    {
        //         DataGridViewRow row = dgvCarreras.SelectedRows[0];
        //        if (!row.IsNewRow)
        //        {
        //             txtIdCarreras.Text = row.Cells["id_carrera"].Value.ToString() ?? string.Empty;
        //             txtNombre.Text = row.Cells["nombre"].Value.ToString() ?? string.Empty;
        //             txtSede.Text = row.Cells["sede"].Value.ToString() ?? string.Empty;
        //             txtEstado.Text = row.Cells["estado"].Value.ToString() ?? string.Empty;
        //         }
        //     }
        //}
        //boton cerrar formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void dgvCarreras_Click(object sender, EventArgs e)
        //{
        //    //cargar datos de la columna clickeada en objetos txt
        //    txtIdCarreras.Text = dgvCarreras.SelectedRows[0].Cells["id_carrera"].Value.ToString();
        //    txtNombre.Text = dgvCarreras.SelectedRows[0].Cells["nombre"].Value.ToString();
        //    txtSede.Text = dgvCarreras.SelectedRows[0].Cells["sede"].Value.ToString();
        //    txtEstado.Text = dgvCarreras.SelectedRows[0].Cells["estado"].Value.ToString();

        //    //deshabilitar edición de texto celda
        //    dgvCarreras.EditMode = DataGridViewEditMode.EditProgrammatically;
        //}

        private void dgvCarreras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evita error al hacer click en el encabezado
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvCarreras.Rows[e.RowIndex];

            txtIdCarreras.Text = fila.Cells["id_carrera"].Value.ToString();
            txtNombre.Text = fila.Cells["nombre"].Value.ToString();
            txtSede.Text = fila.Cells["sede"].Value.ToString();
            txtEstado.Text = fila.Cells["estado"].Value.ToString();

            dgvCarreras.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
    }

}
