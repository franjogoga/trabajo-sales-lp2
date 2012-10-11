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
                myParam3.Value = product.getStockMin();

                System.Data.SqlClient.SqlParameter myParam4 = new System.Data.SqlClient.SqlParameter("@Param4", System.Data.SqlDbType.Float);
                myParam4.Value = product.getStockMax();

                System.Data.SqlClient.SqlParameter myParam5 = new System.Data.SqlClient.SqlParameter("@Param5", System.Data.SqlDbType.Float);
                myParam5.Value = product.getPrecioVenta();

                System.Data.SqlClient.SqlParameter myParam6 = new System.Data.SqlClient.SqlParameter("@Param6", System.Data.SqlDbType.Int);
                myParam6.Value = product.getPrecioCompra();

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
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = "user id=inf282;" + "password=inf282db;" + "server=inti.lab.inf.pucp.edu.pe;" + "database=inf282; " + "connection timeout=30";

            try
            {
                conn.Open();

                string sqlString = "INSERT INTO G08_Personal(IDPersonal," + "Nombres, Apellidos, Email, FechaContrato, Direccion, Sueldo, Puesto, IdArea) " + "VALUES (@Param1, @Param2, @Param3, @Param4, @Param5, @Param6, @Param7, @Param8, @Param9)";

                System.Data.SqlClient.SqlParameter myParam1 = new System.Data.SqlClient.SqlParameter("@Param1", System.Data.SqlDbType.Int);
                myParam1.Value = personal.GetID();

                System.Data.SqlClient.SqlParameter myParam2 = new System.Data.SqlClient.SqlParameter("@Param2", System.Data.SqlDbType.VarChar, 20);
                myParam2.Value = personal.GetName();

                System.Data.SqlClient.SqlParameter myParam3 = new System.Data.SqlClient.SqlParameter("@Param3", System.Data.SqlDbType.VarChar, 20);
                myParam3.Value = personal.GetLastname();

                System.Data.SqlClient.SqlParameter myParam4 = new System.Data.SqlClient.SqlParameter("@Param4", System.Data.SqlDbType.VarChar, 20);
                myParam4.Value = personal.GetEmail();

                System.Data.SqlClient.SqlParameter myParam5 = new System.Data.SqlClient.SqlParameter("@Param5", System.Data.SqlDbType.VarChar, 10);
                myParam5.Value = personal.getDateHired();

                System.Data.SqlClient.SqlParameter myParam6 = new System.Data.SqlClient.SqlParameter("@Param6", System.Data.SqlDbType.VarChar, 30);
                myParam6.Value = personal.getAddress();

                System.Data.SqlClient.SqlParameter myParam7 = new System.Data.SqlClient.SqlParameter("@Param7", System.Data.SqlDbType.Float);
                myParam7.Value = personal.GetSalary();

                System.Data.SqlClient.SqlParameter myParam8 = new System.Data.SqlClient.SqlParameter("@Param8", System.Data.SqlDbType.VarChar, 20);
                myParam8.Value = personal.getWorkStation();

                System.Data.SqlClient.SqlParameter myParam9 = new System.Data.SqlClient.SqlParameter("@Param9", System.Data.SqlDbType.Int);
                myParam9.Value = personal.getWorkArea();

                System.Data.SqlClient.SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(sqlString, conn);

                myCommand.Parameters.Add(myParam1);
                myCommand.Parameters.Add(myParam2);
                myCommand.Parameters.Add(myParam3);
                myCommand.Parameters.Add(myParam4);
                myCommand.Parameters.Add(myParam5);
                myCommand.Parameters.Add(myParam6);
                myCommand.Parameters.Add(myParam7);
                myCommand.Parameters.Add(myParam8);
                myCommand.Parameters.Add(myParam9);
                //System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader();

                myCommand.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
