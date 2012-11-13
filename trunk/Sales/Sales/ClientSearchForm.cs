using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sales
{
    public partial class ClientSearchForm : Form
    {
        public ClientSearchForm()
        {
            InitializeComponent();
        }

        private SqlConnection conn = new SqlConnection("user id=inf282;" +"password=inf282db;" +"server=inti.lab.inf.pucp.edu.pe;" +"database=inf282; " +"connection timeout=30");

        private void loadProducts(String name)
        {
            conn.Open();

            string stringSQL = "SELECT * FROM G08_Cliente WHERE RazonSocial like " + "'%" + txtName.Text + "%'";

            SqlDataAdapter daProducts = new SqlDataAdapter();
            SqlCommand command = new SqlCommand(stringSQL, conn);
            daProducts.SelectCommand = command;

            DataSet dset = new DataSet();
            daProducts.Fill(dset, "G08_Cliente");
            dgvProducts.DataSource = dset;
            dgvProducts.DataMember = "G08_Cliente";           

            conn.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            loadProducts(name);
        }
    }
}