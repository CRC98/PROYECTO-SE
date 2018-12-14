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
    public partial class Registrar_Administrador : Form
    {
        Clases.Administrador jimmy = new Clases.Administrador();
        public Registrar_Administrador()
        {
            InitializeComponent();
        }
        private void llenar()
        {
            jimmy.Id = txtid.Text;
            jimmy.Codigo = txtcodigo.Text;
            jimmy.Tdocumento = txtidtipo.Text;
            jimmy.Documento = txtdni.Text; ;
            jimmy.Nombre = txtnombre.Text;
            jimmy.Apellido = txtapellido.Text;
            jimmy.Fec_nac = txtfecha.Text;
            jimmy.Telefono = txttelefono.Text;
            jimmy.Correo = txtcorreo.Text;
            jimmy.Direccion = txtdireccion.Text;
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
                jimmy.grabaradministrador();
                MessageBox.Show("El Administrador ha sido Registrado", "CORRECTO");
            }
            catch (Exception)
            {
                MessageBox.Show("El Administrador no ha sido Registrado", "ERROR");
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                llenar();
                jimmy.modificaradministrador();
                MessageBox.Show("El Administrador ha sido Modificado", "CORRECTO");
            }
            catch (Exception)
            {
                MessageBox.Show("El Administrador no ha sido Modificado", "ERROR");
                throw;
            }
        }

        private void Registrar_Administrador_Load(object sender, EventArgs e)
        {
            jimmy.ComboTipDoc(cbotipo);
        }

        private void cbotipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbotipo.SelectedIndex > 0)
            {
                string[] valores = jimmy.selec(cbotipo.Text);
                txtidtipo.Text = valores[0];
            }
        }
    }
}
