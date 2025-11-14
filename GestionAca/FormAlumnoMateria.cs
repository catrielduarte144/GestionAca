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
    public partial class FormAlumnoMateria : Form
    {
        public FormAlumnoMateria()
        {
            InitializeComponent();
        }

        private void FormAlumnoMateria_Load(object sender, EventArgs e)
        {
            CargarAlumnoMateria();
        }

        private void CargarAlumnoMateria()
        {
            try
            {
                //código para cargar materias en el DataGridView
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = @"
                        SELECT 
                            a.legajo,
                            CONCAT(a.apellido,', ',a.nombre) AS Nomb_Alumno,
                            mt.nombre AS MATERIA,
                            CONCAT(pf.apellido,', ',pf.nombre) AS PROFESOR_COMPLETO,
                            C.nombre AS CARRERA
                        FROM alumnos_materias am
                        INNER JOIN alumnos a ON a.id_alumno = am.id_alumno
                        INNER JOIN materias mt ON mt.id_materia = am.id_materia
                        INNER JOIN Profesores pf ON pf.id_profesor = mt.id_profesor
                        INNER JOIN carreras c ON c.id_carrera = mt.id_carrera
                        ORDER BY a.legajo, mt.nombre";

                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAlumnoMateria.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar alumno-materia: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarAlumnoMateria();
        }
    }
}
