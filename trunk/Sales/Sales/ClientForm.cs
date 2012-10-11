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

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Add(txtID,txtRazonSocial,txtTelefono,txtDireccion,txtEmail,txtEstado);
            
        }

      
    }
}
