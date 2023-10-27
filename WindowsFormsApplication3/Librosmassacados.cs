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
    public partial class Librosmassacados : Form
    {
        public Librosmassacados()
        {
            InitializeComponent();
        }

        private void Librosmassacados_Load(object sender, EventArgs e)
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
                MySqlCommand cmd = new MySqlCommand("SELECT prestamos.nroinventario, titulo, clasificacion, count(prestamos.nroinventario) as Cantidad FROM prestamos, libro where prestamos.nroinventario = libro.nroinventario" + fechas + " group by prestamos.nroinventario order by Cantidad desc " + limitt, cnn);
                cnn.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                cnn.Close();
                dataGridView1.Columns[0].Width = 74;
                dataGridView1.Columns[2].Width = 70;
                dataGridView1.Columns[3].Width = 70;
                dataGridView1.Columns[1].Width = 300;
                dataGridView1.Columns[0].HeaderText = "NroInventario";
                dataGridView1.Columns[2].HeaderText = "Clasificación";
                dataGridView1.Columns[1].HeaderText = "Título";
            }
            catch (Exception el)
            {
                MessageBox.Show(el + "");
            }

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
                MySqlCommand cmd = new MySqlCommand("SELECT prestamos.nroinventario, titulo, clasificacion, count(prestamos.nroinventario) as Cantidad FROM prestamos, libro where prestamos.nroinventario = libro.nroinventario" + fechas + " group by prestamos.nroinventario order by Cantidad desc " + limitt, cnn); 
                cnn.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                cnn.Close();
                dataGridView1.Columns[0].Width = 74;
                dataGridView1.Columns[2].Width = 70;
                dataGridView1.Columns[3].Width = 70;
                dataGridView1.Columns[1].Width = 300;
                dataGridView1.Columns[0].HeaderText = "NroInventario";
                dataGridView1.Columns[2].HeaderText = "Clasificación";
                dataGridView1.Columns[1].HeaderText = "Título";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
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
                MySqlCommand cmd = new MySqlCommand("SELECT prestamos.nroinventario, titulo, clasificacion, count(prestamos.nroinventario) as Cantidad FROM prestamos, libro where prestamos.nroinventario = libro.nroinventario" + fechas + " group by prestamos.nroinventario order by Cantidad desc " + limitt, cnn);
                cnn.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                cnn.Close();
                dataGridView1.Columns[0].Width = 74;
                dataGridView1.Columns[2].Width = 70;
                dataGridView1.Columns[3].Width = 70;
                dataGridView1.Columns[1].Width = 300;
                dataGridView1.Columns[0].HeaderText = "NroInventario";
                dataGridView1.Columns[2].HeaderText = "Clasificación";
                dataGridView1.Columns[1].HeaderText = "Título";
            }
            catch (Exception el)
            {
                MessageBox.Show(el + "");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
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
                MySqlCommand cmd = new MySqlCommand("SELECT prestamos.nroinventario, titulo, clasificacion, count(prestamos.nroinventario) as Cantidad FROM prestamos, libro where prestamos.nroinventario = libro.nroinventario" + fechas + " group by prestamos.nroinventario order by Cantidad desc " + limitt, cnn); 
                cnn.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                cnn.Close();
                dataGridView1.Columns[0].Width = 74;
                dataGridView1.Columns[2].Width = 70;
                dataGridView1.Columns[3].Width = 70;
                dataGridView1.Columns[1].Width = 300;
                dataGridView1.Columns[0].HeaderText = "NroInventario";
                dataGridView1.Columns[2].HeaderText = "Clasificación";
                dataGridView1.Columns[1].HeaderText = "Título";
            }
            catch (Exception el)
            {
                MessageBox.Show(el + "");
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
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
                MySqlCommand cmd = new MySqlCommand("SELECT prestamos.nroinventario, titulo, clasificacion, count(prestamos.nroinventario) as Cantidad FROM prestamos, libro where prestamos.nroinventario = libro.nroinventario" + fechas + " group by prestamos.nroinventario order by Cantidad desc " + limitt, cnn);
                cnn.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                cnn.Close();
                dataGridView1.Columns[0].Width = 74;
                dataGridView1.Columns[2].Width = 70;
                dataGridView1.Columns[3].Width = 70;
                dataGridView1.Columns[1].Width = 300;
                dataGridView1.Columns[0].HeaderText = "NroInventario";
                dataGridView1.Columns[2].HeaderText = "Clasificación";
                dataGridView1.Columns[1].HeaderText = "Título";
            }
            catch (Exception el)
            {
                MessageBox.Show(el + "");
            }
        }
    }
}
