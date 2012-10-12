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

       private int Id;
       private string Name;
       private  Int32 StMax;
       private  Int32 StMin;
       private  float PCompra;
       private  float Pventa;
   

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

            //MessageBox.Show("Busqueda Correcta");

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

       

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            int fil=0;
            this.Hide();
            Id = Int32.Parse(dataGridView1.Rows[fil].Cells[0].Value.ToString());
            
            Name = dataGridView1.Rows[fil].Cells[1].Value.ToString();
            StMax = Int32.Parse(dataGridView1.Rows[fil].Cells[2].Value.ToString());
            StMin = Int32.Parse(dataGridView1.Rows[fil].Cells[3].Value.ToString());
            PCompra = float.Parse(dataGridView1.Rows[fil].Cells[4].Value.ToString());
            Pventa = float.Parse(dataGridView1.Rows[fil].Cells[5].Value.ToString()); 
            
            
            AddProduct addp = new AddProduct(Id, Name, StMin, StMax, PCompra, Pventa);
            addp.Visible = true;

        }

      
    }
}