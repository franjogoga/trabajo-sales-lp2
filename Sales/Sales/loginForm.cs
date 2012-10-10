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
    public partial class loginForm : Form
    {
        private User usuario = new User();
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
            usuario.SetUser(txtUser.Text);
            usuario.SetPassword(txtPassword.Text);
            if (usuario.hacerConexion() == 0)           
                lblError.Text = "Error Base de Datos";      
            else
                if (usuario.VerificaClave() == 1)
                {
                    mainForm p = new mainForm();
                    p.Show();
                    this.Hide();
                }
                else
                {
                    txtPassword.Text = "";
                    lblError.Text = "Contraseña incorrecta";
                }
           
        }

    }
}
