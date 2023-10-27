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
    public partial class LibroPorAutor : Form
    {
        public LibroPorAutor()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
                MySqlConnection cnn = new MySqlConnection("server=127.0.0.1;database=bibliotecabd;uid=root;pwd=");
                cnn.Open();
                string f = "select NroInventario, Titulo, Editorial, Autor1, Autor2, Autor3, Ubicacion, clasificacion from libro where (Autor1 LIKE '%" + textBox1.Text + "%' or Autor2 LIKE '%" + textBox1.Text + "%' or Autor3 LIKE '%" + textBox1.Text + "%')";
                MySqlCommand cmd = new MySqlCommand(f, cnn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable tb = new DataTable();
                adp.Fill(tb);
                cnn.Close();
                dataGridView1.DataSource = tb;
            
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LibroPorAutor_Load(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection("server=127.0.0.1;database=bibliotecabd;uid=root;pwd=");
            cnn.Open();
            string f = "select NroInventario, Titulo, Editorial, Autor1, Autor2, Autor3, Ubicacion, clasificacion from libro where (Autor1 LIKE '%" + textBox1.Text + "%' or Autor2 LIKE '%" + textBox1.Text + "%' or Autor3 LIKE '%" + textBox1.Text + "%')";
            MySqlCommand cmd = new MySqlCommand(f, cnn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            adp.Fill(tb);
            cnn.Close();
            dataGridView1.DataSource = tb;
        }
    }
}
