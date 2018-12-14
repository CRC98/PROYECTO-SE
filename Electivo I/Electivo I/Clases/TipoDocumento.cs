using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Electivo_I.Clases
{
    class TipoDocumento
    {
        private string id;
        private string nombre;
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
        public void grabartipodoc()
        {
            try
            {
                conectar();
                con.Open();
                string sql = "insert into TipoDcoumento values('" + id + "','" + nombre + "')";
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
        public void eliminartipodoc()
        {
            try
            {
                conectar();
                con.Open();
                string sql = "delete from TipoDocumento where id_tipo='" + id + "'";
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

        public void modificartipodoc()
        {
            try
            {
                conectar();
                con.Open();
                string sql = "update TipoDocumento set nombre='" + nombre + "' where id_tipo = '" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();


            }
            catch (Exception)
            {


                con.Close();
            }
        }
        public DataTable mostrartipodoc()
        {
            conectar();
            con.Open();
            string sql = "Select id_tipo as Codigo, nombre as Documento from TipoDocumento";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Buscartipodoc(string valor)
        {
            try
            {
                conectar();
                con.Open();
                string sql = "Select id_tipo as Codigo, nombre as Documento from TipoDocumento where nombre like '" + valor + "%'";
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
