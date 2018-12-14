using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Electivo_I.Formularios
{
    public partial class Login : Form
    {
        int posY = 0;
        int posX = 0;
        Formularios.Menu administr = new Menu();
        Formularios.Test usuar = new Test();
        Formularios.Invitado inv = new Invitado();
        SqlConnection conex;
        public Login()
        {
            InitializeComponent();
        }
        public void Logear(string usuario, string contraseña)
        {
            try
            {
                conex.Open();
                SqlCommand cmd = new SqlCommand("SELECT usuario, Tipo_usuario FROM Usuario WHERE Usuario = '" + usuario + "' AND contraseña = '" + contraseña + "'", conex);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("pass", contraseña);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);



                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    if (dt.Rows[0][1].ToString() == "Admin")
                    {
                        administr.ShowDialog();

                    }
                    else if (dt.Rows[0][1].ToString() == "usuario")
                    {

                        usuar.ShowDialog();

                    }
                }
                else
                {

                    txtcontraseña.Focus();
                    MessageBox.Show("Usuario y/o Contraseña Incorrecta");
                    conex.Close();

                }
            }
            catch (Exception e)

            {
                MessageBox.Show(e.Message);


            }

        }
        private void btnaceptar_Click(object sender, EventArgs e)
        {
            Logear(txtusuario.Text, txtcontraseña.Text);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            conex = new SqlConnection("database = SE_OV; Data Source = .; integrated security=sspi");
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void txtusuario_Enter(object sender, EventArgs e)
        {
            if (txtusuario.Text == "USUARIO")
            {
                txtusuario.Text = "";
                txtusuario.ForeColor = Color.LightGray;
            }
        }

        private void txtusuario_Leave(object sender, EventArgs e)
        {
            if (txtusuario.Text == "")
            {
                txtusuario.Text = "USUARIO";
                txtusuario.ForeColor = Color.DimGray;
            }
        }

        private void txtcontraseña_Enter(object sender, EventArgs e)
        {
            if (txtcontraseña.Text == "CONTRASEÑA")
            {
                txtcontraseña.Text = "";
                txtcontraseña.ForeColor = Color.LightGray;
                txtcontraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtcontraseña_Leave(object sender, EventArgs e)
        {
            if (txtcontraseña.Text == "")
            {
                txtcontraseña.Text = "CONTRASEÑA";
                txtcontraseña.ForeColor = Color.DimGray;
                txtcontraseña.UseSystemPasswordChar = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion= MessageBox.Show("¿Desea Salir de la Aplicación?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcion == DialogResult.Yes)
            {
                Application.Exit();
            }
                       
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inv.ShowDialog();
            
        }
    }
}
