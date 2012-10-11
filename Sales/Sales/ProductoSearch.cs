using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Libreria;
using SalesService;
using System.Data.SqlClient;

namespace Sales
{
    public partial class ProductoSearch : Form
    {


        private SqlConnection conn = new SqlConnection("user id=inf282;" +
                                "password=inf282db;" +
                                "server=inti.lab.inf.pucp.edu.pe;" +
                                "database=inf282; " +
                                "connection timeout=30");






        public ProductoSearch()
        {
            InitializeComponent();
        }


        private void cargarProductos(String name)
        {

            conn.Open();

            string stringSQL = "SELECT * FROM G08_Producto WHERE NomProd = @param1";
            
            SqlDataAdapter daProductos = new SqlDataAdapter();

           SqlCommand command = new SqlCommand(stringSQL,conn);

           daProductos.SelectCommand = command;


           System.Data.SqlClient.SqlParameter param1 =
                       new System.Data.SqlClient.SqlParameter(
                           "@Param1", System.Data.SqlDbType.VarChar, 20);

           param1.Value = name;

           command.Parameters.Add(param1);

            DataSet dset = new DataSet();

            daProductos.Fill(dset, "G08_Producto");

            dataGridView1.DataSource = dset;

            dataGridView1.DataMember = "G08_Producto";

            conn.Close();

        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Add();

        }


        private void txtBuscar_Click(object sender, EventArgs e)
        {


            String name = txtName.Text;
            cargarProductos(name);
            
            //String nombre = txtName.Text;
            //List<Product> products = new List<Product>();
            //products = Program.service.queryAll(nombre);

        }

      
    }
}