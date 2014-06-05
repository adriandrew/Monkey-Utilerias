using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Entidades
{
    public class Conferencia
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string lugar;

        public string Lugar
        {
            get { return lugar; }
            set { lugar = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private Tipo tipo;

        public Tipo Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        private string conferencista;

        public string Conferencista
        {
            get { return conferencista; }
            set { conferencista = value; }
        }
    
        public void Agregar()
        {
            try {
                string sql = "INSERT INTO Conferencia (nombre,lugar,fecha,conferencista,tipo) VALUES(@nombre, @lugar, @fecha,@conferencista,@tipo)";
                SqlCommand cmm = new SqlCommand(sql,BaseDatos.conn);
                cmm.Parameters.AddWithValue("@nombre", this.Nombre);
                cmm.Parameters.AddWithValue("@lugar", this.Lugar);
                cmm.Parameters.AddWithValue("@fecha", this.Fecha);
                cmm.Parameters.AddWithValue("@conferencista", this.Conferencista);
                cmm.Parameters.AddWithValue("@tipo",((int)this.Tipo).ToString());
                BaseDatos.conn.Open();
                cmm.ExecuteNonQuery();
                BaseDatos.conn.Close();
            }
            catch (Exception ex){
            throw ex;
            }
           
        }

        public void Editar()
        {
            try
            {
                string sql = "UPDATE Conferencia SET nombre=@nombre,lugar=@lugar,fecha=@fecha,conferencista=@conferencista,tipo=@tipo WHERE id=@id";
                SqlCommand cmm = new SqlCommand(sql, BaseDatos.conn);
                cmm.Parameters.AddWithValue("@nombre", this.Nombre);
                cmm.Parameters.AddWithValue("@lugar", this.Lugar);
                cmm.Parameters.AddWithValue("@fecha", this.Fecha);
                cmm.Parameters.AddWithValue("@conferencista", this.Conferencista);
                cmm.Parameters.AddWithValue("@tipo", ((int)this.Tipo).ToString());
                cmm.Parameters.AddWithValue("@id", this.Id);
                BaseDatos.conn.Open();
                cmm.ExecuteNonQuery();
                BaseDatos.conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void Eliminar()
        {
            try
            {
                string sql = "DELETE FROM Conferencia WHERE id=@id";
                SqlCommand cmm = new SqlCommand(sql, BaseDatos.conn);
                cmm.Parameters.AddWithValue("@id", this.Id);
                BaseDatos.conn.Open();
                cmm.ExecuteNonQuery();
                BaseDatos.conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    



    }
}
