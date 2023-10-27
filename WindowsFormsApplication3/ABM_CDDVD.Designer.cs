namespace WindowsFormsApplication1
{
    partial class ABM_CDDVD
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.n_id = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_tipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.n_num = new System.Windows.Forms.NumericUpDown();
            this.dt_fechaingreso = new System.Windows.Forms.DateTimePicker();
            this.tb_clasificacion = new System.Windows.Forms.TextBox();
            this.tb_autordirector = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_materia = new System.Windows.Forms.TextBox();
            this.tb_titulo = new System.Windows.Forms.TextBox();
            this.tb_ciudad = new System.Windows.Forms.TextBox();
            this.tb_edicion = new System.Windows.Forms.TextBox();
            this.tb_editor = new System.Windows.Forms.TextBox();
            this.tb_ubicacion = new System.Windows.Forms.TextBox();
            this.tb_precio = new System.Windows.Forms.TextBox();
            this.tb_duracion = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tb_observaciones = new System.Windows.Forms.TextBox();
            this.tb_coleccion = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cb_ilus = new System.Windows.Forms.ComboBox();
            this.n_ano = new System.Windows.Forms.NumericUpDown();
            this.n_diasdpres = new System.Windows.Forms.NumericUpDown();
            this.cb_estado = new System.Windows.Forms.ComboBox();
            this.cb_caracter = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_ano)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_diasdpres)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Ambos",
            "CDs",
            "DVDs"});
            this.comboBox1.Location = new System.Drawing.Point(101, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione tipo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filtrar por titulo:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(312, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(219, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Location = new System.Drawing.Point(12, 39);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(859, 520);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // n_id
            // 
            this.n_id.Location = new System.Drawing.Point(64, 393);
            this.n_id.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.n_id.Name = "n_id";
            this.n_id.Size = new System.Drawing.Size(120, 20);
            this.n_id.TabIndex = 5;
            this.n_id.ThousandsSeparator = true;
            this.n_id.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 566);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tipo";
            // 
            // cb_tipo
            // 
            this.cb_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tipo.FormattingEnabled = true;
            this.cb_tipo.Items.AddRange(new object[] {
            "DVD",
            "CD"});
            this.cb_tipo.Location = new System.Drawing.Point(109, 566);
            this.cb_tipo.Name = "cb_tipo";
            this.cb_tipo.Size = new System.Drawing.Size(121, 21);
            this.cb_tipo.TabIndex = 7;
            this.cb_tipo.SelectedIndexChanged += new System.EventHandler(this.cb_tipo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 592);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Número";
            // 
            // n_num
            // 
            this.n_num.Location = new System.Drawing.Point(109, 590);
            this.n_num.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.n_num.Name = "n_num";
            this.n_num.Size = new System.Drawing.Size(120, 20);
            this.n_num.TabIndex = 9;
            // 
            // dt_fechaingreso
            // 
            this.dt_fechaingreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_fechaingreso.Location = new System.Drawing.Point(109, 616);
            this.dt_fechaingreso.Name = "dt_fechaingreso";
            this.dt_fechaingreso.Size = new System.Drawing.Size(121, 20);
            this.dt_fechaingreso.TabIndex = 10;
            // 
            // tb_clasificacion
            // 
            this.tb_clasificacion.Location = new System.Drawing.Point(109, 642);
            this.tb_clasificacion.Name = "tb_clasificacion";
            this.tb_clasificacion.Size = new System.Drawing.Size(121, 20);
            this.tb_clasificacion.TabIndex = 11;
            // 
            // tb_autordirector
            // 
            this.tb_autordirector.Location = new System.Drawing.Point(109, 668);
            this.tb_autordirector.Name = "tb_autordirector";
            this.tb_autordirector.Size = new System.Drawing.Size(121, 20);
            this.tb_autordirector.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 622);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Fecha de Ingreso";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 645);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Clasificación";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 671);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Director";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(236, 569);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Título";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(236, 595);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Ciudad";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(236, 621);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Editor";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(236, 647);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Materia";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(236, 673);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Edición";
            // 
            // tb_materia
            // 
            this.tb_materia.Location = new System.Drawing.Point(284, 644);
            this.tb_materia.Name = "tb_materia";
            this.tb_materia.Size = new System.Drawing.Size(100, 20);
            this.tb_materia.TabIndex = 21;
            // 
            // tb_titulo
            // 
            this.tb_titulo.Location = new System.Drawing.Point(284, 566);
            this.tb_titulo.Name = "tb_titulo";
            this.tb_titulo.Size = new System.Drawing.Size(100, 20);
            this.tb_titulo.TabIndex = 22;
            // 
            // tb_ciudad
            // 
            this.tb_ciudad.Location = new System.Drawing.Point(284, 592);
            this.tb_ciudad.Name = "tb_ciudad";
            this.tb_ciudad.Size = new System.Drawing.Size(100, 20);
            this.tb_ciudad.TabIndex = 23;
            // 
            // tb_edicion
            // 
            this.tb_edicion.Location = new System.Drawing.Point(284, 670);
            this.tb_edicion.Name = "tb_edicion";
            this.tb_edicion.Size = new System.Drawing.Size(100, 20);
            this.tb_edicion.TabIndex = 24;
            // 
            // tb_editor
            // 
            this.tb_editor.Location = new System.Drawing.Point(284, 618);
            this.tb_editor.Name = "tb_editor";
            this.tb_editor.Size = new System.Drawing.Size(100, 20);
            this.tb_editor.TabIndex = 25;
            // 
            // tb_ubicacion
            // 
            this.tb_ubicacion.Location = new System.Drawing.Point(460, 618);
            this.tb_ubicacion.Name = "tb_ubicacion";
            this.tb_ubicacion.Size = new System.Drawing.Size(100, 20);
            this.tb_ubicacion.TabIndex = 35;
            // 
            // tb_precio
            // 
            this.tb_precio.Location = new System.Drawing.Point(460, 670);
            this.tb_precio.Name = "tb_precio";
            this.tb_precio.Size = new System.Drawing.Size(100, 20);
            this.tb_precio.TabIndex = 34;
            // 
            // tb_duracion
            // 
            this.tb_duracion.Location = new System.Drawing.Point(460, 644);
            this.tb_duracion.Name = "tb_duracion";
            this.tb_duracion.Size = new System.Drawing.Size(100, 20);
            this.tb_duracion.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(401, 673);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Precio";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(401, 647);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Duración";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(401, 621);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "Ubicación";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(401, 595);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "Año";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(401, 569);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 13);
            this.label17.TabIndex = 26;
            this.label17.Text = "Ilustrado?";
            // 
            // tb_observaciones
            // 
            this.tb_observaciones.Location = new System.Drawing.Point(661, 670);
            this.tb_observaciones.Name = "tb_observaciones";
            this.tb_observaciones.Size = new System.Drawing.Size(100, 20);
            this.tb_observaciones.TabIndex = 44;
            // 
            // tb_coleccion
            // 
            this.tb_coleccion.Location = new System.Drawing.Point(661, 566);
            this.tb_coleccion.Name = "tb_coleccion";
            this.tb_coleccion.Size = new System.Drawing.Size(100, 20);
            this.tb_coleccion.TabIndex = 42;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(566, 674);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 13);
            this.label18.TabIndex = 40;
            this.label18.Text = "Observaciones";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(566, 648);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 13);
            this.label19.TabIndex = 39;
            this.label19.Text = "Caracter";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(566, 622);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 13);
            this.label20.TabIndex = 38;
            this.label20.Text = "Estado";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(566, 596);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(89, 13);
            this.label21.TabIndex = 37;
            this.label21.Text = "Dias de préstamo";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(566, 570);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(54, 13);
            this.label22.TabIndex = 36;
            this.label22.Text = "Colección";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(796, 566);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 46;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(796, 597);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 47;
            this.button2.Text = "Modificar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(796, 638);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 48;
            this.button3.Text = "Dar de baja";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(796, 669);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 49;
            this.button4.Text = "Cancelar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cb_ilus
            // 
            this.cb_ilus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ilus.FormattingEnabled = true;
            this.cb_ilus.Items.AddRange(new object[] {
            "No",
            "Sí"});
            this.cb_ilus.Location = new System.Drawing.Point(460, 565);
            this.cb_ilus.Name = "cb_ilus";
            this.cb_ilus.Size = new System.Drawing.Size(100, 21);
            this.cb_ilus.TabIndex = 50;
            // 
            // n_ano
            // 
            this.n_ano.Location = new System.Drawing.Point(460, 592);
            this.n_ano.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.n_ano.Name = "n_ano";
            this.n_ano.Size = new System.Drawing.Size(100, 20);
            this.n_ano.TabIndex = 51;
            this.n_ano.Value = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            // 
            // n_diasdpres
            // 
            this.n_diasdpres.Location = new System.Drawing.Point(661, 592);
            this.n_diasdpres.Name = "n_diasdpres";
            this.n_diasdpres.Size = new System.Drawing.Size(100, 20);
            this.n_diasdpres.TabIndex = 52;
            // 
            // cb_estado
            // 
            this.cb_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_estado.FormattingEnabled = true;
            this.cb_estado.Items.AddRange(new object[] {
            "Bien",
            "Deteriorado"});
            this.cb_estado.Location = new System.Drawing.Point(661, 617);
            this.cb_estado.Name = "cb_estado";
            this.cb_estado.Size = new System.Drawing.Size(100, 21);
            this.cb_estado.TabIndex = 53;
            // 
            // cb_caracter
            // 
            this.cb_caracter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_caracter.FormattingEnabled = true;
            this.cb_caracter.Items.AddRange(new object[] {
            "Compra",
            "Donación"});
            this.cb_caracter.Location = new System.Drawing.Point(661, 644);
            this.cb_caracter.Name = "cb_caracter";
            this.cb_caracter.Size = new System.Drawing.Size(100, 21);
            this.cb_caracter.TabIndex = 54;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(626, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(219, 20);
            this.textBox2.TabIndex = 56;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(542, 15);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(90, 13);
            this.label23.TabIndex = 55;
            this.label23.Text = "Filtrar por materia:";
            // 
            // ABM_CDDVD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(880, 694);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.cb_caracter);
            this.Controls.Add(this.cb_estado);
            this.Controls.Add(this.n_diasdpres);
            this.Controls.Add(this.n_ano);
            this.Controls.Add(this.cb_ilus);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_observaciones);
            this.Controls.Add(this.tb_coleccion);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.tb_ubicacion);
            this.Controls.Add(this.tb_precio);
            this.Controls.Add(this.tb_duracion);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tb_editor);
            this.Controls.Add(this.tb_edicion);
            this.Controls.Add(this.tb_ciudad);
            this.Controls.Add(this.tb_titulo);
            this.Controls.Add(this.tb_materia);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_autordirector);
            this.Controls.Add(this.tb_clasificacion);
            this.Controls.Add(this.dt_fechaingreso);
            this.Controls.Add(this.n_num);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_tipo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.n_id);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.MaximumSize = new System.Drawing.Size(896, 740);
            this.Name = "ABM_CDDVD";
            this.Text = "CDs y DVDs";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ABM_CDDVD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_ano)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_diasdpres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NumericUpDown n_id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_tipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown n_num;
        private System.Windows.Forms.DateTimePicker dt_fechaingreso;
        private System.Windows.Forms.TextBox tb_clasificacion;
        private System.Windows.Forms.TextBox tb_autordirector;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb_materia;
        private System.Windows.Forms.TextBox tb_titulo;
        private System.Windows.Forms.TextBox tb_ciudad;
        private System.Windows.Forms.TextBox tb_edicion;
        private System.Windows.Forms.TextBox tb_editor;
        private System.Windows.Forms.TextBox tb_ubicacion;
        private System.Windows.Forms.TextBox tb_precio;
        private System.Windows.Forms.TextBox tb_duracion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tb_observaciones;
        private System.Windows.Forms.TextBox tb_coleccion;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cb_ilus;
        private System.Windows.Forms.NumericUpDown n_ano;
        private System.Windows.Forms.NumericUpDown n_diasdpres;
        private System.Windows.Forms.ComboBox cb_estado;
        private System.Windows.Forms.ComboBox cb_caracter;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label23;
    }
}