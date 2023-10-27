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
    public partial class Sociosddb : Form
    {
        public Sociosddb()
        {
            InitializeComponent();
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection("data source = localhost; database=bibliotecabd; user id=root;password=root");
            MySqlCommand cmd = new MySqlCommand("select `NroSocio`, `NroDocumento`, sociosddb.Nombre, `Direccion`, `Localidad`, `CodPostal`, `Provincia`, `TelFijo`, `Celular`, `Responsable` as 'Socio Responsable', `Autorizado1`, `Autorizado2`, `Autorizado3`, `Categorias`, `CuotasImpagas`, `Suspendido`, `FechaFinSusp`, `FechaNac`, `Nacionalidad`, sociosddb.idCobrador, `LugardeCobro`, `FechaAlta`, `Observaciones`, cobrador.Nombre as 'Cobrador' FROM `sociosddb` LEFT OUTER JOIN cobrador on sociosddb.idcobrador = cobrador.idcobrador where  sociosddb.nombre LIKE '%" + textBox18.Text + "%'", cnn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            cnn.Close();
        }

        private void Sociosddb_Load(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection("data source = localhost; database=bibliotecabd; user id=root;password=root");
            MySqlCommand cmd = new MySqlCommand("select `NroSocio`, `NroDocumento`, sociosddb.Nombre, `Direccion`, `Localidad`, `CodPostal`, `Provincia`, `TelFijo`, `Celular`, `Responsable` as 'Socio Responsable', `Autorizado1`, `Autorizado2`, `Autorizado3`, `Categorias`, `CuotasImpagas`, `Suspendido`, `FechaFinSusp`, `FechaNac`, `Nacionalidad`, sociosddb.idCobrador, `LugardeCobro`, `FechaAlta`, `Observaciones`, cobrador.Nombre as 'Cobrador' FROM `sociosddb` LEFT OUTER JOIN cobrador on sociosddb.idcobrador = cobrador.idcobrador where  sociosddb.nombre LIKE '%" + textBox18.Text + "%'", cnn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            cnn.Close();
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

            MySqlConnection cnn = new MySqlConnection("data source = localhost; database=bibliotecabd; user id=root;password=root");
            try
            {
                int nrosocio = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                MySqlCommand cmd2 = new MySqlCommand("insert into socio select * from sociosddb where NroSocio=" + nrosocio + ";delete from sociosddb where nrosocio=" + nrosocio, cnn);
                cnn.Open();
                cmd2.ExecuteNonQuery();
                cnn.Close();
                MySqlCommand cmd = new MySqlCommand("select `NroSocio`, `NroDocumento`, sociosddb.Nombre, `Direccion`, `Localidad`, `CodPostal`, `Provincia`, `TelFijo`, `Celular`, `Responsable` as 'Socio Responsable', `Autorizado1`, `Autorizado2`, `Autorizado3`, `Categorias`, `CuotasImpagas`, `Suspendido`, `FechaFinSusp`, `FechaNac`, `Nacionalidad`, sociosddb.idCobrador, `LugardeCobro`, `FechaAlta`, `Observaciones`, cobrador.Nombre as 'Cobrador' FROM `sociosddb` LEFT OUTER JOIN cobrador on sociosddb.idcobrador = cobrador.idcobrador where  sociosddb.nombre LIKE '%" + textBox18.Text + "%'", cnn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                dataGridView1.Columns[16].Visible = false;
                dataGridView1.Columns[18].Visible = false;
                dataGridView1.Columns[19].Visible = false;
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("Para poder restaurar el socio no debe existir ninguno con mismo número de socio");
                cnn.Close();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MySqlConnection cnn = new MySqlConnection("data source = localhost; database=bibliotecabd; user id=root;password=root");
            int nrosocio = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
            MySqlCommand cmd2 = new MySqlCommand("delete from sociosddb where nrosocio=" + nrosocio, cnn);
            cnn.Open();
            cmd2.ExecuteNonQuery();
            cnn.Close();
            MySqlCommand cmd = new MySqlCommand("select `NroSocio`, `NroDocumento`, sociosddb.Nombre, `Direccion`, `Localidad`, `CodPostal`, `Provincia`, `TelFijo`, `Celular`, `Responsable` as 'Socio Responsable', `Autorizado1`, `Autorizado2`, `Autorizado3`, `Categorias`, `CuotasImpagas`, `Suspendido`, `FechaFinSusp`, `FechaNac`, `Nacionalidad`, sociosddb.idCobrador, `LugardeCobro`, `FechaAlta`, `Observaciones`, cobrador.Nombre as 'Cobrador' FROM `sociosddb` LEFT OUTER JOIN cobrador on sociosddb.idcobrador = cobrador.idcobrador where  sociosddb.nombre LIKE '%" + textBox18.Text + "%'", cnn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            cnn.Close();
        }
    }
}
