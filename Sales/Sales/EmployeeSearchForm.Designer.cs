namespace Sales
{
    partial class EmployeeSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeSearchForm));
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dgvEmployeeSearch = new System.Windows.Forms.DataGridView();
            this.pic1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::Sales.Properties.Resources.search;
            this.btnSearch.Location = new System.Drawing.Point(254, 79);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(141, 49);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "&BUSCAR";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(78, 40);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Nombre:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(152, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(318, 20);
            this.txtName.TabIndex = 2;
            // 
            // dgvEmployeeSearch
            // 
            this.dgvEmployeeSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeSearch.Location = new System.Drawing.Point(26, 146);
            this.dgvEmployeeSearch.Name = "dgvEmployeeSearch";
            this.dgvEmployeeSearch.Size = new System.Drawing.Size(644, 176);
            this.dgvEmployeeSearch.TabIndex = 3;
            this.dgvEmployeeSearch.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvEmployeeSearch_MouseDoubleClick);
            // 
            // pic1
            // 
            this.pic1.Image = global::Sales.Properties.Resources.man_brown;
            this.pic1.Location = new System.Drawing.Point(517, 12);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(128, 128);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pic1.TabIndex = 4;
            this.pic1.TabStop = false;
            // 
            // PersonalSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 337);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.dgvEmployeeSearch);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PersonalSearch";
            this.Text = "Buscar Personal";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridView dgvEmployeeSearch;
        private System.Windows.Forms.PictureBox pic1;
    }
}