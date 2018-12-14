using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electivo_I.Formularios
{
    public partial class Registrar_Cuentas : Form
    {
        Clases.Cuentas jimmy = new Clases.Cuentas();
        public Registrar_Cuentas()
        {
            InitializeComponent();
        }
        private void llenar()
        {

            jimmy.Id = txtid.Text;
            jimmy.Usuario = txtusuario.Text;
            jimmy.Contraseña = txtcontraseña.Text;
            jimmy.Tipo = cbotipo.Text; ;
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            try
            {
                llenar();
                jimmy.grabarcuenta();
                MessageBox.Show("La Cuenta ha sido Registrada", "CORRECTO");
            }
            catch (Exception)
            {
                MessageBox.Show("La Cuenta no ha sido Registrada", "ERROR");
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                llenar();
                jimmy.modificarcuenta();
                MessageBox.Show("La cuenta ha sido Modificada", "CORRECTO");
            }
            catch (Exception)
            {
                MessageBox.Show("La Cuenta no ha sido Modificada", "ERROR");
                throw;
            }
        }
    }
}
