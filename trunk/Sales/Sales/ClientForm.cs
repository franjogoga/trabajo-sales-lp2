using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Libreria;
using System.Data.SqlClient;

namespace Sales
{
    public partial class ClientForm : Form
    {
        private mainForm refMainForm = null;
        private int idCliente=0;

        private SqlConnection conn = new SqlConnection("user id=inf282;" +
                               "password=inf282db;" +
                               "server=inti.lab.inf.pucp.edu.pe;" +
                               "database=inf282; " +
                               "connection timeout=30");


        public ClientForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            refMainForm.Show();
        }

        public void SetrefmainForm(mainForm mainp)
        {
            refMainForm = mainp;
        }  
                    
       void cargaClientes( ){          

           System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand("Select * FROM G08_Cliente", conn);
           conn.Open();

           System.Data.SqlClient.SqlDataReader leer = comando.ExecuteReader();
           dataGridView1.Rows.Clear();  //limpiar la grilla si es voy a llamar este metodo desde otro lugar
           int reglon = 0;

           while (leer.Read())
           {
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
           String seleccionado =(dataGridView1.CurrentRow.Cells["ID"].Value).ToString();
           
           System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand("Select * FROM G08_Cliente where IDCliente=" + seleccionado ,conn);

           conn.Open();

           System.Data.SqlClient.SqlDataReader leer = comando.ExecuteReader();
           
           if(leer.Read()){
               txtID.Text = (leer.GetInt32(0)).ToString();
               txtDireccion.Text = leer.GetString(1);
               txtRazonSocial.Text = leer.GetString(2);
               txtEmail.Text = leer.GetString(3);
               txtTelefono.Text = leer.GetString(4);
               txtEstado.Text = leer.GetString(5);
           }
           conn.Close();
       }

       private void btnAdd_Click_1(object sender, EventArgs e)
       {

           idCliente = Program.service.obtenerNuevoClientID();
           idCliente = idCliente + 1;
           txtID.Text = "" + idCliente;

           Client c = new Client();

           c.setIdCliente(idCliente);
           c.setDireccion((txtDireccion.Text));
           c.setRazonSocial(txtRazonSocial.Text);
           c.setCorreo((txtEmail.Text));
           c.setTelefono((txtTelefono.Text));
           c.setEstadoCliente((txtEstado.Text));
           
           Program.service.addClient(c);

           MessageBox.Show("Cliente Agregado Correctactamente","AVISO",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);

           txtID.Text = "";
           txtDireccion.Text = "";
           txtEstado.Text = "";
           txtRazonSocial.Text = "";
           txtTelefono.Text = "";
           txtEmail.Text = "";

           cargaClientes();
       }

       private void ClientForm_Load_1(object sender, EventArgs e)
       {
          cargaClientes(); 
       }

       private void btnSave_Click(object sender, EventArgs e)
       {
           System.Data.SqlClient.SqlCommand nuevo = new System.Data.SqlClient.SqlCommand("update G08_Cliente set Direccion=@Direccion, RazonSocial=@RazonSocial, Email=@Email, Telefono=@Telefono, EstadoCliente=@Estado where IDCliente=@IDCliente ",conn);

           nuevo.Parameters.AddWithValue("IDCliente", dataGridView1.CurrentRow.Cells["ID"].Value);
           nuevo.Parameters.AddWithValue("Direccion",txtDireccion.Text);   // ponemos lo que vamos a escribir en txtDireccion a la variable que he creado.
           nuevo.Parameters.AddWithValue("RazonSocial", txtRazonSocial.Text);
           nuevo.Parameters.AddWithValue("Email", txtEmail.Text);
           nuevo.Parameters.AddWithValue("Telefono", txtTelefono.Text);
           nuevo.Parameters.AddWithValue("Estado", txtEstado.Text);

           conn.Open();
           nuevo.ExecuteNonQuery();          
           conn.Close();

           cargaClientes();

       }

       private void btnDelete_Click(object sender, EventArgs e)
       {

           DialogResult resultado = MessageBox.Show("¿Esta seguro que quiere eliminar el cliente seleccionado?","AVISO",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
           if (resultado==DialogResult.No){
            return;
           }
           System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand("Delete from G08_Cliente where IDCliente=@IDCliente",conn);
           
           comando.Parameters.AddWithValue("IDCliente", dataGridView1.CurrentRow.Cells["ID"].Value);  //EL IDcliente es el parametro de arriba

           conn.Open();
           comando.ExecuteNonQuery();
           conn.Close();

           MessageBox.Show("Cliente Borrado Correctactamente","AVISO",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
           cargaClientes();
           }

       private void btnSearch_Click(object sender, EventArgs e)
       {
           //ClientSearch cliS = new ClientSearch();
           //cliS.Show();
       }    
    }
}
