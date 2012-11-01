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
using System.Data.SqlClient;

namespace Sales
{
    public partial class PersonalForm : Form
    {         
        private mainForm refMainForm = null;
        private int idpersonal=0;
        private SqlConnection conn = new SqlConnection("user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30");
       
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
            panelPersonal.Enabled = true;
            btnGuardar.Enabled = true;           
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtDNI.Text = "";
            txtEmail.Text = "";
            txtFContrato.Text = "";
            txtNombre.Text = "";
            txtPuesto.Text = "";
            txtSalario.Text = "";            
        }

        void cargaPersonal()
        {
            conn.Open();

            string stringSQL = "SELECT * FROM G08_Personal";
            SqlDataAdapter daPersonal = new SqlDataAdapter();
            SqlCommand command = new SqlCommand(stringSQL, conn);
            daPersonal.SelectCommand = command;
            DataSet dset = new DataSet();
            daPersonal.Fill(dset, "G08_Personal");
            gridPersonal.DataSource = dset;
            gridPersonal.DataMember = "G08_Personal";
            
            conn.Close();
        }

        void ActualizaPersonal()
        {
            float sueldo = float.Parse(txtSalario.Text);
            int idarea = int.Parse(cmbArea.SelectedValue.ToString());
            int idper = int.Parse(lblIdPersonal.Text);
            try
            {
                conn.Open();
                String stringSQL = "Update G08_Personal " +
                                  "Set nombres = " + txtNombre.Text + ", apellidos = " + txtApellido.Text +
                                  " , email =" + txtEmail.Text + " fechaContrato = " + txtFContrato.Text +
                                  "Direccion = " + txtDireccion.Text + " , Sueldo = " + sueldo +
                                  " ,Puesto = " + txtPuesto.Text + " ,idarea= " + idarea + " ,DNI = " + txtDNI.Text +
                                  " Where idPersonal = " + idper;
                SqlCommand comando = new SqlCommand(stringSQL, conn);
                comando.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception)
            {
                
                throw;
            }
            
            panelPersonal.Enabled = false;
            btnGuardar.Enabled = false;
        }
        private void PersonalForm_Load(object sender, EventArgs e)
        {
            DataSet dsArea;
            //Inicializamos Estado
            lblEstado.Text = "Datos de Personal";
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
            cargaPersonal();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            PersonalSearch testDialog = new PersonalSearch();
            testDialog.SetRefPersonal(this);
            testDialog.ShowDialog(this);

        }
        private void btnGuardar_Click(object sender, EventArgs e)
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
            p.setWorkArea(Int32.Parse(cmbArea.SelectedValue.ToString()));
            
            Program.service.addPersonal(p);

            lblError.Text = "Registrado";
           
            cargaPersonal();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            refMainForm.Show();
            this.Dispose();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            lblEstado.Text = "Modificando";
            panelPersonal.Enabled = true;
            btnGuardar.Enabled = true;         
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Seguro que desea eliminar el personal seleccionado?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {
                return;
            }
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand("Delete from G08_Personal where IDPersonal = @IDPersonal", conn);

            comando.Parameters.AddWithValue("IDPersonal", gridPersonal.CurrentRow.Cells["IDPersonal"].Value);  

            conn.Open();
            comando.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Cliente Borrado Correctactamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            cargaPersonal();
        }

        private void PersonalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            refMainForm.Show();
            this.Dispose();
        }
        public void SetPersonalSearch(int id, String name, String lastname,String email,String fecha,
                String direccion, float sueldo,String puesto,int idarea, String dni)
        {
            lblEstado.Text = "Datos de Personal";
            lblIdPersonal.Text = ""+id;
            txtNombre.Text = name;
            txtApellido.Text = lastname;
            txtEmail.Text = email;
            txtFContrato.Text = fecha;
            txtDireccion.Text = direccion;
            txtSalario.Text = ""+sueldo;
            txtPuesto.Text = puesto;
            cmbArea.SelectedIndex = idarea;
            txtDNI.Text = dni;
            btnModificar.Enabled = true;
        }
    }
}
