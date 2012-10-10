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
      
    }
}
