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
    public partial class ClientForm : Form
    {
        private mainForm refMainForm = null; 

        public ClientForm()
        {
            InitializeComponent();
        }

        System.Data.SqlClient.SqlConnection conn =
              new System.Data.SqlClient.SqlConnection();

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            refMainForm.Show();
        }

        public void SetrefmainForm(mainForm mainp)
        {
            refMainForm = mainp;
        }

   

        private void btnNewCliente_Click(object sender, EventArgs e)
        {
            Client c = new Client();

            c.setIdCliente(Int32.Parse(txtID.Text));
            c.setDireccion((txtDireccion.Text));
            c.setRazonSocial(txtRazonSocial.Text);
            c.setCorreo((txtEmail.Text));
            c.setTelefono((txtTelefono.Text));
            c.setEstadoCliente((txtEstado.Text));
           
            Program.service.addClient(c);
        }     

        private void ClientForm_Load(object sender, EventArgs e)
        {
            cargaClientes();       
        }          
            
       void cargaClientes(){
          

            conn.ConnectionString = "user id=inf282;" +
                                       "password=inf282db;" +
                                       "server=inti.lab.inf.pucp.edu.pe;" +
                                       "database=inf282; " +
                                       "connection timeout=30";   

            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand("Select * FROM G08_Cliente",conn);
            
            conn.Open();

            System.Data.SqlClient.SqlDataReader leer = comando.ExecuteReader();

            int reglon=0;

            while(leer.Read()){

                reglon = dataGridView1.Rows.Add();
                dataGridView1.Rows[reglon].Cells["ID"].Value = leer.GetInt32(0);
                dataGridView1.Rows[reglon].Cells["Direccion"].Value = leer.GetString(1);
                dataGridView1.Rows[reglon].Cells["RazonSocial"].Value = leer.GetString(2);
                dataGridView1.Rows[reglon].Cells["Email"].Value = leer.GetString(3);
                dataGridView1.Rows[reglon].Cells["Telefono"].Value = leer.GetString(4);
                dataGridView1.Rows[reglon].Cells["Estado"].Value = leer.GetString(5);
            }

            conn.Close();    
        }

       private void btnModify_Click(object sender, EventArgs e)
       {
           txtID.Focus();
           ModifyClientForm modi = new ModifyClientForm();
           String seleccionado =(dataGridView1.CurrentRow.Cells["ID"].Value).ToString();
           modi.nc_cliente_seleccionado = seleccionado;
           modi.Show();
       }      
    }
}
