using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionAca
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        //navegacion entre formularios
        private void MostrarFormulario(Form formulario)
        {
            this.Hide(); //ocultar el formulario principal
            formulario.ShowDialog(); //abrir form clickeado
            this.Show(); //mostrar el formulario seleccionado
        }

        //evento para boton alumnos
        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            //crear instancia del formulario de alumnos
            FormAlumnos formAlumnos = new FormAlumnos();
            MostrarFormulario(formAlumnos);
        }

        //muestra una instancia de formulario materias
        private void btnMaterias_Click(object sender, EventArgs e)
        {
            //crear instancia del formulario de materias
            FormMaterias formMaterias = new FormMaterias();
            MostrarFormulario(formMaterias);
        }
        // muestra un evento del boton carreras
        private void btnCarreras_Click(object sender, EventArgs e)
        {
            //crear instancia del formulario de carreras
            FormCarreras formCarreras = new FormCarreras();
            MostrarFormulario(formCarreras);
        }
        // muestra evento profesores
        private void btnProfesores_Click(object sender, EventArgs e)
        {
            //crear instancia del formulario de profesores
            FormProfesores formProfesores = new FormProfesores();
            MostrarFormulario(formProfesores);
        }
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            //código para ejecutar al cargar el formulario principal

        }

        //evento para botón salir
        private void btnSalir_Click_1(object sender, EventArgs e)
        { 
            DialogResult result = MessageBox.Show(
                "¿Estás seguro que deseas salir?",
                "Confirmar salida",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnAlumnoMateria_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAlumnoMateria formAsignaciones = new FormAlumnoMateria();
            formAsignaciones.ShowDialog();
            this.Show();
        }
    }
}
