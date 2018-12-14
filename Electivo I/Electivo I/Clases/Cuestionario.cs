using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Electivo_I.Clases
{
    public class Cuestionario
    {
        private string id;
        private string opcion1;
        private string opcion2;
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

        public string Opcion1
        {
            get
            {
                return opcion1;
            }

            set
            {
                opcion1 = value;
            }
        }

        public string Opcion2
        {
            get
            {
                return opcion2;
            }

            set
            {
                opcion2 = value;
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
        public void grabarcuestionario()
        {
            try
            {
                conectar();
                con.Open();
                string sql = "insert into Cuestionario values('" + id + "','" + opcion1 + "','" + opcion2 + "')";
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
        public void eliminarcuestionario()
        {
            try
            {
                conectar();
                con.Open();
                string sql = "delete from Cuenta where id_cuestionario='" + id + "'";
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

        public void modificuestionario()
        {
            try
            {
                conectar();
                con.Open();
                string sql = "update Cuestionario set opcion1='" + opcion1 + "', opcion2='" + opcion2 + "' where id_cuestionario = '" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();


            }
            catch (Exception)
            {


                con.Close();
            }
        }
        public DataTable mostrarcuestionario()
        {
            conectar();
            con.Open();
            string sql = "question";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Buscarcuestionario(string valor)
        {
            try
            {
                conectar();
                con.Open();
                string sql = "select id_cuestionario as [N°], opcion1 as A, opcion2 as B from Cuestionario where id_cuestionario like '" + valor + "%'";
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
