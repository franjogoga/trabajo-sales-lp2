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

        private ClientForm refSalesform = null;
        
        public void SetRefClient(ClientForm refsales)
        {
            refSalesform = refsales;
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

        private void dgvProducts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Id = Int32.Parse(dgvProducts.CurrentRow.Cells[0].Value.ToString());
                String direccion = dgvProducts.CurrentRow.Cells[1].Value.ToString();
                String razonSocial = dgvProducts.CurrentRow.Cells[2].Value.ToString();
                String email = dgvProducts.CurrentRow.Cells[3].Value.ToString();
                String telefono = dgvProducts.CurrentRow.Cells[4].Value.ToString();
                String estado = dgvProducts.CurrentRow.Cells[5].Value.ToString();
                
                refSalesform.setEmployeeSearch(Id,direccion,razonSocial,email,telefono,estado);
                this.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }   
        }

   


    }
}