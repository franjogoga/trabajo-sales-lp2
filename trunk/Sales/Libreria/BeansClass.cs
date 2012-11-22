using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Library
{
    [Serializable]
    public class Sale
    {
        private int id;
        private DateTime date;
        private float subTotal;
        private float igv;
        private float total;
        private string state;
        private string typeDoc;
        private string client;

        public int getId()
        {
            return id;
        }
        public void setId(int id)
        {
            this.id = id;
        }
        public DateTime getDate()
        {
            return date;
        }
        public void setDate(DateTime date)
        {
            this.date = date;
        }
        public float getSubTotal()
        {
            return subTotal;
        }
        public void setSubTotal(float subTotal)
        {
            this.subTotal = subTotal;
        }
        public float getIgv()
        {
            return igv;
        }
        public void setIgv(float igv)
        {
            this.igv = igv;
        }
        public float getTotal()
        {
            return total;
        }
        public void setTotal(float total)
        {
            this.total = total;
        }
        public string getState()
        {
            return state;
        }
        public void setState(string state)
        {
            this.state = state;
        }
        public string getTypeDoc()
        {
            return typeDoc;
        }
        public void setTypeDoc(string typeDoc)
        {
            this.typeDoc = typeDoc;
        }
        public string getClient()
        {
            return client;
        }
        public void setClient(string client)
        {
            this.client = client;
        }
    }
    public class Buzon
    {
        private String nombre;
        private String email;
        private String asunto;

        public String getNombre()
        {
            return nombre;
        }
        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }
        public String getEmail()
        {
            return email;
        }
        public void setEmail(String email)
        {
            this.email = email;
        }
        public void setAsunto(String asunto)
        {
            this.asunto = asunto;
        }
        public String getAsunto()
        {
            return asunto;
        }
    }
    public class Employee
    {
        private int iDEmployee;
        private String name;
        private String lastname;
        private String address;
        private String email;
        private String dni;
        private String dateHired; //ojo falta corregir esto, deberia ser tipo datetime pero no se sabe como se castea
        private float salary;
        private int workArea; //area de trabajo
        private String workStation;//puesto de trabajo

        public Employee()  {   }
        public Employee(int iD, String nam, String last, String add, String ema, String date, float sal)
        {
            iDEmployee = iD;
            name = nam;
            lastname = last;
            address = add;
            dateHired = date;
            salary = sal;
        }
        public void setDNI(string strdni)
        {
            dni = strdni;
        }
        public String getDni()
        {
            return dni;
        }
        public String getWorkStation()
        {
            return workStation;
        }
        public void setWorkStation(String str)
        {
            workStation = str;
        }
        public void setWorkArea(int num)
        {
            workArea = num;
        }
        public int getWorkArea()
        {
            return workArea;
        }
        public void setSalary(float sal)
        {
            salary = sal;
        }
        public float getSalary()
        {
            return salary;
        }
        public void setID(int iD)
        {
            iDEmployee = iD;
        }
        public int getID()
        {
            return iDEmployee;
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public String getName()
        {
            return name;
        }
        public void setLastName(String lastName)
        {
            lastname = lastName;
        }
        public String getLastname()
        {
            return lastname;
        }
        public void setEmail(String eMail)
        {
            email = eMail;
        }
        public String getEmail()
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
        private int idEmployee;
        private SqlConnection conn;

        public void makeConnection()
        {
            conn = new SqlConnection("user id=inf282;"+"password=inf282db;"+"server=inti.lab.inf.pucp.edu.pe;"+"database=inf282; "+"connection timeout=30");
        }
        public int validatePassword()
        {
            int flag;
            try
            {
                conn.Open();
                String sqlString = "SELECT * " +"FROM G08_USUARIO " +"WHERE IDUSER = @param1 and CLAVE = @param2";
                
                SqlParameter myParam1 = new SqlParameter("@Param1", SqlDbType.VarChar, 20);
                myParam1.Value = idUser;
                
                SqlParameter myParam2 = new SqlParameter("@Param2", SqlDbType.VarChar, 20);
                myParam2.Value = password;
                
                SqlCommand myCommand = new SqlCommand(sqlString, conn);
                
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
                    idEmployee = reader.GetInt32(2);
                }
                else
                {
                    flag = 0;
                }

            }
            catch (Exception)
            {
                flag = 0;                
            }
            return flag;
        }

        public void setUser(string user)
        {
            idUser = user;
        }
        public string getUser()
        {
            return idUser;
        }

        public void setPassword(string pass)
        {
            password = pass;
        }
        public string getPassword()
        {
            return password;
        }
    }
    public class Product
    {

        private int idProduct;
        private String name;
        private int stockMin;   //la cantidad minimo que tiene que tener la empresa
        private int stock;   //la cantidad maxima que debe tener la empresa 
        private float purchasePrice;
        private float salePrice;

        public Product()
        {
            idProduct = 0;
            name = "";
            stockMin = 0;
            stock = 0;
            purchasePrice = 0f;
            salePrice = 0f;
        }

        public Product(int idProduct, String name, int stockMin, int stockMax, float purchasePrice, float salePrice)
        {
            this.idProduct = idProduct;
            this.name= name;
            this.stockMin = stockMin;
            this.stock = stockMax;
            this.purchasePrice = 0f;
            this.salePrice= 0f;

        }
        public int getId()
        {
            return idProduct;
        }
        public void setId(int idProduct)
        {
            this.idProduct = idProduct;
        }
        public String getName()
        {
            return name;
        }
        public void setName(String name)
        {
            this.name = name;
        }

        public int getStockMin()
        {
            return stockMin;
        }
        public void setStockMin(int stockMin)
        {
            this.stockMin = stockMin;
        }
        public int getStock()
        {
            return stock;
        }
        public void setStock(int stock)
        {
            this.stock = stock;
        }

        public float getPurchasePrice()
        {
            return purchasePrice;
        }
        public void setPurchasePrice(float purchasePrice)
        {
            this.purchasePrice = purchasePrice;
        }

        public float getSalePrice()
        {
            return salePrice;
        }
        public void setSalePrice(float salePrice)
        {
            this.salePrice = salePrice;
        }
    }
    public class Client
    {
        private int idClient;
        private string address;
        private string state;  //estado del cliente
        private string email;
        private string telephone;
        private string businessName; //Razon Social

        public Client()
        {
            idClient = 0;
            address = "";
            state= "";
            email = "";
            telephone = "";
            businessName = "";
        }

        public Client(int idClient, string address, string state, string email, string telephone, string businessName)
        {
            this.idClient = idClient;
            this.address = address;
            this.state= state;
            this.email = email;
            this.telephone = telephone;
            this.businessName = businessName;
        }

        public string getBusinessName()
        {
            return businessName;
        }

        public int getIdClient()
        {
            return idClient;
        }
        public void setIdClient(int idClient)
        {
            this.idClient = idClient;
        }

        public string getAddress()
        {
            return address;
        }
        public void setAddress(string address)
        {
            this.address = address;
        }
        public string getState()
        {
            return state;
        }

        public void setState(string state)
        {
            this.state= state;
        }
        public string getEmail()
        {
            return email;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }
        public string getTelephone()
        {
            return telephone;
        }
        public void setTelephone(string telephone)
        {
            this.telephone = telephone;
        }
        public void setBusinessName(string businessName)
        {
            this.businessName = businessName;
        }
    }
    public class ClientWeb
    {
        private String nombre;
        private String contraseña;
        private String email;
        private String direccion;
        private String pais;

        public String getNombre()
        {
            return nombre;
        }
        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }
        public String getContraseña()
        {
            return contraseña;
        }
        public void setContraseña(String contraseña)
        {
            this.contraseña = contraseña;
        }
        public String getEmail()
        {
            return email;
        }
        public void setEmail(String email)
        {
            this.email = email;
        }
        public String getDireccion()
        {
            return direccion;
        }
        public void setDireccion(String direccion)
        {
            this.direccion = direccion;
        }
        public String getPais()
        {
            return pais;
        }
        public void setPais(String pais)
        {
            this.pais = pais;
        }
    }
    public class SalesMan
    {
        private int idVendedor;
        private String estado;

        public int getIdVendedor()
        {
            return idVendedor;
        }
        public void setIdVendedor(int idVendedor)
        {
            this.idVendedor = idVendedor;
        }
        public String getEstado()
        {
            return estado;
        }
        public void setEstado(String estado)
        {
            this.estado = estado;
        }
    }
}