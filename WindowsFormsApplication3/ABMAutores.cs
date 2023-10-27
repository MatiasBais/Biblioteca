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
    public partial class ABMAutores : Form
    {
        public ABMAutores()
        {
            InitializeComponent();
        }
        MySqlConnection cnn = new MySqlConnection("Database=bibliotecabd;Data source=localhost;User ID=root");
        private void actualizar()
        {
            string conexion = "Database=bibliotecabd;Data source=localhost;User ID=root";
            MySqlConnection cnn = new MySqlConnection(conexion);
            string consulta = "select * from autor where idAutor>2";
            MySqlDataAdapter data = new MySqlDataAdapter(consulta, cnn);
            DataTable ds = new DataTable();
            data.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.Columns[0].Visible = false;
        }

        private void ABMAutores_Load(object sender, EventArgs e)
        {
            try
            {
                string conexion = "Database=bibliotecabd;Data source=localhost;User ID=root";
                MySqlConnection cnn = new MySqlConnection(conexion);
                string consulta = "select * from autor where idAutor>2";
                MySqlDataAdapter data = new MySqlDataAdapter(consulta, cnn);
                DataTable ds = new DataTable();
                data.Fill(ds);
                dataGridView1.DataSource = ds;
                dataGridView1.Columns[0].Visible = false;
            }
            catch (Exception asd) { MessageBox.Show(asd + ""); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
             MySqlCommand cmd= new MySqlCommand("insert into autor(nombre) values( '"+ textBox1.Text + "')", cnn);
           cnn.Open();
           cmd.ExecuteNonQuery();
           cnn.Close();
           actualizar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("update autor set nombre = '" + textBox1.Text + "' where idautor = " + numericUpDown1.Value, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            actualizar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("delete from autor where idautor = " + numericUpDown1.Value, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            actualizar();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
            textBox1.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value);
        }

        }
    }

