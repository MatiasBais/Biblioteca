using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class fichas : Form
    {
        public fichas()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            asd();
        }
        private void asd() 
        {
            if (textBox1.Text != "0" && textBox1.Text != ""&&textBox2.Text!= "0" && textBox2.Text != "")
            {
                if (Convert.ToInt32(textBox1.Text) <= Convert.ToInt32(textBox2.Text))
                {
                    SistemaBiblioteca.nroinventario = Convert.ToInt32(textBox1.Text);
                    SistemaBiblioteca.nroinventario2 = Convert.ToInt32(textBox2.Text);

                    SistemaBiblioteca.estado2 = true;
                    this.Close();
                }
                else
                    MessageBox.Show("El primer valor debe ser menor o igual al segundo");
            }
            else
            {
                MessageBox.Show("Ingrese un número válido");
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                asd();
            }
        }

        private void fichas_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                asd();
            }
        }
    }
}
