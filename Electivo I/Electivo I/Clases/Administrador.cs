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
    public class Administrador
    {
        private string id;
        private string codigo;
        private string nombre;
        private string apellido;
        private string tdocumento;
        private string documento;
        private string fec_nac;
        private string curso;
        private string telefono;
        private string correo;
        private string direccion;
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

        public string Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
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

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public string Tdocumento
        {
            get
            {
                return tdocumento;
            }

            set
            {
                tdocumento = value;
            }
        }

        public string Documento
        {
            get
            {
                return documento;
            }

            set
            {
                documento = value;
            }
        }

        public string Fec_nac
        {
            get
            {
                return fec_nac;
            }

            set
            {
                fec_nac = value;
            }
        }

        public string Curso
        {
            get
            {
                return curso;
            }

            set
            {
                curso = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public string Correo
        {
            get
            {
                return correo;
            }

            set
            {
                correo = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
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
        public void grabaradministrador()
        {
            try
            {
                conectar();
                con.Open();
                string sql = "insert into Administrador values('" + codigo + "','" + nombre + "','" + apellido + "','" + tdocumento + "','" + documento + "','" + fec_nac + "','" + telefono + "','" + correo + "','" + direccion + "')";
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
        public void eliminaradministrador()
        {
            try
            {
                conectar();
                con.Open();
                string sql = "delete from Administrador where id_administrador='" + id + "'";
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

        public void modificaradministrador()
        {
            try
            {
                conectar();
                con.Open();
                string sql = "update Administrador set cod_administrador='" + codigo + "',nombre='" + nombre + "',apellidos='" + apellido + "',id_tipo='" + tdocumento + "',documento='" + documento + "',fec_nac='" + fec_nac + "',telefono='" + telefono + "',correo='" + correo + "',direccion='" + direccion + "' where id_administrador = '" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();


            }
            catch (Exception)
            {


                con.Close();
            }
        }
        public DataTable mostraradministrador()
        {
            conectar();
            con.Open();
            string sql = "admin";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Buscaradministrador(string campo, string valor)
        {
            try
            {
                conectar();
                con.Open();
                string sql = "select a.id_administrador as [N°], a.cod_administrador as [Codigo], a.nombre as [Nombre], a.apellidos as [Apellidos], td.id_tipo as [Tipo de Documento], a.documento as [Numero] ,a.fec_nac as [Fecha de Nacimiento], a.telefono as [Telefono], a.direccion as [Direccion], a.correo as [Correo] from Administrador a join TipoDocumento td on a.id_tipo=td.id_tipo where " + campo + " like '" + valor + "%'";
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

        public void ComboTipDoc(ComboBox cb)
        {
            cb.Items.Clear();
            conectar();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from TipoDocumento", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb.Items.Add(dr[1].ToString());
            }
            con.Close();
            cb.Items.Insert(0, "Tipo de Documento");
            cb.SelectedIndex = 0;
        }
        public string[] selec(string nombre)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from TipoDocumento where nombre='" + nombre + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            string[] resultado = null;
            while (dr.Read())
            {
                string[] valores =
                {
                    dr[0].ToString()
                };
                resultado = valores;
            }
            con.Close();
            return resultado;
        }
    }

}
