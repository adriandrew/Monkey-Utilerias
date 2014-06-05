using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using AccesoDatos;

namespace Logica
{
   public class Alumno
    {
        int idAlumno, edad, idNivelAcademico;
        string nombre, apellidoPaterno, apellidoMaterno, direccion, telefono;
        DateTime fechaNacimiento;

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public int IdAlumno     
        {
            get { return idAlumno; }
            set { idAlumno = value; }
        }

        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public int Idgrado
        {
            get { return idNivelAcademico; }
            set { idNivelAcademico = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellidop
        {
            get { return apellidoPaterno; }
            set { apellidoPaterno = value; }
        }

        public string Apellidom
        {
            get { return apellidoMaterno; }
            set { apellidoMaterno = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        
       
       public void agregar()
        {
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BaseDatos.conn;
            cmd.Connection.Open();
            //cmd.CommandText.GetType;
            cmd.Connection.Close();
            //cmd.Connection.cl;
           
        }
 
   }
}
