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
            this.btnResetProf = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditarProf = new System.Windows.Forms.Button();
            this.btnEliminarProf = new System.Windows.Forms.Button();
            this.btsCerrarProf = new System.Windows.Forms.Button();
            this.btnInsertarProf = new System.Windows.Forms.Button();
            this.dgvProfesor = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfesor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnResetProf
            // 
            this.btnResetProf.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnResetProf.Location = new System.Drawing.Point(608, 39);
            this.btnResetProf.Margin = new System.Windows.Forms.Padding(2);
            this.btnResetProf.Name = "btnResetProf";
            this.btnResetProf.Size = new System.Drawing.Size(80, 32);
            this.btnResetProf.TabIndex = 58;
            this.btnResetProf.Text = "Editar";
            this.btnResetProf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResetProf.UseVisualStyleBackColor = false;
            this.btnResetProf.Click += new System.EventHandler(this.btnResetProf_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "PROFESORES";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(141, 359);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(2);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(188, 20);
            this.txtApellido.TabIndex = 56;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(401, 359);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(188, 20);
            this.txtTelefono.TabIndex = 55;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(401, 305);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(188, 20);
            this.txtEmail.TabIndex = 54;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(141, 305);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(188, 20);
            this.txtNombre.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 305);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 344);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "APELLIDO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(398, 344);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "TELEFONO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(398, 290);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "EMAIL";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(37, 327);
            this.txtID.Margin = new System.Windows.Forms.Padding(2);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(51, 20);
            this.txtID.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 290);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "NOMBRE";
            // 
            // btnEditarProf
            // 
            this.btnEditarProf.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnEditarProf.Location = new System.Drawing.Point(608, 247);
            this.btnEditarProf.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditarProf.Name = "btnEditarProf";
            this.btnEditarProf.Size = new System.Drawing.Size(80, 32);
            this.btnEditarProf.TabIndex = 46;
            this.btnEditarProf.Text = "RESET";
            this.btnEditarProf.UseVisualStyleBackColor = false;
            this.btnEditarProf.Click += new System.EventHandler(this.btnEditarProf_Click);
            // 
            // btnEliminarProf
            // 
            this.btnEliminarProf.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnEliminarProf.Location = new System.Drawing.Point(608, 183);
            this.btnEliminarProf.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminarProf.Name = "btnEliminarProf";
            this.btnEliminarProf.Size = new System.Drawing.Size(80, 32);
            this.btnEliminarProf.TabIndex = 45;
            this.btnEliminarProf.Text = "Eliminar";
            this.btnEliminarProf.UseVisualStyleBackColor = false;
            this.btnEliminarProf.Click += new System.EventHandler(this.btnEliminarProf_Click);
            // 
            // btsCerrarProf
            // 
            this.btsCerrarProf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btsCerrarProf.Location = new System.Drawing.Point(627, 316);
            this.btsCerrarProf.Margin = new System.Windows.Forms.Padding(2);
            this.btsCerrarProf.Name = "btsCerrarProf";
            this.btsCerrarProf.Size = new System.Drawing.Size(61, 40);
            this.btsCerrarProf.TabIndex = 44;
            this.btsCerrarProf.Text = "Cerrar";
            this.btsCerrarProf.UseVisualStyleBackColor = false;
            this.btsCerrarProf.Click += new System.EventHandler(this.btsCerrarProf_Click);
            // 
            // btnInsertarProf
            // 
            this.btnInsertarProf.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnInsertarProf.Location = new System.Drawing.Point(608, 111);
            this.btnInsertarProf.Margin = new System.Windows.Forms.Padding(2);
            this.btnInsertarProf.Name = "btnInsertarProf";
            this.btnInsertarProf.Size = new System.Drawing.Size(80, 32);
            this.btnInsertarProf.TabIndex = 43;
            this.btnInsertarProf.Text = "Insertar";
            this.btnInsertarProf.UseVisualStyleBackColor = false;
            this.btnInsertarProf.Click += new System.EventHandler(this.btnInsertarProf_Click);
            // 
            // dgvProfesor
            // 
            this.dgvProfesor.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvProfesor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProfesor.Location = new System.Drawing.Point(34, 39);
            this.dgvProfesor.Margin = new System.Windows.Forms.Padding(2);
            this.dgvProfesor.Name = "dgvProfesor";
            this.dgvProfesor.RowHeadersWidth = 62;
            this.dgvProfesor.RowTemplate.Height = 28;
            this.dgvProfesor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProfesor.Size = new System.Drawing.Size(555, 240);
            this.dgvProfesor.TabIndex = 42;
            this.dgvProfesor.DoubleClick += new System.EventHandler(this.dgvProfesor_DoubleClick);
            // 
            // FormProfesores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 415);
            this.Controls.Add(this.btnResetProf);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEditarProf);
            this.Controls.Add(this.btnEliminarProf);
            this.Controls.Add(this.btsCerrarProf);
            this.Controls.Add(this.btnInsertarProf);
            this.Controls.Add(this.dgvProfesor);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormProfesores";
            this.Text = "FormProfesores";
            this.Load += new System.EventHandler(this.FormProfesores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfesor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnResetProf;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditarProf;
        private System.Windows.Forms.Button btnEliminarProf;
        private System.Windows.Forms.Button btsCerrarProf;
        private System.Windows.Forms.Button btnInsertarProf;
        private System.Windows.Forms.DataGridView dgvProfesor;
    }
}