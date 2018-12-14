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
    public partial class Registrar_Alumno : Form
    {
        Clases.Alumno jimmy = new Clases.Alumno();
        Formularios.Test test = new Test();
        public Registrar_Alumno()
        {
            InitializeComponent();
        }
        private void llenar()
        {
            
            jimmy.Codigo = txtcodigo.Text;
            jimmy.Talumno = txttalu.Text;
            jimmy.Tdocumento = txtidtipo.Text;
            jimmy.Documento = txtdocumento.Text; ;
            jimmy.Nombre = txtnombre.Text;
            jimmy.Apellido = txtapellido.Text;
            jimmy.Fec_nac = txtfecha.Text;
            jimmy.Curso = txtcurso.Text;
            jimmy.Telefono = txtdireccion.Text;
            jimmy.Correo = txtcorreo.Text;
            jimmy.Direccion = txtdireccion.Text;
        }
       
        private void btnregistrar_Click(object sender, EventArgs e)
        {
            try
            {
                llenar();
                jimmy.grabaralumno();
                MessageBox.Show("Su cuenta ha sido creada", "CORRECTO");
                
            }
            catch (Exception)
            {
                MessageBox.Show("Losiento, tiene espacios sin rellenar", "ERROR");
                throw;
            }
        }

        private void cbotipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbotipo.SelectedIndex > 0)
            {
                string[] valores = jimmy.selec(cbotipo.Text);
                txtidtipo.Text = valores[0];
            }
        }

        private void Registrar_Alumno_Load(object sender, EventArgs e)
        {
            jimmy.ComboTipDoc(cbotipo);
            jimmy.ComboTipAl(cbotipal);
            jimmy.Combocurso(cbogrado);
            jimmy.ComboUsuario(cbousuario);
            txttalu.Text = "2";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbotipal.SelectedIndex > 0)
            {
                string[] valores = jimmy.selec1(cbotipal.Text);
                txttalu.Text = valores[0];
            }
        }

        private void txttalu_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbogrado.SelectedIndex > 0)
            {
                string[] valores = jimmy.selec2(cbogrado.Text);
                txtcurso.Text = valores[0];
                //txtgrado.Text = valores[2];
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbousuario.SelectedIndex > 0)
            {
                string[] valores = jimmy.selec3(cbousuario.Text);
                txtid.Text = valores[0];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
