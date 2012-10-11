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

namespace Sales
{
    public partial class ProductoSearch : Form
    {
        public ProductoSearch()
        {
            InitializeComponent();
        }

       
  

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {

            String nombre = txtName.Text;
            List<Product> products = new List<Product>();
            products = Program.service.queryAll(nombre);

        }
    }
}
