using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library;
using System.Data.SqlClient;
using System.Data;

namespace SalesService
{
    public class Service
    {
        private List<Product> products = new List<Product>();
        private List<string> userList = new List<string>();

        public int insertBuzon(Buzon b)
        {
            int result = 0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30";

            try
            {
                conn.Open();

                string sqlString = "INSERT INTO G08_Buzon(Nombre,Email,Tema) " + "VALUES (@Param1, @Param2, @Param3)";

                SqlParameter myParam1 = new SqlParameter("@Param1", System.Data.SqlDbType.VarChar, 50);
                myParam1.Value = b.getNombre();

                SqlParameter myParam2 = new SqlParameter("@Param2", System.Data.SqlDbType.VarChar, 50);
                myParam2.Value = b.getEmail();

                SqlParameter myParam3 = new SqlParameter("@Param3", System.Data.SqlDbType.VarChar, 30);
                myParam3.Value = b.getAsunto();

                SqlCommand myCommand = new SqlCommand(sqlString, conn);

                myCommand.Parameters.Add(myParam1);
                myCommand.Parameters.Add(myParam2);
                myCommand.Parameters.Add(myParam3);
                result = 1;
                myCommand.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }
        public SalesMan getVendedor(int idVendedor)
        {
            SalesMan vend = null;
            SqlConnection conn = new SqlConnection("user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30");
            try
            {
                conn.Open();
                String sqlString = "SELECT * " + "FROM G08_Vendedores " + "WHERE IDPersonal = @param1";
                SqlParameter myParam1 = new SqlParameter("@Param1", SqlDbType.Int);
                myParam1.Value = idVendedor;

                SqlCommand myCommand = new SqlCommand(sqlString, conn);

                myCommand.Parameters.Add(myParam1);

                SqlDataReader reader;
                reader = myCommand.ExecuteReader();
                reader.Read();
                int id = reader.GetInt32(0);
                String state = reader.GetString(1);

                vend = new SalesMan();
                vend.setEstado(state);
                vend.setIdVendedor(id);
            }
            catch (Exception ex)
            {
            }

            return vend;
        }
        public List<string> searchEmployeeByUser(string user)
        {
            SqlDataReader reader;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30";
            try
            {
                conn.Open();
                string sqlString = "select a.idpersonal, a.nombres, a.apellidos, b.nomarea, a.puesto "+ "from g08_personal as a, g08_area as b,g08_usuario as c " + "where c.IdUser = @param1 and a.Idpersonal = c.idPersonal and b.idarea = a.idarea";
                SqlParameter myparam1 = new SqlParameter("@param1", SqlDbType.VarChar, 100);
                myparam1.Value = user;
                
                SqlCommand mycommand = new SqlCommand(sqlString, conn);
                mycommand.Parameters.Add(myparam1);
                
                reader = mycommand.ExecuteReader();
                reader.Read();
                string name = reader.GetString(1);
                userList.Add(name);
                string area = reader.GetString(3);
                userList.Add(area);
                string workStation = reader.GetString(4);
                userList.Add(workStation);
                conn.Close();
                return userList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return userList;
        }
        public void addClient(Client client)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30";

            try
            {
                conn.Open();

                string sqlString = "INSERT INTO G08_Cliente(IDCliente," + "Direccion, RazonSocial, Email, Telefono, EstadoCliente) " + "VALUES (@Param1, @Param2, @Param3, @Param4, @Param5, @Param6)";

                SqlParameter myParam1 = new SqlParameter("@Param1", System.Data.SqlDbType.Int);
                myParam1.Value = client.getIdClient();

                SqlParameter myParam2 = new SqlParameter("@Param2", System.Data.SqlDbType.VarChar, 30);
                myParam2.Value = client.getAddress();

                SqlParameter myParam3 = new SqlParameter("@Param3", System.Data.SqlDbType.VarChar, 20);
                myParam3.Value = client.getBusinessName();

                SqlParameter myParam4 = new SqlParameter("@Param4", System.Data.SqlDbType.VarChar, 20);
                myParam4.Value = client.getEmail();

                SqlParameter myParam5 = new SqlParameter("@Param5", System.Data.SqlDbType.VarChar, 15);
                myParam5.Value = client.getTelephone();

                SqlParameter myParam6 = new SqlParameter("@Param6", System.Data.SqlDbType.VarChar, 10);
                myParam6.Value = client.getState();

                SqlCommand myCommand = new SqlCommand(sqlString, conn);

                myCommand.Parameters.Add(myParam1);
                myCommand.Parameters.Add(myParam2);
                myCommand.Parameters.Add(myParam3);
                myCommand.Parameters.Add(myParam4);
                myCommand.Parameters.Add(myParam5);
                myCommand.Parameters.Add(myParam6);                

                myCommand.ExecuteNonQuery();
                conn.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public List<Product> queryAll(string name)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30";
            try
            {
                conn.Open();
                string sqlString = "SELECT * FROM G08_Producto";
                SqlCommand myCommand = new SqlCommand(sqlString, conn);
                SqlDataReader reader = myCommand.ExecuteReader();
                
                while (reader.Read())
                {
                    string nombProd = reader.GetString(1);
                    if (nombProd.CompareTo(name) == 0)
                    {
                        Product prod = new Product();
                        prod.setId(reader.GetInt32(0));
                        prod.setName(nombProd);
                        prod.setStock(reader.GetInt32(0));
                        prod.setSalePrice(reader.GetInt32(0));
                        prod.setPurchasePrice(reader.GetInt32(0));
                        prod.setStockMin(reader.GetInt32(0));
                        products.Add(prod);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return products;
        }
        public void addProduct(Product product)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30";

            try
            {
                conn.Open();
                string sqlString = "INSERT INTO G08_Producto(IDProducto," + "NomProd, StocK, PrecioVenta,  PrecioCompra, stockMin) " + "VALUES (@Param1, @Param2, @Param3, @Param4, @Param5, @Param6)";

                SqlParameter myParam1 = new SqlParameter("@Param1", System.Data.SqlDbType.Int);
                myParam1.Value = product.getId();

                SqlParameter myParam2 = new SqlParameter("@Param2", System.Data.SqlDbType.VarChar, 20);
                myParam2.Value = product.getName();

                SqlParameter myParam3 = new SqlParameter("@Param3", System.Data.SqlDbType.Int);
                myParam3.Value = product.getStock();

                SqlParameter myParam4 = new SqlParameter("@Param4", System.Data.SqlDbType.Decimal);
                myParam4.Value = product.getSalePrice();

                SqlParameter myParam5 = new SqlParameter("@Param5", System.Data.SqlDbType.Decimal);
                myParam5.Value = product.getPurchasePrice();

                SqlParameter myParam6 = new SqlParameter("@Param6", System.Data.SqlDbType.Int);
                myParam6.Value = product.getStockMin();

                SqlCommand myCommand = new SqlCommand(sqlString, conn);

                myCommand.Parameters.Add(myParam1);
                myCommand.Parameters.Add(myParam2);
                myCommand.Parameters.Add(myParam3);
                myCommand.Parameters.Add(myParam4);
                myCommand.Parameters.Add(myParam5);
                myCommand.Parameters.Add(myParam6);

                myCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void addEmployee(Employee employee)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30";

            try
            {
                conn.Open();
                string sqlString = "INSERT INTO G08_Personal(IDPersonal,Nombres, Apellidos, Email, FechaContrato, Direccion, Sueldo, Puesto, IdArea,DNI) "
                                   + "VALUES (@Param1, @Param2, @Param3,  @Param4, @Param5, @Param6, @Param7, @Param8, @Param9,@Param10)";

                SqlParameter myParam1 = new SqlParameter("@Param1", System.Data.SqlDbType.Int);
                myParam1.Value = employee.getID();

                SqlParameter myParam2 = new SqlParameter("@Param2", System.Data.SqlDbType.VarChar, 20);
                myParam2.Value = employee.getName();

                SqlParameter myParam3 = new SqlParameter("@Param3", System.Data.SqlDbType.VarChar, 20);
                myParam3.Value = employee.getLastname();

                SqlParameter myParam4 = new SqlParameter("@Param4", System.Data.SqlDbType.VarChar, 20);
                myParam4.Value = employee.getEmail();

                SqlParameter myParam5 = new SqlParameter("@Param5", System.Data.SqlDbType.VarChar, 10);
                myParam5.Value = employee.getDateHired();

                SqlParameter myParam6 = new SqlParameter("@Param6", System.Data.SqlDbType.VarChar, 30);
                myParam6.Value = employee.getAddress();

                SqlParameter myParam7 = new SqlParameter("@Param7", System.Data.SqlDbType.Float);
                myParam7.Value = employee.getSalary();

                SqlParameter myParam8 = new SqlParameter("@Param8", System.Data.SqlDbType.VarChar, 20);
                myParam8.Value = employee.getWorkStation();

                SqlParameter myParam9 = new SqlParameter("@Param9", System.Data.SqlDbType.Int);
                myParam9.Value = employee.getWorkArea();

                SqlParameter myParam10 = new SqlParameter("@Param10", System.Data.SqlDbType.VarChar, 10);
                myParam10.Value = employee.getDni();

                SqlCommand myCommand = new SqlCommand(sqlString, conn);

                myCommand.Parameters.Add(myParam1);
                myCommand.Parameters.Add(myParam2);
                myCommand.Parameters.Add(myParam3);
                myCommand.Parameters.Add(myParam4);
                myCommand.Parameters.Add(myParam5);
                myCommand.Parameters.Add(myParam6);
                myCommand.Parameters.Add(myParam7);
                myCommand.Parameters.Add(myParam8);
                myCommand.Parameters.Add(myParam9);
                myCommand.Parameters.Add(myParam10);                

                myCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public int getNewIdClient()
        {
            int idLast = 0;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30";
            try
            {
                conn.Open();
                string sqlString = "SELECT * FROM G08_Cliente ORDER by IDCliente DESC";

                SqlCommand myCommand = new SqlCommand(sqlString, conn);
                SqlDataReader reader;

                reader = myCommand.ExecuteReader();
                reader.Read();
                idLast = reader.GetInt32(0);

                conn.Close();
                return idLast;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return idLast;
        }
        public int getNewSaleId()
        {
            int idLast = 0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30";
            try
            {
                conn.Open();

                string sqlString = "SELECT * FROM G08_VENTAS ORDER by IDVENTAS DESC";
                SqlCommand myCommand = new SqlCommand(sqlString, conn);
                SqlDataReader reader;
                reader = myCommand.ExecuteReader();
                reader.Read();
                idLast = reader.GetInt32(0);
                conn.Close();
                return idLast;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return idLast;
        }
        public int getNewEmployeeId()
        {
            int idLast=0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30";
            try
            {
                conn.Open();

                string sqlString = "SELECT * FROM G08_PERSONAL ORDER by IDPERSONAL DESC";
                SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(sqlString, conn);            
                SqlDataReader reader;
                reader = myCommand.ExecuteReader();
                reader.Read();
                idLast = reader.GetInt32(0);
                conn.Close();
                return idLast;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return idLast;
        }
        public DataSet getCmbState()
        {
            DataSet dsState = new DataSet();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30";
            try
            {
                conn.Open();

                string sqlString = "SELECT * FROM G08_EstadoVenta";
                SqlDataAdapter daEstado = new SqlDataAdapter(sqlString, conn);
                dsState = new DataSet("EstadoVenta");
                daEstado.Fill(dsState, "EstadoVenta");
                conn.Close();
                return dsState;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return dsState;
        }
        public DataSet getCmbDocType()
        {
            DataSet dsDocType = new DataSet();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30";
            try
            {
                conn.Open();

                string sqlString = "SELECT * FROM G08_TIPODOC";
                SqlDataAdapter daDocType = new SqlDataAdapter(sqlString, conn);
                DataSet dsDocType1 = new DataSet("TIPODOC");
                daDocType.Fill(dsDocType, "TIPODOC");
                conn.Close();
                return dsDocType;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return dsDocType;
        }
        public DataSet getCmbArea()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30";
            DataSet dsArea2 = new DataSet();
            try
            {
                conn.Open();

                string sqlString = "SELECT * FROM G08_Area";
                SqlDataAdapter daArea = new SqlDataAdapter(sqlString, conn);
                DataSet dsArea = new DataSet("Area");
                daArea.Fill(dsArea,"Area");
                conn.Close();
                return dsArea;                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return dsArea2;
        }
        public ClientWeb getClienteWeb(String nomClient)
        {
            ClientWeb aux = null;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30";
            try
            {
                conn.Open();
                string sqlString = "SELECT * FROM G08_ClienteWeb WHERE NOMBRE = @Param";
                 SqlCommand myCommand = new SqlCommand(sqlString, conn);
                SqlParameter myparam = new SqlParameter("@Param", SqlDbType.Char, 50);
                myparam.Value = nomClient;
                myCommand.Parameters.Add(myparam);

                SqlDataReader reader = myCommand.ExecuteReader();
                
                while (reader.Read())
                {
                    aux = new ClientWeb();
                    aux.setNombre(reader.GetString(0));
                    aux.setContraseña(reader.GetString(1));
                    aux.setDireccion(reader.GetString(3));
                    aux.setEmail(reader.GetString(2));
                    aux.setPais(reader.GetString(4));
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            return aux;
        }
        public Product getProducto(int idProd)
        {
            Product p = null;
            SqlConnection conn = new SqlConnection("user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30");
            try
            {
                conn.Open();
                String sqlString = "SELECT * " + "FROM G08_Producto " + "WHERE IDPRODUCTO = @Param1";
                SqlParameter myParam1 = new SqlParameter("@Param1", SqlDbType.Int);
                myParam1.Value = idProd;

                SqlCommand myCommand = new SqlCommand(sqlString, conn);

                myCommand.Parameters.Add(myParam1);

                SqlDataReader reader;
                reader = myCommand.ExecuteReader();
                reader.Read();
                int id = reader.GetInt32(0);
                String nomProd = reader.GetString(1);
                int stock = reader.GetInt32(2);
                //float pVenta = reader.GetFloat(3);
                //float pCompra = reader.GetFloat(4);
                int stockMin = reader.GetInt32(5);

                p = new Product();
                p.setId(id);
                p.setName(nomProd);
                p.setStock(stock);
                p.setStockMin(stockMin);
                //p.setSalePrice(pVenta);
                //p.setPurchasePrice(pCompra);
            }
            catch (Exception ex)
            {
            }

            return p;
        }
        public User getUsuario(String idUser)
        {
            User usuario = null;
            SqlConnection conn = new SqlConnection("user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30");
            try
            {
                conn.Open();
                String sqlString = "SELECT * " + "FROM G08_USUARIO " + "WHERE IDUSER = @param1";
                SqlParameter myParam1 = new SqlParameter("@Param1", SqlDbType.VarChar, 20);
                myParam1.Value = idUser;

                SqlCommand myCommand = new SqlCommand(sqlString, conn);

                myCommand.Parameters.Add(myParam1);

                SqlDataReader reader;
                reader = myCommand.ExecuteReader();

                reader.Read();
                String userBD = reader.GetString(0);
                String passBD = reader.GetString(1);
                usuario = new User();
                usuario.setUser(userBD);
                usuario.setPassword(passBD);
            }
            catch (Exception)
            {
            } 
            return usuario;
        }
        public int obtenerStock(String nomProducto)
        {
            Product aux = null;
            int valor = 0;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30";
            try
            {
                conn.Open();
                string sqlString = "SELECT * FROM G08_Producto WHERE NomProd=@Param";

                SqlCommand myCommand = new SqlCommand(sqlString, conn);
                SqlParameter myparam = new SqlParameter("@Param", SqlDbType.VarChar,20);

                myparam.Value = nomProducto;
                myCommand.Parameters.Add(myparam);

                SqlDataReader reader = myCommand.ExecuteReader();

                while (reader.Read())
                {
                    aux = new Product();
                    aux.setId(reader.GetInt32(0));
                    aux.setName(reader.GetString(1));
                    aux.setStock(reader.GetInt32(2));

                    if ((aux != null) && (aux.getStock()>0))
                    { valor = 1; }
                }

                
               
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return valor;
        }
        public Sale getSale(int idSale)
        {
            Sale sale = null;
            SqlConnection conn = new SqlConnection("user id=inf282;"+"password=inf282db;"+"server=inti.lab.inf.pucp.edu.pe;"+"database=inf282; "+"connection timeout=30");
            try
            {
                conn.Open();
                String sqlString = "SELECT G08_Ventas.IDVentas, G08_Ventas.Fecha, G08_Ventas.SubTotal, G08_Ventas.IGV, G08_Ventas.Total, G08_EstadoVenta.Descripcion, "+
                    "G08_TipoDoc.NomDoc, G08_Cliente.RazonSocial FROM G08_Ventas, G08_EstadoVenta, G08_Cliente, G08_TipoDoc "+
                    "WHERE G08_Ventas.IDVentas = @idVentas AND G08_Ventas.IDTipoDoc = G08_TipoDoc.IDTipoDoc AND G08_Ventas.IDCliente = G08_Cliente.IDCliente "+
                    "AND G08_Ventas.IDEstado = G08_EstadoVenta.IDEstado";
                SqlParameter id = new SqlParameter("@idVentas", SqlDbType.Int);
                id.Value = idSale;                

                SqlCommand command = new SqlCommand(sqlString, conn);

                command.Parameters.Add(id);

                SqlDataReader reader = command.ExecuteReader();
                sale = new Sale();
                reader.Read();
                sale.setId(idSale);
                sale.setDate(reader.GetDateTime(1));
                sale.setSubTotal(reader.GetFloat(2));
                sale.setIgv(reader.GetFloat(3));
                sale.setTotal(reader.GetFloat(4));
                sale.setState(reader.GetString(5));
                sale.setTypeDoc(reader.GetString(6));
                sale.setClient(reader.GetString(7));
                reader.Close();                
                                             
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return sale;
        }
    }
}
