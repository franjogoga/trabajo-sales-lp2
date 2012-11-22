using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Library;
using System.Threading;

namespace Sales
{
    public partial class ProductForm : Form
    {
        private MainForm refMain = null;
        private SqlConnection conn = new SqlConnection("user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30");

        public void SetRefMain(MainForm mainf)
        {
            refMain = mainf;
        }
        
        public ProductForm(int id, string name, Int32 stMin, Int32 stMax, float purchasePrice, float salePrice)
        {
            InitializeComponent();
            this.dgvProduct.Rows.Add(id, name, stMin, stMax, purchasePrice, salePrice);
        }

        public ProductForm()
        {
            InitializeComponent();

            Thread dateThread = new Thread(updateDate);
            dateThread.Start();

            Thread dgvProductThread = new Thread(updateDgvProduct);
            dgvProductThread.Start();
        }

        public void updateDgvProduct()
        {
            while (true)
            {
                this.loadDgvProduct();
                Thread.Sleep(TimeSpan.FromSeconds(30));
            }
        }
        public delegate void loadDgvProductCallback();
        public void loadDgvProduct()
        {
            if (this.dgvProduct.InvokeRequired)
            {
                loadDgvProductCallback d = new loadDgvProductCallback(loadDgvProduct);
                this.Invoke(d, new object [] { } );
            }
            else
            {                
                SqlCommand command = new SqlCommand("Select * FROM G08_Producto", conn);
                conn.Open();

                SqlDataReader productReader = command.ExecuteReader();
                dgvProduct.Rows.Clear();
                
                int reglon = 0;
                while (productReader.Read())
                {
                    reglon = dgvProduct.Rows.Add();
                    dgvProduct.Rows[reglon].Cells[0].Value = productReader.GetInt32(0);
                    dgvProduct.Rows[reglon].Cells[1].Value = productReader.GetString(1);
                    dgvProduct.Rows[reglon].Cells[2].Value = productReader.GetInt32(5);
                    dgvProduct.Rows[reglon].Cells[3].Value = productReader.GetInt32(2);
                    //dgvProduct.Rows[reglon].Cells["gpriceV"].Value = productReader.GetDecimal(3);
                    //dgvProduct.Rows[reglon].Cells["gPriceC"].Value = productReader.GetDecimal(4);
                    dgvProduct.Rows[reglon].Cells[6].Value = productReader.GetString(6);
                }
                conn.Close();
            }
        }

        public void updateDate()
        {
            while (true)
            {
                DateTime date = DateTime.Now;
                this.setDate(date.ToString());
                Thread.Sleep(500);
            }
        }
        delegate void setDateCallback(string date);
        public void setDate(string date)
        {
            if (this.lblDate.InvokeRequired)
            {
                setDateCallback d = new setDateCallback(setDate);
                this.Invoke(d, new object[] { date });
            }
            else
            {
                this.lblDate.Text = date;
            }
        }        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            txtStMax.Text = "";
            txtStMin.Text = "";
            txtId.Text = "";
            txtPurchasePrice.Text = "";
            txtSalePrice.Text = "";
        }
       
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ProductSearchForm testDialog = new ProductSearchForm();
            testDialog.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Product p = new Product();

            p.setId(Int32.Parse(txtId.Text));
            p.setName(txtName.Text);
            p.setStockMin(Int32.Parse(txtStMin.Text));
            p.setStock(Int32.Parse(txtStMax.Text));
            p.setPurchasePrice(float.Parse(txtPurchasePrice.Text));
            p.setSalePrice(float.Parse(txtSalePrice.Text));

            Program.service.addProduct(p);

            int id = Int32.Parse(txtId.Text);
            string name = txtName.Text;
            int stockMin = (Int32.Parse(txtStMin.Text));
            int stockMax = (Int32.Parse(txtStMax.Text));
            float purchasePrice = (float.Parse(txtPurchasePrice.Text));
            float salePrice = (float.Parse(txtSalePrice.Text));

            this.dgvProduct.Rows.Add(id, name, stockMin, stockMax, purchasePrice, salePrice);

            int rows = this.dgvProduct.RowCount;

            if (rows != 0) MessageBox.Show("Producto añadido");
            else            MessageBox.Show("Error al añadir");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            refMain.Visible = true;            
        }        

        private void dgvProduct_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            String selected = (dgvProduct.CurrentRow.Cells["ID"].Value).ToString();

            conn.ConnectionString = "user id=inf282;"+"password=inf282db;"+"server=inti.lab.inf.pucp.edu.pe;"+"database=inf282; "+"connection timeout=30";

            SqlCommand command = new SqlCommand("Select * FROM G08_Producto where IDProducto=" + selected, conn);

            conn.Open();

            SqlDataReader reading = command.ExecuteReader();

            if (reading.Read())
            {
                txtId.Text = (reading.GetInt32(0)).ToString();
                txtName.Text = reading.GetString(1);
                txtStMax.Text = reading.GetInt32(2).ToString();
                txtSalePrice.Text = reading.GetDecimal(3).ToString();
                txtPurchasePrice.Text = reading.GetDecimal(4).ToString();
                txtStMin.Text = reading.GetInt32(5).ToString();
            }
            conn.Close();
        }

        private void ProductForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            refMain.Visible = true;
            this.Dispose();
        }
    }
}