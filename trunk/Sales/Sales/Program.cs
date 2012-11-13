using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SalesService;

namespace Sales
{
    static class Program
    {               
        public static Service service = new Service();

        static void Main(string[] args)       
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
