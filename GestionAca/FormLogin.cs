using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionAca
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private string HashPassword(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //calcula el hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                //convierte el byte array a string hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) 
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Por favor, ingrese usuario y clave.", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidarCredencialUsuario(usuario, clave))
            {
                // 1. Crear una nueva instancia del menú principal
                FormPrincipal menu = new FormPrincipal();

                // 2. Mostrar el menú principal
                menu.Show();

                // 3. Ocultar el formulario de login actual (this)
                this.Hide();
            }
            else
            {
                // ... (Mostrar error de usuario/clave incorrectos)
            }
        }
        private bool ValidarCredencialUsuario(string usuario, string clave)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    string query = "SELECT COUNT(1) FROM usuarios WHERE usuario = @user AND clave = @pass AND estado = 'activo'";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@user", usuario);
                    command.Parameters.AddWithValue("@pass", clave);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    return count == 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
