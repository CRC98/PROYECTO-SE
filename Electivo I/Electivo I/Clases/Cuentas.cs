using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Electivo_I.Clases
{
    public class Cuentas
    {
        private string id;
        private string usuario;
        private string contraseña;
        private string tipo;
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

        public string Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        public string Contraseña
        {
            get
            {
                return contraseña;
            }

            set
            {
                contraseña = value;
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
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
        public void grabarcuenta()
        {
            try
            {
                conectar();
                con.Open();
                string sql = "insert into Cuenta values('" + usuario + "','" + contraseña + "','" + tipo + "')";
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
        public void eliminarcuenta()
        {
            try
            {
                conectar();
                con.Open();
                string sql = "delete from Cuenta where id_usuario='" + id + "'";
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

        public void modificarcuenta()
        {
            try
            {
                conectar();
                con.Open();
                string sql = "update Administrador set usuario='" + usuario + "',contraseña='" + contraseña + "',tipo='" + tipo + "' where id_usuario = '" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();


            }
            catch (Exception)
            {


                con.Close();
            }
        }
        public DataTable mostrarcuenta()
        {
            conectar();
            con.Open();
            string sql = "useer";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Buscarcuenta(string valor)
        {
            try
            {
                conectar();
                con.Open();
                string sql = "select usuario as Usuario, contraseña as Contraseña, tipo_usuario as [Tipo de Usuario] from Usuario where usuario like '" + valor + "%'";
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
