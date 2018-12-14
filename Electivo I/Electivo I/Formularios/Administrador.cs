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
    public partial class Administrador : Form
    {
        Formularios.Registrar_Administrador admin = new Registrar_Administrador();
        Clases.Administrador jimmy = new Clases.Administrador();
        string campito;
        public Administrador()
        {
            InitializeComponent();
        }
        public String nombre;
        public String tipo;
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string karma = txtbuscar.Text;
                dgdatos.DataSource = jimmy.Buscaradministrador(campito, karma);
            }
            catch (Exception){

                MessageBox.Show("Seleccione un metodo de Busqueda", "Error", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin.ShowDialog();
        }

        private void Administrador_Load(object sender, EventArgs e)
        {

            dgdatos.DataSource = jimmy.mostraradministrador();
        }

        private void txtbuscar_Enter(object sender, EventArgs e)
        {
            if (txtbuscar.Text == "Ingrese el Nom/Cod del Administrador")
            {
                txtbuscar.Text = "";
                txtbuscar.ForeColor = Color.White;
            }
        }

        private void txtbuscar_Leave(object sender, EventArgs e)
        {
            if (txtbuscar.Text == "Ingrese el Nom/Cod del Administrador")
            {
                txtbuscar.Text = "";
                txtbuscar.ForeColor = Color.White;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            campito = "a.nombre";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            campito = "a.cod_administrador";
        }

        private void dgdatos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int pos = dgdatos.CurrentRow.Index;

                tipo = Convert.ToString(dgdatos.Rows[pos].Cells[1].Value);
                nombre = Convert.ToString(dgdatos.Rows[pos].Cells[3].Value);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                throw;
            }

            txtbuscar.Text = "";

            this.Close();
        }
    }
}
