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
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "kevin" && txtPassword.Text == "desarrollo")
            {
                mainForm p = new mainForm();
                p.Show();
                this.Hide();
            }
            else
            {
                txtPassword.Text = ""
                lblError.Text = "Contraseña incorrecta";
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
