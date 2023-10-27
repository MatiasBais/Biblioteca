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
    public partial class ABM_socio : Form
    {
        public ABM_socio()
        {
            InitializeComponent();
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private DataTable cargarcobradores() 
        {
            string connectionstring = "Database=bibliotecabd;Data source=localhost;User ID=root;password=root";
            using (MySqlConnection conn = new MySqlConnection(connectionstring))
            {

                string query = "SELECT * FROM cobrador";
               MySqlDataAdapter cmd = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                cmd.Fill(dt);
                conn.Close();
                return dt;
                
            }
        }
        private void limpiar() 
        {
            textBox1.Clear();
            t_nombre.Clear();
            t_aut1.Clear();
            t_aut2.Clear();
            t_aut3.Clear();
            t_cel.Clear();
            t_cposta.Text = "2705";
            t_dir.Clear();
            t_dni.Clear();
            t_localidad.Text = "Rojas";
            t_lugardcobro.Clear();
            t_nac.Text = "Argentino";
            t_prov.Text = "Buenos Aires";
            t_tel.Clear();
            checkBox1.Checked = false;
            numericUpDown2.Value = 0;
        }
        private void ABM_socio_Load(object sender, EventArgs e)
        {
            c_cobrador.DataSource = cargarcobradores();
            c_cobrador.DisplayMember = "Nombre";
            c_cobrador.ValueMember = "idcobrador";
            cargardatos();
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 200;


            
            
        }
        private void cargardatos() 
        {
            MySqlConnection cnn = new MySqlConnection("data source = localhost; database=bibliotecabd; user id=root;password=root");
            MySqlCommand cmd = new MySqlCommand("select `NroSocio`, `NroDocumento`, socio.Nombre, `Direccion`, `Localidad`, `CodPostal`, `Provincia`, `TelFijo`, `Celular`, `Responsable` as 'Socio Responsable', `Autorizado1`, `Autorizado2`, `Autorizado3`, `Categorias`, `CuotasImpagas`, `Suspendido`, `FechaFinSusp`, `FechaNac`, `Nacionalidad`, socio.idCobrador, `LugardeCobro`, `FechaAlta`, `Observaciones`, cobrador.Nombre as 'Cobrador' FROM `socio` LEFT OUTER JOIN cobrador on socio.idcobrador = cobrador.idcobrador where  socio.nombre LIKE '%"+textBox2.Text + "%'", cnn);
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
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                c_resp.Enabled = true;
                string connectionstring = "Database=bibliotecabd;Data source=localhost;User ID=root;password=root";
                MySqlConnection conn = new MySqlConnection(connectionstring);
                string query = "SELECT * FROM socio order by Nombre";
                MySqlDataAdapter cmd = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                cmd.Fill(dt);
                c_resp.DataSource = dt;
                c_resp.ValueMember = "NroSocio";
                c_resp.DisplayMember = "Nombre";
                conn.Close();

            }
            else 
            {
                c_resp.Enabled = false;
                c_resp.DataSource = null;
                c_resp.ValueMember = null;
                c_resp.DisplayMember = null;
            }
        }
        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
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
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
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
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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
        //private void limpiar() 
        //{
        //    textBox1.Clear();
        //    t_tel.Clear();
        //    t_prov.Clear();
        //    t_nombre.Clear();
        //    t_nac.Clear();
        //    t_lugardcobro.Clear();
        //    t_localidad.Clear();
        //    t_dni.Clear();
        //    t_dir.Clear();
        //    t_cposta.Clear();
        //    t_cel.Clear();
        //    t_aut3.Clear();
        //    t_aut2.Clear();
        //    t_aut1.Clear();
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (numericUpDown2.Value != 0)
                {
                    String nacimiento = d_nac.Value.Year + "/" + d_nac.Value.Month + "/" + d_nac.Value.Day;
                    String alta = dateTimePicker2.Value.Year + "/" + dateTimePicker2.Value.Month + "/" + dateTimePicker2.Value.Day;
                    if (checkBox1.Checked == false)
                    {
                        MySqlConnection cnn = new MySqlConnection("data source=localhost; database=bibliotecabd; user id=root;password=root");
                        cnn.Open();
                        String s = "insert into socio (NroSocio, NroDocumento, Nombre, Direccion, Localidad, CodPostal, Provincia, TelFijo, Celular, Autorizado1, Autorizado2, Autorizado3, Categorias, CuotasImpagas, Suspendido, FechaNac, Nacionalidad, idCobrador, LugardeCobro, FechaAlta, Observaciones) Value ('" + numericUpDown2.Value + "', '" + t_dni.Text + "', '" + t_nombre.Text + "', '" + t_dir.Text + "', '" + t_localidad.Text + "', '" + t_cposta.Text + "', '" + t_prov.Text + "', '" + t_tel.Text + "', '" + t_cel.Text + "', '" + t_aut1.Text + "', '" + t_aut2.Text + "', '" + t_aut3.Text + "', '" + comboBox3.Text + "', '" + n_cuotasimpa.Value + "', 'No','" + nacimiento + "', '" + t_nac.Text + "', '" + c_cobrador.SelectedValue + "','" + t_lugardcobro.Text + "', '" + alta + "','" + textBox1.Text + "')";
                        MySqlCommand cmd = new MySqlCommand(s, cnn);
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                        cargardatos();
                        limpiar();
                    }
                    else
                    {
                        MySqlConnection cnn = new MySqlConnection("data source=localhost; database=bibliotecabd; user id=root;password=root");
                        cnn.Open();
                        String s = "insert into socio (NroSocio, NroDocumento, Nombre, Direccion, Localidad, CodPostal, Provincia, TelFijo, Celular, Autorizado1, Autorizado2, Autorizado3, Categorias, CuotasImpagas, Suspendido, FechaNac, Nacionalidad, idCobrador, LugardeCobro, FechaAlta, Observaciones, Responsable) Value ('" + numericUpDown2.Value + "', '" + t_dni.Text + "', '" + t_nombre.Text + "', '" + t_dir.Text + "', '" + t_localidad.Text + "', '" + t_cposta.Text + "', '" + t_prov.Text + "', '" + t_tel.Text + "', '" + t_cel.Text + "', '" + t_aut1.Text + "', '" + t_aut2.Text + "', '" + t_aut3.Text + "', '" + comboBox3.Text + "', '" + n_cuotasimpa.Value + "', 'No','" + nacimiento + "', '" + t_nac.Text + "', '" + c_cobrador.SelectedValue + "','" + t_lugardcobro.Text + "', '" + alta + "','" + textBox1.Text + "'," + c_resp.SelectedValue + ")";
                        MySqlCommand cmd = new MySqlCommand(s, cnn);
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                        cargardatos();
                        limpiar();
                    }
                }
                else
                {
                    String nacimiento = d_nac.Value.Year + "/" + d_nac.Value.Month + "/" + d_nac.Value.Day;
                    String alta = dateTimePicker2.Value.Year + "/" + dateTimePicker2.Value.Month + "/" + dateTimePicker2.Value.Day;
                    if (checkBox1.Checked == false)
                    {
                        MySqlConnection cnn = new MySqlConnection("data source=localhost; database=bibliotecabd; user id=root;password=root");
                        cnn.Open();
                        String s = "insert into socio (NroDocumento, Nombre, Direccion, Localidad, CodPostal, Provincia, TelFijo, Celular, Autorizado1, Autorizado2, Autorizado3, Categorias, CuotasImpagas, Suspendido, FechaNac, Nacionalidad, idCobrador, LugardeCobro, FechaAlta, Observaciones) Value ('" + t_dni.Text + "', '" + t_nombre.Text + "', '" + t_dir.Text + "', '" + t_localidad.Text + "', '" + t_cposta.Text + "', '" + t_prov.Text + "', '" + t_tel.Text + "', '" + t_cel.Text + "', '" + t_aut1.Text + "', '" + t_aut2.Text + "', '" + t_aut3.Text + "', '" + comboBox3.Text + "', '" + n_cuotasimpa.Value + "', 'No','" + nacimiento + "', '" + t_nac.Text + "', '" + c_cobrador.SelectedValue + "','" + t_lugardcobro.Text + "', '" + alta + "','" + textBox1.Text + "')";
                        MySqlCommand cmd = new MySqlCommand(s, cnn);
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                        cargardatos();
                        limpiar();
                    }
                    else
                    {
                        MySqlConnection cnn = new MySqlConnection("data source=localhost; database=bibliotecabd; user id=root;password=root");
                        cnn.Open();
                        String s = "insert into socio (NroDocumento, Nombre, Direccion, Localidad, CodPostal, Provincia, TelFijo, Celular, Autorizado1, Autorizado2, Autorizado3, Categorias, CuotasImpagas, Suspendido, FechaNac, Nacionalidad, idCobrador, LugardeCobro, FechaAlta, Observaciones, Responsable) Value ('" + t_dni.Text + "', '" + t_nombre.Text + "', '" + t_dir.Text + "', '" + t_localidad.Text + "', '" + t_cposta.Text + "', '" + t_prov.Text + "', '" + t_tel.Text + "', '" + t_cel.Text + "', '" + t_aut1.Text + "', '" + t_aut2.Text + "', '" + t_aut3.Text + "', '" + comboBox3.Text + "', '" + n_cuotasimpa.Value + "', 'No','" + nacimiento + "', '" + t_nac.Text + "', '" + c_cobrador.SelectedValue + "','" + t_lugardcobro.Text + "', '" + alta + "','" + textBox1.Text + "'," + c_resp.SelectedValue + ")";
                        MySqlCommand cmd = new MySqlCommand(s, cnn);
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                        cargardatos();
                        limpiar();
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Nro de socio ya utilizado");
            }
            numericUpDown2.Value = 0;

            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;


        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                String nacimiento = d_nac.Value.Year + "/" + d_nac.Value.Month + "/" + d_nac.Value.Day;
                String alta = dateTimePicker2.Value.Year + "/" + dateTimePicker2.Value.Month + "/" + dateTimePicker2.Value.Day;
                MySqlConnection cnn = new MySqlConnection("data source=localhost; database=bibliotecabd; user id=root;password=root");
                cnn.Open();
                String s = "UPDATE socio SET Responsable ='', NroDocumento='" + t_dni.Text + "', Nombre='" + t_nombre.Text + "', Direccion= '" + t_dir.Text + "', Localidad='" + t_localidad.Text + "', CodPostal= '" + t_cposta.Text + "', Provincia= '" + t_prov.Text + "', TelFijo= '" + t_tel.Text + "', Celular= '" + t_cel.Text + "', Autorizado1= '" + t_aut1.Text + "', Autorizado2= '" + t_aut2.Text + "', Autorizado3= '" + t_aut3.Text + "', Categorias= '" + comboBox3.Text + "', CuotasImpagas= '" + n_cuotasimpa.Value + "', FechaNac= '" + nacimiento + "', Nacionalidad= '" + t_nac.Text + "', idCobrador= '" + c_cobrador.SelectedValue + "', LugardeCobro= '" + t_lugardcobro.Text + "', FechaAlta= '" + alta + "', Observaciones= '" + textBox1.Text + "' where NroSocio = " + numericUpDown2.Value;
                MySqlCommand cmd = new MySqlCommand(s, cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
                cargardatos();
                limpiar();
            }
            else 
            {
                String nacimiento = d_nac.Value.Year + "/" + d_nac.Value.Month + "/" + d_nac.Value.Day;
                String alta = dateTimePicker2.Value.Year + "/" + dateTimePicker2.Value.Month + "/" + dateTimePicker2.Value.Day;
                MySqlConnection cnn = new MySqlConnection("data source=localhost; database=bibliotecabd; user id=root;password=root");
                cnn.Open();
                String s = "UPDATE socio SET  Responsable ='" + c_resp.SelectedValue + "', NroDocumento='" + t_dni.Text + "', Nombre='" + t_nombre.Text + "', Direccion= '" + t_dir.Text + "', Localidad='" + t_localidad.Text + "', CodPostal= '" + t_cposta.Text + "', Provincia= '" + t_prov.Text + "', TelFijo= '" + t_tel.Text + "', Celular= '" + t_cel.Text + "', Autorizado1= '" + t_aut1.Text + "', Autorizado2= '" + t_aut2.Text + "', Autorizado3= '" + t_aut3.Text + "', Categorias= '" + comboBox3.Text + "', CuotasImpagas= '" + n_cuotasimpa.Value + "', FechaNac= '" + nacimiento + "', Nacionalidad= '" + t_nac.Text + "', idCobrador= '" + c_cobrador.SelectedValue + "', LugardeCobro= '" + t_lugardcobro.Text + "', FechaAlta= '" + alta + "', Observaciones= '" + textBox1.Text + "' where NroSocio = " + numericUpDown2.Value;
                MySqlCommand cmd = new MySqlCommand(s, cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
                cargardatos();
                limpiar();
            }
            numericUpDown2.Value = 0;
            numericUpDown2.Enabled = true;
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
           numericUpDown2.Value = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
           t_dni.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
           t_nombre.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
           t_dir.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
           t_localidad.Text= dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();
           t_cposta.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString();
           t_prov.Text= dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString();
           t_tel.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[7].Value.ToString();
           t_cel.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.ToString();
           if (Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[9].Value) != "" && Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[9].Value) != "0")
           {
               c_resp.SelectedValue = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[9].Value);
               checkBox1.Checked = true;
           }
           else 
           {
               checkBox1.Checked = false;
           }
           t_aut1.Text= dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[10].Value.ToString();
           t_aut2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[11].Value.ToString();
           t_aut3.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[12].Value.ToString();
           comboBox3.Text= dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[13].Value.ToString();
           n_cuotasimpa.Text= dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[14].Value.ToString();
           string N= dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[17].Value.ToString();
           DateTime fecha = Convert.ToDateTime(N);
           d_nac.Value = fecha;
           t_nac.Text= dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[18].Value.ToString();
           c_cobrador.SelectedValue= Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[19].Value.ToString());
           t_lugardcobro.Text= dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[20].Value.ToString();
           string f=dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[21].Value.ToString();
           DateTime fecha1= Convert.ToDateTime(f);
           dateTimePicker2.Value= fecha1;
           textBox1.Text= dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[22].Value.ToString();
           numericUpDown2.Enabled = false;
           button1.Visible = false;
           button2.Visible = true;
           button3.Visible = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            String nacimiento = d_nac.Value.Year + "/" + d_nac.Value.Month + "/" + d_nac.Value.Day;
            String alta = dateTimePicker2.Value.Year + "/" + dateTimePicker2.Value.Month + "/" + dateTimePicker2.Value.Day;
            DialogResult DR = MessageBox.Show("¿Desea dar de baja el socio?", " ", MessageBoxButtons.YesNo);
            if (DR == DialogResult.Yes)
            {
                MySqlConnection cnn = new MySqlConnection("data source=localhost; database=bibliotecabd; user id=root;password=root");
                cnn.Open();
                String s = "delete from sociosddb where nrosocio="+numericUpDown2.Value+";insert into sociosddb select * from socio where NroSocio=" + numericUpDown2.Value + ";delete from reservas where NroSocio=" + numericUpDown2.Value + "; delete from prestamos where NroSocio=" + numericUpDown2.Value + " ;delete from socio where NroSocio =" + numericUpDown2.Value;
                MySqlCommand cmd = new MySqlCommand(s, cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
                cargardatos();
                numericUpDown2.Value = 0;
                limpiar();

                numericUpDown2.Enabled = true;
                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                e.SuppressKeyPress = true;
                numericUpDown2.Value = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                t_dni.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
                t_nombre.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
                t_dir.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
                t_localidad.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();
                t_cposta.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString();
                t_prov.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString();
                t_tel.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[7].Value.ToString();
                t_cel.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.ToString();
                if (Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[9].Value) != "")
                {
                    c_resp.SelectedValue = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[9].Value);
                }
                t_aut1.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[10].Value.ToString();
                t_aut2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[11].Value.ToString();
                t_aut3.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[12].Value.ToString();
                comboBox3.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[13].Value.ToString();
                n_cuotasimpa.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[14].Value.ToString();
                string N = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[17].Value.ToString();
                DateTime fecha = Convert.ToDateTime(N);
                d_nac.Value = fecha;
                t_nac.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[18].Value.ToString();
                c_cobrador.SelectedValue = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[19].Value.ToString());
                t_lugardcobro.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[20].Value.ToString();
                string f = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[21].Value.ToString();
                DateTime fecha1 = Convert.ToDateTime(f);
                dateTimePicker2.Value = fecha1;
                textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[22].Value.ToString();
                numericUpDown2.Enabled = false;
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = true;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            limpiar();

            numericUpDown2.Enabled = true;
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            cargardatos();
        }
        public static int ssnrosocio = 0;
        private void suspenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ssnrosocio = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
            suspension2 ada = new suspension2();
            ada.ShowDialog();
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
    }
}
