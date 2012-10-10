using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Libreria
{
    public class Personal
    {
        private int iDPersonal;
        private String name;
        private String lastname;
        private String address;
        private String email;
        private DateTime dateHired;
        private float salary;
        private String workArea; //area de trabajo
        private String workStation;//puesto de trabajo
        public Personal(int iD, String nam, String last, String add, String ema, DateTime date, float sal)
        {
            iDPersonal = iD;
            name = nam;
            lastname = last;
            address = add;
            dateHired = date;
            salary = sal;
        }
        public void SetSalary(float sal)
        {
            salary = sal;
        }
        public float GetSalary()
        {
            return salary;
        }
        public void SetiID(int iD)
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
        public String GetLastname(){
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
        public void GetDateHired(DateTime date)
        {
            dateHired = date;
        }
        public DateTime SetHired()
        {
            return dateHired;
        }
    }
    public class User
    {
        private string idUser;
        private string password;
        private int idPersonal;

        public void SetID(int ID)
        {
            idPersonal = ID;
        }
        public int GetID()
        {
            return idPersonal;
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
        private int state;


        public Product(int codigo, String nombre, int stockMin, int stockMax, int estado)
        {
            idProduct = codigo;
            name = nombre;
            this.stockMin = stockMin;
            this.stockMax = stockMax;
            state = estado;
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

        /**
         * @return the Estado
         */
        public int getState()
        {
            return state;
        }

        /**
         * @param Estado the Estado to set
         */
        public void setState(int Estado)
        {
            this.state = Estado;
        }

    }
    public class Client
    {

        private int IdClient;
        private float MountDebts;  //es el monto que debe el cliente
        private String Address;
        private String Observation;  //comentario respecto el cliente
        private String Email;
        private String Telephone;
        private String businessName; //Razon Social

        public Client(int idCliente, float montoDeudas, String direccion,
                String observacion, String correo, String telefono, String razonSocial)
        {

            IdClient = idCliente;
            MountDebts = montoDeudas;
            Address = direccion;
            Observation = observacion;
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
        public float getMontoDeudas()
        {
            return MountDebts;
        }
        public void setMontoDeudas(float montoDeudas)
        {
            MountDebts = montoDeudas;
        }
        public String getDireccion()
        {
            return Address;
        }
        public void setDireccion(String direccion)
        {
            Address = direccion;
        }
        public String getObservacion()
        {
            return Observation;
        }
        public void setObservacion(String observacion)
        {
            Observation = observacion;
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