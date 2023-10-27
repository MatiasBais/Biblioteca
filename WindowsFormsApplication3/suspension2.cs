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
    public partial class suspension2 : Form
    {
        public suspension2()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int nrosocio = ABM_socio.ssnrosocio;
            string fecha = monthCalendar1.SelectionRange.Start.Year + "/" + monthCalendar1.SelectionRange.Start.Month + "/" + monthCalendar1.SelectionRange.Start.Day;
            string q = "Update socio set Suspendido='Si', FechaFinSusp='" + fecha + "' where NroSocio=" + nrosocio;
            MySqlConnection cnn = new MySqlConnection("data source=localhost;database=bibliotecabd;user id=root");
            cnn.Open();
            MySqlCommand cmd = new MySqlCommand(q, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
