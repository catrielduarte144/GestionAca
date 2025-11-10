namespace GestionAca
{
    partial class FormProfesores
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
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditarProf = new System.Windows.Forms.Button();
            this.btnEliminarProf = new System.Windows.Forms.Button();
            this.btsCerrar = new System.Windows.Forms.Button();
            this.btnInsertarProf = new System.Windows.Forms.Button();
            this.dgvProfesor = new System.Windows.Forms.DataGridView();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfesor)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(375, 533);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(187, 28);
            this.cmbEstado.TabIndex = 36;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(103, 452);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(187, 26);
            this.txtNombre.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 510);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "APELLIDO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 510);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "ESTADO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(371, 429);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "TELEFONO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "EMAIL";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(103, 365);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(187, 26);
            this.txtID.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 429);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "NOMBRE";
            // 
            // btnEditarProf
            // 
            this.btnEditarProf.BackColor = System.Drawing.SystemColors.Info;
            this.btnEditarProf.Location = new System.Drawing.Point(695, 162);
            this.btnEditarProf.Name = "btnEditarProf";
            this.btnEditarProf.Size = new System.Drawing.Size(120, 50);
            this.btnEditarProf.TabIndex = 24;
            this.btnEditarProf.Text = "Editar";
            this.btnEditarProf.UseVisualStyleBackColor = false;
            // 
            // btnEliminarProf
            // 
            this.btnEliminarProf.BackColor = System.Drawing.SystemColors.Info;
            this.btnEliminarProf.Location = new System.Drawing.Point(695, 263);
            this.btnEliminarProf.Name = "btnEliminarProf";
            this.btnEliminarProf.Size = new System.Drawing.Size(120, 50);
            this.btnEliminarProf.TabIndex = 23;
            this.btnEliminarProf.Text = "Eliminar";
            this.btnEliminarProf.UseVisualStyleBackColor = false;
            // 
            // btsCerrar
            // 
            this.btsCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btsCerrar.Location = new System.Drawing.Point(857, 85);
            this.btsCerrar.Name = "btsCerrar";
            this.btsCerrar.Size = new System.Drawing.Size(65, 34);
            this.btsCerrar.TabIndex = 22;
            this.btsCerrar.Text = "Cerrar";
            this.btsCerrar.UseVisualStyleBackColor = false;
            // 
            // btnInsertarProf
            // 
            this.btnInsertarProf.BackColor = System.Drawing.SystemColors.Info;
            this.btnInsertarProf.Location = new System.Drawing.Point(695, 85);
            this.btnInsertarProf.Name = "btnInsertarProf";
            this.btnInsertarProf.Size = new System.Drawing.Size(120, 50);
            this.btnInsertarProf.TabIndex = 21;
            this.btnInsertarProf.Text = "Insertar";
            this.btnInsertarProf.UseVisualStyleBackColor = false;
            // 
            // dgvProfesor
            // 
            this.dgvProfesor.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvProfesor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProfesor.Location = new System.Drawing.Point(21, 85);
            this.dgvProfesor.Name = "dgvProfesor";
            this.dgvProfesor.RowHeadersWidth = 62;
            this.dgvProfesor.RowTemplate.Height = 28;
            this.dgvProfesor.Size = new System.Drawing.Size(668, 228);
            this.dgvProfesor.TabIndex = 20;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(375, 365);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(187, 26);
            this.txtEmail.TabIndex = 37;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(375, 452);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(187, 26);
            this.txtTelefono.TabIndex = 38;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(103, 533);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(187, 26);
            this.txtApellido.TabIndex = 39;
            // 
            // FormProfesores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 577);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEditarProf);
            this.Controls.Add(this.btnEliminarProf);
            this.Controls.Add(this.btsCerrar);
            this.Controls.Add(this.btnInsertarProf);
            this.Controls.Add(this.dgvProfesor);
            this.Name = "FormProfesores";
            this.Text = "FormProfesores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfesor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditarProf;
        private System.Windows.Forms.Button btnEliminarProf;
        private System.Windows.Forms.Button btsCerrar;
        private System.Windows.Forms.Button btnInsertarProf;
        private System.Windows.Forms.DataGridView dgvProfesor;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtApellido;
    }
}