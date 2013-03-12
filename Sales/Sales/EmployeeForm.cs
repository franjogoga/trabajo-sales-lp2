using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library;
using Sales;
using System.Data.SqlClient;

namespace Sales
{
    public partial class EmployeeForm : Form
    {         
        private MainForm refMainForm = null;
        private int idEmployee=0;
        private SqlConnection conn = new SqlConnection("user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30");
       
        public EmployeeForm()
        {
            InitializeComponent();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            refMainForm.Show();
        }
        public void setrefmainForm(MainForm mainp)
        {
            refMainForm = mainp;
        }
        private void btnNewUser_Click(object sender, EventArgs e)
        {
            UserForm user = new UserForm();
            user.setRef(this);
            user.setIDPers(idEmployee);
            user.Show();
        }
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            paneEmployee.Enabled = true;
            btnSave.Enabled = true;           
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtDNI.Text = "";
            txtEmail.Text = "";
            txtDateHired.Text = "";
            txtName.Text = "";
            txtWorkStation.Text = "";
            txtSalary.Text = "";            
        }

        void loadEmployee()
        {
            conn.Open();

            string stringSQL = "SELECT * FROM G08_Personal";
            SqlDataAdapter daEmployee = new SqlDataAdapter();
            SqlCommand command = new SqlCommand(stringSQL, conn);
            daEmployee.SelectCommand = command;
            DataSet dset = new DataSet();
            daEmployee.Fill(dset, "G08_Personal");
            dgvEmployee.DataSource = dset;
            dgvEmployee.DataMember = "G08_Personal";
            
            conn.Close();
        }

        void updateEmployee()
        {
            float salary = float.Parse(txtSalary.Text);
            int idarea = int.Parse(cmbArea.SelectedValue.ToString());
            int idper = int.Parse(lblIdEmployee.Text);
            try
            {
                conn.Open();
                String stringSQL = "Update G08_Personal "+"Set nombres = @param1 ,apellidos = @param2 , email = @param3"+
                                  " ,fechaContrato = @param4 ,Direccion = @param5 , Sueldo = @param6" +" ,Puesto = @param7 ,idarea= @param8 ,DNI = @param9" + 
                                  " Where idPersonal = @param10";
                SqlParameter myparam1 = new SqlParameter("@param1",SqlDbType.VarChar,20);
                SqlParameter myparam2 = new SqlParameter("@param2",SqlDbType.VarChar,20);
                SqlParameter myparam3 = new SqlParameter("@param3",SqlDbType.VarChar,20);
                SqlParameter myparam4 = new SqlParameter("@param4",SqlDbType.VarChar,10);
                SqlParameter myparam5 = new SqlParameter("@param5",SqlDbType.VarChar,30);
                SqlParameter myparam6 = new SqlParameter("@param6",SqlDbType.Float);
                SqlParameter myparam7 = new SqlParameter("@param7",SqlDbType.VarChar,20);
                SqlParameter myparam8 = new SqlParameter("@param8",SqlDbType.Int);
                SqlParameter myparam9 = new SqlParameter("@param9",SqlDbType.VarChar,10);
                SqlParameter myparam10 = new SqlParameter("@param10",SqlDbType.Int);
                myparam1.Value = txtName.Text;
                myparam2.Value = txtLastName.Text;
                myparam3.Value = txtEmail.Text;
                myparam4.Value = txtDateHired.Text;
                myparam5.Value = txtAddress.Text;
                myparam6.Value = salary;
                myparam7.Value = txtWorkStation.Text;
                myparam8.Value = idarea;
                myparam9.Value = txtDNI.Text;
                myparam10.Value = idper;
                SqlCommand comando = new SqlCommand(stringSQL, conn);
                comando.Parameters.Add(myparam1);
                comando.Parameters.Add(myparam2);
                comando.Parameters.Add(myparam3);
                comando.Parameters.Add(myparam4);
                comando.Parameters.Add(myparam5);
                comando.Parameters.Add(myparam6);
                comando.Parameters.Add(myparam7);
                comando.Parameters.Add(myparam8);
                comando.Parameters.Add(myparam9);
                comando.Parameters.Add(myparam10);
                comando.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
            paneEmployee.Enabled = false;
            btnSave.Enabled = false;
        }
        private void PersonalForm_Load(object sender, EventArgs e)
        {
            DataSet dsArea;
            //Inicializamos Estado
            lblState.Text = "Datos de Personal";
            //Instrucciones para cargar el combo box
            dsArea = Program.service.getCmbArea();
            cmbArea.DataSource = dsArea.Tables[0].DefaultView;
            cmbArea.DisplayMember = "NomArea";
            cmbArea.ValueMember = "IdArea";
            cmbArea.SelectedIndex = -1;
            //Instrucciones para cargar el Id de Personal
            idEmployee = Program.service.getNewEmployeeId();
            idEmployee = idEmployee + 1;
            lblIdEmployee.Text = "" + idEmployee;
            loadEmployee();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            EmployeeSearchForm testDialog = new EmployeeSearchForm();
            testDialog.SetRefPersonal(this);
            testDialog.ShowDialog(this);

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Employee p = new Employee();
            if (lblState.Text == "Modificando")
            {
                updateEmployee();
                lblError.Text = "Actualizado";
                lblState.Text = "Datos de Personal";
            }
            else
            {
                p.setName(txtName.Text);
                p.setLastName(txtLastName.Text);
                p.setEmail(txtEmail.Text);
                p.setSalary(float.Parse(txtSalary.Text));
                p.setDateHired(txtDateHired.Text);
                p.setID(Int32.Parse(lblIdEmployee.Text));
                p.setDNI(txtDNI.Text);
                p.setWorkStation(txtWorkStation.Text);
                p.setAddress(txtAddress.Text);
                p.setWorkArea(Int32.Parse(cmbArea.SelectedValue.ToString()));

                Program.service.addEmployee(p);

                lblError.Text = "Registrado";
            }
            loadEmployee();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            refMainForm.Show();
            this.Dispose();
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            lblState.Text = "Modificando";
            paneEmployee.Enabled = true;
            btnSave.Enabled = true;         
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Seguro que desea eliminar el personal seleccionado?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {
                return;
            }
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand("Delete from G08_Personal where IDPersonal = @IDPersonal", conn);

            comando.Parameters.AddWithValue("IDPersonal", dgvEmployee.CurrentRow.Cells["IDPersonal"].Value);  

            conn.Open();
            comando.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Cliente Borrado Correctactamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            loadEmployee();
        }

        private void PersonalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            refMainForm.Show();
            this.Dispose();
        }
        public void setEmployeeSearch(int id, string name, string lastname, string email, string date, string address, float salary, string workStation,int idarea, String dni)
        {
            lblState.Text = "Datos de Personal";
            lblIdEmployee.Text = ""+id;
            txtName.Text = name;
            txtLastName.Text = lastname;
            txtEmail.Text = email;
            txtDateHired.Text = date;
            txtAddress.Text = address;
            txtSalary.Text = ""+salary;
            txtWorkStation.Text = workStation;
            cmbArea.SelectedIndex = idarea;
            txtDNI.Text = dni;
            paneEmployee.Enabled = false;
            btnSave.Enabled = false;
            btnModify.Enabled = true;
        }

        private void dgvEmployee_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                lblIdEmployee.Text = dgvEmployee.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = dgvEmployee.CurrentRow.Cells[1].Value.ToString();
                txtLastName.Text = dgvEmployee.CurrentRow.Cells[2].Value.ToString();
                txtEmail.Text = dgvEmployee.CurrentRow.Cells[3].Value.ToString();
                txtDateHired.Text = dgvEmployee.CurrentRow.Cells[4].Value.ToString();
                txtAddress.Text = dgvEmployee.CurrentRow.Cells[5].Value.ToString();
                txtSalary.Text = dgvEmployee.CurrentRow.Cells[6].Value.ToString();
                txtWorkStation.Text = dgvEmployee.CurrentRow.Cells[7].Value.ToString();
                cmbArea.SelectedIndex = int.Parse(dgvEmployee.CurrentRow.Cells[8].Value.ToString()) -1;
                txtDNI.Text = dgvEmployee.CurrentRow.Cells[9].Value.ToString();
                paneEmployee.Enabled = false;
                btnSave.Enabled = false;
                btnModify.Enabled = true;
                lblError.Text = "";
                lblState.Text = "Datos de Personal";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }   
        }
    }
}
