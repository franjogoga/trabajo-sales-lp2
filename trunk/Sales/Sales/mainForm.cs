using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sales
{
    public partial class mainForm : Form
    {
        private loginForm refLoginForm = null;
        public mainForm()
        {
            InitializeComponent();
        }

        public void Setrefmain(loginForm reflog)
        {
            refLoginForm = reflog;
        }
        private void btnPersonal_Click_1(object sender, EventArgs e)
        {
            PersonalForm pForm = new PersonalForm();
            pForm.Show();
            pForm.SetrefmainForm(this);
            this.Hide();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            ClientForm pClient = new ClientForm();
            pClient.Show();
            pClient.SetrefmainForm(this);
            this.Hide();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnProduct_Click(object sender, EventArgs e)
        {                  
                    this.Visible = false;
                    AddProduct p = new AddProduct();
                    p.Visible = true;       
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            SalesForm salesF = new SalesForm();
            salesF.Show();
            salesF.SetRefMain(this);
            this.Hide();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Está seguro que desea cerrar sesión?","Cerrar Sesión",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                refLoginForm.limpiar();
                refLoginForm.Show();
                this.Dispose();
            }
            else
            {
                e.Cancel = true;
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Está seguro que desea cerrar sesión?", "Cerrar Sesión",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                refLoginForm.limpiar();
                refLoginForm.Show();
                this.Dispose();
            }
        }
    }
}
