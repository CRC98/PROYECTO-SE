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
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
        }

        private void AbrirFormPanel(object Formhijo)
        {
            if (this.PanelContenedor3.Controls.Count > 0)
                this.PanelContenedor3.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContenedor3.Controls.Add(fh);
            this.PanelContenedor3.Tag = fh;
            fh.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Alumnos());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Administrador());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Invitados());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Cuentas());

        }
    }
}
