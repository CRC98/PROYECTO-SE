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
    public partial class Menu : Form
    {
        Formularios.R_Test report = new R_Test();
        public Menu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 200)
            {
                MenuVertical.Width = 30;
            }
            else
            {
                MenuVertical.Width = 200;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelhora.Text = DateTime.Now.ToString("HH:mm:ss");
            labelfecha.Text = DateTime.Now.ToLongDateString();
        }

        private void AbrirFormPanel(object Formhijo)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(fh);
            this.PanelContenedor.Tag = fh;
            fh.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Archivo());
            pictureBox1.Enabled = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Usuario());
            pictureBox1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea Salir del Menu Administrador?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcion == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            report.ShowDialog();
            pictureBox1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Acerca_de());
            pictureBox1.Enabled = true;
        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelhora_Click(object sender, EventArgs e)
        {

        }
    }
}
