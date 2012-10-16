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
        private SqlConnection conn = new SqlConnection("user id=inf282;"+"password=inf282db;"+"server=inti.lab.inf.pucp.edu.pe;"+"database=inf282; "+"connection timeout=30");

        public PersonalSearch()
        {
            InitializeComponent();
        }

        private void cargarPersonal(String name)
        {
            conn.Open();
            string stringSQL = "SELECT * FROM G08_Personal WHERE Nombres = @param1";

            SqlDataAdapter daPersonal = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(stringSQL, conn);
            daPersonal.SelectCommand = command;

            System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@Param1", System.Data.SqlDbType.VarChar, 20);
            param1.Value = name;

            command.Parameters.Add(param1);

            DataSet dset = new DataSet();

            daPersonal.Fill(dset, "G08_Personal");

            dataGridView1.DataSource = dset;

            dataGridView1.DataMember = "G08_Personal";            

            conn.Close();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            String name = txtNombre.Text;
            cargarPersonal(name);
        }   
    }   
}
