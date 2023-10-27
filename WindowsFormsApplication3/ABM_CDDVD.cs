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
    public partial class ABM_CDDVD : Form
    {
        public ABM_CDDVD()
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

            string query = "select * from cddvd where titulo like '%" + textBox1.Text + "%' and Materia LIKE '%"+textBox2.Text+"%' " + tipo;
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
        
        private void ABM_CDDVD_Load(object sender, EventArgs e)
        {
            cb_caracter.SelectedIndex = 0;
            cb_estado.SelectedIndex = 0;
            cb_ilus.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            cb_tipo.SelectedIndex = 0;
            actualizar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cb_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_tipo.SelectedIndex == 0)
                label7.Text = "Director";
            else
                label7.Text = "Autor";
        }
        
        private void limpiar() 
        {
            tb_autordirector.Clear();
            tb_ciudad.Clear();
            tb_clasificacion.Clear();
            tb_coleccion.Clear();
            tb_duracion.Clear();
            tb_edicion.Clear();
            tb_editor.Clear();
            tb_materia.Clear();
            tb_observaciones.Clear();
            tb_precio.Clear();
            tb_titulo.Clear();
            tb_ubicacion.Clear();
            
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            limpiar();
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(n_id.Value);
            string tipo = cb_tipo.Text;
            int nro = Convert.ToInt32(n_num.Value);
            if (nro == 0)
            {
                MessageBox.Show("El número debe ser distinto a 0");
                return;
            }
            string fechaingreso = dt_fechaingreso.Value.Year + "/" + dt_fechaingreso.Value.Month + "/" + dt_fechaingreso.Value.Day;
            string clasificacion = tb_clasificacion.Text;
            string autordirector = tb_autordirector.Text;
            string titulo = tb_titulo.Text;
            string ciudad = tb_ciudad.Text;
            string editor = tb_editor.Text;
            string materia = tb_materia.Text;
            string edicion = tb_edicion.Text;
            string ilus = cb_ilus.Text;
            int año = Convert.ToInt32(n_ano.Value);
            string ubicacion = tb_ubicacion.Text;
            string duracion = tb_duracion.Text;
            string precio = tb_precio.Text;
            string coleccion = tb_coleccion.Text;
            int diasdeprestamo = Convert.ToInt32(n_diasdpres.Value);
            string estado = cb_estado.Text;
            string caracter = cb_caracter.Text;
            string observaciones = tb_observaciones.Text;
            string query = "UPDATE `cddvd` SET `Tipo`='"+tipo+"',`Numero`='"+nro+"',`FechadeIngreso`='"+fechaingreso+"',`Clasificacion`='"+clasificacion+"',`Autor`='"+autordirector+"',`Titulo`='"+tipo+"',`Ciudad`='"+ciudad+"',`Editor`='"+editor+"',`Materia`='"+materia+"',`Edicion`='"+edicion+"',`Ilus`='"+ilus+"',`Año`='"+año+"',`Ubicacion`='"+ubicacion+"',`Duracion`='"+duracion+"',`Precio`='"+precio+"',`Coleccion`='"+coleccion+"',`DiasdePrestamo`='"+diasdeprestamo+"',`Estado`='"+estado+"',`Caracter`='"+caracter+"',`Observaciones`='"+observaciones+"' WHERE id= "+id;
            MySqlConnection cnn = new MySqlConnection("database=bibliotecabd;data source=localhost;user id=root;password=root");
            MySqlCommand cmd = new MySqlCommand(query, cnn);
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
            DialogResult DR = MessageBox.Show("¿Desea dar de baja el CD o DVD?", " ", MessageBoxButtons.YesNo);
            if (DR == DialogResult.Yes)
            {
                int id = Convert.ToInt32(n_id.Value);
                string query = "delete from cddvdddb where id="+id+";insert into cddvdddb select * from cddvd where id=" + id + " ; delete from cddvd where id=" + id;
                MySqlConnection cnn = new MySqlConnection("database=bibliotecabd;data source=localhost;user id=root;password=root");
                MySqlCommand cmd = new MySqlCommand(query, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                actualizar();
                limpiar();
                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            actualizar();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            
                int id = Convert.ToInt32(n_id.Value);
                string tipo = cb_tipo.Text;
                int nro = Convert.ToInt32(n_num.Value);
                if (nro == 0)
                {
                    MessageBox.Show("El número debe ser distinto a 0");
                    return;
                }
                string fechaingreso = dt_fechaingreso.Value.Year + "/" + dt_fechaingreso.Value.Month + "/" + dt_fechaingreso.Value.Day;
                string clasificacion = tb_clasificacion.Text;
                string autordirector = tb_autordirector.Text;
                string titulo = tb_titulo.Text;
                string ciudad = tb_ciudad.Text;
                string editor = tb_editor.Text;
                string materia = tb_materia.Text;
                string edicion = tb_edicion.Text;
                string ilus = cb_ilus.Text;
                int año = Convert.ToInt32(n_ano.Value);
                string ubicacion = tb_ubicacion.Text;
                string duracion = tb_duracion.Text;
                string precio = tb_precio.Text;
                string coleccion = tb_coleccion.Text;
                int diasdeprestamo = Convert.ToInt32(n_diasdpres.Value);
                string estado = cb_estado.Text;
                string caracter = cb_caracter.Text;
                string observaciones = tb_observaciones.Text;
                string query = "insert into cddvd(`id`, `Tipo`, `Numero`, `FechadeIngreso`, `Clasificacion`, `Autor`, `Titulo`, `Ciudad`, `Editor`, `Materia`, `Edicion`, `Ilus`, `Año`, `Ubicacion`, `Duracion`, `Precio`, `Coleccion`, `DiasdePrestamo`, `Estado`, `Caracter`, `Observaciones`) VALUES ('" + id + "','" + tipo + "','" + nro + "','" + fechaingreso + "','" + clasificacion + "','" + autordirector + "','" + titulo + "','" + ciudad + "','" + editor + "','" + materia + "','" + edicion + "','" + ilus + "','" + año + "','" + ubicacion + "','" + duracion + "','" + precio + "','" + coleccion + "','" + diasdeprestamo + "','" + estado + "','" + caracter + "','" + observaciones + "')";
                MySqlConnection cnn = new MySqlConnection("database=bibliotecabd;data source=localhost;user id=root;password=root");
                MySqlCommand cmd = new MySqlCommand(query, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                actualizar();
                limpiar();
           

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            n_id.Value = Convert.ToDecimal(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
            if(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString() =="CD")
                cb_tipo.SelectedIndex=1;
            else
                cb_tipo.SelectedIndex=0;
            n_num.Value = Convert.ToDecimal(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value);
            string[] fecha=dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString().Split('/');
            string fecha2 = fecha[0] + "/" + fecha[1] + "/" + fecha[2];
            DateTime dt = Convert.ToDateTime(fecha2);
            dt_fechaingreso.Value = dt;
            tb_clasificacion.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();
            tb_autordirector.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString();
            tb_titulo.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString();
            tb_ciudad.Text=dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[7].Value.ToString();
            tb_editor.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.ToString();
            tb_materia.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[9].Value.ToString();
            tb_edicion.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[10].Value.ToString();
            if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[11].Value.ToString() == "Sí")
                cb_ilus.SelectedIndex = 1;
            else
                cb_ilus.SelectedIndex = 0;
            n_ano.Value=Convert.ToDecimal(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[12].Value);
            tb_ubicacion.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[13].Value.ToString();
            tb_duracion.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[14].Value.ToString();
            tb_precio.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[15].Value.ToString();
            tb_coleccion.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[16].Value.ToString();
            n_diasdpres.Value = Convert.ToDecimal(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[17].Value);
            if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[18].Value.ToString() == "Bien")
                cb_estado.SelectedIndex = 0;
            else
                cb_estado.SelectedIndex = 1;
            if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[19].Value.ToString() == "Compra")
                cb_caracter.SelectedIndex = 0;
            else
                cb_caracter.SelectedIndex = 1;
            tb_observaciones.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[20].Value.ToString();
            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = true;
            
            
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            actualizar();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.Enter)
            {
                e.SuppressKeyPress = true;
                n_id.Value = Convert.ToDecimal(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString() == "CD")
                    cb_tipo.SelectedIndex = 1;
                else
                    cb_tipo.SelectedIndex = 0;
                n_num.Value = Convert.ToDecimal(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value);
                string[] fecha = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString().Split('/');
                string fecha2 = fecha[0] + "/" + fecha[1] + "/" + fecha[2];
                DateTime dt = Convert.ToDateTime(fecha2);
                dt_fechaingreso.Value = dt;
                tb_clasificacion.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();
                tb_autordirector.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString();
                tb_titulo.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString();
                tb_ciudad.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[7].Value.ToString();
                tb_editor.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.ToString();
                tb_materia.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[9].Value.ToString();
                tb_edicion.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[10].Value.ToString();
                if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[11].Value.ToString() == "Sí")
                    cb_ilus.SelectedIndex = 1;
                else
                    cb_ilus.SelectedIndex = 0;
                n_ano.Value = Convert.ToDecimal(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[12].Value);
                tb_ubicacion.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[13].Value.ToString();
                tb_duracion.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[14].Value.ToString();
                tb_precio.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[15].Value.ToString();
                tb_coleccion.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[16].Value.ToString();
                n_diasdpres.Value = Convert.ToDecimal(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[17].Value);
                if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[18].Value.ToString() == "Bien")
                    cb_estado.SelectedIndex = 0;
                else
                    cb_estado.SelectedIndex = 1;
                if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[19].Value.ToString() == "Compra")
                    cb_caracter.SelectedIndex = 0;
                else
                    cb_caracter.SelectedIndex = 1;
                tb_observaciones.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[20].Value.ToString();
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = true;
            
            }
        }
    }
}
