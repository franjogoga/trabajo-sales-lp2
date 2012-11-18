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

namespace Sales
{
    public partial class SalesForm : Form
    {
        private SqlConnection conn = new SqlConnection("user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30");
        private MainForm refMain = null;
        private String prodname;
        private int idProd;
        private float pVenta;
        private int idVentas;
        private int fil=0;
        private int var = 0;

        public SalesForm()
        {
            InitializeComponent();
        }
        public void SetClient(int idcliente, String nameCliente)
        {
            txtIdClient.Text = ""+idcliente;
            txtNomClient.Text = nameCliente;
        }
        public void SetRefMain(MainForm refM)
        {
            refMain = refM;
        }
        public void SetDatos(int id, String nam, float pv){
            idProd = id;
            prodname = nam;
            pVenta = pv;

            dataGridView1.Rows[fil].Cells["ID"].Value = id;
            dataGridView1.Rows[fil].Cells["Producto"].Value = nam;
            dataGridView1.Rows[fil].Cells["PrecUnit"].Value = pVenta;
            btnSelPro.Enabled = false;
            lblEvent.Text = "Ingrese Cantidad de Producto";
            fil++;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ProductSearchForm pSearch = new ProductSearchForm();
            pSearch.SetRefSales(this);//le envio la direccion de la ventana padre al hijo
            pSearch.ShowDialog(this);    
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            refMain.Show();
            this.Dispose();
        }

        private void BeginNewSale()
        {
            DataSet dsTipoDoc;
            DataSet dsEstado;
            lblEvent.Text = "";
            lblError.Text = "";
            btnNew.Enabled = false; 
            //Texboxes de Cliente no editable
            txtIdClient.ReadOnly = true;
            txtNomClient.ReadOnly = true;
            txtTotal.ReadOnly = true;
            //Instrucciones para cargar el combo TipoDoc
            dsTipoDoc = Program.service.getCmbDocType();
            cmbTipoDoc.DataSource = dsTipoDoc.Tables[0].DefaultView;
            cmbTipoDoc.DisplayMember = "NomDoc";
            cmbTipoDoc.ValueMember = "IdTipoDoc";
            cmbTipoDoc.SelectedIndex = -1;
            //Instrucciones para cargar el combo Estado de Ventas
            dsEstado = Program.service.getCmbState();
            cmbEstado.DataSource = dsEstado.Tables[0].DefaultView;
            cmbEstado.DisplayMember = "Descripcion";
            cmbEstado.ValueMember = "IDEstado";
            cmbEstado.SelectedIndex = -1;
            //Instrucciones para cargar el Id de Ventas
            idVentas = Program.service.getNewSaleId();
            idVentas++;
            lblIdVenta.Text = "" + idVentas;
        }
        private void SalesForm_Load(object sender, EventArgs e)
        {
            BeginNewSale();
            txtIGV.Enabled = false;
            txtIGV.Text = ""+ 18;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ClientSearch2 clieForm = new ClientSearch2();
            clieForm.SetRefSales(this);
            clieForm.ShowDialog(this);
        }

        private void SalesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            refMain.Show();
            this.Dispose();
        }
        private void almacenaVentaxProducto()
        {
            try
            {
                conn.Open();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {

                    SqlCommand command = new SqlCommand("G08_AlmacenaVentaxProducto", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@idVenta", SqlDbType.Int);
                    command.Parameters["@idVenta"].Value = int.Parse(lblIdVenta.Text);

                    command.Parameters.Add("@idProducto", SqlDbType.Int);
                    command.Parameters["@idProducto"].Value = dataGridView1.Rows[i].Cells[1].Value;

                    command.Parameters.Add("@cantidad", SqlDbType.Int);
                    command.Parameters["@cantidad"].Value = dataGridView1.Rows[i].Cells[0].Value;

                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }
        private void almacenaVenta()
        {
            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand("G08_AlamcenaVenta", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@idVenta", SqlDbType.Int);
                command.Parameters["@idVenta"].Value = int.Parse(lblIdVenta.Text);

                command.Parameters.Add("@fecha", SqlDbType.DateTime);
                command.Parameters["@fecha"].Value = DateTime.Parse(txtDate.Text);

                command.Parameters.Add("@subtotal ", SqlDbType.Money);
                command.Parameters["@subtotal "].Value = float.Parse(txtTotal.Text)-(float.Parse(txtTotal.Text) * float.Parse(txtIGV.Text) / 100);

                command.Parameters.Add("@igv", SqlDbType.Float);
                command.Parameters["@igv"].Value = float.Parse(txtIGV.Text);

                command.Parameters.Add("@total", SqlDbType.Money);
                command.Parameters["@total"].Value = float.Parse(txtTotal.Text);

                command.Parameters.Add("@idEstado", SqlDbType.Int);
                command.Parameters["@idEstado"].Value = cmbEstado.SelectedValue;

                command.Parameters.Add("@idTipoDoc", SqlDbType.Int);
                command.Parameters["@idTipoDoc"].Value = cmbTipoDoc.SelectedValue;

                command.Parameters.Add("@idCliente", SqlDbType.Int);
                command.Parameters["@idCliente"].Value = int.Parse(txtIdClient.Text);

                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtIdClient.Text == "") lblError.Text = "Falta Datos";
            else if (txtNomClient.Text == "") lblError.Text = "Falta Datos";
            else if (cmbEstado.SelectedItem.ToString() == "") lblError.Text = "Falta Datos";
            else if (cmbTipoDoc.SelectedItem.ToString() == "") lblError.Text = "Falta Datos";
            else
            {
                almacenaVenta();
                almacenaVentaxProducto();
                lblError.Text = "Venta Guardada";
            }
            dataGridView1.Enabled = false;
            txtDate.Enabled = false;
            txtIGV.Enabled = false;
            txtTotal.Enabled = false;
            cmbEstado.Enabled = false;
            cmbTipoDoc.Enabled = false;
            btnBuscar.Enabled = false;
            btnModificar.Enabled = false;
            btnSelPro.Enabled = false;
            btnNew.Enabled = true;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnSelPro.Enabled = true;
            lblEvent.Text = "Ingrese nuevo Producto";
            try
            {
                if (dataGridView1.CurrentRow.Cells["SubTotal"].Value == null)
                {
                    int cantidad = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    float Pventa = float.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                    dataGridView1.CurrentRow.Cells["SubTotal"].Value = pVenta * cantidad;
                    var = (Int32)(var + pVenta * cantidad);

                    txtTotal.Text = var.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblEvent.Text = "";
            var = 0;
            dataGridView1.Enabled = true;
            dataGridView1.Rows.Clear();
            cmbEstado.Enabled = true;
            cmbEstado.SelectedValue = 0;
            cmbTipoDoc.Enabled = true;
            cmbTipoDoc.SelectedValue = 0;
            txtDate.Enabled = true;
            txtIdClient.Text = "";
            txtIGV.Text = "";
            txtIGV.Enabled = true;
            txtNomClient.Text = "";
            txtTotal.Text = "";
            btnBuscar.Enabled = true;
            btnModificar.Enabled = true;
            btnSelPro.Enabled = true;
            btnNew.Enabled = false;
            //Instrucciones para cargar el Id de Ventas
            idVentas = Program.service.getNewSaleId();
            idVentas++;
            lblIdVenta.Text = "" + idVentas;
        }
    }
}
