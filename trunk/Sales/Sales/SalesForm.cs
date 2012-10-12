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

           

        }
        private void button1_Click(object sender, EventArgs e)
        {
            ProductSearch2 pSearch = new ProductSearch2();
            pSearch.Visible = true;
            pSearch.SetRefSales(this);//le envio la direccion de la ventana padre al hijo
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            refMain.Show();
            this.Dispose();
        }
    }
}
