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
            usuario = new User();
            usuario.SetUser(txtUser.Text);
            usuario.SetPassword(txtPassword.Text);
            usuario.HacerConexion();
            if (usuario.ValidarPassword() == 1)
            {
                mainForm p = new mainForm();
                p.Show();
                p.Setrefmain(this);
                this.Hide();
            }
            else
            {
                lblError.Text = "Contraseña incorrecta";
                txtPassword.Text = "";
            }
            
        }

        private void keypressed(Object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnAccept.Click += new EventHandler(btnAccept_Click);
                this.btnAccept_Click(sender, e);
            }
        }

    }
}
