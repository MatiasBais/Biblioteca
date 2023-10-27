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
    public partial class NLPprestamo : Form
    {
        public NLPprestamo()
        {
            InitializeComponent();
        }

        private void NLPprestamo_Load(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection("Data source=localhost;database=bibliotecabd;user=root");
            MySqlCommand cmd = new MySqlCommand("Select * from parametros", cnn);
            cnn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) 
            {
                int i = Convert.ToInt32(reader["CLibrosPrestamo"]);
                switch (i)
                {
                    case 1:
                        radioButton1.Checked = true;
                        break;
                    case 2:
                        radioButton2.Checked = true;
                        break;
                    case 3:
                        radioButton3.Checked = true;
                        break;
                    case 4:
                        radioButton4.Checked=true;
                        break;
                }
            }
            cnn.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(!radioButton1.Checked)
                return;
            MySqlConnection cnn = new MySqlConnection("Data source=localhost;database=bibliotecabd;user=root");
            MySqlCommand cmd = new MySqlCommand("update parametros set CLibrosPrestamo=1", cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }        

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(!radioButton2.Checked)
                return;
            MySqlConnection cnn = new MySqlConnection("Data source=localhost;database=bibliotecabd;user=root");
            MySqlCommand cmd = new MySqlCommand("update parametros set CLibrosPrestamo=2", cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if(!radioButton3.Checked)
                return;
            MySqlConnection cnn = new MySqlConnection("Data source=localhost;database=bibliotecabd;user=root");
            MySqlCommand cmd = new MySqlCommand("update parametros set CLibrosPrestamo=3", cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if(!radioButton4.Checked)
                return;
            MySqlConnection cnn = new MySqlConnection("Data source=localhost;database=bibliotecabd;user=root");
            MySqlCommand cmd = new MySqlCommand("update parametros set CLibrosPrestamo=4", cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
