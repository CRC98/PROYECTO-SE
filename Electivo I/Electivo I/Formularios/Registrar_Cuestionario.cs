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
    public partial class Registrar_Cuestionario : Form
    {
        Clases.Cuestionario jimmy = new Clases.Cuestionario();
        public Registrar_Cuestionario()
        {
            InitializeComponent();
        }
        private void llenar()
        {

            jimmy.Id = txtid.Text;
            jimmy.Opcion1 = txtopcion1.Text;
            jimmy.Opcion2 = txtopcion2.Text;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                llenar();
                jimmy.modificuestionario();
                MessageBox.Show("La cuestion ha sido Modificada", "CORRECTO");
            }
            catch (Exception)
            {
                MessageBox.Show("La Cuestion no ha sido Modificada", "ERROR");
                throw;
            }
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            try
            {
                llenar();
                jimmy.grabarcuestionario();
                MessageBox.Show("La Cuestion ha sido Registrada", "CORRECTO");
            }
            catch (Exception)
            {
                MessageBox.Show("La Cuestion no ha sido Registrada", "ERROR");
                throw;
            }
        }
    }
}
