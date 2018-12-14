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
    public partial class Profesiones : Form
    {
        Formularios.Registrar_Profesiones prof = new Registrar_Profesiones();
        Clases.Profesiones jimmy = new Clases.Profesiones();
        public Profesiones()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prof.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string karma = txtbuscar.Text;
                dgdatos.DataSource = jimmy.Buscarcarrera(karma);
            }

            catch (Exception) {

                MessageBox.Show("Se ha producido un error", "Error", MessageBoxButtons.OK);
            }
            
        }

        private void Profesiones_Load(object sender, EventArgs e)
        {
            dgdatos.DataSource = jimmy.mostrarcarrera();
        }

        private void txtbuscar_Leave(object sender, EventArgs e)
        {
            if (txtbuscar.Text == "Ingrese el Nombre de la Profesion")
            {
                txtbuscar.Text = "";
                txtbuscar.ForeColor = Color.White;
            }
        }

        private void txtbuscar_Enter(object sender, EventArgs e)
        {
            if (txtbuscar.Text == "Ingrese el Nombre de la Profesion")
            {
                txtbuscar.Text = "";
                txtbuscar.ForeColor = Color.White;
            }
        }
    }
}
