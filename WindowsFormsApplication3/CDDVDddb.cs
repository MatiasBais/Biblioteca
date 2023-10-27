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
    public partial class CDDVDddb : Form
    {
        public CDDVDddb()
        {
            InitializeComponent();
        }

        private void CDDVDddb_Load(object sender, EventArgs e)
        {

            comboBox1.SelectedIndex = 0;
            string tipo = "";
            if (comboBox1.SelectedIndex == 0)
                tipo = "";
            else if (comboBox1.SelectedIndex == 1)
                tipo = " and tipo='CD'";
            else
                tipo = " and tipo='DVD'";

            string query = "select * from cddvdddb where titulo like '%" + textBox1.Text + "%' and Materia LIKE '%" + textBox2.Text + "%' " + tipo;
            MySqlConnection cnn = new MySqlConnection("database=bibliotecabd;data source = localhost;user id=root");
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string tipo = "";
            if (comboBox1.SelectedIndex == 0)
                tipo = "";
            else if (comboBox1.SelectedIndex == 1)
                tipo = " and tipo='CD'";
            else
                tipo = " and tipo='DVD'";

            string query = "select * from cddvdddb where titulo like '%" + textBox1.Text + "%' and Materia LIKE '%" + textBox2.Text + "%' " + tipo;
            MySqlConnection cnn = new MySqlConnection("database=bibliotecabd;data source = localhost;user id=root");
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string tipo = "";
            if (comboBox1.SelectedIndex == 0)
                tipo = "";
            else if (comboBox1.SelectedIndex == 1)
                tipo = " and tipo='CD'";
            else
                tipo = " and tipo='DVD'";

            string query = "select * from cddvdddb where titulo like '%" + textBox1.Text + "%' and Materia LIKE '%" + textBox2.Text + "%' " + tipo;
            MySqlConnection cnn = new MySqlConnection("database=bibliotecabd;data source = localhost;user id=root");
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = "";
            if (comboBox1.SelectedIndex == 0)
                tipo = "";
            else if (comboBox1.SelectedIndex == 1)
                tipo = " and tipo='CD'";
            else
                tipo = " and tipo='DVD'";

            string query = "select * from cddvdddb where titulo like '%" + textBox1.Text + "%' and Materia LIKE '%" + textBox2.Text + "%' " + tipo;
            MySqlConnection cnn = new MySqlConnection("database=bibliotecabd;data source = localhost;user id=root");
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                var relativeMousePosition = dataGridView1.PointToClient(Cursor.Position);
                contextMenuStrip1.Show(dataGridView1, relativeMousePosition);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void restaurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                string query2 = "insert into cddvd select * from cddvdddb where id=" + id + " ; delete from cddvdddb where id=" + id;
                MySqlConnection cnn2 = new MySqlConnection("database=bibliotecabd;data source=localhost;user id=root");
                MySqlCommand cmd2 = new MySqlCommand(query2, cnn2);
                cnn2.Open();
                cmd2.ExecuteNonQuery();
                cnn2.Close();
                string tipo = "";
                if (comboBox1.SelectedIndex == 0)
                    tipo = "";
                else if (comboBox1.SelectedIndex == 1)
                    tipo = " and tipo='CD'";
                else
                    tipo = " and tipo='DVD'";

                string query = "select * from cddvdddb where titulo like '%" + textBox1.Text + "%' and Materia LIKE '%" + textBox2.Text + "%' " + tipo;
                MySqlConnection cnn = new MySqlConnection("database=bibliotecabd;data source = localhost;user id=root");
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

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
            string query2 = " delete from cddvdddb where id=" + id;
            MySqlConnection cnn2 = new MySqlConnection("database=bibliotecabd;data source=localhost;user id=root");
            MySqlCommand cmd2 = new MySqlCommand(query2, cnn2);
            cnn2.Open();
            cmd2.ExecuteNonQuery();
            cnn2.Close();
            string tipo = "";
            if (comboBox1.SelectedIndex == 0)
                tipo = "";
            else if (comboBox1.SelectedIndex == 1)
                tipo = " and tipo='CD'";
            else
                tipo = " and tipo='DVD'";

            string query = "select * from cddvdddb where titulo like '%" + textBox1.Text + "%' and Materia LIKE '%" + textBox2.Text + "%' " + tipo;
            MySqlConnection cnn = new MySqlConnection("database=bibliotecabd;data source = localhost;user id=root");
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
    }
}
