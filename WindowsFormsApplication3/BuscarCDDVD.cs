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
    public partial class BuscarCDDVD : Form
    {
        public BuscarCDDVD()
        {
            InitializeComponent();
        }
        private void actualizar()
        {
            string tipo = "";
            if (comboBox1.SelectedIndex == 0)
                tipo = "";
            else if (comboBox1.SelectedIndex == 1)
                tipo = " and tipo='CD'";
            else
                tipo = " and tipo='DVD'";

            string query = "select * from cddvd where titulo like '%" + textBox1.Text + "%' and Materia LIKE '%" + textBox2.Text + "%' " + tipo;
            MySqlConnection cnn = new MySqlConnection("database=bibliotecabd;data source = localhost;user id=root;password=root");
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            cnn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            cnn.Close();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[19].Visible = false;
        }
        private void BuscarCDDVD_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            actualizar();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            actualizar();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            actualizar();
        }
    }
}
