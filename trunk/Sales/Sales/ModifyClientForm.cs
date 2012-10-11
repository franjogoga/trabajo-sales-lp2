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
    public partial class ModifyClientForm : Form
    {
        public ModifyClientForm()
        {
            InitializeComponent();
        }
        System.Data.SqlClient.SqlConnection conn =
             new System.Data.SqlClient.SqlConnection();

        public String nc_cliente_seleccionado;

        private void ModifyClientForm_Load(object sender, EventArgs e)
        {
            
            carga_datos();
        }

        void carga_datos() {

         
            conn.ConnectionString = "user id=inf282;" +
                                       "password=inf282db;" +
                                       "server=inti.lab.inf.pucp.edu.pe;" +
                                       "database=inf282; " +
                                       "connection timeout=30";

            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand("Select * FROM G08_Cliente",conn);

            conn.Open();

            System.Data.SqlClient.SqlDataReader leer = comando.ExecuteReader();

            if(leer.Read()){

                txtID.Text = (leer.GetInt32(0)).ToString();
                txtDireccion.Text = leer.GetString(1);
                txtRazonSocial.Text = leer.GetString(2);
                txtEmail.Text = leer.GetString(3);
                txtTelefono.Text = leer.GetString(4);
                txtEstado.Text = leer.GetString(5);            
            }
            conn.Close();
        }

       
    }
}
