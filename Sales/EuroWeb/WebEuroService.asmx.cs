using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Library;
using SalesService;

namespace EuroWeb
{
    /// <summary>
    /// Summary description for WebEuroService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebEuroService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int ValidarUsuario(string iduser,string pass)
        {
            int val = 0;
            User user = new User();
            user.setUser(iduser.ToUpper());
            user.setPassword(pass.ToUpper());
            user.makeConnection();
            if (user.validatePassword() == 1)
            {
                val = 1;
            }
            else
            {
                val = 0;
            }
            return val;
        }
         [WebMethod]
        public ClientWeb ObtnerClienteWeb(String idUser)
        {
            ClientWeb client = null;
            Service myservice = new Service();

            client = myservice.getClienteWeb(idUser.ToUpper());
            return client;
        }
    }
}
