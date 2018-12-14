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
    public partial class Archivo : Form
    {
        public Archivo()
        {
            InitializeComponent();
        }

        private void AbrirFormPanel(object Formhijo)
        {
            if (this.PanelContenedor2.Controls.Count > 0)
                this.PanelContenedor2.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContenedor2.Controls.Add(fh);
            this.PanelContenedor2.Tag = fh;
            fh.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new TipoDocumento());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Profesiones());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Cuestionario());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Opciones());
        }
    }
}
