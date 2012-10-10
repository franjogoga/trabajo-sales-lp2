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

            p.setName(txtName.Text);
            p.setCodigo(int  txt);
            p.setPrice(float.Parse(txtPrice.Text));
            p.setStock(Int32.Parse(txtStock.Text));

            //MainClass.service.addProduct(p);


        }
    }
}
