using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Libreria;

namespace Sales
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {


            Product p = new Product();
      

            p.setCodigo(Int32.Parse(txtId.Text));
            p.setName(txtName.Text);  
            p.setStockMin(Int32.Parse(txtStMax.Text));
            p.setStockMax(Int32.Parse(txtStMin.Text));
            p.setPrecioCompra(float.Parse(txtPcompra.Text));
            p.setPrecioVenta(float.Parse(txtPcompra.Text));

            
            
                Program.service.addProduct(p);
           


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
