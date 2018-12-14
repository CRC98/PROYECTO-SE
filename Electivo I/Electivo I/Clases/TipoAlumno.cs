using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Electivo_I.Clases
{
    public class TipoAlumno
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

        public void grabarTipAlumno()
        {
            try
            {
                conectar();
                con.Open();
                string sql = "insert into Tipo_Alumno values('" + nombre + "')";
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
        public void eliminarTipAlumno()
        {
            try
            {
                conectar();
                con.Open();
                string sql = "delete from Tipo_Alumno where id_tip='" + id + "'";
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

        public void modificarTipAlumno()
        {
            try
            {
                conectar();
                con.Open();
                string sql = "update Tipo_Alumno set nombre='" + nombre + "' where id_tip = '" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();


            }
            catch (Exception)
            {


                con.Close();
            }
        }
        public DataTable mostrarTipAlumno()
        {
            conectar();
            con.Open();
            string sql = "Select id_tip as [N°],nombre as [Tipo de Alumno] from Tipo_Alumno";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable BuscarTipAlumno(string valor)
        {
            try
            {
                conectar();
                con.Open();
                string sql = "Select id_tip as [N°],nombre as [Tipo de Alumno] from Tipo_Alumno where nombre like '" + valor + "%'";
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
