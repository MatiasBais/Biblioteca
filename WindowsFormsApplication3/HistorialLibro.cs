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
    public partial class HistorialLibro : Form
    {
        public HistorialLibro()
        {
            InitializeComponent();
        }
        List<string> lista = new List<string>();
        private void HistorialLibro_Load(object sender, EventArgs e)
        {
            
            
            MySqlConnection cnn = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root;password=root");
            string query = "select NroInventario from libro order by NroInventario limit 1";
            MySqlCommand cmd20 = new MySqlCommand(query, cnn);
            cnn.Open();
            MySqlDataReader reader45 = cmd20.ExecuteReader();

            if (reader45.Read())
            {
                
                textBox4.Text = (reader45["NroInventario"].ToString());
            }
            reader45.Close();
            cnn.Close();

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            MySqlConnection cnn2 = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root;password=root");
            MySqlCommand cmd = new MySqlCommand("select autor1, titulo, clasificacion from libro where Nroinventario=" + domainUpDown1.Text, cnn2);
            cnn2.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBox1.Text = reader["autor1"].ToString();
                textBox2.Text = reader["Titulo"].ToString();
                textBox3.Text = reader["clasificacion"].ToString();

            }
            else
            {
                if (suma)
                    textBox4.Text = (Convert.ToInt32(textBox4.Text) + 1).ToString();
                if (resta)
                    textBox4.Text = (Convert.ToInt32(textBox4.Text) - 1).ToString();
                suma = false;
                resta = false;
                return;
            }
            reader.Close();
            MySqlCommand cmd2 = new MySqlCommand("SELECT `idPrestamo`, `Devuelto`, `FechaPrestacion`, prestamos.`NroInventario`, Titulo, DiasDePrestamo, prestamos.NroSocio as Titicaca FROM `prestamos`, `libro` WHERE  prestamos.NroInventario=libro.NroInventario and prestamos.NroInventario =" + domainUpDown1.Text + " order by idPrestamo desc", cnn2);
            MySqlDataReader reader2 = cmd2.ExecuteReader();

            for (int i = 0; reader2.Read(); i++)
            {
                if (i < 10)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[1].Value = reader2["Titicaca"].ToString();
                    string fechap = reader2["FechaPrestacion"].ToString();
                    DateTime f = Convert.ToDateTime(fechap);
                    double dias = Convert.ToDouble(reader2["DiasDePrestamo"].ToString());
                    f = f.AddDays(dias);
                    string[] fe = f.ToString().Split(' ');
                    dataGridView1.Rows[i].Cells[0].Value = fe[0];
                }
                else if (i < 20)
                {
                    dataGridView1.Rows[i - 10].Cells[3].Value = reader2["Titicaca"].ToString();
                    string fechap = reader2["FechaPrestacion"].ToString();
                    DateTime f = Convert.ToDateTime(fechap);
                    double dias = Convert.ToDouble(reader2["DiasDePrestamo"].ToString());
                    f = f.AddDays(dias);
                    string[] fe = f.ToString().Split(' ');
                    dataGridView1.Rows[i - 10].Cells[2].Value = fe[0];
                }
                else if (i < 30)
                {
                    dataGridView1.Rows[i - 20].Cells[5].Value = reader2["Titicaca"].ToString();
                    string fechap = reader2["FechaPrestacion"].ToString();
                    DateTime f = Convert.ToDateTime(fechap);
                    double dias = Convert.ToDouble(reader2["DiasDePrestamo"].ToString());
                    f = f.AddDays(dias);
                    string[] fe = f.ToString().Split(' ');
                    dataGridView1.Rows[i - 20].Cells[4].Value = fe[0];
                }
            }
            

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {


            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                MySqlConnection cnn2 = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root;password=root");
                MySqlCommand cmd = new MySqlCommand("select autor1, titulo, clasificacion from libro where Nroinventario=" + domainUpDown1.Text, cnn2);
                cnn2.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox1.Text = reader["autor1"].ToString();
                    textBox2.Text = reader["Titulo"].ToString();
                    textBox3.Text = reader["clasificacion"].ToString();

                }
                else 
                {
                    if (suma)
                        textBox4.Text = (Convert.ToInt32(textBox4.Text) + 1).ToString();
                    if (resta)
                        textBox4.Text = (Convert.ToInt32(textBox4.Text) - 1).ToString();
                    suma = false;
                    resta = false;
                    return;
                }
                reader.Close();
                MySqlCommand cmd2 = new MySqlCommand("SELECT `idPrestamo`, `Devuelto`, `FechaPrestacion`, prestamos.`NroInventario`, Titulo, DiasDePrestamo, prestamos.NroSocio as Titicaca FROM `prestamos`, `libro` WHERE  prestamos.NroInventario=libro.NroInventario and prestamos.NroInventario =" + domainUpDown1.Text + " order by idPrestamo desc", cnn2);
                MySqlDataReader reader2 = cmd2.ExecuteReader();

                for (int i = 0; reader2.Read() && i<=30; i++)
                {
                    if (i < 10)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[1].Value = reader2["Titicaca"].ToString();
                        string fechap = reader2["FechaPrestacion"].ToString();
                        DateTime f = Convert.ToDateTime(fechap);
                        double dias = Convert.ToDouble(reader2["DiasDePrestamo"].ToString());
                        f = f.AddDays(dias);
                        string[] fe = f.ToString().Split(' ');
                        dataGridView1.Rows[i].Cells[0].Value = fe[0];
                    }
                    else if (i < 20)
                    {
                        dataGridView1.Rows[i - 10].Cells[3].Value = reader2["Titicaca"].ToString();
                        string fechap = reader2["FechaPrestacion"].ToString();
                        DateTime f = Convert.ToDateTime(fechap);
                        double dias = Convert.ToDouble(reader2["DiasDePrestamo"].ToString());
                        f = f.AddDays(dias);
                        string[] fe = f.ToString().Split(' ');
                        dataGridView1.Rows[i - 10].Cells[2].Value = fe[0];
                    }
                    else if (i < 30)
                    {
                        dataGridView1.Rows[i - 20].Cells[5].Value = reader2["Titicaca"].ToString();
                        string fechap = reader2["FechaPrestacion"].ToString();
                        DateTime f = Convert.ToDateTime(fechap);
                        double dias = Convert.ToDouble(reader2["DiasDePrestamo"].ToString());
                        f = f.AddDays(dias);
                        string[] fe = f.ToString().Split(' ');
                        dataGridView1.Rows[i - 20].Cells[4].Value = fe[0];
                    }
                }
                reader2.Close();
                cnn2.Close();
                suma = false;
                resta = false;
            }

            catch (Exception el)
            {
                // MessageBox.Show(el + "");
            }
        }
        bool suma = false;
        bool resta = false;
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type.ToString() == "SmallIncrement")
            {
                if (textBox4.Text == "1")
                    return;
                int i = Convert.ToInt32(textBox4.Text);
                int i2 = i-1;
                textBox4.Text = i2.ToString();
                resta = true;
                //MessageBox.Show("abajo");
            }
            else if (e.Type.ToString() == "SmallDecrement")
            {
                int i = Convert.ToInt32(textBox4.Text);
                int i2 = i+1;
                textBox4.Text = i2.ToString();
                suma = true;
                //MessageBox.Show("arriba");
            }
        }
        

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
                return;
            domainUpDown1.Text = textBox4.Text;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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
