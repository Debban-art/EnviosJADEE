namespace EnvíosJADEE.Forms
{
    partial class frmDetallesDeOrden
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.dgvOrden = new System.Windows.Forms.DataGridView();
            this.gpbDatosDestinatario = new System.Windows.Forms.GroupBox();
            this.txtNombreDestinatario = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtTelefonoDestinatario = new System.Windows.Forms.TextBox();
            this.lblApellidoPat = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtApellidoPatDestinatario = new System.Windows.Forms.TextBox();
            this.txtApellidoMatDestinatario = new System.Windows.Forms.TextBox();
            this.lblApellidoMat = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.cmbEstatus = new System.Windows.Forms.ComboBox();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.lblEstatus = new System.Windows.Forms.Label();
            this.txtCostoTotal = new System.Windows.Forms.TextBox();
            this.btnCambiar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblPeso = new System.Windows.Forms.Label();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.lblCostoTotal = new System.Windows.Forms.Label();
            this.gbpDireccionEnvio = new System.Windows.Forms.GroupBox();
            this.cmbColonia = new System.Windows.Forms.ComboBox();
            this.lblPais = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.txtNoCasa = new System.Windows.Forms.TextBox();
            this.lblCodigoPostal = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.lblColoni = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lblNoCasa = new System.Windows.Forms.Label();
            this.cmbPaís = new System.Windows.Forms.ComboBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.cmbMunicipio = new System.Windows.Forms.ComboBox();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNombreEmisor = new System.Windows.Forms.Label();
            this.txtNombreEmisor = new System.Windows.Forms.TextBox();
            this.gpb = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrden)).BeginInit();
            this.gpbDatosDestinatario.SuspendLayout();
            this.gbpDireccionEnvio.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gpb.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(69)))));
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(984, 37);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.Size = new System.Drawing.Size(431, 322);
            this.dgvProductos.TabIndex = 20;
            // 
            // dgvOrden
            // 
            this.dgvOrden.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(69)))));
            this.dgvOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrden.Location = new System.Drawing.Point(724, 606);
            this.dgvOrden.Name = "dgvOrden";
            this.dgvOrden.ReadOnly = true;
            this.dgvOrden.Size = new System.Drawing.Size(678, 68);
            this.dgvOrden.TabIndex = 59;
            // 
            // gpbDatosDestinatario
            // 
            this.gpbDatosDestinatario.Controls.Add(this.gpb);
            this.gpbDatosDestinatario.Controls.Add(this.txtNombreDestinatario);
            this.gpbDatosDestinatario.Controls.Add(this.lblNombre);
            this.gpbDatosDestinatario.Controls.Add(this.txtTelefonoDestinatario);
            this.gpbDatosDestinatario.Controls.Add(this.lblApellidoPat);
            this.gpbDatosDestinatario.Controls.Add(this.lblTelefono);
            this.gpbDatosDestinatario.Controls.Add(this.txtApellidoPatDestinatario);
            this.gpbDatosDestinatario.Controls.Add(this.txtApellidoMatDestinatario);
            this.gpbDatosDestinatario.Controls.Add(this.lblApellidoMat);
            this.gpbDatosDestinatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Bold);
            this.gpbDatosDestinatario.Location = new System.Drawing.Point(13, 579);
            this.gpbDatosDestinatario.Name = "gpbDatosDestinatario";
            this.gpbDatosDestinatario.Size = new System.Drawing.Size(866, 150);
            this.gpbDatosDestinatario.TabIndex = 86;
            this.gpbDatosDestinatario.TabStop = false;
            this.gpbDatosDestinatario.Text = "Datos del destinatario";
            // 
            // txtNombreDestinatario
            // 
            this.txtNombreDestinatario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtNombreDestinatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreDestinatario.Location = new System.Drawing.Point(14, 54);
            this.txtNombreDestinatario.Name = "txtNombreDestinatario";
            this.txtNombreDestinatario.Size = new System.Drawing.Size(267, 21);
            this.txtNombreDestinatario.TabIndex = 60;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(10, 31);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(52, 15);
            this.lblNombre.TabIndex = 59;
            this.lblNombre.Text = "Nombre";
            // 
            // txtTelefonoDestinatario
            // 
            this.txtTelefonoDestinatario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtTelefonoDestinatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefonoDestinatario.Location = new System.Drawing.Point(15, 110);
            this.txtTelefonoDestinatario.Name = "txtTelefonoDestinatario";
            this.txtTelefonoDestinatario.Size = new System.Drawing.Size(267, 21);
            this.txtTelefonoDestinatario.TabIndex = 79;
            // 
            // lblApellidoPat
            // 
            this.lblApellidoPat.AutoSize = true;
            this.lblApellidoPat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellidoPat.Location = new System.Drawing.Point(295, 31);
            this.lblApellidoPat.Name = "lblApellidoPat";
            this.lblApellidoPat.Size = new System.Drawing.Size(97, 15);
            this.lblApellidoPat.TabIndex = 62;
            this.lblApellidoPat.Text = "Apellido Paterno";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(11, 87);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(55, 15);
            this.lblTelefono.TabIndex = 78;
            this.lblTelefono.Text = "Télefono";
            // 
            // txtApellidoPatDestinatario
            // 
            this.txtApellidoPatDestinatario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtApellidoPatDestinatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoPatDestinatario.Location = new System.Drawing.Point(299, 54);
            this.txtApellidoPatDestinatario.Name = "txtApellidoPatDestinatario";
            this.txtApellidoPatDestinatario.Size = new System.Drawing.Size(267, 21);
            this.txtApellidoPatDestinatario.TabIndex = 63;
            // 
            // txtApellidoMatDestinatario
            // 
            this.txtApellidoMatDestinatario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtApellidoMatDestinatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoMatDestinatario.Location = new System.Drawing.Point(585, 54);
            this.txtApellidoMatDestinatario.Name = "txtApellidoMatDestinatario";
            this.txtApellidoMatDestinatario.Size = new System.Drawing.Size(267, 21);
            this.txtApellidoMatDestinatario.TabIndex = 65;
            // 
            // lblApellidoMat
            // 
            this.lblApellidoMat.AutoSize = true;
            this.lblApellidoMat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellidoMat.Location = new System.Drawing.Point(581, 31);
            this.lblApellidoMat.Name = "lblApellidoMat";
            this.lblApellidoMat.Size = new System.Drawing.Size(100, 15);
            this.lblApellidoMat.TabIndex = 64;
            this.lblApellidoMat.Text = "Apellido Materno";
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.Location = new System.Drawing.Point(13, 60);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(267, 21);
            this.txtClave.TabIndex = 58;
            // 
            // cmbEstatus
            // 
            this.cmbEstatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.cmbEstatus.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstatus.FormattingEnabled = true;
            this.cmbEstatus.Location = new System.Drawing.Point(15, 118);
            this.cmbEstatus.Name = "cmbEstatus";
            this.cmbEstatus.Size = new System.Drawing.Size(266, 29);
            this.cmbEstatus.TabIndex = 51;
            this.cmbEstatus.SelectedIndexChanged += new System.EventHandler(this.cmbEstatus_SelectedIndexChanged);
            // 
            // btnMostrar
            // 
            this.btnMostrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrar.ForeColor = System.Drawing.Color.White;
            this.btnMostrar.Location = new System.Drawing.Point(299, 55);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(111, 30);
            this.btnMostrar.TabIndex = 57;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = false;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // lblEstatus
            // 
            this.lblEstatus.AutoSize = true;
            this.lblEstatus.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstatus.Location = new System.Drawing.Point(12, 94);
            this.lblEstatus.Name = "lblEstatus";
            this.lblEstatus.Size = new System.Drawing.Size(59, 21);
            this.lblEstatus.TabIndex = 52;
            this.lblEstatus.Text = "Estatus";
            // 
            // txtCostoTotal
            // 
            this.txtCostoTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtCostoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostoTotal.Location = new System.Drawing.Point(311, 205);
            this.txtCostoTotal.Name = "txtCostoTotal";
            this.txtCostoTotal.Size = new System.Drawing.Size(267, 21);
            this.txtCostoTotal.TabIndex = 73;
            // 
            // btnCambiar
            // 
            this.btnCambiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnCambiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiar.ForeColor = System.Drawing.Color.White;
            this.btnCambiar.Location = new System.Drawing.Point(299, 118);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(111, 29);
            this.btnCambiar.TabIndex = 55;
            this.btnCambiar.Text = "Cambiar Estatus";
            this.btnCambiar.UseVisualStyleBackColor = false;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(431, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 30);
            this.button1.TabIndex = 58;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(431, 118);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(111, 29);
            this.btnCancelar.TabIndex = 56;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeso.Location = new System.Drawing.Point(602, 182);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(35, 15);
            this.lblPeso.TabIndex = 21;
            this.lblPeso.Text = "Peso";
            // 
            // txtPeso
            // 
            this.txtPeso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeso.Location = new System.Drawing.Point(607, 205);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(267, 21);
            this.txtPeso.TabIndex = 74;
            // 
            // lblCostoTotal
            // 
            this.lblCostoTotal.AutoSize = true;
            this.lblCostoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoTotal.Location = new System.Drawing.Point(307, 183);
            this.lblCostoTotal.Name = "lblCostoTotal";
            this.lblCostoTotal.Size = new System.Drawing.Size(68, 15);
            this.lblCostoTotal.TabIndex = 20;
            this.lblCostoTotal.Text = "Costo Total";
            // 
            // gbpDireccionEnvio
            // 
            this.gbpDireccionEnvio.Controls.Add(this.cmbColonia);
            this.gbpDireccionEnvio.Controls.Add(this.lblPais);
            this.gbpDireccionEnvio.Controls.Add(this.lblEstado);
            this.gbpDireccionEnvio.Controls.Add(this.lblMunicipio);
            this.gbpDireccionEnvio.Controls.Add(this.txtNoCasa);
            this.gbpDireccionEnvio.Controls.Add(this.lblCodigoPostal);
            this.gbpDireccionEnvio.Controls.Add(this.txtCalle);
            this.gbpDireccionEnvio.Controls.Add(this.lblColoni);
            this.gbpDireccionEnvio.Controls.Add(this.lblCalle);
            this.gbpDireccionEnvio.Controls.Add(this.lblNoCasa);
            this.gbpDireccionEnvio.Controls.Add(this.cmbPaís);
            this.gbpDireccionEnvio.Controls.Add(this.cmbEstado);
            this.gbpDireccionEnvio.Controls.Add(this.cmbMunicipio);
            this.gbpDireccionEnvio.Controls.Add(this.txtCodigoPostal);
            this.gbpDireccionEnvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Bold);
            this.gbpDireccionEnvio.Location = new System.Drawing.Point(12, 348);
            this.gbpDireccionEnvio.Name = "gbpDireccionEnvio";
            this.gbpDireccionEnvio.Size = new System.Drawing.Size(886, 225);
            this.gbpDireccionEnvio.TabIndex = 80;
            this.gbpDireccionEnvio.TabStop = false;
            this.gbpDireccionEnvio.Text = "Dirección de destino";
            // 
            // cmbColonia
            // 
            this.cmbColonia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.cmbColonia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbColonia.FormattingEnabled = true;
            this.cmbColonia.Location = new System.Drawing.Point(309, 116);
            this.cmbColonia.Name = "cmbColonia";
            this.cmbColonia.Size = new System.Drawing.Size(267, 23);
            this.cmbColonia.TabIndex = 78;
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPais.Location = new System.Drawing.Point(17, 29);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(31, 15);
            this.lblPais.TabIndex = 24;
            this.lblPais.Text = "País";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(306, 29);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(45, 15);
            this.lblEstado.TabIndex = 25;
            this.lblEstado.Text = "Estado";
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMunicipio.Location = new System.Drawing.Point(592, 29);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(61, 15);
            this.lblMunicipio.TabIndex = 26;
            this.lblMunicipio.Text = "Municipio";
            // 
            // txtNoCasa
            // 
            this.txtNoCasa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtNoCasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoCasa.Location = new System.Drawing.Point(20, 182);
            this.txtNoCasa.Name = "txtNoCasa";
            this.txtNoCasa.Size = new System.Drawing.Size(267, 21);
            this.txtNoCasa.TabIndex = 77;
            // 
            // lblCodigoPostal
            // 
            this.lblCodigoPostal.AutoSize = true;
            this.lblCodigoPostal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoPostal.Location = new System.Drawing.Point(17, 93);
            this.lblCodigoPostal.Name = "lblCodigoPostal";
            this.lblCodigoPostal.Size = new System.Drawing.Size(83, 15);
            this.lblCodigoPostal.TabIndex = 27;
            this.lblCodigoPostal.Text = "Codigo Postal";
            // 
            // txtCalle
            // 
            this.txtCalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtCalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalle.Location = new System.Drawing.Point(596, 116);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(267, 21);
            this.txtCalle.TabIndex = 76;
            // 
            // lblColoni
            // 
            this.lblColoni.AutoSize = true;
            this.lblColoni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColoni.Location = new System.Drawing.Point(306, 93);
            this.lblColoni.Name = "lblColoni";
            this.lblColoni.Size = new System.Drawing.Size(49, 15);
            this.lblColoni.TabIndex = 28;
            this.lblColoni.Text = "Colonia";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalle.Location = new System.Drawing.Point(592, 93);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(35, 15);
            this.lblCalle.TabIndex = 29;
            this.lblCalle.Text = "Calle";
            // 
            // lblNoCasa
            // 
            this.lblNoCasa.AutoSize = true;
            this.lblNoCasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoCasa.Location = new System.Drawing.Point(17, 159);
            this.lblNoCasa.Name = "lblNoCasa";
            this.lblNoCasa.Size = new System.Drawing.Size(71, 15);
            this.lblNoCasa.TabIndex = 30;
            this.lblNoCasa.Text = "No de Casa";
            // 
            // cmbPaís
            // 
            this.cmbPaís.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.cmbPaís.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaís.FormattingEnabled = true;
            this.cmbPaís.Location = new System.Drawing.Point(20, 54);
            this.cmbPaís.Name = "cmbPaís";
            this.cmbPaís.Size = new System.Drawing.Size(267, 23);
            this.cmbPaís.TabIndex = 67;
            // 
            // cmbEstado
            // 
            this.cmbEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.cmbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(309, 54);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(267, 23);
            this.cmbEstado.TabIndex = 68;
            // 
            // cmbMunicipio
            // 
            this.cmbMunicipio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.cmbMunicipio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMunicipio.FormattingEnabled = true;
            this.cmbMunicipio.Location = new System.Drawing.Point(596, 54);
            this.cmbMunicipio.Name = "cmbMunicipio";
            this.cmbMunicipio.Size = new System.Drawing.Size(267, 23);
            this.cmbMunicipio.TabIndex = 69;
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtCodigoPostal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoPostal.Location = new System.Drawing.Point(20, 116);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(267, 21);
            this.txtCodigoPostal.TabIndex = 70;
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClave.Location = new System.Drawing.Point(9, 37);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(89, 15);
            this.lblClave.TabIndex = 17;
            this.lblClave.Text = "Clave de orden";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblNombreEmisor);
            this.groupBox2.Controls.Add(this.dgvOrden);
            this.groupBox2.Controls.Add(this.txtNombreEmisor);
            this.groupBox2.Controls.Add(this.dgvProductos);
            this.groupBox2.Controls.Add(this.gpbDatosDestinatario);
            this.groupBox2.Controls.Add(this.lblClave);
            this.groupBox2.Controls.Add(this.gbpDireccionEnvio);
            this.groupBox2.Controls.Add(this.lblCostoTotal);
            this.groupBox2.Controls.Add(this.txtPeso);
            this.groupBox2.Controls.Add(this.lblPeso);
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnCambiar);
            this.groupBox2.Controls.Add(this.txtCostoTotal);
            this.groupBox2.Controls.Add(this.lblEstatus);
            this.groupBox2.Controls.Add(this.btnMostrar);
            this.groupBox2.Controls.Add(this.cmbEstatus);
            this.groupBox2.Controls.Add(this.txtClave);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(25, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1534, 750);
            this.groupBox2.TabIndex = 85;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de envío";
            // 
            // lblNombreEmisor
            // 
            this.lblNombreEmisor.AutoSize = true;
            this.lblNombreEmisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreEmisor.Location = new System.Drawing.Point(12, 183);
            this.lblNombreEmisor.Name = "lblNombreEmisor";
            this.lblNombreEmisor.Size = new System.Drawing.Size(93, 15);
            this.lblNombreEmisor.TabIndex = 87;
            this.lblNombreEmisor.Text = "Nombre emisor";
            // 
            // txtNombreEmisor
            // 
            this.txtNombreEmisor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtNombreEmisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreEmisor.Location = new System.Drawing.Point(16, 205);
            this.txtNombreEmisor.Name = "txtNombreEmisor";
            this.txtNombreEmisor.Size = new System.Drawing.Size(267, 21);
            this.txtNombreEmisor.TabIndex = 88;
            // 
            // gpb
            // 
            this.gpb.Controls.Add(this.textBox1);
            this.gpb.Controls.Add(this.label1);
            this.gpb.Controls.Add(this.textBox2);
            this.gpb.Controls.Add(this.label2);
            this.gpb.Controls.Add(this.label3);
            this.gpb.Controls.Add(this.textBox3);
            this.gpb.Controls.Add(this.textBox4);
            this.gpb.Controls.Add(this.label4);
            this.gpb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Bold);
            this.gpb.Location = new System.Drawing.Point(8, 8);
            this.gpb.Name = "gpb";
            this.gpb.Size = new System.Drawing.Size(866, 150);
            this.gpb.TabIndex = 87;
            this.gpb.TabStop = false;
            this.gpb.Text = "Datos del vehiculo";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(14, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(267, 21);
            this.textBox1.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 59;
            this.label1.Text = "Nombre";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(15, 110);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(267, 21);
            this.textBox2.TabIndex = 79;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(295, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 62;
            this.label2.Text = "Apellido Paterno";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 78;
            this.label3.Text = "Télefono";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(299, 54);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(267, 21);
            this.textBox3.TabIndex = 63;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(585, 54);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(267, 21);
            this.textBox4.TabIndex = 65;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(581, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 15);
            this.label4.TabIndex = 64;
            this.label4.Text = "Apellido Materno";
            // 
            // frmDetallesDeOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(1598, 839);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmDetallesDeOrden";
            this.Text = "Detalles de Orden";
            this.Load += new System.EventHandler(this.frmDetallesDeOrden_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrden)).EndInit();
            this.gpbDatosDestinatario.ResumeLayout(false);
            this.gpbDatosDestinatario.PerformLayout();
            this.gbpDireccionEnvio.ResumeLayout(false);
            this.gbpDireccionEnvio.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gpb.ResumeLayout(false);
            this.gpb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridView dgvOrden;
        private System.Windows.Forms.GroupBox gpbDatosDestinatario;
        private System.Windows.Forms.TextBox txtNombreDestinatario;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtTelefonoDestinatario;
        private System.Windows.Forms.Label lblApellidoPat;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtApellidoPatDestinatario;
        private System.Windows.Forms.TextBox txtApellidoMatDestinatario;
        private System.Windows.Forms.Label lblApellidoMat;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.ComboBox cmbEstatus;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Label lblEstatus;
        private System.Windows.Forms.TextBox txtCostoTotal;
        private System.Windows.Forms.Button btnCambiar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Label lblCostoTotal;
        private System.Windows.Forms.GroupBox gbpDireccionEnvio;
        private System.Windows.Forms.ComboBox cmbColonia;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.TextBox txtNoCasa;
        private System.Windows.Forms.Label lblCodigoPostal;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Label lblColoni;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.Label lblNoCasa;
        private System.Windows.Forms.ComboBox cmbPaís;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.ComboBox cmbMunicipio;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gpb;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNombreEmisor;
        private System.Windows.Forms.TextBox txtNombreEmisor;
    }
}