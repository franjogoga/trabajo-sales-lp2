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
    public partial class UserForm : Form
    {
        private PersonalForm refPerForm = null;
        private int IdPersonal;
        public UserForm()
        {
            InitializeComponent();
        }
        public void SetRef(PersonalForm refp){
            refPerForm = refp;
        }
        public void SetIDPers(int idp)
        {
            IdPersonal = idp;
            lblIdPersonal.Text = "" + IdPersonal;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
