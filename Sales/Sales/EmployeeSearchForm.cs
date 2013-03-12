using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sales
{
    public partial class EmployeeSearchForm : Form
    {
        private SqlConnection conn = new SqlConnection("user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;"+"database=inf282; "+"connection timeout=30");
        public EmployeeSearchForm()
        {
            InitializeComponent();
        }

        private void loadEmployee(string name)
        {
            try
            {
                conn.Open();

                string stringSQL = "SELECT * FROM G08_Personal WHERE Nombres like "+"'%"+txtName.Text+"%'";
                SqlDataAdapter daEmployee = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(stringSQL, conn);
                daEmployee.SelectCommand = command;
                SqlParameter param1 = new SqlParameter("@Param1", SqlDbType.VarChar, 20);
                param1.Value = name;
                command.Parameters.Add(param1);

                DataSet dset = new DataSet();

                daEmployee.Fill(dset, "G08_Personal");
                dgvEmployeeSearch.DataSource = dset;
                dgvEmployeeSearch.DataMember = "G08_Personal";               

                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString()); 
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            loadEmployee(name);
        }        
        private EmployeeForm RefpForm = null;

        public void SetRefPersonal(EmployeeForm pform)
        {
            RefpForm = pform;
        }

        private void dgvEmployeeSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Id = Int32.Parse(dgvEmployeeSearch.CurrentRow.Cells[0].Value.ToString());
                String Name = dgvEmployeeSearch.CurrentRow.Cells[1].Value.ToString();
                String lastname = dgvEmployeeSearch.CurrentRow.Cells[2].Value.ToString();
                String email = dgvEmployeeSearch.CurrentRow.Cells[3].Value.ToString();
                String fecha = dgvEmployeeSearch.CurrentRow.Cells[4].Value.ToString();
                String direccion = dgvEmployeeSearch.CurrentRow.Cells[5].Value.ToString();
                float sueldo = float.Parse(dgvEmployeeSearch.CurrentRow.Cells[6].Value.ToString());
                String puesto = dgvEmployeeSearch.CurrentRow.Cells[7].Value.ToString();
                int idarea = int.Parse(dgvEmployeeSearch.CurrentRow.Cells[8].Value.ToString()) - 1;
                String dni = dgvEmployeeSearch.CurrentRow.Cells[9].Value.ToString();

                RefpForm.setEmployeeSearch(Id, Name, lastname, email, fecha, direccion, sueldo, puesto, idarea, dni);
                this.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }   
        }
    }
}