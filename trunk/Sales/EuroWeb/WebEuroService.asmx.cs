using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Library;
using SalesService;
using System.Xml.Serialization;
using System.Data.SqlClient;
using System.Data;

namespace EuroWeb
{
    [Serializable]
    public class SaleWeb
    {
        public int id;
        public DateTime date;
        public float subTotal;
        public float igv;
        public float total;
        public string state;
        public string typeDoc;
        public string client;
    }
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
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int ValidarUsuario(string iduser, string pass)
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
        public XmlSerializer ObtnerClienteWeb(String idUser)
        {
            ClientWeb client = null;
            Service myservice = new Service();
            XmlSerializer x = null;
            client = myservice.getClienteWeb(idUser.ToUpper());
            if (client != null)
            {
                x = new XmlSerializer(client.GetType());
                x.Serialize(Console.Out, client);
            }

            Console.WriteLine();
            Console.ReadLine();
            return x;
        }
        [WebMethod]
        public String SObtnerClienteWeb(String idUser)
        {
            ClientWeb client = null;
            Service myservice = new Service();
            XmlSerializer x = null;
            client = myservice.getClienteWeb(idUser.ToUpper());
            if (client != null)
            {
                x = new XmlSerializer(client.GetType());
                x.Serialize(Console.Out, client);
            }
            else
                return "Serializacion = " + 0;
            Console.WriteLine();
            Console.ReadLine();
            return "Serializacion = " + client.getNombre();
        }
        [WebMethod]
        public XmlSerializer ObtenerProducto(int idProd)
        {
            XmlSerializer x = null;
            Product prod = new Product();
            Service myservice = new Service();
            prod = myservice.getProducto(idProd);
            if (prod != null)
            {
                x = new XmlSerializer(prod.GetType());
                x.Serialize(Console.Out, prod);
            }
            Console.WriteLine();
            Console.ReadLine();
            return x;
        }
        [WebMethod]
        public String SObtenerProducto(int idProd)
        {
            XmlSerializer x = null;
            Product prod = new Product();
            Service myservice = new Service();
            prod = myservice.getProducto(idProd);
            if (prod != null)
            {
                x = new XmlSerializer(prod.GetType());
                x.Serialize(Console.Out, prod);
            }
            else
                return "Serializacion = " + 0;
            Console.WriteLine();
            Console.ReadLine();
            return "Serializacion = " + prod.getName();

        }
        [WebMethod]
        public XmlSerializer ObtenerUsuario(String idUser)
        {
            User usuario = new User();
            Service myservice = new Service();
            XmlSerializer x = null;
            usuario = myservice.getUsuario(idUser);
            if (usuario != null)
            {
                x = new XmlSerializer(usuario.GetType());
                x.Serialize(Console.Out, usuario);
            }

            Console.WriteLine();
            Console.ReadLine();
            return x;
        }
        [WebMethod]
        public String SObtenerUsuario(String idUser)
        {
            User usuario = new User();
            Service myservice = new Service();
            XmlSerializer x = null;
            usuario = myservice.getUsuario(idUser);
            if (usuario != null)
            {
                x = new XmlSerializer(usuario.GetType());
                x.Serialize(Console.Out, usuario);
            }
            else
                return "Serializacion = " + 0;

            Console.WriteLine();
            Console.ReadLine();
            return "Serializacion = " + usuario.getUser();
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
        [WebMethod]
        public XmlSerializer ObtenerCalificacionVendedor(int idVendedor)
        {
            XmlSerializer x = null;
            SalesMan seller = new SalesMan();
            Service myservice = new Service();
            seller = myservice.getVendedor(idVendedor);
            if (seller != null)
            {
                x = new XmlSerializer(seller.GetType());
                x.Serialize(Console.Out, seller);
            }
            Console.WriteLine();
            Console.ReadLine();
            return x;
        }
        [WebMethod]
        public String SObtenerCalificacionVendedor(int idVendedor)
        {
            SalesMan seller = new SalesMan();
            Service myservice = new Service();
            XmlSerializer x = null;
            seller = myservice.getVendedor(idVendedor);
            if (seller != null)
            {
                x = new XmlSerializer(seller.GetType());
                x.Serialize(Console.Out, seller);
            }
            else
                return "Serializacion = " + 0;
            Console.WriteLine();
            Console.ReadLine();
            return "Serializacion = " + seller.getEstado();
        }

        [WebMethod]
        public SaleWeb obtenerVenta(int idVenta)
        {
            Service service = new Service();
            Sale sale = service.getSale(idVenta);

            SaleWeb saleWeb = new SaleWeb();
            saleWeb.id = idVenta;
            saleWeb.date = sale.getDate();
            saleWeb.subTotal = sale.getSubTotal();
            saleWeb.total = sale.getTotal();
            saleWeb.igv = sale.getIgv();
            saleWeb.state = sale.getState();
            saleWeb.typeDoc = sale.getTypeDoc();
            saleWeb.client = sale.getClient();
            return saleWeb;
        }
    }
}
