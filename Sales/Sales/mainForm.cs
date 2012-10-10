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
        public mainForm()
        {
            InitializeComponent();
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
    }
}
