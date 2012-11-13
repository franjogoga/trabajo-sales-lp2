using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library;
using System.Data.SqlClient;

namespace Sales
{
    public partial class ClientForm : Form
    {
        private MainForm refMainForm = null;
        private int idClient=0;

        private SqlConnection conn = new SqlConnection("user id=inf282;"+"password=inf282db;"+"server=inti.lab.inf.pucp.edu.pe;"+"database=inf282; "+"connection timeout=30");

        public ClientForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            refMainForm.Show();
        }

        public void SetrefmainForm(MainForm mainp)
        {
            refMainForm = mainp;
        }  
                    
       void loadClients( ){          

           SqlCommand command = new SqlCommand("Select * FROM G08_Cliente", conn);
           conn.Open();

           SqlDataReader reading = command.ExecuteReader();
           dgvClient.Rows.Clear();  //limpiar la grilla si es voy a llamar este metodo desde otro lugar
           int reg = 0;

           while (reading.Read())
           {
               reg= dgvClient.Rows.Add();
               dgvClient.Rows[reg].Cells["ID"].Value = reading.GetInt32(0);
               dgvClient.Rows[reg].Cells["Direccion"].Value = reading.GetString(1);
               dgvClient.Rows[reg].Cells["RazonSocial"].Value = reading.GetString(2);
               dgvClient.Rows[reg].Cells["Email"].Value = reading.GetString(3);
               dgvClient.Rows[reg].Cells["Telefono"].Value = reading.GetString(4);
               dgvClient.Rows[reg].Cells["Estado"].Value = reading.GetString(5);
           }
           conn.Close(); 
        }

       private void btnModify_Click(object sender, EventArgs e)
       {
           panelClient.Enabled = true;
           btnSave.Enabled = true;
           String selected =(dgvClient.CurrentRow.Cells["ID"].Value).ToString();
           
           SqlCommand command = new SqlCommand("Select * FROM G08_Cliente where IDCliente=" + selected ,conn);

           conn.Open();

           SqlDataReader reading = command.ExecuteReader();
           
           if(reading.Read()){
               txtID.Text = (reading.GetInt32(0)).ToString();
               txtAddress.Text = reading.GetString(1);
               txtBusinessName.Text = reading.GetString(2);
               txtEmail.Text = reading.GetString(3);
               txtTelephone.Text = reading.GetString(4);
               txtState.Text = reading.GetString(5);
           }
           conn.Close();
       }

       private void btnAdd_Click_1(object sender, EventArgs e)
       {
           panelClient.Enabled = true;
           btnSave.Enabled = false;
           btnModify.Enabled = false;

           idClient = Program.service.getNewIdClient();

           if (txtBusinessName.Text == "") {
               txtID.Text = "" + idClient;
           }

           if (txtBusinessName.Text != "")
           {
               idClient = idClient + 1;
               txtID.Text = "" + idClient;

               Client c = new Client();

               c.setIdClient(idClient);
               c.setAddress((txtAddress.Text));
               c.setBusinessName(txtBusinessName.Text);
               c.setEmail((txtEmail.Text));
               c.setTelephone((txtTelephone.Text));
               c.setState((txtState.Text));
           
               Program.service.addClient(c);
           
                MessageBox.Show("Cliente Agregado Correctactamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                txtID.Text = "";
                txtAddress.Text = "";
                txtState.Text = "";
                txtBusinessName.Text = "";
                txtTelephone.Text = "";
                txtEmail.Text = "";
                loadClients();        
           }               
       }

       private void ClientForm_Load_1(object sender, EventArgs e)
       {
            panelClient.Enabled = false;
            loadClients(); 
       }

       private void btnSave_Click(object sender, EventArgs e)
       {
           SqlCommand newp = new SqlCommand("update G08_Cliente set Direccion=@Direccion, RazonSocial=@RazonSocial, Email=@Email, Telefono=@Telefono, EstadoCliente=@Estado where IDCliente=@IDCliente ",conn);

           newp.Parameters.AddWithValue("IDCliente", dgvClient.CurrentRow.Cells["ID"].Value);
           newp.Parameters.AddWithValue("Direccion",txtAddress.Text);   // ponemos lo que vamos a escribir en txtDireccion a la variable que he creado.
           newp.Parameters.AddWithValue("RazonSocial", txtBusinessName.Text);
           newp.Parameters.AddWithValue("Email", txtEmail.Text);
           newp.Parameters.AddWithValue("Telefono", txtTelephone.Text);
           newp.Parameters.AddWithValue("Estado", txtState.Text);

           conn.Open();
           newp.ExecuteNonQuery();          
           conn.Close();

           loadClients();
       }    

       private void btnSearch_Click(object sender, EventArgs e)
       {
           ClienteSearch testDialog = new ClienteSearch();
           testDialog.ShowDialog(this);
       }

       private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
       {
           this.Dispose();
           refMainForm.Show();
       }

       private void btnNuevo_Click_1(object sender, EventArgs e)
       {
           txtBusinessName.Text = "";
           txtAddress.Text = "";
           txtState.Text = "";
           txtTelephone.Text = "";
           txtEmail.Text = "";
           btnModify.Enabled = true;
       }    
    }
}