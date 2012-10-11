using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Libreria
{
    public class Personal
    {
        private int iDPersonal;
        private String name;
        private String lastname;
        private String address;
        private String email;
        private String dni;
        private String dateHired; //ojo falta corregir esto, deberia ser tipo datetime pero no se sabe como se castea
        private float salary;
        private int workArea; //area de trabajo
        private String workStation;//puesto de trabajo

        //Data Source=KEVIN-VAIO\\SQLEXPRESS;Initial Catalog=EuroBD;Integrated Security=True

        public Personal()
        {
        }
        public Personal(int iD, String nam, String last, String add, String ema, String date, float sal)
        {
            iDPersonal = iD;
            name = nam;
            lastname = last;
            address = add;
            dateHired = date;
            salary = sal;
        }
        public void SetDNI(string strdni)
        {
            dni = strdni;
        }
        public String GetDni()
        {
            return dni;
        }
        public String getWorkStation()
        {
            return workStation;
        }
        public void setWorkStation(String cad)
        {
            workStation = cad;
        }
        public void setWorkArea(int numero)
        {
            workArea = numero;
        }
        public int getWorkArea()
        {
            return workArea;
        }
        public void SetSalary(float sal)
        {
            salary = sal;
        }
        public float GetSalary()
        {
            return salary;
        }
        public void SetID(int iD)
        {
            iDPersonal = iD;
        }
        public int GetID()
        {
            return iDPersonal;
        }
        public void SetName(String name)
        {
            this.name = name;
        }
        public String GetName()
        {
            return name;
        }
        public void SetLastName(String lastName)
        {
            lastname = lastName;
        }
        public String GetLastname()
        {
            return lastname;
        }
        public void SetEmail(String eMail)
        {
            email = eMail;
        }
        public String GetEmail()
        {
            return email;
        }
        public void setDateHired(String date)
        {
            dateHired = date;
        }
        public String getDateHired()
        {
            return dateHired;
        }
        public String getAddress()
        {
            return address;
        }
        public void setAddress(String dir)
        {
            address = dir;
        }


    }

    public class User
    {
        private String idUser;
        private String password;
        private int idPersonal;
        private SqlConnection con;

        public void HacerConexion()
        {
            con = new SqlConnection("user id=inf282;"+"password=inf282db;"+"server=inti.lab.inf.pucp.edu.pe;"+"database=inf282; "+"connection timeout=30");
        }
        public int ValidarPassword()
        {
            int flag;
            try
            {
                con.Open();
                String sqlString = "SELECT * " +"FROM G08_USUARIO " +"WHERE IDUSER = @param1 and CLAVE = @param2";
                
                SqlParameter myParam1 = new SqlParameter("@Param1", SqlDbType.VarChar, 20);
                myParam1.Value = idUser;
                
                SqlParameter myParam2 = new SqlParameter("@Param2", SqlDbType.VarChar, 20);
                myParam2.Value = password;
                
                SqlCommand myCommand = new SqlCommand(sqlString, con);
                
                myCommand.Parameters.Add(myParam1);
                myCommand.Parameters.Add(myParam2);

                SqlDataReader reader;
                reader = myCommand.ExecuteReader();
                
                reader.Read();
                String userBD = reader.GetString(0);
                String passBD = reader.GetString(1);
                
                if (idUser.Equals(userBD) && password.Equals(passBD))
                {
                    flag = 1;
                    idPersonal = reader.GetInt32(2);
                }
                else
                {
                    flag = 0;
                }

            }
            catch (Exception)
            {
                flag = 0;
                //throw; esto no funca, no se debe hacer
            }
            return flag;
        }

        public void SetUser(string user)
        {
            idUser = user;
        }
        public string GetUser()
        {
            return idUser;
        }

        public void SetPassword(string pass)
        {
            password = pass;
        }
        public string GetPassword()
        {
            return password;
        }
    }

    public class Product
    {

        private int idProduct;
        private String name;
        private int stockMin;   //la cantidad minimo que tiene que tener la empresa
        private int stockMax;   //la cantidad maxima que debe tener la empresa 
        float PrecioCompra;
        float PrecioVenta;

        public Product()
        {
            idProduct = 0;
            name = "";
            this.stockMin = 0;
            this.stockMax = 0;
            PrecioCompra = 0f;
            PrecioVenta = 0f;

        }

        public Product(int codigo, String nombre, int stockMin, int stockMax, float PrecioCompra, float PrecioVenta)
        {
            idProduct = codigo;
            name = nombre;
            this.stockMin = stockMin;
            this.stockMax = stockMax;
            PrecioCompra = 0f;
            PrecioVenta = 0f;

        }
        public int getCodigo()
        {
            return idProduct;
        }
        public void setCodigo(int codigo)
        {
            idProduct = codigo;
        }
        public String getName()
        {
            return name;
        }
        public void setName(String nombre)
        {
            name = nombre;
        }

        public int getStockMin()
        {
            return stockMin;
        }
        public void setStockMin(int stockMin)
        {
            this.stockMin = stockMin;
        }
        public int getStockMax()
        {
            return stockMax;
        }
        public void setStockMax(int stockMax)
        {
            this.stockMax = stockMax;
        }


        public float getPrecioCompra()
        {
            return PrecioCompra;
        }
        public void setPrecioCompra(float pCompra)
        {
            this.PrecioCompra = pCompra;
        }


        public float getPrecioVenta()
        {
            return PrecioVenta;
        }
        public void setPrecioVenta(float pVenta)
        {
            this.PrecioVenta = pVenta;
        }

    }

    public class Client
    {

        private int IdClient;
        private String Address;
        private String EstadoCliente;  //estado del cliente
        private String Email;
        private String Telephone;
        private String businessName; //Razon Social

        public Client()
        {
            IdClient = 0;
            Address = "";
            EstadoCliente = "";
            Email = "";
            Telephone = "";
            businessName = "";
        }

        public Client(int idCliente, String direccion, String estadoCliente, String correo, String telefono, String razonSocial)
        {

            IdClient = idCliente;
            Address = direccion;
            EstadoCliente = estadoCliente;
            Email = correo;
            Telephone = telefono;
            businessName = razonSocial;
        }


        public String getRazonSocial()
        {
            return this.businessName;
        }

        public int getIdCliente()
        {
            return IdClient;
        }
        public void setIdCliente(int idCliente)
        {
            IdClient = idCliente;
        }

        public String getDireccion()
        {
            return Address;
        }
        public void setDireccion(String direccion)
        {
            Address = direccion;
        }
        public String getEstadoCliente()
        {
            return EstadoCliente;
        }


        public void setEstadoCliente(String estadoCliente)
        {
            EstadoCliente = estadoCliente;
        }
        public String getCorreo()
        {
            return Email;
        }
        public void setCorreo(String correo)
        {
            Email = correo;
        }
        public String getTelefono()
        {
            return Telephone;
        }
        public void setTelefono(String telefono)
        {
            Telephone = telefono;
        }

        public void setRazonSocial(String RazonSocial)
        {
            this.businessName = RazonSocial;
        }
    }
}

   
