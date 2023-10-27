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
    public partial class notas : Form
    {
        public notas()
        {
            InitializeComponent();
        }

        private void notas_Load(object sender, EventArgs e)
        {
            string conexion = "Database=bibliotecabd;Data source=localhost;User ID=root";
            MySqlConnection cnn = new MySqlConnection(conexion);
            cnn.Open();
            string consulta = "select * from usuarios where id_usuario="+Form1.idusuario;
            MySqlCommand data = new MySqlCommand(consulta, cnn);
            cnn.Close();
            cnn.Open();
            MySqlDataReader reader = data.ExecuteReader();
            if (reader.Read()) 
            {
                textBox1.Text = reader["Notas"].ToString();
            }
            cnn.Close();
            textBox1.Focus();
            if(textBox1.Text!="<Notas>")
                textBox1.SelectionStart = textBox1.TextLength;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string conexion = "Database=bibliotecabd;Data source=localhost;User ID=root";
            MySqlConnection cnn = new MySqlConnection(conexion);
            string consulta = "update usuarios set Notas='" + textBox1.Text + "' where id_usuario =" + Form1.idusuario;
            MySqlCommand data = new MySqlCommand(consulta, cnn);
            cnn.Open();
            data.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
