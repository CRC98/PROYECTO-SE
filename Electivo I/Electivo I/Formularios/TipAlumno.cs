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
    public partial class TipAlumno : Form
    {
        Formularios.Registrar_TipoAlumno opciones = new Registrar_TipoAlumno();
        Clases.TipoAlumno jimmy = new Clases.TipoAlumno();

        public TipAlumno()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            opciones.ShowDialog();
        }

        private void txtbuscar_Leave(object sender, EventArgs e)
        {
            if (txtbuscar.Text == "Ingrese el tipo de Alumno")
            {
                txtbuscar.Text = "";
                txtbuscar.ForeColor = Color.White;
            }
        }

        private void txtbuscar_Enter(object sender, EventArgs e)
        {
            if (txtbuscar.Text == "Ingrese el tipo de Alumno")
            {
                txtbuscar.Text = "";
                txtbuscar.ForeColor = Color.White;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try {
                string karma = txtbuscar.Text;
                dgdatos.DataSource = jimmy.BuscarTipAlumno(karma);
            }
            catch (Exception) {
                MessageBox.Show("Se ha producido un error", "Error", MessageBoxButtons.OK);
            }
        }

        private void TipAlumno_Load(object sender, EventArgs e)
        {
            dgdatos.DataSource = jimmy.mostrarTipAlumno();
        }
    }
}
