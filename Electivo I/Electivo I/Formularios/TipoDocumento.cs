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
    public partial class TipoDocumento : Form
    {
        Formularios.Registrar_TipoDocumento doc = new Registrar_TipoDocumento();
        Clases.TipoDocumento jimmy = new Clases.TipoDocumento();
        public TipoDocumento()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doc.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string karma = txtbuscar.Text;
                dgdatos.DataSource = jimmy.Buscartipodoc(karma);
            }
            catch (Exception){
                MessageBox.Show("Se ha producido un error", "Error", MessageBoxButtons.OK);
            }
           
        }

        private void TipoDocumento_Load(object sender, EventArgs e)
        {
            dgdatos.DataSource = jimmy.mostrartipodoc();
        }

        private void txtbuscar_Leave(object sender, EventArgs e)
        {
            if (txtbuscar.Text == "Ingrese el Nombre del Documento")
            {
                txtbuscar.Text = "";
                txtbuscar.ForeColor = Color.White;
            }
        }

        private void txtbuscar_Enter(object sender, EventArgs e)
        {
            if (txtbuscar.Text == "Ingrese el Nombre del Documento")
            {
                txtbuscar.Text = "";
                txtbuscar.ForeColor = Color.White;
            }
        }
    }
}
