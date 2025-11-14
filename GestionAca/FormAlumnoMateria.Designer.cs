namespace GestionAca
{
    partial class FormAlumnoMateria
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
            this.dgvAlumnoMateria = new System.Windows.Forms.DataGridView();
            this.btsCerrar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnoMateria)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAlumnoMateria
            // 
            this.dgvAlumnoMateria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnoMateria.Location = new System.Drawing.Point(26, 75);
            this.dgvAlumnoMateria.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvAlumnoMateria.Name = "dgvAlumnoMateria";
            this.dgvAlumnoMateria.RowHeadersWidth = 62;
            this.dgvAlumnoMateria.RowTemplate.Height = 28;
            this.dgvAlumnoMateria.Size = new System.Drawing.Size(547, 395);
            this.dgvAlumnoMateria.TabIndex = 23;
            // 
            // btsCerrar
            // 
            this.btsCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btsCerrar.Location = new System.Drawing.Point(414, 42);
            this.btsCerrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btsCerrar.Name = "btsCerrar";
            this.btsCerrar.Size = new System.Drawing.Size(43, 22);
            this.btsCerrar.TabIndex = 24;
            this.btsCerrar.Text = "Cerrar";
            this.btsCerrar.UseVisualStyleBackColor = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.SystemColors.Info;
            this.btnActualizar.Location = new System.Drawing.Point(493, 37);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(80, 32);
            this.btnActualizar.TabIndex = 25;
            this.btnActualizar.Text = "ACTUALIZAR";
            this.btnActualizar.UseVisualStyleBackColor = false;
            // 
            // FormAlumnoMateria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(919, 549);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btsCerrar);
            this.Controls.Add(this.dgvAlumnoMateria);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormAlumnoMateria";
            this.Text = "FormAlumnoMateria";
            this.Load += new System.EventHandler(this.FormAlumnoMateria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnoMateria)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlumnoMateria;
        private System.Windows.Forms.Button btsCerrar;
        private System.Windows.Forms.Button btnActualizar;
    }
}