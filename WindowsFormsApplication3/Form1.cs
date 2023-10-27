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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int idusuario = 0;
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private DataTable cargar() 
        {
            string connectionstring = "Database=bibliotecabd;Data source=localhost;User ID=root";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            string consulta = "Select * from usuarios ";
            MySqlDataAdapter data = new MySqlDataAdapter(consulta, conn);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }
        private void permisos() 
        {

            string connectionstring = "Database=bibliotecabd;Data source=localhost;User ID=root";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            string query = "SELECT * FROM usuarios WHERE nombre='" + comboBox1.Text + "' and contraseña='" + textBox2.Text + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            
            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();
            string permisos = "";
        
            if (reader.Read())
            {
                permisos = Convert.ToString(reader["permisos"]);
                idusuario=Convert.ToInt32(reader["id_usuario"]);

            }
            else
            {
                MessageBox.Show("Contraseña incorrecta");
            }
            if (permisos == "1")
            {
                SistemaBiblioteca sis = new SistemaBiblioteca();
                this.Hide();
                sis.ShowDialog();
                if (asd)
                {
                    asd = false;
                    this.Show();
                    textBox2.Text = "";
                    return;
                }
                this.Close();
            }
            else if (permisos == "2")
            {
                Form2 sis = new Form2();
                this.Hide();
                sis.ShowDialog();
                if (asd)
                {
                    asd = false;
                    this.Show();
                    textBox2.Text = "";
                    return;
                }
                this.Close();
            }
            reader.Close();
            conn.Close();
        }
        public static bool asd = false;
        private void button1_Click(object sender, EventArgs e)
        {

            permisos();

            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = cargar();
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "nombre";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                permisos();
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                permisos();
            }
        }
    }
    }


