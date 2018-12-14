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
    public partial class Registrar_Profesiones : Form
    {
        Clases.Profesiones jimmy = new Clases.Profesiones();
        public Registrar_Profesiones()
        {
            InitializeComponent();
        }
        private void llenar()
        {
            jimmy.Id = txtid.Text;
            jimmy.Nombre = txtnombre.Text;
            jimmy.Duracion = txtduracion.Text;
            jimmy.Descripcion = txtdescripcion.Text; ;
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
                jimmy.grabarcarrera();
                MessageBox.Show("El Alumno ha sido Registrado", "CORRECTO");
            }
            catch (Exception)
            {
                MessageBox.Show("El Alumno no ha sido Registrado", "ERROR");
                throw;
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            try
            {

                llenar();
                jimmy.modificarcarrera();
                MessageBox.Show("La carrera ha sido Modificada", "CORRECTO");
            }
            catch (Exception)
            {
                MessageBox.Show("La carrera no ha sido Modificada", "ERROR");
                throw;
            }
        }
    }
}
