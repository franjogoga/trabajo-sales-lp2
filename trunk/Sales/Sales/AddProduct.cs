using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using Libreria;
using System.Threading;


namespace Sales
{

    public partial class AddProduct : Form
    {
       

        private mainForm Refmain = null;
        private SqlConnection conn = new System.Data.SqlClient.SqlConnection();
        
        Thread hiloConsumidor;
        ClaseCompartida objCompartido = new ClaseCompartida();
             
        public void SetRefMain(mainForm mainf)
        {
        
       
            Refmain = mainf;
        }

        
        public AddProduct(int Id, string Name, Int32 StMin, Int32 StMax, float PCompra,
        float PVenta)
        {

            InitializeComponent();
            this.dataGridView1.Rows.Add(Id, Name, StMin, StMax, PCompra, PVenta);


        }

        public AddProduct()
        {
            InitializeComponent();
            hiloConsumidor = new Thread(new ThreadStart(correConsumidor));
            hiloConsumidor.Start();
        }


        bool finalizar = false;

        public void correConsumidor()
        {
            while (!finalizar)
            {
                try
                {
                    objCompartido.espera();
                    Invoke(new miDelegado(actualizarTitulo));
                }
                catch (Exception e) { }
            }
        }
       
        public delegate void miDelegado();

        public void actualizarTitulo()
        {
            this.Text = "" + LaOtra.getValor();
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
            this.dataGridView1.Rows.Add();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ProductSearch testDialog = new ProductSearch();
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


            this.dataGridView1.Rows.Add(id, name, StockMin, StockMax, PrecioCompra, PrecioVenta);

            int filas = this.dataGridView1.RowCount;

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


            String seleccionado = (dataGridView1.CurrentRow.Cells["ID"].Value).ToString();

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




        //private void AddProduct_Load(object sender, EventArgs e)
        //{

        //    //lblhora.Text = MyDate.ToString();


        //    while (true)
        //    {

        //        //DateTime MyDate = DateTime.Now;
        //        //lblhora.Text = MyDate.ToString();
        //        //Thread.Sleep(1000);

          


        //    }

       

        //}
           
 

      
		




        }


    public class ClaseProductora
    {
        Thread hilo;

        public ClaseProductora(ClaseCompartida objCompartido)
        {
            LaOtra laOtra = new LaOtra(objCompartido);
            hilo = new Thread(new ThreadStart(laOtra.corre));
            hilo.Start();
        }

    }


    public class LaOtra
    {
        private static int i;
        private bool finalizar = false;
        private ClaseCompartida objCompartido;

        public LaOtra(ClaseCompartida obj)
        {
            this.objCompartido = obj;
        }
        public static string getValor()
        {

            DateTime MyDate = DateTime.Now;
            return MyDate.ToString();
        }

        public void corre()
        {
            i = 0;
            while (!finalizar)
            {
                i++;
                try { Thread.Sleep(1000); }
                catch (Exception e) { };
                objCompartido.notifica();
            }
        }
    }


    public class ClaseCompartida
    {
        ClaseProductora objProductor;

        public ClaseCompartida()
        {
            objProductor = new ClaseProductora(this);
        }

        public void espera()
        {
            Monitor.Enter(this);
            try { Monitor.Wait(this); }
            catch (Exception) { }
            Monitor.Exit(this);
        }
        public void notifica()
        {
            Monitor.Enter(this);
            Monitor.Pulse(this);
            Monitor.Exit(this);
        }
    }	

   
    }


