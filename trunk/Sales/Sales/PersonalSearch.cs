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
    public partial class PersonalSearch : Form
    {

        private SqlConnection conn = new SqlConnection("user id=inf282;" +
                                "password=inf282db;" +
                                "server=inti.lab.inf.pucp.edu.pe;" +
                                "database=inf282; " +
                                "connection timeout=30");
        public PersonalSearch()
        {
            InitializeComponent();
        }

        private void cargarPersonal(String name)
        {
            try
            {
                conn.Open();

                string stringSQL = "SELECT * FROM G08_Personal WHERE Nombres like "+"'%"+txtName.Text+"%'";
                SqlDataAdapter daPersonal = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(stringSQL, conn);
                daPersonal.SelectCommand = command;
                System.Data.SqlClient.SqlParameter param1 =
                           new System.Data.SqlClient.SqlParameter("@Param1", System.Data.SqlDbType.VarChar, 20);
                param1.Value = name;
                command.Parameters.Add(param1);

                DataSet dset = new DataSet();

                daPersonal.Fill(dset, "G08_Personal");
                dataGridView1.DataSource = dset;
                dataGridView1.DataMember = "G08_Personal";

                //MessageBox.Show("Busqueda Correcta");

                conn.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            cargarPersonal(name);
        }
        private void PersonalSearch_Load(object sender, EventArgs e)
        {

        }
        private PersonalForm RefpForm = null;
        public void SetRefPersonal(PersonalForm pform)
        {
            RefpForm = pform;
        }
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Id = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                String Name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                String lastname = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                String email = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                String fecha = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                String direccion = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                float sueldo = float.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString());
                String puesto = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                int idarea = int.Parse(dataGridView1.CurrentRow.Cells[8].Value.ToString()) - 1;
                String dni = dataGridView1.CurrentRow.Cells[9].Value.ToString();

                RefpForm.SetPersonalSearch(Id, Name, lastname, email, fecha, direccion, sueldo, puesto, idarea, dni);
                this.Dispose();
            }
            catch (Exception)
            {
                throw;
            }   
        }
    }
}
