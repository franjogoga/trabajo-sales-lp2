﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Libreria;
using Sales;

namespace Sales
{
    public partial class PersonalForm : Form
    {
        private mainForm refMainForm = null; 
        public PersonalForm()
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

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Personal p = new Personal();

            p.SetName(txtName.Text);
            p.SetLastName(txtLastName.Text);
            p.SetEmail(txtEmail.Text);
            p.SetSalary(float.Parse(txtSalary.Text));
            p.setDateHired(txtDateH.Text);
            p.SetID(Int32.Parse(txtDNI.Text));
            p.setWorkArea(Int32.Parse(txtIdArea.Text));
            p.setWorkStation(txtPuesto.Text);
            p.setAddress(txtAddress.Text);

            Program.service.addPersonal(p);

        }        
    }
}
