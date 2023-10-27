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
    public partial class ABM_Libros2 : Form
    {
        public ABM_Libros2()
        {
            InitializeComponent();
        }
        MySqlConnection l = new MySqlConnection("Server=127.0.0.1;database=bibliotecabd; uid=root;password=root;");
        private void loadd()
        {
            MySqlCommand cmd2 = new MySqlCommand("select * from libro where titulo LIKE '%"+textBox18.Text+"%'", l);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            numericUpDown3.Enabled = false;
            numericUpDown3.Value = 0;
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
        private void ABM_Libros_Load(object sender, EventArgs e)
        {
             
            
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 2;
            comboBox8.SelectedIndex = 0;
            comboBox9.SelectedIndex = 0;
            loadd();
            textBox14.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox14.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            addItems(DataCollection);
            textBox14.AutoCompleteCustomSource = DataCollection;
            textBox15.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox15.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection2 = new AutoCompleteStringCollection();
            addItems(DataCollection2);
            textBox15.AutoCompleteCustomSource = DataCollection2;
            textBox16.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox16.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection3 = new AutoCompleteStringCollection();
            addItems(DataCollection3);
            textBox16.AutoCompleteCustomSource = DataCollection3;
            textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection4 = new AutoCompleteStringCollection();
            addItems2(DataCollection4);
            textBox2.AutoCompleteCustomSource = DataCollection4;
            textBox11.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox11.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection5 = new AutoCompleteStringCollection();
            addItems3(DataCollection5);
            textBox11.AutoCompleteCustomSource = DataCollection5;
            textBox3.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox3.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection6 = new AutoCompleteStringCollection();
            addItems4(DataCollection6);
            textBox3.AutoCompleteCustomSource = DataCollection6;
            MySqlConnection cnn = new MySqlConnection("database=bibliotecabd; data source=localhost; user id=root;password=root");
            MySqlCommand cmd = new MySqlCommand("select avg(paginas) as caca from libro", cnn);
            cnn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                numericUpDown2.Value= Convert.ToInt32(reader["caca"]);
            }
            reader.Close();
            cnn.Close();

       
            

        }
        public void addItems4(AutoCompleteStringCollection col)
        {


            MySqlConnection cnn = new MySqlConnection("database=bibliotecabd; data source=localhost; user id=root;password=root");
            MySqlCommand cmd = new MySqlCommand("select materia from libro", cnn);
            cnn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                col.Add(reader[0].ToString());
            }
            reader.Close();
            cnn.Close();

        }
        public void addItems2(AutoCompleteStringCollection col)
        {


            MySqlConnection cnn = new MySqlConnection("database=bibliotecabd; data source=localhost; user id=root;password=root");
            MySqlCommand cmd = new MySqlCommand("select editorial from libro", cnn);
            cnn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                col.Add(reader[0].ToString());
            }
            reader.Close();
            cnn.Close();

        }
        public void addItems3(AutoCompleteStringCollection col)
        {


            MySqlConnection cnn = new MySqlConnection("database=bibliotecabd; data source=localhost; user id=root;password=root");
            MySqlCommand cmd = new MySqlCommand("select coleccion from libro", cnn);
            cnn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                col.Add(reader[0].ToString());
            }
            reader.Close();
            cnn.Close();

        }
        private void label22_Click(object sender, EventArgs e)
        {

        }
        private void limpiar() 
        {
            textBox1.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            numericUpDown1.Value = 0;
            MySqlConnection cnn = new MySqlConnection("database=bibliotecabd; data source=localhost; user id=root;password=root");
            MySqlCommand cmd = new MySqlCommand("select avg(paginas) as caca from libro", cnn);
            cnn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                numericUpDown2.Value = Convert.ToInt32(reader["caca"]);
            }
            reader.Close();
            cnn.Close();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                if (numericUpDown1.Value == 0)
                {
                    MySqlConnection cnn = new MySqlConnection("data source=localhost; database=bibliotecabd; user id=root;password=root");
                    cnn.Open();
                    String d = dateTimePicker1.Value.Year + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day;
                    String s = "INSERT INTO libro (Titulo, Editorial, Autor1, Autor2, Autor3, Materia, Clasificacion, LugardeEdicion, Edicion, Ilust, AnodeEdicion, Ubicacion, Paginas, Medida, Precio, ISBN, Coleccion, DiasdePrestamo, Edad, Color, Estado, Caracter, Observaciones, FechadeIngreso) values ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox14.Text + "', '" + textBox15.Text + "', '" + textBox16.Text + "', '" + textBox3.Text + "', '" + comboBox5.SelectedValue + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + comboBox6.SelectedValue + "', '" + textBox6.Text + "', '" + textBox7.Text + "', " + Convert.ToInt32(numericUpDown2.TextAlign) + ", '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "', '" + comboBox7.Text + "', " + Convert.ToInt32(numericUpDown3.Text) + ", '" + textBox12.Text + "', '" + comboBox8.Text + "', '" + comboBox9.Text + "', '" + textBox13.Text + "', '" + d + "')";
                    MySqlCommand cmd = new MySqlCommand(s, cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    loadd();
                }
                else
                {
                    MySqlConnection cnn = new MySqlConnection("data source=localhost; database=bibliotecabd; user id=root;password=root");
                    cnn.Open();
                    String d = dateTimePicker1.Value.Year + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day;
                    String s = "INSERT INTO libro (NroInventario, Titulo, Editorial, Autor1, Autor2, Autor3, Materia, Clasificacion, LugardeEdicion, Edicion, Ilust, AnodeEdicion, Ubicacion, Paginas, Medida, Precio, ISBN, Coleccion, DiasdePrestamo, Edad, Color, Estado, Caracter, Observaciones, FechadeIngreso) values ('" + numericUpDown1.Value + "' ,'" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox14.Text + "', '" + textBox15.Text + "', '" + textBox16.Text +"', '" + textBox3.Text + "', '" + comboBox5.SelectedValue + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + comboBox6.SelectedValue + "', '" + textBox6.Text + "', '" + textBox7.Text + "', " + Convert.ToInt32(numericUpDown2.TextAlign) + ", '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "', '" + comboBox7.Text + "', " + Convert.ToInt32(numericUpDown3.Text) + ", '" + textBox12.Text + "', '" + comboBox8.Text + "', '" + comboBox9.Text + "', '" + textBox13.Text + "', '" + d + "')";
                    MySqlCommand cmd = new MySqlCommand(s, cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    loadd();
                    
                }
                limpiar();
                button1.Visible = true;
                b_borrar.Visible = false;
                b_modificar.Visible = false;
                
            }

            


        private void b_modificar_Click(object sender, EventArgs e)
        {
            String d = dateTimePicker1.Value.Year + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day;
            l.Open();
            string es =  " UPDATE libro SET titulo= '"+ textBox1.Text +"',editorial='" + textBox2.Text +"',autor1='" + textBox14.Text + "',autor2='" + textBox15.Text + "',autor3='" + textBox16.Text + "', materia='" + textBox3.Text+"', clasificacion ='"+ comboBox5.Text +"',lugardeedicion ='"+ textBox4.Text+"',edicion='"+ textBox5.Text+"',ilust='"+ comboBox6.Text+"',anodeedicion='"+textBox6.Text+"',ubicacion ='" + textBox7.Text+"',paginas='" +numericUpDown2.Value+"',medida='"+textBox8.Text+"',precio='"+textBox9.Text+"',isbn='"+textBox10.Text+"',coleccion='"+textBox11.Text+"',diasdeprestamo= '"+comboBox7.Text+"',edad='"+numericUpDown3.Value+"',color='" + textBox12.Text+"',estado='"+comboBox8.Text+"',caracter='"+comboBox9.Text+"',observaciones='"+textBox13.Text+"',fechadeingreso='"+ d +"' where nroinventario= '"+ numericUpDown1.Value + "'";
            MySqlCommand cmd = new MySqlCommand(es, l);
            cmd.ExecuteNonQuery();

            numericUpDown1.Enabled = true;
            l.Close();
            limpiar();
            loadd();
            button1.Visible = true;
            b_borrar.Visible = false;
            b_modificar.Visible = false;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

          
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Visible = false;
            b_borrar.Visible = true;
            b_modificar.Visible = true;
            numericUpDown1.Text= dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            textBox14.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value);
            textBox15.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value);
            textBox16.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value);
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString();
            textBox17.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[7].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.ToString();
            textBox5.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[9].Value.ToString();
            comboBox6.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[10].Value.ToString();
            textBox6.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[11].Value.ToString();
            textBox7.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[12].Value.ToString();
            numericUpDown2.Text= dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[13].Value.ToString();
            textBox8.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[14].Value.ToString();
            textBox9.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[15].Value.ToString();
            textBox10.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[16].Value.ToString();
            textBox11.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[17].Value.ToString();
            comboBox7.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[18].Value.ToString();
            if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[19].Value.ToString() != "0" && dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[19].Value.ToString() != "")
            {
                numericUpDown3.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[19].Value.ToString();
                numericUpDown3.Enabled = true;
                checkBox1.Checked = true;
            }
            else 
            {
                numericUpDown3.Text = "0";
                numericUpDown3.Enabled = false;
                checkBox1.Checked = false;
            }
            textBox12.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[20].Value.ToString();
            comboBox8.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[21].Value.ToString();
            comboBox9.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[22].Value.ToString();
            textBox13.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[23].Value.ToString();
            string fecha = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[24].Value.ToString();
            DateTime fecha1 = Convert.ToDateTime(fecha);
            dateTimePicker1.Value = fecha1;
            numericUpDown1.Enabled = false;
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void b_borrar_Click(object sender, EventArgs e)
        {
            DialogResult DR = MessageBox.Show("¿Desea dar de baja el libro?", " ", MessageBoxButtons.YesNo);
            if (DR == DialogResult.Yes)
            {
                String d = dateTimePicker1.Value.Year + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day;
                MySqlConnection cnn = new MySqlConnection("server=127.0.0.1;database=bibliotecabd;uid=root;password=root");
                cnn.Open();
                string t = "Delete from librosddb where Nroinventario =" + numericUpDown1.Value+";insert into librosddb select * from libro where NroInventario=" + numericUpDown1.Value + ";delete from reservas where NroInventario=" + numericUpDown1.Value + " ;delete from prestamos where NroInventario=" + numericUpDown1.Value + " ;Delete from libro where Nroinventario =" + numericUpDown1.Value;
                MySqlCommand cmd = new MySqlCommand(t, cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
                loadd();
                limpiar();

                numericUpDown1.Enabled = true;
                button1.Visible = true;
                b_borrar.Visible = false;
                b_modificar.Visible = false;
            }



        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            


        }
        public void addItems(AutoCompleteStringCollection col)
        {
            
          
                MySqlConnection cnn = new MySqlConnection("database=bibliotecabd; data source=localhost; user id=root;password=root");
                MySqlCommand cmd = new MySqlCommand("select autor1 from libro union select autor2 from libro union select autor3 from libro", cnn);
                cnn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    col.Add(reader[0].ToString());
                }
                reader.Close();
                cnn.Close();
            
            


        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            comboBox5.Text =textBox17.Text; 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                numericUpDown3.Enabled = true;
            else
                numericUpDown3.Enabled = false;
            numericUpDown3.Value = 0;
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            loadd();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.Enter)
            {
                e.SuppressKeyPress = true;
                numericUpDown1.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
                textBox14.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value);
                textBox15.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value);
                textBox16.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value);
                textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString();
                textBox17.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[7].Value.ToString();
                textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.ToString();
                textBox5.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[9].Value.ToString();
                comboBox6.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[10].Value.ToString();
                textBox6.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[11].Value.ToString();
                textBox7.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[12].Value.ToString();
                numericUpDown2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[13].Value.ToString();
                textBox8.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[14].Value.ToString();
                textBox9.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[15].Value.ToString();
                textBox10.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[16].Value.ToString();
                textBox11.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[17].Value.ToString();
                comboBox7.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[18].Value.ToString();
                if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[19].Value.ToString() != "0" && dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[19].Value.ToString() != "")
                {
                    numericUpDown3.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[19].Value.ToString();
                    numericUpDown3.Enabled = true;
                }
                else
                {
                    numericUpDown3.Text = "0";
                    numericUpDown3.Enabled = false;
                }
                textBox12.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[20].Value.ToString();
                comboBox8.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[21].Value.ToString();
                comboBox9.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[22].Value.ToString();
                textBox13.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[23].Value.ToString();
                string fecha = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[24].Value.ToString();
                DateTime fecha1 = Convert.ToDateTime(fecha);
                dateTimePicker1.Value = fecha1;
                button1.Visible = false;
                b_borrar.Visible = true;
                b_modificar.Visible = true;

                numericUpDown1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();

            numericUpDown1.Enabled = true;
            button1.Visible = true;
            b_borrar.Visible = false;
            b_modificar.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}