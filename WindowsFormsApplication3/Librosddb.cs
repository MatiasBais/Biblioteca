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
    public partial class Librosddb : Form
    {
        public Librosddb()
        {
            InitializeComponent();
        }
        MySqlConnection l = new MySqlConnection("Server=127.0.0.1;database=bibliotecabd; uid=root;pwd=;;");

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            MySqlCommand cmd2 = new MySqlCommand("select * from librosddb where titulo LIKE '%" + textBox18.Text + "%'", l);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Visible = false;
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].Visible = false;
            dataGridView1.Columns[24].Visible = false;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[7].Width = 50;
            dataGridView1.Columns[1].Width = 200;
            l.Close();
        }

        private void Librosddb_Load(object sender, EventArgs e)
        {
            MySqlCommand cmd2 = new MySqlCommand("select * from librosddb where titulo LIKE '%" + textBox18.Text + "%'", l);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Visible = false;
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].Visible = false;
            dataGridView1.Columns[24].Visible = false;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[7].Width = 50;
            dataGridView1.Columns[1].Width = 200;
            l.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void restaurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int nroinventario = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                MySqlCommand cmd = new MySqlCommand("insert into libro select * from librosddb where NroInventario=" + nroinventario + ";delete from librosddb where nroinventario=" + nroinventario, l);
                l.Open();
                cmd.ExecuteNonQuery();
                l.Close();
                MySqlCommand cmd2 = new MySqlCommand("select * from librosddb where titulo LIKE '%" + textBox18.Text + "%'", l);
                MySqlDataAdapter adp2 = new MySqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                adp2.Fill(dt2);
                dataGridView1.DataSource = dt2;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                dataGridView1.Columns[18].Visible = false;
                dataGridView1.Columns[19].Visible = false;
                dataGridView1.Columns[20].Visible = false;
                dataGridView1.Columns[21].Visible = false;
                dataGridView1.Columns[22].Visible = false;
                dataGridView1.Columns[23].Visible = false;
                dataGridView1.Columns[24].Visible = false;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[7].Width = 50;
                dataGridView1.Columns[1].Width = 200;
                l.Close();
            }
            catch 
            {
                MessageBox.Show("Para poder restaurar el libro no tiene que existir ninguno con mismo número de inventario");
                l.Close();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int nroinventario = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
            MySqlCommand cmd = new MySqlCommand("delete from librosddb where nroinventario=" + nroinventario, l);
            l.Open();
            cmd.ExecuteNonQuery();
            l.Close();
            MySqlCommand cmd2 = new MySqlCommand("select * from librosddb where titulo LIKE '%" + textBox18.Text + "%'", l);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Visible = false;
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].Visible = false;
            dataGridView1.Columns[24].Visible = false;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[7].Width = 50;
            dataGridView1.Columns[1].Width = 200;
            l.Close();
        }
    }
}
