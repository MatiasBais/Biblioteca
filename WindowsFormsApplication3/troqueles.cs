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
    public partial class troqueles : Form
    {
        public troqueles()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void asd() 
        {
            int soc1 = -10, soc2 = -10;
            try
            {
                soc1 = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
            }
            try
            {
                soc2 = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
            }
            if ((soc1 == -10 && soc2 == -10) || (soc1 == 0 && soc2 == 0))
            {
                MessageBox.Show("Ingrese al menos un socio");
            }
            else
            {
                try
                {
                    SistemaBiblioteca.socio1 = Convert.ToInt32(textBox1.Text);
                }
                catch
                {
                }
                try
                {
                    SistemaBiblioteca.socio2 = Convert.ToInt32(textBox2.Text);
                }
                catch
                {
                }
                try
                {
                    SistemaBiblioteca.cuota = Convert.ToInt32(textBox3.Text);
                }
                catch
                {
                }
                SistemaBiblioteca.estado = true;
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            asd();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void troqueles_Load(object sender, EventArgs e)
        {

        }
    }
}
