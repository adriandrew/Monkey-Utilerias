using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Entidades {
  public class Ciudadano {

    #region Campos
    private int id;
    private string nombre;
    private string apellidos;
    private DateTime fechaNacimiento;
    private Sexo sexo;
    private string domicilio;
    private string escolaridad;    
    private string ocupacion;
    #endregion Campos

    #region Propiedades
    public int Id {
      get { return id; }
      set { id = value; }
    }
    public string Nombre {
      get { return nombre; }
      set { nombre = value; }
    }
    public string Apellidos {
      get { return apellidos; }
      set { apellidos = value; }
    }
    public DateTime FechaNacimiento {
      get { return fechaNacimiento; }
      set { fechaNacimiento = value; }
    }
    public Sexo Sexo {
      get { return sexo; }
      set { sexo = value; }
    }
    public string Domicilio {
      get { return domicilio; }
      set { domicilio = value; }
    }
    public string Escolaridad {
      get { return escolaridad; }
      set { escolaridad = value; }
    }
    public string Ocupacion {
      get { return ocupacion; }
      set { ocupacion = value; }
    }
    #endregion Propiedades

    #region Metodos

    public void Agregar() {
      try {
        string sql = "INSERT INTO Ciudadano (nombre, apellidos, fechaNacimiento, sexo, domicilio, escolaridad, ocupacion) VALUES (@nombre, @apellidos, @fechaNacimiento, @sexo, @domicilio, @escolaridad, @ocupacion)";
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = BaseDatos.conn;
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@nombre", this.Nombre);
        cmd.Parameters.AddWithValue("@apellidos", this.Apellidos);
        cmd.Parameters.AddWithValue("@fechaNacimiento", this.FechaNacimiento);
        cmd.Parameters.AddWithValue("@sexo", ((int)this.Sexo).ToString());
        cmd.Parameters.AddWithValue("@domicilio", this.Domicilio);
        cmd.Parameters.AddWithValue("@escolaridad", this.Escolaridad);
        cmd.Parameters.AddWithValue("@ocupacion", this.Ocupacion);
        BaseDatos.conn.Open();
        cmd.ExecuteNonQuery();
      } catch (Exception ex) {
        throw ex;
      } finally {
        BaseDatos.conn.Close();
      }
    }

    public void Editar() {
      try {
        string sql = "UPDATE Ciudadano SET nombre = @nombre, apellidos = @apellidos, fechaNacimiento = @fechaNacimiento, sexo = @sexo, domicilio = @domicilio, escolaridad = @escolaridad, ocupacion = @ocupacion WHERE id = @id";
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = BaseDatos.conn;
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@id", this.Id);
        cmd.Parameters.AddWithValue("@nombre", this.Nombre);
        cmd.Parameters.AddWithValue("@apellidos", this.Apellidos);
        cmd.Parameters.AddWithValue("@fechaNacimiento", this.FechaNacimiento);
        cmd.Parameters.AddWithValue("@sexo", ((int)this.Sexo).ToString());
        cmd.Parameters.AddWithValue("@domicilio", this.Domicilio);
        cmd.Parameters.AddWithValue("@escolaridad", this.Escolaridad);
        cmd.Parameters.AddWithValue("@ocupacion", this.Ocupacion);
        BaseDatos.conn.Open();
        cmd.ExecuteNonQuery();
      } catch (Exception ex) {
        throw ex;
      } finally {
        BaseDatos.conn.Close();
      }
    }

    public void Eliminar() {
      try {
        string sql = "DELETE FROM Ciudadano WHERE id = @id";
        SqlCommand cmd = new SqlCommand(sql, BaseDatos.conn);
        cmd.Parameters.AddWithValue("@id", this.Id);
        BaseDatos.conn.Open();
        cmd.ExecuteNonQuery();
      } catch (Exception ex) {
        throw ex;
      } finally {
        BaseDatos.conn.Close();
      }
    }

    public void Obtener() {
      try {
        string sql = "SELECT * FROM Ciudadano WHERE id = @id";
        SqlCommand cmd = new SqlCommand(sql, BaseDatos.conn);
        cmd.Parameters.AddWithValue("@id", this.Id);
        BaseDatos.conn.Open();
        SqlDataReader r = cmd.ExecuteReader();
        while (r.Read()) {
          this.Nombre = r["nombre"].ToString();
          this.Apellidos = r["apellidos"].ToString();
          this.FechaNacimiento = Convert.ToDateTime(r["fechaNacimiento"].ToString());
          this.Sexo = (Sexo)(Convert.ToInt32(r["sexo"].ToString()));
          this.Domicilio = r["domicilio"].ToString();
          this.Escolaridad = r["escolaridad"].ToString();
          this.Ocupacion = r["ocupacion"].ToString();
        }
      } catch (Exception ex) {
        throw ex;
      } finally {
        BaseDatos.conn.Close();
      }
    }

    public static List<Ciudadano> ObtenerListado() {
      List<Ciudadano> list = new List<Ciudadano>();
      try {
        string sql = "SELECT * FROM Ciudadano";
        SqlCommand cmd = new SqlCommand(sql, BaseDatos.conn);
        BaseDatos.conn.Open();
        SqlDataReader r = cmd.ExecuteReader();
        Ciudadano c;
        while (r.Read()) {
          c = new Ciudadano();
          c.Id = Convert.ToInt32(r["id"]);
          c.Nombre = r["nombre"].ToString();
          c.Apellidos = r["apellidos"].ToString();
          c.FechaNacimiento = Convert.ToDateTime(r["fechaNacimiento"].ToString());
          c.Sexo = (Sexo)(Convert.ToInt32(r["sexo"].ToString()));
          c.Domicilio = r["domicilio"].ToString();
          c.Escolaridad = r["escolaridad"].ToString();
          c.Ocupacion = r["ocupacion"].ToString();
          list.Add(c);
        }
        return list;
      } catch (Exception ex) {
        return list;
        throw ex;
      } finally {
        BaseDatos.conn.Close();
      }
    }

    public static List<Ciudadano> ObtenerListadoCriterios(string _nombre, string _apellidos) {
      List<Ciudadano> list = new List<Ciudadano>();
      try {
        StringBuilder sql = new StringBuilder();
        sql.Append("SELECT * FROM Ciudadano WHERE ");
        if (!String.IsNullOrEmpty(_nombre)) {
          sql.Append("nombre LIKE '%");
          sql.Append(_nombre);
          sql.Append("%'");
        }
        if (!String.IsNullOrEmpty(_apellidos)) {
          if (!String.IsNullOrEmpty(_nombre))
            sql.Append(" AND ");
          sql.Append("apellidos LIKE '%");
          sql.Append(_apellidos);
          sql.Append("%'");
        }

        SqlCommand cmd = new SqlCommand(sql.ToString(), BaseDatos.conn);        
        BaseDatos.conn.Open();
        SqlDataReader r = cmd.ExecuteReader();
        Ciudadano c;
        while (r.Read()) {
          c = new Ciudadano();
          c.Id = Convert.ToInt32(r["id"]);
          c.Nombre = r["nombre"].ToString();
          c.Apellidos = r["apellidos"].ToString();
          c.FechaNacimiento = Convert.ToDateTime(r["fechaNacimiento"].ToString());
          c.Sexo = (Sexo)(Convert.ToInt32(r["sexo"].ToString()));
          c.Domicilio = r["domicilio"].ToString();
          c.Escolaridad = r["escolaridad"].ToString();
          c.Ocupacion = r["ocupacion"].ToString();
          list.Add(c);
        }
        return list;
      } catch (Exception ex) {
        return list;
        throw ex;
      } finally {
        BaseDatos.conn.Close();
      }
    }

    #endregion Metodos

  }
}
