using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class sociosmasactivos : Form
    {
        public sociosmasactivos()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
            else
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
            actualizar();
        }
        private void actualizar() 
        {
            try
            {
                string fechas = "";
                if (!checkBox1.Checked)
                {
                    string fecha1 = dateTimePicker1.Value.Year + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day;
                    string fecha2 = dateTimePicker2.Value.Year + "/" + dateTimePicker2.Value.Month + "/" + dateTimePicker2.Value.Day;
                    if (dateTimePicker1.Value.Date <= dateTimePicker2.Value.Date)
                    {
                        fechas = " and fechaprestacion between '" + fecha1 + "' and '" + fecha2 + "'";
                    }
                    else
                    {
                        fechas = " and fechaprestacion between '" + fecha2 + "' and '" + fecha1 + "'";
                    }
                }
                int limit = 0;
                if (textBox1.Text != "")
                    limit = Convert.ToInt32(textBox1.Text);
                string limitt = "";
                if (limit != 0)
                    limitt = "limit " + limit;

                MySqlConnection cnn = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root;password=root");
                MySqlCommand cmd = new MySqlCommand("SELECT prestamos.nrosocio, nombre, celular, count(prestamos.nrosocio) as Cantidad FROM prestamos, socio where prestamos.nrosocio = socio.nrosocio" + fechas + " group by prestamos.nrosocio order by Cantidad desc " + limitt, cnn);
                cnn.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                cnn.Close();
                dataGridView1.Columns[0].Width = 74;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 70;
                dataGridView1.Columns[1].Width = 270;
                dataGridView1.Columns[0].HeaderText = "NroSocio";
                dataGridView1.Columns[2].HeaderText = "Celular";
                dataGridView1.Columns[1].HeaderText = "Nombre";
            }
            catch (Exception el)
            {
                MessageBox.Show(el + "");
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
        }

        private void sociosmasactivos_Load(object sender, EventArgs e)
        {
            actualizar();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            actualizar();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            actualizar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            actualizar();
        }
    }
}
