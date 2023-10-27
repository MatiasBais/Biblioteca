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
    public partial class PRestamoporsocio : Form
    {
        public PRestamoporsocio()
        {
            InitializeComponent();
        }
        MySqlConnection cnn = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root");

        private void PRestamoporsocio_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].Visible = false;
            MySqlCommand cmd45 = new MySqlCommand("select * from socio limit 1", cnn);
            cnn.Open();
            MySqlDataReader reader45 = cmd45.ExecuteReader();

            while (reader45.Read())
            {
                
                textBox5.Text = (reader45["NroSocio"].ToString());
            }
            reader45.Close();
            cnn.Close();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            MySqlConnection cnn2 = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root");
            MySqlCommand cmd = new MySqlCommand("select * from socio where NroSocio=" + textBox5.Text, cnn2);
            cnn2.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBox1.Text = reader["Nombre"].ToString();
                textBox2.Text = reader["Direccion"].ToString();
                textBox3.Text = reader["Celular"].ToString();
                if (textBox3.Text == "")
                {
                    textBox3.Text = reader["TelFijo"].ToString();
                }
                if (textBox3.Text == "")
                {
                    textBox3.Text = "No tiene";
                }
            }
            else
            {
                if (suma)
                    textBox5.Text = (Convert.ToInt32(textBox5.Text) + 1).ToString();
                if (resta)
                    textBox5.Text = (Convert.ToInt32(textBox5.Text) - 1).ToString();
                suma = false;
                resta = false;
                return;
            }
            reader.Close();
            MySqlCommand cmd2 = new MySqlCommand("SELECT `idPrestamo`, `Devuelto`, `FechaPrestacion`, prestamos.`NroInventario`, Titulo, DiasDePrestamo FROM `prestamos`, `libro` WHERE  prestamos.NroInventario=libro.NroInventario and NroSocio =" + domainUpDown1.Text, cnn2);
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            int i = 0;
            while (reader2.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = reader2["idPrestamo"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = reader2["NroInventario"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = reader2["Titulo"].ToString();
                string fechap = reader2["FechaPrestacion"].ToString();
                string dev = reader2["Devuelto"].ToString();
                DateTime f = Convert.ToDateTime(fechap);
                double dias = Convert.ToDouble(reader2["DiasDePrestamo"].ToString());
                f = f.AddDays(dias);

                string[] fe = f.ToString().Split(' ');

                dataGridView1.Rows[i].Cells[3].Value = fe[0];
                if (dev == "Si")
                {
                    dataGridView1.Rows[i].Cells[4].Value = true;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[4].Value = false;
                }
                i++;
            }
            reader2.Close();
            cnn2.Close();
            suma = false;
            resta = false;
            
            
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                MySqlConnection cnn2 = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root");
                MySqlCommand cmd = new MySqlCommand("select * from socio where NroSocio=" + domainUpDown1.Text, cnn2);
                cnn2.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox1.Text = reader["Nombre"].ToString();
                    textBox2.Text = reader["Direccion"].ToString();
                    textBox3.Text = reader["Celular"].ToString();
                    if (textBox3.Text == "")
                    {
                        textBox3.Text = reader["TelFijo"].ToString();
                    }
                    if (textBox3.Text == "")
                    {
                        textBox3.Text = "No tiene";
                    }
                }
                else
                {
                    if (suma)
                        textBox5.Text = (Convert.ToInt32(textBox5.Text) + 1).ToString();
                    if (resta)
                        textBox5.Text = (Convert.ToInt32(textBox5.Text) - 1).ToString();
                    suma = false;
                    resta = false;
                    return;
                }
                reader.Close();
                MySqlCommand cmd2 = new MySqlCommand("SELECT `idPrestamo`, `Devuelto`, `FechaPrestacion`, prestamos.`NroInventario`, Titulo, DiasDePrestamo FROM `prestamos`, `libro` WHERE  prestamos.NroInventario=libro.NroInventario and NroSocio =" + domainUpDown1.Text + " order by FechaPrestacion desc limit 30", cnn2);
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                int i = 0;
                while (reader2.Read())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = reader2["idPrestamo"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = reader2["NroInventario"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = reader2["Titulo"].ToString();
                    string fechap = reader2["FechaPrestacion"].ToString();
                    string dev = reader2["Devuelto"].ToString();
                    DateTime f = Convert.ToDateTime(fechap);
                    double dias = Convert.ToDouble(reader2["DiasDePrestamo"].ToString());
                    f = f.AddDays(dias);

                    string[] fe = f.ToString().Split(' ');

                    dataGridView1.Rows[i].Cells[3].Value = fe[0];
                    if (dev == "Si")
                    {
                        dataGridView1.Rows[i].Cells[4].Value = true;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[4].Value = false;
                    }
                    i++;
                }
                reader2.Close();
                cnn2.Close();
                suma = false;
                resta = false;
            }
            catch 
            {
            }

        }
        bool resta = false;
        bool suma = false;
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type.ToString() == "SmallIncrement")
            {
                if (textBox5.Text == "1")
                    return;
                int i = Convert.ToInt32(textBox5.Text);
                int i2 = i - 1;
                textBox5.Text = i2.ToString();
                resta = true;
                //MessageBox.Show("abajo");
            }
            else if (e.Type.ToString() == "SmallDecrement")
            {
                int i = Convert.ToInt32(textBox5.Text);
                int i2 = i + 1;
                textBox5.Text = i2.ToString();
                suma = true;
                //MessageBox.Show("arriba");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
                return;
            textBox3.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
            domainUpDown1.Text = textBox5.Text;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
