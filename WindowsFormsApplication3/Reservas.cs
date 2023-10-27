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
    public partial class Reservas : Form
    {
        public Reservas()
        {
            InitializeComponent();
        }
        MySqlConnection cnn = new MySqlConnection("database=bibliotecabd;data source=localhost;user id = root;password=root");
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox1.Enabled = true;
            else
                textBox1.Enabled = false;
            buscar();
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                textBox2.Enabled = true;
            else
                textBox2.Enabled = false;
            buscar();
        }
        private void Reservas_Load(object sender, EventArgs e)
        {
            try
            {
                //MySqlCommand cmd = new MySqlCommand("SELECT idReserva, reservas.NroInventario, titulo, reservas.NroSocio, socio.nombre as 'Nombre', Fecha, reservas.Estado FROM reservas, socio, libro where reservas.nrosocio=socio.nrosocio and reservas.nroinventario=libro.nroinventario and reservas.nrosocio=" + textBox2.Text + " and reservas.nroinventario=" + textBox1.Text, cnn);
                //cnn.Open();
                //MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //adp.Fill(dt);
                //dataGridView1.DataSource = dt;
                //cnn.Close();
                buscar();
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Width = 50;
                dataGridView1.Columns[3].Width = 50;
            }
            catch (Exception el)
            {
                MessageBox.Show(el + "");
            }

        }
        private void buscar()
        {
            if (textBox2.Text == "")
                return;
            if (textBox1.Text == "")
                return;
            string query = "SELECT idReserva, reservas.NroInventario, titulo, reservas.NroSocio, socio.nombre as 'Nombre', Fecha, reservas.Estado FROM reservas, socio, libro where reservas.nrosocio=socio.nrosocio and reservas.nroinventario=libro.nroinventario";
            if (checkBox1.Checked)
                query = query + " and reservas.nroinventario=" + textBox1.Text;
            if (checkBox2.Checked)
                query = query + " and reservas.nrosocio=" + textBox2.Text;
            query = query + queryy();
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            cnn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            cnn.Close();

        }
        private string queryy()
        {
            string hola = "";
            if (checkBox3.Checked && checkBox4.Checked && checkBox5.Checked)
                hola = " and (reservas.estado='En espera' or reservas.estado='Realizada' or reservas.estado='Cancelada')";
            else if (checkBox3.Checked && !checkBox4.Checked && checkBox5.Checked)
                hola = " and (reservas.estado='En espera' or reservas.estado='Realizada')";
            else if (checkBox3.Checked && checkBox4.Checked && !checkBox5.Checked)
                hola = " and (reservas.estado='En espera' or reservas.estado='Cancelada')";
            else if (checkBox3.Checked && !checkBox4.Checked && !checkBox5.Checked)
                hola = " and reservas.estado='En espera'";
            else if (!checkBox3.Checked && checkBox4.Checked && checkBox5.Checked)
                hola = " and (reservas.estado='Cancelada' or reservas.estado='Realizada')";
            else if (!checkBox3.Checked && checkBox4.Checked && !checkBox5.Checked)
                hola = " and reservas.estado='Cancelada'";
            else if (!checkBox3.Checked && !checkBox4.Checked && checkBox5.Checked)
                hola = " and reservas.estado='Realizada'";
            return hola;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            buscar();
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox3.Checked && !checkBox4.Checked && !checkBox5.Checked)
            {
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                return;
            }
            buscar();
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox3.Checked && !checkBox4.Checked && !checkBox5.Checked)
            {
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                return;
            }
            buscar();
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox3.Checked && !checkBox4.Checked && !checkBox5.Checked)
            {
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
            }
            buscar();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            buscar();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool existen = false;
            DialogResult DR = MessageBox.Show("Desea generar la reserva del libro Nro: "+textBox1.Text+" a nombre del socio Nro: "+textBox2.Text+"?", " ", MessageBoxButtons.YesNo);
            if (DR == DialogResult.Yes)
            {
                MySqlCommand cmd2 = new MySqlCommand("select * from socio where nrosocio=" + textBox2.Text, cnn);
                cnn.Open();
                MySqlDataReader reader = cmd2.ExecuteReader();
                if (reader.Read())
                {
                    MySqlConnection cnn2 = new MySqlConnection("database=bibliotecabd;data source=localhost;user id = root;password=root");
                    MySqlCommand cmd22 = new MySqlCommand("select * from libro where nroinventario=" + textBox1.Text, cnn2);
                    cnn2.Open();
                    MySqlDataReader reader2 = cmd22.ExecuteReader();
                    if (!reader2.Read())
                        MessageBox.Show("El libro no existe");
                    else
                        existen = true;
                    reader2.Close();
                    cnn2.Close();
                }
                else
                    MessageBox.Show("El socio no existe");
                
                reader.Close();
                cnn.Close();
                if (!existen)
                    return;
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into reservas(NroInventario,NroSocio)values('" + textBox1.Text + "', '" + textBox2.Text + "')", cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
                buscar();
            }

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var relativeMousePosition = dataGridView1.PointToClient(Cursor.Position);
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                contextMenuStrip1.Show(dataGridView1, relativeMousePosition);
            }
        }

        private void enEsperaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cnn.Open();
            MySqlCommand cmd = new MySqlCommand("update reservas set estado='En espera' where idReserva="+dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            buscar();
        }

        private void realizadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cnn.Open();
            MySqlCommand cmd = new MySqlCommand("update reservas set estado='Realizada' where idReserva=" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            buscar();
        }

        private void canceladaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cnn.Open();
            MySqlCommand cmd = new MySqlCommand("update reservas set estado='Cancelada' where idReserva=" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            buscar();
        }
    }
}
