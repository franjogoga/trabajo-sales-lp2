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
        public void setRef(PersonalForm refp){
            refPerForm = refp;
        }
        public void setIDPers(int idp)
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
