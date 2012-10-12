using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Libreria;
using System.Data.SqlClient;
using System.Data;

namespace SalesService
{
    public class Service
    {
        private List<Product> products = new List<Product>();

        public void addClient(Client client)
        {
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = "user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30";

            try
            {
                conn.Open();

                string sqlString = "INSERT INTO G08_Cliente(IDCliente," + "Direccion, RazonSocial, Email, Telefono, EstadoCliente) " + "VALUES (@Param1, @Param2, @Param3, @Param4, @Param5, @Param6)";

                System.Data.SqlClient.SqlParameter myParam1 = new System.Data.SqlClient.SqlParameter("@Param1", System.Data.SqlDbType.Int);
                myParam1.Value = client.getIdCliente();


                System.Data.SqlClient.SqlParameter myParam2 = new System.Data.SqlClient.SqlParameter("@Param2", System.Data.SqlDbType.VarChar, 30);
                myParam2.Value = client.getDireccion();

                System.Data.SqlClient.SqlParameter myParam3 = new System.Data.SqlClient.SqlParameter("@Param3", System.Data.SqlDbType.VarChar, 20);
                myParam3.Value = client.getRazonSocial();

                System.Data.SqlClient.SqlParameter myParam4 = new System.Data.SqlClient.SqlParameter("@Param4", System.Data.SqlDbType.VarChar, 20);
                myParam4.Value = client.getCorreo();

                System.Data.SqlClient.SqlParameter myParam5 = new System.Data.SqlClient.SqlParameter("@Param5", System.Data.SqlDbType.VarChar, 15);
                myParam5.Value = client.getTelefono();

                System.Data.SqlClient.SqlParameter myParam6 = new System.Data.SqlClient.SqlParameter("@Param6", System.Data.SqlDbType.VarChar, 10);
                myParam6.Value = client.getEstadoCliente();

                System.Data.SqlClient.SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(sqlString, conn);

                myCommand.Parameters.Add(myParam1);
                myCommand.Parameters.Add(myParam2);
                myCommand.Parameters.Add(myParam3);
                myCommand.Parameters.Add(myParam4);
                myCommand.Parameters.Add(myParam5);
                myCommand.Parameters.Add(myParam6);
                //System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader();

                myCommand.ExecuteNonQuery();

                conn.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public List<Product> queryAll(String nombre)
        {
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = "user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30";

            try
            {
                conn.Open();

                string sqlString = "SELECT * FROM G08_Producto";

                System.Data.SqlClient.SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(sqlString, conn);

                System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader();

                while (reader.Read())
                {
                    String nombProd = reader.GetString(1);

                    if (nombProd.CompareTo(nombre) == 0)
                    {
                        Product pr = new Product();
                        pr.setCodigo(reader.GetInt32(0));
                        pr.setName(nombProd);
                        pr.setStockMax(reader.GetInt32(0));
                        pr.setPrecioVenta(reader.GetInt32(0));
                        pr.setPrecioCompra(reader.GetInt32(0));
                        pr.setStockMin(reader.GetInt32(0));
                        products.Add(pr);
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
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = "user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30";

            try
            {
                conn.Open();

                string sqlString = "INSERT INTO G08_Producto(IDProducto," + "NomProd, stockMax, PrecioVenta,  PrecioCompra, stockMin) " + "VALUES (@Param1, @Param2, @Param3, @Param4, @Param5, @Param6)";

                System.Data.SqlClient.SqlParameter myParam1 = new System.Data.SqlClient.SqlParameter("@Param1", System.Data.SqlDbType.Int);
                myParam1.Value = product.getCodigo();

                System.Data.SqlClient.SqlParameter myParam2 = new System.Data.SqlClient.SqlParameter("@Param2", System.Data.SqlDbType.VarChar, 20);
                myParam2.Value = product.getName();

                System.Data.SqlClient.SqlParameter myParam3 = new System.Data.SqlClient.SqlParameter("@Param3", System.Data.SqlDbType.Int);
                myParam3.Value = product.getStockMax();

                System.Data.SqlClient.SqlParameter myParam4 = new System.Data.SqlClient.SqlParameter("@Param4", System.Data.SqlDbType.Float);
                myParam4.Value = product.getPrecioVenta();

                System.Data.SqlClient.SqlParameter myParam5 = new System.Data.SqlClient.SqlParameter("@Param5", System.Data.SqlDbType.Float);
                myParam5.Value = product.getPrecioCompra();

                System.Data.SqlClient.SqlParameter myParam6 = new System.Data.SqlClient.SqlParameter("@Param6", System.Data.SqlDbType.Int);
                myParam6.Value = product.getStockMin();

                System.Data.SqlClient.SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(sqlString, conn);

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

        public void addPersonal(Personal personal)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30";

            try
            {
                conn.Open();

                string sqlString = "INSERT INTO G08_Personal(IDPersonal,"
                                   + "Nombres, Apellidos, Email, FechaContrato, Direccion, Sueldo, Puesto, IdArea,DNI) "
                                   + "VALUES (@Param1, @Param2, @Param3, @Param4, @Param5, @Param6, @Param7, @Param8, @Param9,@Param10)";

                SqlParameter myParam1 = new SqlParameter("@Param1", SqlDbType.Int);
                myParam1.Value = personal.GetID();

                SqlParameter myParam2 = new SqlParameter("@Param2", SqlDbType.VarChar, 20);
                myParam2.Value = personal.GetName();

                SqlParameter myParam3 = new SqlParameter("@Param3", SqlDbType.VarChar, 20);
                myParam3.Value = personal.GetLastname();

                SqlParameter myParam4 = new SqlParameter("@Param4", SqlDbType.VarChar, 20);
                myParam4.Value = personal.GetEmail();

                SqlParameter myParam5 = new SqlParameter("@Param5", SqlDbType.VarChar, 10);
                myParam5.Value = personal.getDateHired();

                SqlParameter myParam6 = new SqlParameter("@Param6", SqlDbType.VarChar, 30);
                myParam6.Value = personal.getAddress();

                SqlParameter myParam7 = new SqlParameter("@Param7", SqlDbType.Float);
                myParam7.Value = personal.GetSalary();

                SqlParameter myParam8 = new SqlParameter("@Param8", SqlDbType.VarChar, 20);
                myParam8.Value = personal.getWorkStation();

                SqlParameter myParam9 = new SqlParameter("@Param9", SqlDbType.Int);
                myParam9.Value = personal.getWorkArea();

                SqlParameter myParam10 = new SqlParameter("@Param10", SqlDbType.VarChar,10);
                myParam9.Value = personal.GetDni();

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
                //System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader();

                myCommand.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public int obtenerNuevoClientID()
        {
            int idLast = 0;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30";
            try
            {
                conn.Open();

                string sqlString = "SELECT * FROM G08_Cliente ORDER by IDCliente DESC";

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




        public int obtenerNuevoID()
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



        public DataSet GetCmbArea()
        {
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
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
    }
}
