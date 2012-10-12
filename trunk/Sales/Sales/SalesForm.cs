using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sales
{
    public partial class SalesForm : Form
    {
        private mainForm refMain = null;
        private String prodname;
        private int idProd;
        private float pVenta;
        private int idVentas;
        private int fil=0;

        public SalesForm()
        {
            InitializeComponent();
        }
        public void SetRefMain(mainForm refM)
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
            fil++;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ProductSearch2 pSearch = new ProductSearch2();
            pSearch.SetRefSales(this);//le envio la direccion de la ventana padre al hijo
            pSearch.ShowDialog(this);
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            refMain.Show();
            this.Dispose();
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int cantidad = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            float Pventa = float.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            dataGridView1.CurrentRow.Cells["SubTotal"].Value = pVenta * cantidad;

        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            DataSet dsTipoDoc;
            DataSet dsEstado;
            //Instrucciones para cargar el combo TipoDoc
            dsTipoDoc = Program.service.GetCmbTipoDoc();
            cmbTipoDoc.DataSource = dsTipoDoc.Tables[0].DefaultView;
            cmbTipoDoc.DisplayMember = "NomDoc";
            cmbTipoDoc.ValueMember = "IdTipoDoc";
            cmbTipoDoc.SelectedIndex = -1;
            //Instrucciones para cargar el combo Estado de Ventas
            dsEstado = Program.service.GetCmbEstado();
            cmbEstado.DataSource = dsEstado.Tables[0].DefaultView;
            cmbEstado.DisplayMember = "Descripcion";
            cmbEstado.ValueMember = "IDEstado";
            cmbEstado.SelectedIndex = -1;
            //Instrucciones para cargar el Id de Ventas
            idVentas = Program.service.obtenerNuevoIDVenta();
            idVentas++; 
            lblIdVenta.Text = "" + idVentas;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ClientSearch2 clieForm = new ClientSearch2();
            clieForm.SetRefSales(this);
            clieForm.ShowDialog(this);
        }
    }
}
