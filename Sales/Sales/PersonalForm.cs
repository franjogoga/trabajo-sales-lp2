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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
            refMainForm.Show();
        }
        public void SetrefmainForm(mainForm mainp)
        {
            refMainForm = mainp;
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            UserForm user = new UserForm();
            user.SetRef(this);
            user.SetIDPers(idpersonal);
            user.Show();
        }

        private void btnAgregarPersonal_Click(object sender, EventArgs e)
        {
            Personal p = new Personal();
            
            p.SetName(txtNombre.Text);
            p.SetLastName(txtApellido.Text);
            p.SetEmail(txtEmail.Text);
            p.SetSalary(float.Parse(txtSalario.Text));
            p.setDateHired(txtFContrato.Text);
            p.SetID(Int32.Parse(lblIdPersonal.Text));
            p.SetDNI(txtDNI.Text);
            p.setWorkStation(txtPuesto.Text);
            p.setAddress(txtDireccion.Text);

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
            cmbArea.SelectedIndex = -1;
            //Instrucciones para cargar el Id de Personal
            idpersonal = Program.service.obtenerNuevoID();
            idpersonal = idpersonal + 1;
            lblIdPersonal.Text = "" + idpersonal;
        }        
    }
}
