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
   public class Alumno
    {
        private string codigo;
        private string talumno;
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

        public string Talumno
        {
            get
            {
                return talumno;
            }

            set
            {
                talumno = value;
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
        public void grabaralumno()
        {
            try
            {
                conectar();
                con.Open();
                string sql = "insert into Alumno values('" + codigo + "','" + talumno + "','" + nombre + "','" + apellido + "','" + tdocumento + "','" + documento + "','" + fec_nac + "','" + curso + "','" + telefono + "','" + correo + "','" + direccion + "')";
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
        public void eliminaralumno()
        {
            try
            {
                conectar();
                con.Open();
                string sql = "delete from Alumno where cod_alumno='" + codigo + "'";
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

        public void modificaralumno()
        {
            try
            {
                conectar();
                con.Open();
                string sql = "update Alumno set id_tip='" + talumno + "',nombre='" + nombre + "',apellidos='" + apellido + "',id_tipo='" + tdocumento + "',documento='" + documento + "',fec_nac='" + fec_nac + "',curso='" + curso + "',telefono='" + telefono + "',correo='" + correo + "',direccion='" + direccion + "' where cod_alumno = '" + codigo + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();


            }
            catch (Exception)
            {


                con.Close();
            }
        }
        public DataTable mostraralumno()
        {
            conectar();
            con.Open();
            string sql = "select a.cod_alumno as [Codigo], ta.id_tip as [Tipo de Alumno], a.nombre as [Nombre], a.apellidos as [Apellidos], td.id_tipo as [Tipo de Documento], a.documento as [Numero] ,a.fec_nac as [Fecha de Nacimiento], c.grado as [Grado], a.telefono as [Telefono], a.direccion as [Direccion], a.correo as [Correo] from Alumno a inner join Tipo_Alumno ta on a.id_tip=ta.id_tip inner join Curso c on a.id_curso=c.id_curso inner join TipoDocumento td on a.id_tipo=td.id_tipo";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Buscaralumno(string campo, string valor)
        {
            try
            {
                conectar();
                con.Open();
                string sql = "select a.cod_alumno as [Codigo], ta.id_tip as [Tipo de Alumno], a.nombre as [Nombre], a.apellidos as [Apellidos], td.id_tipo as [Tipo de Documento], a.documento as [Numero] ,a.fec_nac as [Fecha de Nacimiento], c.grado as [Grado], a.telefono as [Telefono], a.direccion as [Direccion], a.correo as [Correo] from Alumno a inner join Tipo_Alumno ta on a.id_tip=ta.id_tip inner join Curso c on a.id_curso=c.id_curso inner join TipoDocumento td on a.id_tipo=td.id_tipo where " + campo + " like '" + valor + "%'";
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

        public void ComboTipAl(ComboBox cb)
        {
            cb.Items.Clear();
            conectar();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Tipo_Alumno", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb.Items.Add(dr[1].ToString());
            }
            con.Close();
            cb.Items.Insert(0, "invitado");
            cb.SelectedIndex = 0;
        }
        public string[] selec1(string nombre)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Tipo_Alumno where nombre='" + nombre + "'", con);
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

        public void Combocurso(ComboBox cb)
        {
            cb.Items.Clear();
            conectar();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Curso", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb.Items.Add(dr[1].ToString());
                //cb.Items.Add(dr[2].ToString());
            }
            con.Close();
            cb.Items.Insert(0, "Seleccione Curso");
            cb.SelectedIndex = 0;
        }
        public string[] selec2(string nombre)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Curso where grado='" + nombre + "'", con);
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
        public void ComboUsuario(ComboBox cb)
        {
            cb.Items.Clear();
            conectar();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Usuario", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb.Items.Add(dr[3].ToString());
            }
            con.Close();
            cb.Items.Insert(0, "Tipo de Usuario");
            cb.SelectedIndex = 0;
        }
        public string[] selec3(string nombre)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Usuario where Tipo_usuario='" + nombre + "'", con);
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
