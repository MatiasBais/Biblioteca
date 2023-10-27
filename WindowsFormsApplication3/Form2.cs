using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void buscarPorNombreToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BuscarPorNombre bn = new BuscarPorNombre();
            bn.ShowDialog();
        }

        private void buscarPorDNIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarporDNI bd = new BuscarporDNI();
            bd.ShowDialog();

        }

        private void buscarPorNroSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarporNrodeSocio ns = new BuscarporNrodeSocio();
            ns.ShowDialog();
        }

        private void buscarPorNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Libroportitulo asd = new Libroportitulo();
            asd.ShowDialog();
        }

        private void buscarPorNroInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibroporNroinventario asd = new LibroporNroinventario();
            asd.ShowDialog();
        }

        private void buscarPorISBNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibroporISBN asd = new LibroporISBN();
            asd.ShowDialog();
        }

        private void buscarPorAutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibroPorAutor asd = new LibroPorAutor();
            asd.ShowDialog();
        }

        private void historialLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistorialLibro asd = new HistorialLibro();
            asd.ShowDialog();
        }

        private void buscarPorNroSocioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PRestamoporsocio asd = new PRestamoporsocio();
            asd.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.asd = true;
            this.Close();
        }

        private void cDsDVDsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarCDDVD asd = new BuscarCDDVD();
            asd.ShowDialog();
        }
    }
}
