using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Libreria;
using System.Threading;

namespace Sales
{
    public partial class AddProduct : Form
    {
        private mainForm Refmain = null;
        private SqlConnection conn = new SqlConnection();

        public void SetRefMain(mainForm mainf)
        {
            Refmain = mainf;
        }
        
        public AddProduct(int Id, string Name, Int32 StMin, Int32 StMax, float PCompra, float PVenta)
        {
            InitializeComponent();
            this.dgvProduct.Rows.Add(Id, Name, StMin, StMax, PCompra, PVenta);
        }

        public AddProduct()
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
                conn.ConnectionString = "user id=inf282;"+"password=inf282db;"+"server=inti.lab.inf.pucp.edu.pe;"+"database=inf282; "+"connection timeout=30";

                SqlCommand command = new SqlCommand("Select * FROM G08_Producto", conn);
                conn.Open();

                SqlDataReader reading = command.ExecuteReader();
                dgvProduct.Rows.Clear();
                int reglon = 0;

                while (reading.Read())
                {
                    reglon = dgvProduct.Rows.Add();
                    dgvProduct.Rows[reglon].Cells["ID"].Value = reading.GetInt32(0);
                    dgvProduct.Rows[reglon].Cells["gProduct"].Value = reading.GetString(1);
                    dgvProduct.Rows[reglon].Cells["gStockMin"].Value = reading.GetInt32(5);
                    dgvProduct.Rows[reglon].Cells["gStockMax"].Value = reading.GetInt32(2);
                    dgvProduct.Rows[reglon].Cells["gpriceV"].Value = reading.GetDecimal(3);
                    dgvProduct.Rows[reglon].Cells["gPriceC"].Value = reading.GetDecimal(4);
                    dgvProduct.Rows[reglon].Cells["gImg"].Value = reading.GetString(6);
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
            txtPcompra.Text = "";
            txtPventa.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.dgvProduct.Rows.Add();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ProductSearch2 testDialog = new ProductSearch2();
            testDialog.Visible = true;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            //this.dataGridView1.Rows.Add(txtId, txtName, txtStMin, txtStMax, txtPcompra, txtPventa);
            //this.dataGridView1.Rows[0](

            Product p = new Product();

            p.setCodigo(Int32.Parse(txtId.Text));
            p.setName(txtName.Text);
            p.setStockMin(Int32.Parse(txtStMin.Text));
            p.setStockMax(Int32.Parse(txtStMax.Text));
            p.setPrecioCompra(float.Parse(txtPcompra.Text));
            p.setPrecioVenta(float.Parse(txtPventa.Text));

            Program.service.addProduct(p);

            int id = Int32.Parse(txtId.Text);
            string name = txtName.Text;
            int StockMin = (Int32.Parse(txtStMin.Text));
            int StockMax = (Int32.Parse(txtStMax.Text));
            float PrecioCompra = (float.Parse(txtPcompra.Text));
            float PrecioVenta = (float.Parse(txtPventa.Text));

            this.dgvProduct.Rows.Add(id, name, StockMin, StockMax, PrecioCompra, PrecioVenta);

            int filas = this.dgvProduct.RowCount;

            if (filas != 0)
                MessageBox.Show("Producto añadido");
            else
                MessageBox.Show("Error al añadir");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Refmain.Visible = true;
            this.Dispose();
        }

        private void btnModify_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            String seleccionado = (dgvProduct.CurrentRow.Cells["ID"].Value).ToString();

            conn.ConnectionString = "user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30";

            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand("Select * FROM G08_Producto where IDProducto=" + seleccionado, conn);

            conn.Open();

            System.Data.SqlClient.SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read())
            {
                txtId.Text = (leer.GetInt32(0)).ToString();
                txtName.Text = leer.GetString(1);
                txtStMax.Text = leer.GetInt32(2).ToString();
                txtPventa.Text = leer.GetDecimal(3).ToString();
                txtPcompra.Text = leer.GetDecimal(4).ToString();
                txtStMin.Text = leer.GetInt32(5).ToString();
            }
            conn.Close();
        }

        private void AddProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            Refmain.Visible = true;
            this.Dispose();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Refmain.Visible = true;
        }

    }
}