using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library;


namespace Sales
{
    public partial class LoginForm : Form
    {
        private User usuario = new User();
        public LoginForm()
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
            usuario.setUser(txtUser.Text.ToUpper());
            usuario.setPassword(txtPassword.Text.ToUpper());
            usuario.makeConnection();
            if (usuario.validatePassword() == 1)
            {
                MainForm p = new MainForm();
                p.setUser(usuario.getUser());
                p.Show();       
                p.setrefmain(this);
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
        public void limpiar()
        {
            txtPassword.Text = "";
        }

    }
}
