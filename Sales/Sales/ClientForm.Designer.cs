namespace Sales
{
    partial class ClientForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNewCliente = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtEstado);
            this.panel1.Controls.Add(this.txtTelefono);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.txtDireccion);
            this.panel1.Controls.Add(this.txtRazonSocial);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(138, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 237);
            this.panel1.TabIndex = 0;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(111, 18);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "ID";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(363, 67);
            this.txtEstado.Multiline = true;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(120, 20);
            this.txtEstado.TabIndex = 11;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(363, 15);
            this.txtTelefono.Multiline = true;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(108, 20);
            this.txtTelefono.TabIndex = 9;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(111, 140);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(138, 20);
            this.txtEmail.TabIndex = 8;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(111, 55);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(138, 20);
            this.txtDireccion.TabIndex = 7;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(111, 94);
            this.txtRazonSocial.Multiline = true;
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(100, 20);
            this.txtRazonSocial.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(280, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Estado Cliente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Telefono:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Direccion:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Razon Social:";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Sales.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(653, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 48);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Guardar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::Sales.Properties.Resources.search;
            this.btnSearch.Location = new System.Drawing.Point(654, 66);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 39);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "&Buscar";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnModify
            // 
            this.btnModify.Image = global::Sales.Properties.Resources.modify;
            this.btnModify.Location = new System.Drawing.Point(653, 111);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(106, 37);
            this.btnModify.TabIndex = 3;
            this.btnModify.Text = "&Modificar";
            this.btnModify.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModify.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Sales.Properties.Resources.delete;
            this.btnDelete.Location = new System.Drawing.Point(653, 154);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(106, 41);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "&Eliminar";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Image = global::Sales.Properties.Resources.application_exit;
            this.btnExit.Location = new System.Drawing.Point(652, 201);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(107, 59);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "&Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNewCliente
            // 
            this.btnNewCliente.Image = global::Sales.Properties.Resources.add_user;
            this.btnNewCliente.Location = new System.Drawing.Point(12, 126);
            this.btnNewCliente.Name = "btnNewCliente";
            this.btnNewCliente.Size = new System.Drawing.Size(104, 97);
            this.btnNewCliente.TabIndex = 6;
            this.btnNewCliente.UseVisualStyleBackColor = true;
            this.btnNewCliente.Click += new System.EventHandler(this.btnNewCliente_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.CausesValidation = false;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Direccion,
            this.RazonSocial,
            this.Email,
            this.Telefono,
            this.Estado});
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dataGridView1.Location = new System.Drawing.Point(52, 278);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.Size = new System.Drawing.Size(643, 150);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 7;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Sales.Properties.Resources.man_brown;
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(104, 99);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Direccion
            // 
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.Name = "Direccion";
            // 
            // RazonSocial
            // 
            this.RazonSocial.HeaderText = "Razon Social";
            this.RazonSocial.Name = "RazonSocial";
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 422);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnNewCliente);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Name = "ClientForm";
            this.Text = "Mantenimiento Cliente";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNewCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
    }
}