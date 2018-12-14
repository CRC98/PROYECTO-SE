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
    public partial class Registrar_TipoDocumento : Form
    {
        Clases.TipoDocumento jimmy = new Clases.TipoDocumento();
        public Registrar_TipoDocumento()
        {
            InitializeComponent();
        }
        private void llenar()
        {

            //jimmy.Id = txtid.Text;
            //jimmy.co+ = txtusuario.Text;
            //jimmy.Contraseña = txtcontraseña.Text;
            //jimmy.Tipo = cbotipo.Text; ;

        }
        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {

        }
    }
}
