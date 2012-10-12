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
            pSearch.ShowDialog(this);
            pSearch.SetRefSales(this);//le envio la direccion de la ventana padre al hijo
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
            //Instrucciones para cargar el combo TipoDoc
            dsTipoDoc = Program.service.GetCmbTipoDoc();
            cmbTipoDoc.DataSource = dsTipoDoc.Tables[0].DefaultView;
            cmbTipoDoc.DisplayMember = "NomDoc";
            cmbTipoDoc.ValueMember = "IdTipo";
            cmbTipoDoc.SelectedIndex = -1;
            //Instrucciones para cargar el Id de Ventas
            idVentas = Program.service.obtenerNuevoID();
            idVentas++;
            lblIdVenta.Text = "" + lblIdVenta;
        }
    }
}
