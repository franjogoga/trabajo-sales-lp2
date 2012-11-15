using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EuroWeb.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }


        protected void LoginButton_Click(object sender, EventArgs e)
        {
            localhost.WebEuroService webService = new localhost.WebEuroService();
          
            String iduser = LoginUser.UserName;
            String pass = LoginUser.Password;
            int val = webService.ValidarUsuario(iduser,pass);

            if (val == 1)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
              
            }
        }

        protected void LoginButton_Command(object sender, CommandEventArgs e)
        {

        }
    }
}
