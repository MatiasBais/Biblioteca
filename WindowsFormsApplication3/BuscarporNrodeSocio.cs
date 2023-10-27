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
    public partial class BuscarporNrodeSocio : Form
    {
        public BuscarporNrodeSocio()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection("data source = localhost; database=bibliotecabd; user id=root;password=root");
            MySqlCommand cmd = new MySqlCommand("select `NroSocio`, `NroDocumento`, socio.Nombre, `Direccion`, `Localidad`, `CodPostal`, `Provincia`, `TelFijo`, `Celular`, `Responsable` as 'Socio Responsable', `Autorizado1`, `Autorizado2`, `Autorizado3`, `Categorias`, `CuotasImpagas`, `Suspendido`, `FechaFinSusp`, `FechaNac`, `Nacionalidad`, socio.idCobrador, `LugardeCobro`, `FechaAlta`, `Observaciones`, cobrador.Nombre as 'Cobrador' FROM `socio` LEFT OUTER JOIN cobrador on socio.idcobrador = cobrador.idcobrador where  socio.nrosocio LIKE '%" + textBox1.Text + "%'", cnn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Visible = false;
            dataGridView1.Columns[22].Visible = false;
            cnn.Close();
        }

        private void BuscarporNrodeSocio_Load(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection("data source = localhost; database=bibliotecabd; user id=root;password=root");
            MySqlCommand cmd = new MySqlCommand("select `NroSocio`, `NroDocumento`, socio.Nombre, `Direccion`, `Localidad`, `CodPostal`, `Provincia`, `TelFijo`, `Celular`, `Responsable` as 'Socio Responsable', `Autorizado1`, `Autorizado2`, `Autorizado3`, `Categorias`, `CuotasImpagas`, `Suspendido`, `FechaFinSusp`, `FechaNac`, `Nacionalidad`, socio.idCobrador, `LugardeCobro`, `FechaAlta`, `Observaciones`, cobrador.Nombre as 'Cobrador' FROM `socio` LEFT OUTER JOIN cobrador on socio.idcobrador = cobrador.idcobrador where  socio.nrosocio LIKE '%" + textBox1.Text + "%'", cnn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Visible = false;
            dataGridView1.Columns[22].Visible = false;
            cnn.Close();
        }
    }
}
