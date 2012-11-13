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
    public partial class MainForm : Form
    {
        private LoginForm refLoginForm = null;
        private String nomUser; 
        public MainForm()
        {
            InitializeComponent();
        }

        public void setrefmain(LoginForm reflog)
        {
            refLoginForm = reflog;
        }
        public void setUser(string user)
        {
            nomUser = user;
        }
        private void btnEmployee_Click(object sender, EventArgs e)
        {
            EmployeeForm pForm = new EmployeeForm();
            pForm.Show();
            pForm.setrefmainForm(this);
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
            try
            {
                List<String> userList = Program.service.searchEmployeeByUser(nomUser);          
                lblName.Text = userList[0];
                lblArea.Text = userList[1];
                lblWorkStation.Text = userList[2];
            }
            catch (Exception)
            {        
               
            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {                  
                    this.Visible = false;
                    ProductForm p = new ProductForm();
                    p.SetRefMain(this);
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
            if (result == DialogResult.Yes)
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
            if (result == DialogResult.Yes)
            {
                refLoginForm.limpiar();
                refLoginForm.Show();
                this.Dispose();
            }
        }        
    }
}