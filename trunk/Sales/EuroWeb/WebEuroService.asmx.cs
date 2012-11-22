using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Library;
using SalesService;
using System.Xml.Serialization;

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
        public int ValidarClienteWeb(String iduser, String pass)
        {
            int val = 0;
            ClientWeb client = new ClientWeb();
            Service myservice = new Service();

            client = myservice.getClienteWeb(iduser.ToUpper());
            pass = pass.ToUpper();
            if (client.getContraseña().Equals(pass))
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
        public XmlSerializer ObtnerClienteWeb(String idUser)
        {
            ClientWeb client = null;
            Service myservice = new Service();
            client = myservice.getClienteWeb(idUser.ToUpper());
            XmlSerializer x = new XmlSerializer(client.GetType());
            x.Serialize(Console.Out, client);
            Console.WriteLine();
            Console.ReadLine();
            return x;
        }
         [WebMethod]
         public String Ingresar_Consulta(String name, String email, String subject)
         {
             String cad1 = "Consulta y/o sugerencia agregada con Exito";
             String cad2 = "No se pudo ingresar su consulta y/o sugerencia";
             int valor = 0;
             if ((name != "") && (email != "") && (subject != ""))
             {
                 Service myService = new Service();
                 Buzon buz = new Buzon();
                 buz.setNombre(name);
                 buz.setEmail(email);
                 buz.setAsunto(subject);

                 valor = myService.insertBuzon(buz);

             }

             if (valor > 0)
             {
                 return cad1;
             }
             else
             {
                 return cad2;
             }
         }

         [WebMethod]
         public XmlSerializer ObtenerUsuario(String idUser)
         {
             User usuario = new User();
             Service myservice = new Service();
             usuario = myservice.getUsuario(idUser);
             XmlSerializer x = new XmlSerializer(usuario.GetType());
             x.Serialize(Console.Out,usuario);
             Console.WriteLine();
             Console.ReadLine();
             return x;
         }
         [WebMethod]
         public String ConsultarStock(String nomProd)
         {
             String cad1 = "Si hay stock del producto";
             String cad2 = "No hay productos";
             int valor = 0;

             Service myService = new Service();
             valor = myService.obtenerStock(nomProd);

             if (valor > 0)
             {
                 return cad1;
             }
             else
             {
                 return cad2;
             }
         }
    }
}
