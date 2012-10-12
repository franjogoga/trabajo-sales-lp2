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
    public partial class ClientSearch : Form
    {
        System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

        public ClientSearch()
        {
            
           
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }


    }
}
