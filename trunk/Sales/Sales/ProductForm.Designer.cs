namespace Sales
{
    partial class ProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductForm));
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gstockMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gStockMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gPriceC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpriceV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gImg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.paneProductForm = new System.Windows.Forms.Panel();
            this.txtSalePrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPurchasePrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStMax = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStMin = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.paneProductForm.SuspendLayout();
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
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvProduct
            // 
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.gProduct,
            this.gstockMin,
            this.gStockMax,
            this.gPriceC,
            this.gpriceV,
            this.gImg});
            this.dgvProduct.Location = new System.Drawing.Point(86, 313);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.Size = new System.Drawing.Size(642, 97);
            this.dgvProduct.TabIndex = 20;
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
            // btnDelete
            // 
            this.btnDelete.Image = global::Sales.Properties.Resources.delete;
            this.btnDelete.Location = new System.Drawing.Point(621, 156);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(129, 39);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "&Eliminar";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
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
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            // paneProductForm
            // 
            this.paneProductForm.Controls.Add(this.txtSalePrice);
            this.paneProductForm.Controls.Add(this.label2);
            this.paneProductForm.Controls.Add(this.txtPurchasePrice);
            this.paneProductForm.Controls.Add(this.label3);
            this.paneProductForm.Controls.Add(this.txtStMax);
            this.paneProductForm.Controls.Add(this.label10);
            this.paneProductForm.Controls.Add(this.txtStMin);
            this.paneProductForm.Controls.Add(this.label9);
            this.paneProductForm.Controls.Add(this.txtName);
            this.paneProductForm.Controls.Add(this.txtId);
            this.paneProductForm.Controls.Add(this.label5);
            this.paneProductForm.Controls.Add(this.label1);
            this.paneProductForm.Location = new System.Drawing.Point(147, 14);
            this.paneProductForm.Name = "paneProductForm";
            this.paneProductForm.Size = new System.Drawing.Size(438, 214);
            this.paneProductForm.TabIndex = 12;
            // 
            // txtSalePrice
            // 
            this.txtSalePrice.Location = new System.Drawing.Point(335, 50);
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.Size = new System.Drawing.Size(67, 20);
            this.txtSalePrice.TabIndex = 23;
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
            // txtPurchasePrice
            // 
            this.txtPurchasePrice.Location = new System.Drawing.Point(335, 11);
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.Size = new System.Drawing.Size(67, 20);
            this.txtPurchasePrice.TabIndex = 21;
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
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(12, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(68, 13);
            this.lblDate.TabIndex = 22;
            this.lblDate.Text = "lblhoraaaaaa";
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 482);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.paneProductForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProductForm";
            this.Text = "AddProduct";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.paneProductForm.ResumeLayout(false);
            this.paneProductForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel paneProductForm;
        private System.Windows.Forms.TextBox txtStMax;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStMin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSalePrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPurchasePrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn gstockMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn gStockMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn gPriceC;
        private System.Windows.Forms.DataGridViewTextBoxColumn gpriceV;
        private System.Windows.Forms.DataGridViewTextBoxColumn gImg;
        private System.Windows.Forms.Label lblDate;
    }
}