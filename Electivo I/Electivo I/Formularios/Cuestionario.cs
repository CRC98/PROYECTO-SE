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
    public partial class Cuestionario : Form
    {
        Formularios.Registrar_Cuestionario question = new Registrar_Cuestionario();
        Clases.Cuestionario jimmy = new Clases.Cuestionario();
        public Cuestionario()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string karma = txtbuscar.Text;
                dgdatos.DataSource = jimmy.Buscarcuestionario(karma);
            }
            catch (Exception) {
                MessageBox.Show("Se ha producido un error", "Error", MessageBoxButtons.OK);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            question.ShowDialog();
        }

        private void Cuestionario_Load(object sender, EventArgs e)
        {
            dgdatos.DataSource = jimmy.mostrarcuestionario();
        }

        private void txtbuscar_Leave(object sender, EventArgs e)
        {
            if (txtbuscar.Text == "Ingrese el Numero de la pregunta")
            {
                txtbuscar.Text = "";
                txtbuscar.ForeColor = Color.White;
            }
        }

        private void txtbuscar_Enter(object sender, EventArgs e)
        {
            if (txtbuscar.Text == "Ingrese el Numero de la pregunta")
            {
                txtbuscar.Text = "";
                txtbuscar.ForeColor = Color.White;
            }
        }
    }
}
