namespace Sales
{
    partial class AddProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProduct));
            this.btnExit = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gstockMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gStockMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gPriceC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpriceV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gImg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button5 = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPventa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPcompra = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStMax = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStMin = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Image = global::Sales.Properties.Resources.application_exit;
            this.btnExit.Location = new System.Drawing.Point(621, 215);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(129, 69);
            this.btnExit.TabIndex = 21;
            this.btnExit.Text = "&Salir";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.gProduct,
            this.gstockMin,
            this.gStockMax,
            this.gPriceC,
            this.gpriceV,
            this.gImg});
            this.dataGridView1.Location = new System.Drawing.Point(86, 313);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(642, 97);
            this.dataGridView1.TabIndex = 20;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // gProduct
            // 
            this.gProduct.HeaderText = "Producto";
            this.gProduct.Name = "gProduct";
            // 
            // gstockMin
            // 
            this.gstockMin.HeaderText = "Stock Min";
            this.gstockMin.Name = "gstockMin";
            // 
            // gStockMax
            // 
            this.gStockMax.HeaderText = "Stock Max";
            this.gStockMax.Name = "gStockMax";
            // 
            // gPriceC
            // 
            this.gPriceC.HeaderText = "PrecioCompra";
            this.gPriceC.Name = "gPriceC";
            // 
            // gpriceV
            // 
            this.gpriceV.HeaderText = "PrecioVenta";
            this.gpriceV.Name = "gpriceV";
            // 
            // gImg
            // 
            this.gImg.HeaderText = "Img";
            this.gImg.Name = "gImg";
            // 
            // button5
            // 
            this.button5.Image = global::Sales.Properties.Resources.delete;
            this.button5.Location = new System.Drawing.Point(621, 156);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(129, 39);
            this.button5.TabIndex = 18;
            this.button5.Text = "&Eliminar";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btnModify
            // 
            this.btnModify.Image = global::Sales.Properties.Resources.modify;
            this.btnModify.Location = new System.Drawing.Point(621, 109);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(129, 39);
            this.btnModify.TabIndex = 17;
            this.btnModify.Text = "&Modificar";
            this.btnModify.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModify.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::Sales.Properties.Resources.search;
            this.btnSearch.Location = new System.Drawing.Point(621, 63);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(129, 39);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "&Buscar";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Sales.Properties.Resources.plus;
            this.btnAdd.Location = new System.Drawing.Point(122, 244);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdd.Size = new System.Drawing.Size(483, 40);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Agregar Nuevo Producto";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Sales.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(621, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 45);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "&Guardar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPventa);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPcompra);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtStMax);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtStMin);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(147, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 214);
            this.panel1.TabIndex = 12;
            // 
            // txtPventa
            // 
            this.txtPventa.Location = new System.Drawing.Point(335, 50);
            this.txtPventa.Name = "txtPventa";
            this.txtPventa.Size = new System.Drawing.Size(67, 20);
            this.txtPventa.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Precio Venta";
            // 
            // txtPcompra
            // 
            this.txtPcompra.Location = new System.Drawing.Point(335, 11);
            this.txtPcompra.Name = "txtPcompra";
            this.txtPcompra.Size = new System.Drawing.Size(67, 20);
            this.txtPcompra.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Precio Compra";
            // 
            // txtStMax
            // 
            this.txtStMax.Location = new System.Drawing.Point(122, 114);
            this.txtStMax.Name = "txtStMax";
            this.txtStMax.Size = new System.Drawing.Size(100, 20);
            this.txtStMax.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Stock Max";
            // 
            // txtStMin
            // 
            this.txtStMin.Location = new System.Drawing.Point(122, 75);
            this.txtStMin.Name = "txtStMin";
            this.txtStMin.Size = new System.Drawing.Size(100, 20);
            this.txtStMin.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Stock Min";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(122, 46);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 6;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(122, 11);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 482);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddProduct";
            this.Text = "AddProduct";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtStMax;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStMin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPventa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPcompra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn gstockMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn gStockMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn gPriceC;
        private System.Windows.Forms.DataGridViewTextBoxColumn gpriceV;
        private System.Windows.Forms.DataGridViewTextBoxColumn gImg;
    }
}