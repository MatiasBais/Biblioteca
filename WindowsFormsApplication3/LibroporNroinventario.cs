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
    public partial class LibroporNroinventario : Form
    {
        public LibroporNroinventario()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection("server=127.0.0.1;database=bibliotecabd;uid=root;password=root");
            cnn.Open();
            string f = "select NroInventario, Titulo, Editorial, Autor1, Autor2, Autor3, Ubicacion, clasificacion from libro where NroInventario like '%" + textBox1.Text + "%'";
            MySqlCommand cmd = new MySqlCommand(f, cnn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            adp.Fill(tb);
            cnn.Close();
            dataGridView1.DataSource = tb;
        }

        private void LibroporNroinventario_Load(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection("server=127.0.0.1;database=bibliotecabd;uid=root;password=root");
            cnn.Open();
            string f = "select NroInventario, Titulo, Editorial, Autor1, Autor2, Autor3, Ubicacion, clasificacion from libro where NroInventario like '%" + textBox1.Text + "%'";
            MySqlCommand cmd = new MySqlCommand(f, cnn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            adp.Fill(tb);
            cnn.Close();
            dataGridView1.DataSource = tb;
        }
    }
}
