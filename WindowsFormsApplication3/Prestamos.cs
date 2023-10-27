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
    public partial class Prestamos : Form
    {
        public Prestamos()
        {
            InitializeComponent();
        }
       
        public static int gnrosocio;

        MySqlConnection cnn = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root");
       
        private void Prestamos_Load(object sender, EventArgs e)
        {
            textBox5.Text = "1";

            dataGridView1.Columns[0].Visible = false;
            MySqlCommand cmd45 = new MySqlCommand("select * from socio limit 1", cnn);
            cnn.Open();
            MySqlDataReader reader45 = cmd45.ExecuteReader();

            while (reader45.Read())
            {
                
               textBox5.Text = (reader45["NroSocio"].ToString());
               domainUpDown1.Text = textBox5.Text;
            }
            reader45.Close();
            cnn.Close();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            MySqlConnection cnn2 = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root");
            MySqlCommand cmd = new MySqlCommand("select * from socio where NroSocio=" + textBox5.Text, cnn2);
            cnn2.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBox1.Text = reader["Nombre"].ToString();
                textBox2.Text = reader["Direccion"].ToString();
                textBox3.Text = reader["Celular"].ToString();
                dataGridView1.Rows.Clear();
                if (textBox3.Text == "")
                {
                    textBox3.Text = reader["TelFijo"].ToString();
                }
                if (textBox3.Text == "")
                {
                    textBox3.Text = "No tiene";
                }
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                if (suma)
                    textBox5.Text = (Convert.ToInt32(textBox5.Text) + 1).ToString();
                if (resta)
                    textBox5.Text = (Convert.ToInt32(textBox5.Text) - 1).ToString();
                suma = false;
                resta = false;
                return;
            }
            reader.Close();
            cnn2.Close();
            MySqlCommand cmd2 = new MySqlCommand("SELECT `idPrestamo`, `Devuelto`, `FechaPrestacion`, prestamos.`NroInventario`, Titulo, DiasDePrestamo FROM `prestamos`, `libro` WHERE  prestamos.NroInventario=libro.NroInventario and NroSocio =" + domainUpDown1.Text + " order by FechaPrestacion desc limit 30", cnn2);
            cnn2.Open();
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            int i = 0;
            while (reader2.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = reader2["idPrestamo"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = reader2["NroInventario"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = reader2["Titulo"].ToString();
                string fechap = reader2["FechaPrestacion"].ToString();
                string dev = reader2["Devuelto"].ToString();
                DateTime f = Convert.ToDateTime(fechap);
                double dias = Convert.ToDouble(reader2["DiasDePrestamo"].ToString());
                f = f.AddDays(dias);

                string[] fe = f.ToString().Split(' ');

                dataGridView1.Rows[i].Cells[3].Value = fe[0];
                if (dev == "Si")
                {
                    dataGridView1.Rows[i].Cells[4].Value = true;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[4].Value = false;
                }
                i++;
            }
            reader2.Close();
            cnn2.Close();
            suma = false;
            resta = false;
            actualizar();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void b_agregar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("Seleccione un socio válido");
                return;
 
            }
            MySqlConnection cnn12 = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root");
            MySqlCommand cmd = new MySqlCommand("select * from socio where NroSocio="+domainUpDown1.Text, cnn12);
            cnn12.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                string susp = reader["Suspendido"].ToString();
                if (susp == "Si")
                {
                    string fecha = reader["FechaFinSusp"].ToString();
                    MessageBox.Show("Usuario suspendido hasta " + fecha + ". Imposible otorgar préstamo");
                }
                else 
                {
                    MySqlConnection cnn13 = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root");
                    MySqlCommand cmd2 = new MySqlCommand("select * from prestamos where Devuelto='No' and NroSocio=" + domainUpDown1.Text, cnn13);
                    cnn13.Open();
                    MySqlDataReader reader2 = cmd2.ExecuteReader();
                    int cantidadlibros = 0;
                    while (reader2.Read()) 
                    {
                        cantidadlibros++;
                    }
                    reader2.Close();
                    cnn13.Close();
                    MySqlConnection cnn14 = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root");
                    MySqlCommand cmd5 = new MySqlCommand("select * from parametros", cnn14);
                    cnn14.Open();
                    MySqlDataReader reader5 = cmd5.ExecuteReader();
                    if (reader5.Read())
                    {

                        if (cantidadlibros >= Convert.ToInt32(reader5["CLibrosPrestamo"]))
                        {
                            if (cantidadlibros == 1)
                            {
                                MessageBox.Show("El socio ya tiene 1 libro en su posesión");
                            }
                            else
                            {
                                MessageBox.Show("El socio ya tiene " + cantidadlibros + " libros en su posesión");
                            }
                        }
                        else
                        {
                            groupBox1.Visible = true;
                        }
                        
                    }
                    reader5.Close();
                    cnn14.Close();
                }
            }
            reader.Close();
            cnn12.Close();    
        }
        private void actualizar() 
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                MySqlConnection cnn2 = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root");
                MySqlCommand cmd = new MySqlCommand("select * from socio where NroSocio=" + textBox5.Text, cnn2);
                cnn2.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox1.Text = reader["Nombre"].ToString();
                    textBox2.Text = reader["Direccion"].ToString();
                    textBox3.Text = reader["Celular"].ToString();
                    if (textBox3.Text == "")
                    {
                        textBox3.Text = reader["TelFijo"].ToString();
                    }
                    if (textBox3.Text == "")
                    {
                        textBox3.Text = "No tiene";
                    }
                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    if (suma)
                        textBox5.Text = (Convert.ToInt32(textBox5.Text) + 1).ToString();
                    if (resta)
                        textBox5.Text = (Convert.ToInt32(textBox5.Text) - 1).ToString();
                    suma = false;
                    resta = false;
                    return;
                }
                reader.Close();
                cnn2.Close();
                MySqlCommand cmd2 = new MySqlCommand("SELECT `idPrestamo`, `Devuelto`, `FechaPrestacion`, prestamos.`NroInventario`, Titulo, DiasDePrestamo FROM `prestamos`, `libro` WHERE  prestamos.NroInventario=libro.NroInventario and NroSocio =" + domainUpDown1.Text + " order by FechaPrestacion desc limit 30", cnn2);
                cnn2.Open();
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                int i = 0;
                while (reader2.Read())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = reader2["idPrestamo"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = reader2["NroInventario"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = reader2["Titulo"].ToString();
                    string fechap = reader2["FechaPrestacion"].ToString();
                    string dev = reader2["Devuelto"].ToString();
                    DateTime f = Convert.ToDateTime(fechap);
                    double dias = Convert.ToDouble(reader2["DiasDePrestamo"].ToString());
                    f = f.AddDays(dias);

                    string[] fe = f.ToString().Split(' ');

                    dataGridView1.Rows[i].Cells[3].Value = fe[0];
                    if (dev == "Si")
                    {
                        dataGridView1.Rows[i].Cells[4].Value = true;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[4].Value = false;
                    }
                    i++;
                }
                reader2.Close();
                cnn2.Close();
                suma = false;
                resta = false;
            }
            catch (Exception el) 
            {
                MessageBox.Show(el + "");
            }
        }
        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            if (domainUpDown1.Text == "")
                return;
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                MySqlConnection cnn2 = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root");
                MySqlCommand cmd = new MySqlCommand("select * from socio where NroSocio=" + domainUpDown1.Text, cnn2);
                cnn2.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox1.Text = reader["Nombre"].ToString();
                    textBox2.Text = reader["Direccion"].ToString();
                    textBox3.Text = reader["Celular"].ToString();
                    if (textBox3.Text == "")
                    {
                        textBox3.Text = reader["TelFijo"].ToString();
                    }
                    if (textBox3.Text == "")
                    {
                        textBox3.Text = "No tiene";
                    }
                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    if (suma)
                        textBox5.Text = (Convert.ToInt32(textBox5.Text) + 1).ToString();
                    if (resta)
                        textBox5.Text = (Convert.ToInt32(textBox5.Text) - 1).ToString();
                    suma = false;
                    resta = false;
                    return;
                }
                reader.Close();
                cnn2.Close();
                MySqlCommand cmd2 = new MySqlCommand("SELECT `idPrestamo`, `Devuelto`, `FechaPrestacion`, prestamos.`NroInventario`, Titulo, DiasDePrestamo FROM `prestamos`, `libro` WHERE  prestamos.NroInventario=libro.NroInventario and NroSocio =" + domainUpDown1.Text + " order by FechaPrestacion desc limit 30", cnn2);
                cnn2.Open();
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                int i = 0;
                while (reader2.Read())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = reader2["idPrestamo"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = reader2["NroInventario"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = reader2["Titulo"].ToString();
                    string fechap = reader2["FechaPrestacion"].ToString();
                    string dev = reader2["Devuelto"].ToString();
                    DateTime f = Convert.ToDateTime(fechap);
                    double dias = Convert.ToDouble(reader2["DiasDePrestamo"].ToString());
                    f = f.AddDays(dias);

                    string[] fe = f.ToString().Split(' ');

                    dataGridView1.Rows[i].Cells[3].Value = fe[0];
                    if (dev == "Si")
                    {
                        dataGridView1.Rows[i].Cells[4].Value = true;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[4].Value = false;
                    }
                    i++;
                }
                reader2.Close();
                cnn2.Close();
                suma = false;
                resta = false;
            }
            catch (Exception el)
            {
                MessageBox.Show(el + "");
            }

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private void cambiarEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MySqlConnection cnn12 = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root");
       
                string q="";
                if (Convert.ToBoolean(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value) == true)
                {
                    q = "Update prestamos set Devuelto='No' where idPrestamo=" + Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                    DataGridViewCheckBoxCell holis = (DataGridViewCheckBoxCell)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4];
                    holis.Value = false;
                }
                else
                {
                    q = "Update prestamos set Devuelto='Si' where idPrestamo=" + Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                    DataGridViewCheckBoxCell holis = (DataGridViewCheckBoxCell)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4];
                    holis.Value = true;
                    DateTime hoy = DateTime.Today.Date;
                    DateTime fechadev = Convert.ToDateTime(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value);
                    if (hoy > fechadev)
                    {
                        gnrosocio = Convert.ToInt32(domainUpDown1.Text);
                        suspension asd = new suspension();
                        asd.ShowDialog();

                    }

                }
                if (q != "")
                {
                    cnn12.Open();
                    MySqlCommand cmd = new MySqlCommand(q, cnn12);
                    cmd.ExecuteNonQuery();
                    cnn12.Close();
                }
                groupBox1.Visible = false;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4) 
            {
                MySqlConnection cnn12 = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root");

                string q = "";
                if (Convert.ToBoolean(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value) == true)
                {
                    q = "Update prestamos set Devuelto='No' where idPrestamo=" + Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                    DataGridViewCheckBoxCell holis = (DataGridViewCheckBoxCell)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4];
                    holis.Value = false;
                }
                else
                {
                    q = "Update prestamos set Devuelto='Si' where idPrestamo=" + Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                    DataGridViewCheckBoxCell holis = (DataGridViewCheckBoxCell)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4];
                    holis.Value = true;
                    DateTime hoy = DateTime.Today.Date;
                    DateTime fechadev = Convert.ToDateTime(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value);
                    if (hoy > fechadev)
                    {
                        gnrosocio = Convert.ToInt32(domainUpDown1.Text);
                        suspension asd = new suspension();
                        asd.ShowDialog();

                    }

                }
                if (q != "")
                {
                    cnn12.Open();
                    MySqlCommand cmd = new MySqlCommand(q, cnn12);
                    cmd.ExecuteNonQuery();
                    cnn12.Close();
                }
                groupBox1.Visible = false;
            }
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

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlConnection cnn12 = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root");
       
            cnn12.Open();
            string q;
            q = "Delete from prestamos  where idPrestamo=" + Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);     
            MySqlCommand cmd = new MySqlCommand(q, cnn12);
            cmd.ExecuteNonQuery();
            cnn12.Close();
            domainUpDown1.Text = textBox5.Text;
            actualizar();
            groupBox1.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection cnn133 = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root");
                MySqlCommand cmd23 = new MySqlCommand("select idReserva, libro.NroInventario, libro.Titulo, socio.NroSocio, socio.nombre as 'Nombre', socio.Celular from libro, socio, reservas where socio.nrosocio=reservas.nrosocio and libro.nroinventario=reservas.nroinventario and reservas.Estado='En espera' and libro.nroinventario=" + textBox4.Text+" order by fecha asc limit 1", cnn133);
                cnn133.Open();
                MySqlDataReader reader33 = cmd23.ExecuteReader();

                if (reader33.Read())
                {
                    if (domainUpDown1.Text != reader33["Nrosocio"].ToString())
                    {
                        DialogResult DR = MessageBox.Show("El libro se encuentra reservado por el socio Nro: " + reader33["Nrosocio"].ToString() + ". Desea entregarselo de igual manera?", " ", MessageBoxButtons.YesNo);

                        if (DR == DialogResult.Yes)
                        {

                        }
                        else
                        {
                            DialogResult dr2 = MessageBox.Show("Desea hacer la reserva?", " ", MessageBoxButtons.YesNo);
                            if (dr2 == DialogResult.Yes) 
                            {
                                cnn.Open();
                                MySqlCommand cmd = new MySqlCommand("insert into reservas(NroInventario, NroSocio) values ('"+textBox4.Text+"', '"+textBox5.Text+"')", cnn);
                                cmd.ExecuteNonQuery();
                                cnn.Close();
                            }
                            return;
                        }
                    }
                    else 
                    {
                        cnn.Open();
                        MySqlCommand cmd = new MySqlCommand("update reservas set estado='Realizada' where idreserva=" + reader33["idreserva"].ToString(), cnn);
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                    cnn133.Close();
                }
            }

            catch(Exception el)
            {
                MessageBox.Show(el + "");
            }
            
            
            MySqlConnection cnn13 = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root");
            MySqlCommand cmd2 = new MySqlCommand("select * from libro where NroInventario="+textBox4.Text, cnn13);
            cnn13.Open();
            MySqlDataReader reader = cmd2.ExecuteReader();

            if (reader.Read())
            {
                MySqlConnection cnn14 = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root");
                MySqlCommand cmd4 = new MySqlCommand("select * from prestamos where NroInventario=" + textBox4.Text, cnn14);
                cnn14.Open();
                MySqlDataReader reader2 = cmd4.ExecuteReader();
                string prestado = "No";
                int socio=0;
                while (reader2.Read()) 
                {
                    if (reader2["Devuelto"].ToString() == "No") 
                    {
                        prestado = "Si";
                        socio = Convert.ToInt32(reader2["NroSocio"].ToString());
                    }
                }
                reader2.Close();
                cnn14.Close();
                if (prestado == "No")
                {
                    MySqlConnection cnn12 = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root");
                    string fecha = dateTimePicker1.Value.Year + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day;
                    cnn12.Open();
                    string q;
                    q = "INSERT INTO `prestamos`(`FechaPrestacion`, `NroInventario`, `NroSocio`) VALUES ('" + fecha + "','" + textBox4.Text + "','" + domainUpDown1.Text + "')";
                    MySqlCommand cmd = new MySqlCommand(q, cnn12);
                    cmd.ExecuteNonQuery();
                    cnn12.Close();
                    int asd = Convert.ToInt32(domainUpDown1.Text);
                    domainUpDown1.Text = "2342";
                    domainUpDown1.Text = asd.ToString();

                    groupBox1.Visible = false;
                }
                else 
                {
                    //MessageBox.Show("El libro se encuentra en posesión del socio nro " + socio.ToString());
                    DialogResult dr2 = MessageBox.Show("El libro se encuentra en posesión del socio nro: " + socio.ToString()+". Desea hacer la reserva?", " ", MessageBoxButtons.YesNo);
                    if (dr2 == DialogResult.Yes)
                    {
                        cnn.Open();
                        MySqlCommand cmd = new MySqlCommand("insert into reservas(NroInventario, NroSocio) values ('" + textBox4.Text + "', '" + textBox5.Text + "')", cnn);
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }

            }
                

            else 
            {
                MessageBox.Show("Libro no existente");
            }
            cnn13.Close();
            reader.Close();


            textBox4.Clear();
            
            
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {

            groupBox1.Visible = false;
            textBox4.Clear();
        }
        bool suma = false;
        bool resta = false;
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type.ToString() == "SmallIncrement")
            {
                if (textBox5.Text == "1")
                    return;
                int i = Convert.ToInt32(textBox5.Text);
                int i2 = i - 1;
                textBox5.Text = i2.ToString();
                resta = true;
                //MessageBox.Show("abajo");
            }
            else if (e.Type.ToString() == "SmallDecrement")
            {
                int i = Convert.ToInt32(textBox5.Text);
                int i2 = i + 1;
                textBox5.Text = i2.ToString();
                suma = true;
                //MessageBox.Show("arriba");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
                return;
            domainUpDown1.Text = textBox5.Text;
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
    }
}
