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
    public partial class ABM_cobrador : Form
    {
        public ABM_cobrador()
        {
            InitializeComponent();
        }
        MySqlConnection cnn = new MySqlConnection("Database=bibliotecabd;Data source=localhost;User ID=root;password=root");

        private void button1_Click(object sender, EventArgs e)
        {
           MySqlCommand cmd= new MySqlCommand("insert into cobrador(nombre,telefono) values( '"+ textBox1.Text + "','" + textBox2.Text +"')", cnn);
           cnn.Open();
           cmd.ExecuteNonQuery();
           cnn.Close();
           actualizar();
           limpiar();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ABM_cobrador_Load(object sender, EventArgs e)
        {
            try
            {
                string conexion = "Database=bibliotecabd;Data source=localhost;User ID=root;password=root";
                MySqlConnection cnn = new MySqlConnection(conexion);
                string consulta = "select * from cobrador";
                MySqlDataAdapter data = new MySqlDataAdapter(consulta, cnn);
                DataTable ds = new DataTable();
                data.Fill(ds);
                dataGridView1.DataSource = ds;
                dataGridView1.Columns[0].Visible = false;
                cnn.Close();
            }
            catch (Exception asd) { MessageBox.Show(asd + ""); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
            textBox1.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value);
            textBox2.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value);
            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = true;
        }
        private void limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("update cobrador set nombre = '" + textBox1.Text + "' , telefono = '" + textBox2.Text +"' where idcobrador = " + numericUpDown1.Value, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            actualizar();
            limpiar();
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("delete from cobrador where idcobrador = " + numericUpDown1.Value, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            actualizar();
            limpiar();
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
        }
        private void actualizar()
        {
            string conexion = "Database=bibliotecabd;Data source=localhost;User ID=root;password=root";
            MySqlConnection cnn = new MySqlConnection(conexion);
            string consulta = "select * from cobrador";
            MySqlDataAdapter data = new MySqlDataAdapter(consulta, cnn);
            DataTable ds = new DataTable();
            data.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.Columns[0].Visible = false;
            cnn.Close();
        }

        private void ABM_cobrador_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void ABM_cobrador_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            limpiar();
        }
    }
}
