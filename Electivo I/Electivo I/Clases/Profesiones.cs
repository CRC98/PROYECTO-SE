using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Electivo_I.Clases
{
   public class Profesiones
    {
        private string id;
        private string nombre;
        private string duracion;
        private string descripcion;
        SqlConnection con;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Duracion
        {
            get
            {
                return duracion;
            }

            set
            {
                duracion = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        private void conectar()
        {
            try
            {
                con = new SqlConnection("database= SE_OV;data source=.;integrated security=sspi");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void grabarcarrera()
        {
            try
            {
                conectar();
                con.Open();
                string sql = "insert into Carreras values('" + nombre + "','" + duracion + "','" + descripcion + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception)
            {

                con.Close();
                throw;
            }

        }
        public void eliminarcarrera()
        {
            try
            {
                conectar();
                con.Open();
                string sql = "delete from Carreras where id_carrera='" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception)
            {

                con.Close();
                throw;
            }
        }

        public void modificarcarrera()
        {
            try
            {
                conectar();
                con.Open();
                string sql = "update Carrera set nombre='" + nombre + "', duracion='" + duracion + "', descripcion='" + descripcion + "'  where id_carrera = '" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();


            }
            catch (Exception)
            {


                con.Close();
            }
        }
        public DataTable mostrarcarrera()
        {
            conectar();
            con.Open();
            string sql = "profesion";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Buscarcarrera(string valor)
        {
            try
            {
                conectar();
                con.Open();
                string sql = "select id_carrera as [N°], nombre as Profesion, duracion as Duracion, descripcion as Descripcion from Carreras where nombre like '" + valor + "%'";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception)
            {
                con.Close();

                throw;
            }
        }

    }
}
