﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Libreria;

namespace Sales
{
    public partial class AddProduct : Form
    {
        public AddProduct( int Id, string Name,Int32 StMin, Int32 StMax, float PCompra,
         float PVenta)
        {
            InitializeComponent();
            this.dataGridView1.Rows.Add(Id, Name, StMin, StMax, PCompra, PVenta);

        }

        public AddProduct()
        {
            InitializeComponent();
            

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
            ProductoSearch testDialog = new ProductoSearch();
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

            this.Visible = false;
            mainForm mform = new mainForm();
            mform.Visible = true;


        }

         





    } 

}