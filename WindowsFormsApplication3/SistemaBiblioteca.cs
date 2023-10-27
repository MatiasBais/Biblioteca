using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;
using MySql.Data.MySqlClient;
using Microsoft;

namespace WindowsFormsApplication1
{
    public partial class SistemaBiblioteca : Form
    {
        public SistemaBiblioteca()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            ABM_cobrador cob = new ABM_cobrador();
            cob.ShowDialog();


        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void SistemaBiblioteca_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void actualizar()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            MySqlConnection cnn = new MySqlConnection("database=bibliotecabd;data source= localhost; user id=root;password=root");
            MySqlCommand cmd = new MySqlCommand("select libro.NroInventario, libro.Titulo, socio.NroSocio, socio.nombre as 'Nombre', socio.Celular, prestamos.FechaPrestacion, libro.DiasdePrestamo, (curdate()-prestamos.FechaPrestacion) as dias from libro, socio, prestamos where prestamos.FechaPrestacion <= DATE_SUB(CURDATE(), INTERVAL 10 day) and socio.nrosocio=prestamos.nrosocio and libro.nroinventario=prestamos.nroinventario and Devuelto='No' ", cnn);
            cnn.Open();
            MySqlDataReader adp = cmd.ExecuteReader();
            for (int i = 0; adp.Read(); )
            {
                string fecha = adp["FechaPrestacion"].ToString();
                DateTime dt = new DateTime();
                dt = Convert.ToDateTime(fecha);
                //MessageBox.Show(dt + "");
                int dias = Convert.ToInt32(adp["diasDeprestamo"].ToString());
                //MessageBox.Show(dias+"");
                dt = dt.AddDays(dias);
                //MessageBox.Show(dt + "");
                if (dt > DateTime.Now.Date)
                {
                }
                else
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = adp["NroInventario"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = adp["Titulo"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = adp["NroSocio"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = adp["Nombre"].ToString();
                    int diasv = Convert.ToInt32(adp["dias"].ToString());

                    dataGridView1.Rows[i].Cells[5].Value = diasv - dias;
                    dataGridView1.Rows[i].Cells[4].Value = dt.Day + "/" + dt.Month + "/" + dt.Year;
                    i++;
                }
            }

            cnn.Close();
            int he = 0;
            if (dataGridView1.RowCount != 0)
            {
                DataGridViewRow row = dataGridView1.Rows[0];
                he = row.Height;
                dataGridView1.Visible = true;
                label1.Visible = true;
            }
            else
            {
                dataGridView1.Visible = false;
                label1.Visible = false;
            }
            int size1 = dataGridView1.ColumnHeadersHeight + (dataGridView1.RowCount * he);
            dataGridView1.Height = size1;

            try
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Refresh();
                MySqlConnection cnn2 = new MySqlConnection("database=bibliotecabd;data source= localhost; user id=root;password=root");
                MySqlCommand cmd2 = new MySqlCommand("select idreserva, libro.NroInventario, libro.Titulo, socio.NroSocio, socio.nombre as 'Nombre', socio.Celular from libro, socio, reservas where socio.nrosocio=reservas.nrosocio and libro.nroinventario=reservas.nroinventario and reservas.Estado='En espera'", cnn2);
                cnn2.Open();
                MySqlDataReader adp2 = cmd2.ExecuteReader();
                while (adp2.Read()) 
                {
                    string idreserva = adp2["idreserva"].ToString();
                    string libronro = adp2["nroinventario"].ToString();
                    string librotitulo = adp2["titulo"].ToString();
                    string socionro = adp2["nrosocio"].ToString();
                    string socionombre = adp2["nombre"].ToString();
                    string celular = adp2["celular"].ToString();
                    MySqlConnection cnn3 = new MySqlConnection("database=bibliotecabd;data source= localhost; user id=root;password=root");
                    MySqlCommand cmd3 = new MySqlCommand("select * from prestamos where NroInventario="+ libronro+" order by fechaprestacion desc", cnn3);
                    cnn3.Open();
                    MySqlDataReader reader2 = cmd3.ExecuteReader();
                    if (reader2.Read())
                    {
                        if (reader2["Devuelto"].ToString() == "Si")
                        {
                            dataGridView2.Rows.Add();
                            int numerofila = dataGridView2.RowCount - 1;
                            dataGridView2.Rows[numerofila].Cells[0].Value = idreserva;
                            dataGridView2.Rows[numerofila].Cells[1].Value = libronro;
                            dataGridView2.Rows[numerofila].Cells[2].Value = librotitulo;
                            dataGridView2.Rows[numerofila].Cells[3].Value = socionro;
                            dataGridView2.Rows[numerofila].Cells[4].Value = socionombre;
                            dataGridView2.Rows[numerofila].Cells[5].Value = celular;
                        }
                    }
                    else 
                    {
                        dataGridView2.Rows.Add();
                        int numerofila = dataGridView2.RowCount - 1;
                        dataGridView2.Rows[numerofila].Cells[0].Value = idreserva;
                        dataGridView2.Rows[numerofila].Cells[1].Value = libronro;
                        dataGridView2.Rows[numerofila].Cells[2].Value = librotitulo;
                        dataGridView2.Rows[numerofila].Cells[3].Value = socionro;
                        dataGridView2.Rows[numerofila].Cells[4].Value = socionombre;
                        dataGridView2.Rows[numerofila].Cells[5].Value = celular;
                    }
                    reader2.Close();
                    cnn3.Close();
                }
                
                dataGridView2.Columns[0].Visible = false;
                adp2.Close();
                cnn2.Close();
                int he2 = 0;
                //MessageBox.Show(dataGridView2.RowCount + "");
                if (dataGridView2.RowCount != 0)
                {
                    DataGridViewRow row = dataGridView2.Rows[0];
                    he2 = row.Height;
                    dataGridView2.Visible = true;
                    label2.Visible = true;
                }
                else
                {
                    dataGridView2.Visible = false;
                    label2.Visible = false;
                }
                int size2 = dataGridView2.ColumnHeadersHeight + (dataGridView2.RowCount * he2);

                dataGridView2.Height = size2;
                if (!dataGridView1.Visible)
                {
                    dataGridView2.Location = dataGridView1.Location;
                    label2.Location = label1.Location;
                }
                else
                {
                    Point p1 = new Point(815, 55), p2 = new Point(707, 82);

                    label2.Location = p1;
                    dataGridView2.Location = p2;
                }
            }
            catch (Exception el)
            {
                MessageBox.Show(el + "");
            }
        }
        private void SistemaBiblioteca_Load(object sender, EventArgs e)
        {
            actualizar();

        }

        private void cobradoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM_cobrador cob = new ABM_cobrador();
            cob.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ;

        }

  

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void notasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notas asd = new notas();
            asd.ShowDialog();
        }

        private void agregarLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM_Libros2 abml = new ABM_Libros2();
            this.Hide();
            abml.ShowDialog();
            this.Show();
            actualizar();
        }

        private void aBMPrestamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prestamos pr = new Prestamos();
            pr.ShowDialog();
            actualizar();
        }

        private void aBMSociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM_socio asd = new ABM_socio();
            this.Hide();
            asd.WindowState = FormWindowState.Maximized;
            asd.ShowDialog();
            this.Show();
            actualizar();
        }

        private void buscarPorNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarPorNombre asd = new BuscarPorNombre();
            asd.ShowDialog();
        }

        private void buscarPorDNIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarporDNI asd = new BuscarporDNI();
            asd.ShowDialog();
        }

        private void buscarPorNroSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarporNrodeSocio asd = new BuscarporNrodeSocio();
            asd.ShowDialog();
        }

        private void porTituloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Libroportitulo asd = new Libroportitulo();
            this.Hide();
            asd.ShowDialog();
            this.Show();
        }

        private void porAutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibroPorAutor asd = new LibroPorAutor();
            asd.ShowDialog();
        }

        private void porISBNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibroporISBN asd = new LibroporISBN();
            asd.ShowDialog();
        }

        private void porNroInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibroporNroinventario asd = new LibroporNroinventario();
            asd.ShowDialog();
        }

        private void historialLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistorialLibro asd = new HistorialLibro();
            asd.ShowDialog();
        }

        private void administrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM_usuarios asda = new ABM_usuarios();
            asda.ShowDialog();
        }

        private void notasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            notas asda = new notas();
            asda.ShowDialog();
        }

        private void especificarCantLibrosPrestadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NLPprestamo asda = new NLPprestamo();
            asda.ShowDialog();

        }
        public static int socio1 = 0;
        public static int cuota = 0;
        public static int socio2 = 0;
        public static bool estado = false;
        public static int nroinventario = 0;

        private void imprimirTroquelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            troqueles asd = new troqueles();
            asd.ShowDialog();

            if (estado == true)
            {
                PrintDialog pdi = new PrintDialog();
                pdi.Document = printDocument1;

                if (pdi.ShowDialog() == DialogResult.OK)
                {
                    if (cuota == 0)
                    {
                        cuota = 30;
                    }
                    //printDocument1.DefaultPageSettings.PaperSize.Height = 832;
                    //printDocument1.DefaultPageSettings.PaperSize.Width = 756;
                    //printDocument1.Print();
                    System.Drawing.Printing.PaperSize pp = new System.Drawing.Printing.PaperSize("", 890, 890);

                    printDocument1.DefaultPageSettings.PaperSize = pp;
                    printDocument1.DefaultPageSettings.Margins.Bottom = 0;
                    printDocument1.DefaultPageSettings.Margins.Top = 0;
                    printDocument1.DefaultPageSettings.Margins.Left = 0;
                    printDocument1.DefaultPageSettings.Margins.Right = 0;
                    this.ForzarTamano(printDocument1, System.Drawing.Printing.PaperKind.Custom);
                    printDocument1.Print();

                    estado = false;
                    socio1 = 0;
                    cuota = 0;
                    socio2 = 0;
                }


            }

        }
        bool ForzarTamano(System.Drawing.Printing.PrintDocument ObjPrintDocument, System.Drawing.Printing.PaperKind ObjPaperKind)
        {

            if (ObjPrintDocument.PrinterSettings.PaperSizes[1].Kind == ObjPaperKind)
            {

                ObjPrintDocument.DefaultPageSettings.PaperSize =
                ObjPrintDocument.PrinterSettings.PaperSizes[1];
                return true;
            }

            return false;
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Image newImage = Image.FromFile(@"C:\Users\Septimo.Septimo-PC\Pictures\2017-11-11\001.jpg");
            //e.Graphics.DrawImage(newImage, 0,0);
            MySqlConnection cnn = new MySqlConnection("data source= localhost; database=bibliotecabd;user id = root;password=root");
            int i = 0;
            cnn.Open();
            MySqlCommand cmd = new MySqlCommand("select NroSocio, nombre, direccion, lugardecobro from socio where (NroSocio=" + socio1 + " or NroSocio=" + socio2 + ")", cnn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int nrosocio = Convert.ToInt32(reader["NroSocio"].ToString());
                string nombre = reader["nombre"].ToString();
                string direccion = reader["direccion"].ToString();
                string lugardecobro = reader["lugardecobro"].ToString();
                string nombre2 = "";
                int r = 13;
                if (nombre.Length > 27)
                {

                    nombre2 = nombre.Remove(27);
                }
                else
                {
                    nombre2 = nombre;
                }
                if (i == 0)
                {

                    i++;
                    e.Graphics.DrawString(nrosocio.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 448, 71);
                    e.Graphics.DrawString(nombre, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 438, 102);
                    e.Graphics.DrawString(direccion, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 481, 112 + 7);
                    e.Graphics.DrawString(lugardecobro, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 485, 130 + 2);
                    e.Graphics.DrawString(cuota.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 660, 71);

                    e.Graphics.DrawString(nombre2 + " " + nrosocio, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 16, 219 - 12 + 12);
                    e.Graphics.DrawString(cuota.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 65, 238 - 10 + 12);
                    e.Graphics.DrawString(DateTime.Now.Year.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 189, 238 - 12 + 12);

                    e.Graphics.DrawString(nombre2 + " " + nrosocio, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 281, 219 - 12 + 12);
                    e.Graphics.DrawString(cuota.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 330, 238 - 10 + 12);
                    e.Graphics.DrawString(DateTime.Now.Year.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 453, 238 - 12 + 12);

                    e.Graphics.DrawString(nombre2 + " " + nrosocio, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 555, 219 - 12 + 12);
                    e.Graphics.DrawString(cuota.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 607, 238 - 10 + 12);
                    e.Graphics.DrawString(DateTime.Now.Year.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 708, 238 - 12 + 12);

                    e.Graphics.DrawString(nombre2 + " " + nrosocio, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 16, 328 - 12 + 12);
                    e.Graphics.DrawString(cuota.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 65, 347 - 12 + 12);
                    e.Graphics.DrawString(DateTime.Now.Year.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 189, 347 - 12 + 12);

                    e.Graphics.DrawString(nombre2 + " " + nrosocio, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 281, 328 - 12 + 12);
                    e.Graphics.DrawString(cuota.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 330, 347 - 12 + 12);
                    e.Graphics.DrawString(DateTime.Now.Year.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 453, 347 - 12 + 12);

                    e.Graphics.DrawString(nombre2 + " " + nrosocio, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 555, 328 - 12 + 12);
                    e.Graphics.DrawString(cuota.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 604, 347 - 12 + 12);
                    e.Graphics.DrawString(DateTime.Now.Year.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 708, 347 - 12 + 12);
                }
                else
                {
                    e.Graphics.DrawString(nrosocio.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 445, 483 - 12 + r);
                    e.Graphics.DrawString(nombre, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 437, 508 - 6 + r);
                    e.Graphics.DrawString(direccion, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 478, 527 - 10 + r);
                    e.Graphics.DrawString(lugardecobro, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 483, 543 - 10 + r);
                    e.Graphics.DrawString(cuota.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 658, 483 - 12 + r);

                    e.Graphics.DrawString(nombre2 + " " + nrosocio, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 16, 612 + 5 + r);
                    e.Graphics.DrawString(cuota.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 65, 631 + 8 + r);
                    e.Graphics.DrawString(DateTime.Now.Year.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 189, 631 + 5 + r);

                    e.Graphics.DrawString(nombre2 + " " + nrosocio, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 281, 612 + 5 + r);
                    e.Graphics.DrawString(cuota.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 330, 631 + 8 + r);
                    e.Graphics.DrawString(DateTime.Now.Year.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 453, 631 + 5 + r);

                    e.Graphics.DrawString(nombre2 + " " + nrosocio, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 555, 612 + 5 + r);
                    e.Graphics.DrawString(cuota.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 604, 631 + 8 + r);
                    e.Graphics.DrawString(DateTime.Now.Year.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 718, 631 + 5 + r);

                    e.Graphics.DrawString(nombre2 + " " + nrosocio, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 16, 721 + 5 + r);
                    e.Graphics.DrawString(cuota.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 65, 740 + 8 + r);
                    e.Graphics.DrawString(DateTime.Now.Year.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 189, 740 + 5 + r);

                    e.Graphics.DrawString(nombre2 + " " + nrosocio, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 281, 721 + 5 + r);
                    e.Graphics.DrawString(cuota.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 330, 740 + 8 + r);
                    e.Graphics.DrawString(DateTime.Now.Year.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 453, 740 + 5 + r);

                    e.Graphics.DrawString(nombre2 + " " + nrosocio, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 555, 721 + 5 + r);
                    e.Graphics.DrawString(cuota.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 604, 740 + 8 + r);
                    e.Graphics.DrawString(DateTime.Now.Year.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 718, 740 + 5 + r);
                    i = 0;
                }
            }
            cnn.Close();
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
        public static bool estado2 = false;
        public static int nroinventario2 = 0;
       Stack<int> inventarios = new Stack<int>();
        private void imprimirFichasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            estado2 = false;
            fichas asd = new fichas();
            asd.ShowDialog();
            PrintDialog pdi = new PrintDialog();
            if (estado2 == true)
            {
                pdi.Document = printDocument2;
                if (pdi.ShowDialog() == DialogResult.OK)
                {
                    
                        MySqlConnection cnn = new MySqlConnection("database=bibliotecabd;data source=localhost; user id=root;password=root");
                        MySqlCommand cmd = new MySqlCommand("select * from libro where nroinventario>=" + nroinventario + " and nroinventario<=" + nroinventario2, cnn);
                        cnn.Open();
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read()) 
                        {
                            inventarios.Push(Convert.ToInt32(reader["NroInventario"].ToString()));
                        }
                        cnn.Close();
                    //printDocument2.DefaultPageSettings.PaperSize.Width = 504;
                    //printDocument2.DefaultPageSettings.PaperSize.Height = 1200;
                    //printDocument2.Print();
                    System.Drawing.Printing.PaperSize pp = new System.Drawing.Printing.PaperSize("", 504, 1200);

                    printDocument2.DefaultPageSettings.PaperSize = pp;
                    printDocument2.DefaultPageSettings.Margins.Bottom = 0;
                    printDocument2.DefaultPageSettings.Margins.Top = 0;
                    printDocument2.DefaultPageSettings.Margins.Left = 0;
                    printDocument2.DefaultPageSettings.Margins.Right = 0;
                    this.ForzarTamano(printDocument2, System.Drawing.Printing.PaperKind.Custom);
                    printDocument2.Print();
                }
            }
        }
        int il = 0;
        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

                MySqlConnection cnn = new MySqlConnection("data source= localhost; database=bibliotecabd;user id = root;password=root");
                cnn.Open();
                int nro = inventarios.Pop();
                MySqlCommand cmd = new MySqlCommand("select * from libro where NroInventario =" +nro, cnn);
                MySqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    string[] ubicacion = { "", "" };
                    try
                    {
                        ubicacion = reader["clasificacion"].ToString().Split('(');

                        if (ubicacion[1] != "")
                        {
                            try
                            {
                                ubicacion[1] = ubicacion[1].Replace(")", "");
                            }
                            catch
                            {
                            }

                        }
                    }
                    catch
                    {
                    }
                    string autor = reader["autor1"].ToString();
                    string tresautor = autor.Substring(0, 3);
                    string[] autoralreves = autor.Split(',');
                    try
                    {
                        autoralreves[1].Trim();
                    }
                    catch { }
                    string titulo = reader["titulo"].ToString();
                    string lugaredicion = reader["LugardeEdicion"].ToString();
                    string editorial = reader["editorial"].ToString();
                    string año = reader["AnodeEdicion"].ToString();
                    string paginas = reader["paginas"].ToString();
                    if (paginas == "0!")
                    {
                        paginas = "s/p";
                    }
                    string ilust = reader["ilust"].ToString();
                    string medida = reader["medida"].ToString();
                    string coleccion = reader["coleccion"].ToString();
                    string categoria = reader["materia"].ToString();
                    string edad = reader["edad"].ToString();
                    string isbn = reader["isbn"].ToString();
                    if (isbn != "")
                    {
                        isbn = "ISBN " + isbn;
                    }

                    //primer planilla
                    try
                    {
                        e.Graphics.DrawString(ubicacion[1], new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 20, 32);

                    }
                    catch
                    {
                    }
                    try
                    {
                        e.Graphics.DrawString(ubicacion[0], new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 12, 52);
                    }
                    catch
                    {
                    }
                    e.Graphics.DrawString(autor, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 96, 52);
                    e.Graphics.DrawString(tresautor, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 12, 72);
                    if (autoralreves.Length == 2)
                        e.Graphics.DrawString(titulo + " / " + autoralreves[1] + " " + autoralreves[0], new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 116, 72);
                    else if (autoralreves.Length == 1)
                        e.Graphics.DrawString(titulo + " / " + autoralreves[0], new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 116, 72);
                    e.Graphics.DrawString(nro.ToString(), new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 12, 92);
                    e.Graphics.DrawString(lugaredicion + " / " + editorial + " / " + año, new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 96, 92);
                    e.Graphics.DrawString(paginas + " p. ; " + ilust + " ;" + medida + "cm ; " + coleccion, new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 116, 112);
                    if (edad != "0" && edad != "")
                    {
                        e.Graphics.DrawString(categoria, new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 116, 192);
                        e.Graphics.DrawString("A partir de " + edad + " años", new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 116, 212);
                    }
                    else
                    {
                        e.Graphics.DrawString(categoria, new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 116, 212);
                    }
                    e.Graphics.DrawString(isbn, new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 116, 232);
                    //segunda
                    try
                    {
                        e.Graphics.DrawString(ubicacion[1], new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 20, 332);
                    }
                    catch
                    {
                    }
                    try
                    {
                        e.Graphics.DrawString(ubicacion[0], new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 12, 352);
                    }
                    catch
                    {
                    }
                    e.Graphics.DrawString(autor, new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 96, 352);
                    e.Graphics.DrawString(tresautor, new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 12, 372);
                    try
                    {
                        e.Graphics.DrawString(titulo + " / " + autoralreves[1] + " " + autoralreves[0], new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 116, 372);
                    }
                    catch
                    {
                        e.Graphics.DrawString(titulo + " / " + autoralreves[0], new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 116, 372);
                    }
                    e.Graphics.DrawString(nro.ToString(), new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 12, 392);
                    e.Graphics.DrawString(lugaredicion + " / " + editorial + " / " + año, new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 96, 392);
                    e.Graphics.DrawString(paginas + " p. ; " + ilust + " ;" + medida + "cm ; " + coleccion, new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 116, 412);
                    e.Graphics.DrawString(categoria, new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 116, 332);
                    if (edad != "0" && edad != "")
                        e.Graphics.DrawString("A partir de " + edad + " años", new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 116, 512);
                    e.Graphics.DrawString(isbn, new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 116, 532);
                    //tercera
                    try
                    {
                        e.Graphics.DrawString(ubicacion[1], new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 20, 632);
                    }
                    catch
                    {
                    }
                    try
                    {
                        e.Graphics.DrawString(ubicacion[0], new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 12, 652);
                    }
                    catch
                    {
                    }
                    e.Graphics.DrawString(autor, new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 96, 652);
                    e.Graphics.DrawString(tresautor, new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 12, 672);
                    try
                    {
                        e.Graphics.DrawString(titulo + " / " + autoralreves[1] + " " + autoralreves[0], new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 116, 672);
                    }
                    catch
                    {
                        e.Graphics.DrawString(titulo + " / " + autoralreves[0], new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 116, 672);

                    }
                    e.Graphics.DrawString(nro.ToString(), new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 12, 692);
                    e.Graphics.DrawString(lugaredicion + " / " + editorial + " / " + año, new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 96, 692);
                    e.Graphics.DrawString(paginas + " p. ; " + ilust + " ;" + medida + "cm ; " + coleccion, new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 116, 712);
                    e.Graphics.DrawString(titulo, new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 96, 732);
                    e.Graphics.DrawString(categoria, new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 116, 632);
                    if (edad != "0" && edad != "")
                        e.Graphics.DrawString("A partir de " + edad + " años", new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 116, 812);
                    e.Graphics.DrawString(isbn, new Font("Arial", 8 + 2, FontStyle.Regular), Brushes.Black, 116, 832);
                    //cuarta
                    e.Graphics.DrawString("Autor:.......................................................................................", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 12, 912);
                    e.Graphics.DrawString("Titulo:.......................................................................................", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 12, 932);
                    e.Graphics.DrawString("          " + autor, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 12, 911);
                    e.Graphics.DrawString("          " + titulo, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 12, 931);
                    try
                    {
                        e.Graphics.DrawString("(" + ubicacion[1] + ") " + ubicacion[0], new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 397, 911);
                    }
                    catch
                    {
                        try
                        {
                            e.Graphics.DrawString(ubicacion[0], new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 397, 911);
                        }
                        catch
                        {
                        }
                    }
                    e.Graphics.DrawString(tresautor, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 410, 931);
                    e.Graphics.DrawString(nro.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 410, 951);
                    e.Graphics.DrawString(".................................................................................................", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 12, 951);
                    Point punto1 = new Point(12, 971);
                    Point punto2 = new Point(12, 1171);
                    Point punto3 = new Point(468, 971);
                    Point punto4 = new Point(468, 1171);
                    Point punto5 = new Point(164, 971);
                    Point punto6 = new Point(164, 1171);
                    Point punto7 = new Point(316, 971);
                    Point punto8 = new Point(316, 1171);
                    Point punto9 = new Point(96, 971);
                    Point punto10 = new Point(96, 1171);
                    Point punto11 = new Point(400, 971);
                    Point punto12 = new Point(400, 1171);
                    Point punto13 = new Point(248, 971);
                    Point punto14 = new Point(248, 1171);
                    Pen pen = new Pen(Color.Black, 1);
                    e.Graphics.DrawLine(pen, punto1, punto2);
                    e.Graphics.DrawLine(pen, punto1, punto3);
                    e.Graphics.DrawLine(pen, punto2, punto4);
                    e.Graphics.DrawLine(pen, punto3, punto4);
                    e.Graphics.DrawLine(pen, punto5, punto6);
                    e.Graphics.DrawLine(pen, punto7, punto8);
                    e.Graphics.DrawLine(pen, punto9, punto10);
                    e.Graphics.DrawLine(pen, punto11, punto12);
                    e.Graphics.DrawLine(pen, punto13, punto14);
                    int y = 989;
                    for (int x = 0; x < 10; x++)
                    {
                        int x1 = 12;
                        int x2 = 468;
                        Point p1 = new Point(x1, y);
                        Point p2 = new Point(x2, y);
                        e.Graphics.DrawLine(pen, p1, p2);
                        y = y + 18;
                    }

                    e.Graphics.DrawString("Vencimiento", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 24, 975);
                    e.Graphics.DrawString("Vencimiento", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 176, 975);
                    e.Graphics.DrawString("Vencimiento", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 328, 975);
                    e.Graphics.DrawString("Nº Lector", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 106, 975);
                    e.Graphics.DrawString("Nº Lector", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 260, 975);
                    e.Graphics.DrawString("Nº Lector", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 412, 975);

                }
                if (inventarios.Count == 0)
                    e.HasMorePages = false;
                else
                    e.HasMorePages = true;
                cnn.Close();
            }
            

            
            

       

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reservas rsv = new Reservas();
            rsv.ShowDialog();
            actualizar();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.asd = true;
            this.Close();
        }

        private void librosMásSacadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Librosmassacados asd = new Librosmassacados();
            asd.ShowDialog();

        }

        private void sociosMásActivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sociosmasactivos asd = new sociosmasactivos();
            asd.ShowDialog();
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "AcroRd32.EXE";
            startInfo.Arguments = @"C:\Manualdeusuario.pdf";
            Process.Start(startInfo);
        }
        public static bool estado3 =false;
        private void imprimirRendicionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            estado3 = false;
            rendiciones asd = new rendiciones();
            asd.ShowDialog();
            PrintDialog pdi = new PrintDialog();
            if (estado3)
            {
                try
                {
                    MySqlConnection cnn = new MySqlConnection("database=bibliotecabd;data source=localhost; user id=root;password=root");
                    MySqlCommand cmd = new MySqlCommand("select * from libro where nroinventario>=" + nroinventario3 + " and nroinventario<=" + nroinventario4+" order by NroInventario desc", cnn);
                    cnn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string[] fecha = { "", "" };
                        if (reader["FechadeIngreso"].ToString() != "")
                            fecha = reader["FechadeIngreso"].ToString().Split(' ');
                        string pedo = reader["NroInventario"].ToString() + "|" + fecha[0] + "|" + reader["Autor1"].ToString() + "|" + reader["Titulo"].ToString() + "|" + reader["Editorial"].ToString() + "|" + reader["Caracter"].ToString();
                        inventarios2.Push(pedo);
                    }
                    cnn.Close();
                    SaveFileDialog fichero = new SaveFileDialog();
                    fichero.Filter = "Excel (*.xls)|*.xls";
                    if (fichero.ShowDialog() == DialogResult.OK)
                    {
                        Microsoft.Office.Interop.Excel.Application aplicacion;
                        Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                        Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                        aplicacion = new Microsoft.Office.Interop.Excel.Application();
                        libros_trabajo = aplicacion.Workbooks.Add();
                        hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                        
                        hoja_trabajo.Cells[1, 1] = "NroInventario";
                        hoja_trabajo.Cells[1, 2] = "FechaIngreso";
                        hoja_trabajo.Cells[1, 3] = "Autor";
                        hoja_trabajo.Cells[1, 4] = "Titulo";
                        hoja_trabajo.Cells[1, 5] = "Editorial";
                        hoja_trabajo.Cells[1, 6] = "Caracter";
                        int i = 1;
                        foreach (string caca in inventarios2)
                        {
                            string[] datos = caca.Split('|');
                            hoja_trabajo.Cells[(i + 1), 1] = datos[0];
                            hoja_trabajo.Cells[(i + 1), 2] = datos[1];
                            hoja_trabajo.Cells[(i + 1), 3] = datos[2];
                            hoja_trabajo.Cells[(i + 1), 4] = datos[3];
                            hoja_trabajo.Cells[(i + 1), 5] = datos[4];
                            hoja_trabajo.Cells[(i + 1), 6] = datos[5];
                            i++;

                        }
                        libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                        libros_trabajo.Close(true);

                    }
                }
                catch (Exception el)
                {
                }

                
            }
        }
        static void OpenMicrosoftExcel(string f)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "EXCEL.EXE";
            startInfo.Arguments = f;
            Process.Start(startInfo);
        }
        
        public static int nroinventario3 = 0;
        Stack<String> inventarios2 = new Stack<String>();
        public static int nroinventario4 = 0;
        private void printDocument3_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) 
        {

        }

        private void aBMCDsDVDsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM_CDDVD asd = new ABM_CDDVD();
            asd.ShowDialog();
        }

        private void bucrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarCDDVD asd = new BuscarCDDVD();
            asd.ShowDialog();
        }

        private void librosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Librosddb asd = new Librosddb();
            asd.ShowDialog();
        }

        private void sociosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sociosddb asd = new Sociosddb();
            asd.ShowDialog();
        }

        private void cDsDVDsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CDDVDddb asd = new CDDVDddb();
            asd.ShowDialog();
        }

    }
}
