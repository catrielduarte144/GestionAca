namespace GestionAca
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAlumno = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMateria = new System.Windows.Forms.Button();
            this.btnCarrera = new System.Windows.Forms.Button();
            this.btnProfesor = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAlumnoMateria = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAlumno
            // 
            this.btnAlumno.BackColor = System.Drawing.SystemColors.Info;
            this.btnAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnAlumno.Location = new System.Drawing.Point(166, 159);
            this.btnAlumno.Name = "btnAlumno";
            this.btnAlumno.Size = new System.Drawing.Size(183, 62);
            this.btnAlumno.TabIndex = 0;
            this.btnAlumno.Text = "Alumno";
            this.btnAlumno.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(122, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(513, 64);
            this.label1.TabIndex = 5;
            this.label1.Text = "Gestión Academica";
            // 
            // btnMateria
            // 
            this.btnMateria.BackColor = System.Drawing.SystemColors.Info;
            this.btnMateria.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnMateria.Location = new System.Drawing.Point(498, 170);
            this.btnMateria.Name = "btnMateria";
            this.btnMateria.Size = new System.Drawing.Size(183, 62);
            this.btnMateria.TabIndex = 6;
            this.btnMateria.Text = "Materia";
            this.btnMateria.UseVisualStyleBackColor = false;
            // 
            // btnCarrera
            // 
            this.btnCarrera.BackColor = System.Drawing.SystemColors.Info;
            this.btnCarrera.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnCarrera.Location = new System.Drawing.Point(166, 278);
            this.btnCarrera.Name = "btnCarrera";
            this.btnCarrera.Size = new System.Drawing.Size(183, 62);
            this.btnCarrera.TabIndex = 7;
            this.btnCarrera.Text = "Carrera";
            this.btnCarrera.UseVisualStyleBackColor = false;
            // 
            // btnProfesor
            // 
            this.btnProfesor.BackColor = System.Drawing.SystemColors.Info;
            this.btnProfesor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnProfesor.Location = new System.Drawing.Point(498, 278);
            this.btnProfesor.Name = "btnProfesor";
            this.btnProfesor.Size = new System.Drawing.Size(183, 62);
            this.btnProfesor.TabIndex = 8;
            this.btnProfesor.Text = "Profesor";
            this.btnProfesor.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSalir.Location = new System.Drawing.Point(551, 385);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(117, 62);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_1);
            // 
            // btnAlumnoMateria
            // 
            this.btnAlumnoMateria.BackColor = System.Drawing.SystemColors.Info;
            this.btnAlumnoMateria.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnAlumnoMateria.Location = new System.Drawing.Point(166, 376);
            this.btnAlumnoMateria.Name = "btnAlumnoMateria";
            this.btnAlumnoMateria.Size = new System.Drawing.Size(283, 62);
            this.btnAlumnoMateria.TabIndex = 10;
            this.btnAlumnoMateria.Text = "AlumnoMateria";
            this.btnAlumnoMateria.UseVisualStyleBackColor = false;
            this.btnAlumnoMateria.Click += new System.EventHandler(this.btnAlumnoMateria_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAlumnoMateria);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnProfesor);
            this.Controls.Add(this.btnCarrera);
            this.Controls.Add(this.btnMateria);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAlumno);
            this.Name = "FormPrincipal";
            this.Text = "FormPrincipal";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAlumno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMateria;
        private System.Windows.Forms.Button btnCarrera;
        private System.Windows.Forms.Button btnProfesor;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAlumnoMateria;
    }
}