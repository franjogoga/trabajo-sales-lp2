using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Libreria;


namespace SalesService
{
    public class Service
    {

        private List<Product> products = new List<Product>();


        public List<Product> queryAll(String nombre)
        
        {

            System.Data.SqlClient.SqlConnection conn =
                    new System.Data.SqlClient.SqlConnection();


            conn.ConnectionString = "user id=inf282;" +
                                "password=inf282db;" +
                                "server=inti.lab.inf.pucp.edu.pe;" +
                                "database=inf282; " +
                                "connection timeout=30";




            try
            {
                conn.Open();

                string sqlString = "SELECT * FROM G08_Producto";


                System.Data.SqlClient.SqlCommand myCommand =
                   new System.Data.SqlClient.SqlCommand(sqlString, conn);

                    System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader();


                    while (reader.Read())
                    {

                        String nombProd = reader.GetString(1);


                      //  if (clients[i]() == nombre) return clients[i];
                      // return null;


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


            System.Data.SqlClient.SqlConnection conn =
                       new System.Data.SqlClient.SqlConnection();


            conn.ConnectionString = "user id=inf282;" +
                                "password=inf282db;" +
                                "server=inti.lab.inf.pucp.edu.pe;" +
                                "database=inf282; " +
                                "connection timeout=30";
            
            
           
            try
            {
                conn.Open();

                string sqlString = "INSERT INTO G08_Producto(IDProducto," +
                               "NomProd, stockMax, PrecioVenta,  PrecioCompra, stockMin) " +
                               "VALUES (@Param1, @Param2, @Param3, @Param4, @Param5, @Param6)";



                System.Data.SqlClient.SqlParameter myParam1 =
                        new System.Data.SqlClient.SqlParameter(
                            "@Param1", System.Data.SqlDbType.Int);

                myParam1.Value = product.getCodigo();


                System.Data.SqlClient.SqlParameter myParam2 =
                        new System.Data.SqlClient.SqlParameter(
                            "@Param2", System.Data.SqlDbType.VarChar,20);

                myParam2.Value = product.getName();

                System.Data.SqlClient.SqlParameter myParam3 =
                        new System.Data.SqlClient.SqlParameter(
                            "@Param3", System.Data.SqlDbType.Int);
                
                myParam3.Value = product.getStockMin();

                System.Data.SqlClient.SqlParameter myParam4 =
                        new System.Data.SqlClient.SqlParameter(
                            "@Param4", System.Data.SqlDbType.Float);
                
                myParam4.Value = product.getStockMax();
                
                System.Data.SqlClient.SqlParameter myParam5 =
                       new System.Data.SqlClient.SqlParameter(
                           "@Param5", System.Data.SqlDbType.Float);
                myParam5.Value = product.getPrecioVenta();

                System.Data.SqlClient.SqlParameter myParam6 =
                        new System.Data.SqlClient.SqlParameter(
                            "@Param6", System.Data.SqlDbType.Int);
                myParam6.Value = product.getPrecioCompra();


                System.Data.SqlClient.SqlCommand myCommand =
                    new System.Data.SqlClient.SqlCommand(sqlString, conn);

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


    }

}

