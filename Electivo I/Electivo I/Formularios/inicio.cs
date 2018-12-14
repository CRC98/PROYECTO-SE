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
    public partial class inicio : Form
    {
        Formularios.Login menu = new Login();
        public inicio()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void inicio_Load(object sender, EventArgs e)
        {
            //label1.Parent = pictureBox1;
            //label1.BackColor = Color.Transparent;
        }
        public void fn_prbar_() {
            progressBar1.Increment(1);
            label1.Text = progressBar1.Value.ToString() + "%";
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                this.Hide();
                menu.Show();
            }
            //else {
            //    MessageBox.Show("Se ha producido un error");
            //}
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            fn_prbar_();
        }
    }
}
