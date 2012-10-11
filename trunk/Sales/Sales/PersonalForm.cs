using System;
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
        private int idpersonal;
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
            UserForm user = new UserForm();
            user.SetRef(this);
            user.SetIDPers(idpersonal);
            user.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Personal p = new Personal();
            
            p.SetName(txtName.Text);
            p.SetLastName(txtLastName.Text);
            p.SetEmail(txtEmail.Text);
            p.SetSalary(float.Parse(txtSalary.Text));
            p.setDateHired(txtDateH.Text);
            p.SetID(Int32.Parse(lblIdPersonal.Text));
            p.SetDNI(txtDNI.Text);
            p.setWorkStation(txtPuesto.Text);
            p.setAddress(txtAddress.Text);

            Program.service.addPersonal(p);

        }

        private void PersonalForm_Load(object sender, EventArgs e)
        {
            DataSet dsArea;
            //Instrucciones para cargar el combo box
            dsArea = Program.service.GetCmbArea();
            cmbArea.DataSource = dsArea.Tables[0].DefaultView;
            cmbArea.DisplayMember = "NomArea";
            cmbArea.ValueMember = "IdArea";
            //Instrucciones para cargar el Id de Personal
            idpersonal = Program.service.obtenerNuevoID();
            idpersonal = idpersonal + 1;
            lblIdPersonal.Text = "" + idpersonal;
        }        
    }
}
