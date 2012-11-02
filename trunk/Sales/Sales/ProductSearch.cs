using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sales
{
    public partial class ProductSearch : Form
    {
        private SalesForm refSales = null;
        private SqlConnection conn = new SqlConnection("user id=inf282;"+"password=inf282db;"+"server=inti.lab.inf.pucp.edu.pe;"+"database=inf282; "+"connection timeout=30");
        public ProductSearch()
        {
            InitializeComponent();
        }

        private void ProductSearch_Load(object sender, EventArgs e)
        {

        }
        private void cargarProductos(String name)
        {

            conn.Open();

            string stringSQL = "SELECT * FROM G08_Producto WHERE NomProd like " + "'%" + txtName.Text + "%'";

            SqlDataAdapter daProductos = new SqlDataAdapter();
            SqlCommand command = new SqlCommand(stringSQL, conn);
            daProductos.SelectCommand = command;

            DataSet dset = new DataSet();
            daProductos.Fill(dset, "G08_Producto");
            dataGridView1.DataSource = dset;
            dataGridView1.DataMember = "G08_Producto";

            //MessageBox.Show("Busqueda Correcta");

            conn.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            cargarProductos(name);
        }
    }
}
