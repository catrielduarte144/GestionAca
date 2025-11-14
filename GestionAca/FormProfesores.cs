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
        string cadenaConexion = "Server =localhost\\SQLEXPRESS; Database=GestionAcademica; Trusted_Connection=True ";

        public FormProfesores()
        {
            InitializeComponent();
        }
        //ESTE BOTON SE LLAMA EDITAR, PERO SU LABEL ES RESET, IMPORTAAAANTEEEEE SE LLAMA EDIATR NO ME DEJA CAMBIARLO O SE ROMPE TODO AAAAA
        //AL BOTON QUE SE LLAMA RESET LE VOY A PONER DE LABEL EDITAR
        private void btnEditarProf_Click(object sender, EventArgs e)
        {
            limpiar();
            btnInsertarProf.Enabled = true;
            btnEditarProf.Enabled = false;
        }

        //esto es para cargar el data grid 
        private void FormProfesores_Load(object sender, EventArgs e)
        {
            leerProfesores();
            limpiar();
        }
        private void leerProfesores()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);

                conexion.Open();

                // MessageBox.Show("Conectado");

                string query = "select * from Profesores";

                //comando para realizar acciones, leer, modificar o borrar
                SqlCommand comando = new SqlCommand(query, conexion);

                SqlDataReader lector;

                comando.CommandText = query;

                DataTable tablaMemoria = new DataTable();

                lector = comando.ExecuteReader();

                tablaMemoria.Load(lector);

                //se da el control de que datos son los que estas cargando
                dgvProfesor.DataSource = tablaMemoria;

                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void limpiar()
        {
            //editar es el reset y eliminar es editar 
            btnEditarProf.Enabled = false;
            btnEliminarProf.Enabled = false;
            txtID.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";

            txtNombre.Focus();
        }

        private void agregarProfe()
        {
            //validacion de boxes
            if (!validacionBox())
            {
                return;
            }

            //validar datos
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string email = txtEmail.Text;
            string telefono = txtTelefono.Text;

            try
            {
                SqlConnection cm = new SqlConnection(cadenaConexion);
                cm.Open();

                string query = "insert into Profesores (apellido, nombre, email, telefono) values (@apellido, @nombre, @email, @telefono)";
                SqlCommand cmd = new SqlCommand(query, cm);

                cmd.CommandText = query;

                //parametros

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@email", email);

                int filas = cmd.ExecuteNonQuery();
                MessageBox.Show($"Se registraron {filas} registros");

                cm.Close();
                leerProfesores();
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnInsertarProf_Click(object sender, EventArgs e)
        {
            agregarProfe();
        }

        private void dgvProfesor_DoubleClick(object sender, EventArgs e)
        {
            //bloquear boton insertar
            btnInsertarProf.Enabled = false;
            btnEditarProf.Enabled = true;
            btnEliminarProf.Enabled = true;

            //pasa datos de las cajas de txt a las celdas de la tabla 

            txtID.Text = dgvProfesor.SelectedCells[0].Value.ToString();
            txtNombre.Text = dgvProfesor.SelectedCells[1].Value.ToString();
            txtApellido.Text = dgvProfesor.SelectedCells[2].Value.ToString();
            txtEmail.Text = dgvProfesor.SelectedCells[3].Value.ToString();
            txtTelefono.Text = dgvProfesor.SelectedCells[4].Value.ToString();

        }
        //este boton se llama reset, peor su label es EDITAR por lo que es el btn editar
        private void btnResetProf_Click(object sender, EventArgs e)
        {
            editarProfesor();
        }
        private void editarProfesor()
        {
            //validacion de boxes
            if (!validacionBox())
            {
                return;
            }

            int id_profesor = int.Parse(txtID.Text);
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string email = txtEmail.Text;
            string telefono = txtTelefono.Text;

            try
            {
                SqlConnection con = new SqlConnection(cadenaConexion);
                con.Open();

                string consultaSql = "update Profesores set apellido =@apellido, nombre = @nombre, email = @email, telefono = @telefono where id_profesor = @id_profesor";
                SqlCommand cod = new SqlCommand(consultaSql, con);

                //parametros

                cod.Parameters.AddWithValue("@nombre", nombre);
                cod.Parameters.AddWithValue("@apellido", apellido);
                cod.Parameters.AddWithValue("@telefono", telefono);
                cod.Parameters.AddWithValue("@email", email);
                cod.Parameters.AddWithValue("@id_profesor", id_profesor);



                int filas = cod.ExecuteNonQuery();
                MessageBox.Show($"Se modifico un {filas} registro con ID: {id_profesor}");

                con.Close();

                leerProfesores();
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        //validacion de boxes
        private bool validacionBox()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("El campo nombre se encuentra vacio.");
                txtNombre.Focus();
                return false;
            }
            else
            {
                if (txtApellido.Text == "")
                {
                    MessageBox.Show("El campo Apellido se encuentra vacio.");
                    txtApellido.Focus();
                    return false;
                }
                else
                {
                    if (txtTelefono.Text == "")
                    {
                        MessageBox.Show("El campo telefono se encuentra vacio");
                        txtTelefono.Focus();
                        return false;
                    }
                    else
                    {
                        if (txtEmail.Text == "")
                        {
                            MessageBox.Show("El campo email se encuentra vacio");
                            txtEmail.Focus();
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }

        }

        private void btnEliminarProf_Click(object sender, EventArgs e)
        {
            EliminarProf();
        }
        private void EliminarProf()
        {
            int id_profesor = int.Parse(txtID.Text);
            if (txtID.Text == "")
            {
                MessageBox.Show("Debe tene un ID para eliminar.");
                return;
            }

            //mensaje de advertencia 
            DialogResult resultado = MessageBox.Show($"¿Desea eliminar este contacto?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                try
                {
                    SqlConnection con = new SqlConnection(cadenaConexion);
                    con.Open();

                    string consultaSQLn = "delete profesores where id_profesor = @id_profesor";
                    SqlCommand cmd = new SqlCommand(consultaSQLn, con);

                    cmd.Parameters.AddWithValue("@id_profesor", id_profesor);

                    int filas = cmd.ExecuteNonQuery();

                    MessageBox.Show($"Se eliminaron {filas} registros con ID: {id_profesor} ");
                    con.Close();
                    leerProfesores();
                    limpiar();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else
            {
                return;
            }


        }

        private void btsCerrarProf_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
