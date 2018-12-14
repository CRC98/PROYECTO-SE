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
    public partial class Alumnos : Form
    {
        Formularios.Registrar_Alumno alumno = new Registrar_Alumno();
        Clases.Alumno jimmy = new Clases.Alumno();
        string campito;
        public Alumnos()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string karma = txtbuscar.Text;
                dgdatos.DataSource = jimmy.Buscaralumno(campito, karma);
            }
            catch (Exception) {
                MessageBox.Show("Seleccione un metodo de Busqueda", "Error", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alumno.ShowDialog();
        }

        private void Alumnos_Load(object sender, EventArgs e)
        {
            
            dgdatos.DataSource = jimmy.mostraralumno();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            campito = "a.nombre";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            campito = "cod_alumno";
        }

        private void txtbuscar_Leave(object sender, EventArgs e)
        {
            if (txtbuscar.Text == "Ingrese el Nom/cod del Alumno")
            {
                txtbuscar.Text = "";
                txtbuscar.ForeColor = Color.White;
            }
        }

        private void txtbuscar_Enter(object sender, EventArgs e)
        {
            if (txtbuscar.Text == "Ingrese el Nom/cod del Alumno")
            {
                txtbuscar.Text = "";
                txtbuscar.ForeColor = Color.White;
            }
        }
    }
}
