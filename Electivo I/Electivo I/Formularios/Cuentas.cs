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
    public partial class Cuentas : Form
    {
        //Formularios.Registrar_Cuentas cuenta = new Registrar_Cuentas();
        Clases.Cuentas jimmy = new Clases.Cuentas();
        public Cuentas()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string karma = txtbuscar.Text;
                dgdatos.DataSource = jimmy.Buscarcuenta(karma);
            }
            catch (Exception){

                MessageBox.Show("Se ha producido un error", "Error", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cuenta.ShowDialog();
        }

        private void Cuentas_Load(object sender, EventArgs e)
        {
            dgdatos.DataSource = jimmy.mostrarcuenta();
        }

        private void txtbuscar_Enter(object sender, EventArgs e)
        {
            if (txtbuscar.Text == "Ingrese el Cod. del Alumno/Admin")
            {
                txtbuscar.Text = "";
                txtbuscar.ForeColor = Color.White;
            }
        }

        private void txtbuscar_Leave(object sender, EventArgs e)
        {
            if (txtbuscar.Text == "Ingrese el Cod. del Alumno/Admin")
            {
                txtbuscar.Text = "";
                txtbuscar.ForeColor = Color.White;
            }
        }
    }
}
