namespace WindowsFormsApplication1
{
    partial class Form2
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.librosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPorNombreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPorNroInventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPorISBNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPorAutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sociosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPorNombreToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPorDNIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPorNroSocioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prestamosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPorNroSocioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.historialLibroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cDsDVDsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sociosToolStripMenuItem,
            this.librosToolStripMenuItem,
            this.cDsDVDsToolStripMenuItem,
            this.prestamosToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(393, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // librosToolStripMenuItem
            // 
            this.librosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarPorNombreToolStripMenuItem,
            this.buscarPorNroInventarioToolStripMenuItem,
            this.buscarPorISBNToolStripMenuItem,
            this.buscarPorAutorToolStripMenuItem});
            this.librosToolStripMenuItem.Name = "librosToolStripMenuItem";
            this.librosToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.librosToolStripMenuItem.Text = "Libros";
            // 
            // buscarPorNombreToolStripMenuItem
            // 
            this.buscarPorNombreToolStripMenuItem.Name = "buscarPorNombreToolStripMenuItem";
            this.buscarPorNombreToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.buscarPorNombreToolStripMenuItem.Text = "Buscar por titulo";
            this.buscarPorNombreToolStripMenuItem.Click += new System.EventHandler(this.buscarPorNombreToolStripMenuItem_Click);
            // 
            // buscarPorNroInventarioToolStripMenuItem
            // 
            this.buscarPorNroInventarioToolStripMenuItem.Name = "buscarPorNroInventarioToolStripMenuItem";
            this.buscarPorNroInventarioToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.buscarPorNroInventarioToolStripMenuItem.Text = "Buscar por NroInventario";
            this.buscarPorNroInventarioToolStripMenuItem.Click += new System.EventHandler(this.buscarPorNroInventarioToolStripMenuItem_Click);
            // 
            // buscarPorISBNToolStripMenuItem
            // 
            this.buscarPorISBNToolStripMenuItem.Name = "buscarPorISBNToolStripMenuItem";
            this.buscarPorISBNToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.buscarPorISBNToolStripMenuItem.Text = "Buscar por ISBN";
            this.buscarPorISBNToolStripMenuItem.Click += new System.EventHandler(this.buscarPorISBNToolStripMenuItem_Click);
            // 
            // buscarPorAutorToolStripMenuItem
            // 
            this.buscarPorAutorToolStripMenuItem.Name = "buscarPorAutorToolStripMenuItem";
            this.buscarPorAutorToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.buscarPorAutorToolStripMenuItem.Text = "Buscar por autor";
            this.buscarPorAutorToolStripMenuItem.Click += new System.EventHandler(this.buscarPorAutorToolStripMenuItem_Click);
            // 
            // sociosToolStripMenuItem
            // 
            this.sociosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarPorNombreToolStripMenuItem1,
            this.buscarPorDNIToolStripMenuItem,
            this.buscarPorNroSocioToolStripMenuItem});
            this.sociosToolStripMenuItem.Name = "sociosToolStripMenuItem";
            this.sociosToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.sociosToolStripMenuItem.Text = "Socios";
            // 
            // buscarPorNombreToolStripMenuItem1
            // 
            this.buscarPorNombreToolStripMenuItem1.Name = "buscarPorNombreToolStripMenuItem1";
            this.buscarPorNombreToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.buscarPorNombreToolStripMenuItem1.Text = "Buscar por nombre";
            this.buscarPorNombreToolStripMenuItem1.Click += new System.EventHandler(this.buscarPorNombreToolStripMenuItem1_Click);
            // 
            // buscarPorDNIToolStripMenuItem
            // 
            this.buscarPorDNIToolStripMenuItem.Name = "buscarPorDNIToolStripMenuItem";
            this.buscarPorDNIToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.buscarPorDNIToolStripMenuItem.Text = "Buscar por DNI";
            this.buscarPorDNIToolStripMenuItem.Click += new System.EventHandler(this.buscarPorDNIToolStripMenuItem_Click);
            // 
            // buscarPorNroSocioToolStripMenuItem
            // 
            this.buscarPorNroSocioToolStripMenuItem.Name = "buscarPorNroSocioToolStripMenuItem";
            this.buscarPorNroSocioToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.buscarPorNroSocioToolStripMenuItem.Text = "Buscar por NroSocio";
            this.buscarPorNroSocioToolStripMenuItem.Click += new System.EventHandler(this.buscarPorNroSocioToolStripMenuItem_Click);
            // 
            // prestamosToolStripMenuItem
            // 
            this.prestamosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarPorNroSocioToolStripMenuItem1,
            this.historialLibroToolStripMenuItem});
            this.prestamosToolStripMenuItem.Name = "prestamosToolStripMenuItem";
            this.prestamosToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.prestamosToolStripMenuItem.Text = "Prestamos";
            // 
            // buscarPorNroSocioToolStripMenuItem1
            // 
            this.buscarPorNroSocioToolStripMenuItem1.Name = "buscarPorNroSocioToolStripMenuItem1";
            this.buscarPorNroSocioToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.buscarPorNroSocioToolStripMenuItem1.Text = "Buscar por NroSocio";
            this.buscarPorNroSocioToolStripMenuItem1.Click += new System.EventHandler(this.buscarPorNroSocioToolStripMenuItem1_Click);
            // 
            // historialLibroToolStripMenuItem
            // 
            this.historialLibroToolStripMenuItem.Name = "historialLibroToolStripMenuItem";
            this.historialLibroToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.historialLibroToolStripMenuItem.Text = "Historial libro";
            this.historialLibroToolStripMenuItem.Click += new System.EventHandler(this.historialLibroToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // cDsDVDsToolStripMenuItem
            // 
            this.cDsDVDsToolStripMenuItem.Name = "cDsDVDsToolStripMenuItem";
            this.cDsDVDsToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.cDsDVDsToolStripMenuItem.Text = "CDs/DVDs";
            this.cDsDVDsToolStripMenuItem.Click += new System.EventHandler(this.cDsDVDsToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.coleccion_de_libros;
            this.ClientSize = new System.Drawing.Size(393, 355);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Biblioteca Rojas";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem librosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarPorNombreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarPorNroInventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarPorISBNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sociosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarPorNombreToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem buscarPorDNIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarPorNroSocioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prestamosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarPorNroSocioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem historialLibroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarPorAutorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cDsDVDsToolStripMenuItem;

    }
}