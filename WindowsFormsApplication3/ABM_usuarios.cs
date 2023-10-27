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
    public partial class ABM_usuarios : Form
    {
        public ABM_usuarios()
        {
            InitializeComponent();
        }
        MySqlConnection cnn = new MySqlConnection("Database=bibliotecabd;Data source=localhost;User ID=root");

        private void Usuario_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void limpiar() 
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("insert into usuarios(nombre,contraseña,Permisos) values( '" + textBox1.Text + "','" + textBox2.Text + "' , '" + numericUpDown1.Value + "')", cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            actualizar();
            limpiar();
        }

        private void ABM_usuarios_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            try
            {
                string conexion = "Database=bibliotecabd;Data source=localhost;User ID=root";
                MySqlConnection cnn = new MySqlConnection(conexion);
                string consulta = "select * from usuarios";
                MySqlDataAdapter data = new MySqlDataAdapter(consulta, cnn);
                DataTable ds = new DataTable();
                data.Fill(ds);
                dataGridView1.DataSource = ds;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                cnn.Close();
            }
            catch (Exception asd) { MessageBox.Show(asd + ""); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void actualizar()
        {
            string conexion = "Database=bibliotecabd;Data source=localhost;User ID=root";
            MySqlConnection cnn = new MySqlConnection(conexion);
            string consulta = "select * from usuarios";
            MySqlDataAdapter data = new MySqlDataAdapter(consulta, cnn);
            DataTable ds = new DataTable();
            data.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            cnn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("update usuarios set Nombre = '" + textBox1.Text + "' , Contraseña = '" + textBox2.Text + "' , Permisos = " + numericUpDown1.Value + " where id_usuario ="+ numericUpDown2.Value, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            actualizar();
            limpiar();
            button1.Visible = true;
            button4.Visible = false;
            button3.Visible = false;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value);
            textBox1.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value);
            numericUpDown2.Value = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
            button1.Visible = false;
            button4.Visible = true;
            button3.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("delete from usuarios where Id_usuario = " + numericUpDown2.Value, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            actualizar();
            limpiar();
            button1.Visible = true;
            button4.Visible = false;
            button3.Visible = false;
        }

        private void Contraseña_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            button1.Visible = true;
            button4.Visible = false;
            button3.Visible = false;
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                numericUpDown1.Value = 1;
            else
                numericUpDown1.Value = 2;
        }
        }
    }

