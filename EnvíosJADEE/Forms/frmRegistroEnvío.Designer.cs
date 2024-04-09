namespace EnvíosJADEE.Forms
{
    partial class frmEnvíos
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
            this.lblDatosDePersonaQueEnvía = new System.Windows.Forms.Label();
            this.lblIdProducto = new System.Windows.Forms.Label();
            this.lblCostoTotal = new System.Windows.Forms.Label();
            this.lblPeso = new System.Windows.Forms.Label();
            this.lblPais = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.lblCodigoPostal = new System.Windows.Forms.Label();
            this.lblColoni = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lblNoCasa = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAñadir = new System.Windows.Forms.Button();
            this.txtNombreEmisor = new System.Windows.Forms.TextBox();
            this.txtNombreDestinatario = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtApellidoPatDestinatario = new System.Windows.Forms.TextBox();
            this.lblApellidoPat = new System.Windows.Forms.Label();
            this.txtApellidoMatDestinatario = new System.Windows.Forms.TextBox();
            this.lblApellidoMat = new System.Windows.Forms.Label();
            this.cmbPaís = new System.Windows.Forms.ComboBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.cmbMunicipio = new System.Windows.Forms.ComboBox();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.txtCostoTotal = new System.Windows.Forms.TextBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtNoCasa = new System.Windows.Forms.TextBox();
            this.txtTelefonoDestinatario = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.gbpDireccionEnvio = new System.Windows.Forms.GroupBox();
            this.cmbColonia = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.gpbDatosDestinatario = new System.Windows.Forms.GroupBox();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.gbpDireccionEnvio.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gpbDatosDestinatario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDatosDePersonaQueEnvía
            // 
            this.lblDatosDePersonaQueEnvía.AutoSize = true;
            this.lblDatosDePersonaQueEnvía.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosDePersonaQueEnvía.Location = new System.Drawing.Point(9, 37);
            this.lblDatosDePersonaQueEnvía.Name = "lblDatosDePersonaQueEnvía";
            this.lblDatosDePersonaQueEnvía.Size = new System.Drawing.Size(173, 15);
            this.lblDatosDePersonaQueEnvía.TabIndex = 17;
            this.lblDatosDePersonaQueEnvía.Text = "Nombre de persona que envía";
            // 
            // lblIdProducto
            // 
            this.lblIdProducto.AutoSize = true;
            this.lblIdProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdProducto.Location = new System.Drawing.Point(295, 39);
            this.lblIdProducto.Name = "lblIdProducto";
            this.lblIdProducto.Size = new System.Drawing.Size(62, 15);
            this.lblIdProducto.TabIndex = 18;
            this.lblIdProducto.Text = "Productos";
            // 
            // lblCostoTotal
            // 
            this.lblCostoTotal.AutoSize = true;
            this.lblCostoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoTotal.Location = new System.Drawing.Point(8, 94);
            this.lblCostoTotal.Name = "lblCostoTotal";
            this.lblCostoTotal.Size = new System.Drawing.Size(68, 15);
            this.lblCostoTotal.TabIndex = 20;
            this.lblCostoTotal.Text = "Costo Total";
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeso.Location = new System.Drawing.Point(293, 93);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(35, 15);
            this.lblPeso.TabIndex = 21;
            this.lblPeso.Text = "Peso";
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
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(129, 653);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(111, 41);
            this.btnCancelar.TabIndex = 32;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // btnAñadir
            // 
            this.btnAñadir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnAñadir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAñadir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadir.ForeColor = System.Drawing.Color.White;
            this.btnAñadir.Location = new System.Drawing.Point(12, 653);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(111, 41);
            this.btnAñadir.TabIndex = 31;
            this.btnAñadir.Text = "Añadir";
            this.btnAñadir.UseVisualStyleBackColor = false;
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click_1);
            // 
            // txtNombreEmisor
            // 
            this.txtNombreEmisor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtNombreEmisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreEmisor.Location = new System.Drawing.Point(13, 60);
            this.txtNombreEmisor.Name = "txtNombreEmisor";
            this.txtNombreEmisor.Size = new System.Drawing.Size(267, 21);
            this.txtNombreEmisor.TabIndex = 58;
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
            // txtApellidoPatDestinatario
            // 
            this.txtApellidoPatDestinatario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtApellidoPatDestinatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoPatDestinatario.Location = new System.Drawing.Point(299, 54);
            this.txtApellidoPatDestinatario.Name = "txtApellidoPatDestinatario";
            this.txtApellidoPatDestinatario.Size = new System.Drawing.Size(267, 21);
            this.txtApellidoPatDestinatario.TabIndex = 63;
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
            // cmbPaís
            // 
            this.cmbPaís.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.cmbPaís.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cmbMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMunicipio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMunicipio.FormattingEnabled = true;
            this.cmbMunicipio.Location = new System.Drawing.Point(596, 54);
            this.cmbMunicipio.Name = "cmbMunicipio";
            this.cmbMunicipio.Size = new System.Drawing.Size(267, 23);
            this.cmbMunicipio.TabIndex = 69;
            this.cmbMunicipio.SelectedIndexChanged += new System.EventHandler(this.cmbMunicipio_SelectedIndexChanged);
            // 
            // cmbProducto
            // 
            this.cmbProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(299, 58);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(267, 23);
            this.cmbProducto.TabIndex = 72;
            // 
            // txtCostoTotal
            // 
            this.txtCostoTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtCostoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostoTotal.Location = new System.Drawing.Point(12, 116);
            this.txtCostoTotal.Name = "txtCostoTotal";
            this.txtCostoTotal.Size = new System.Drawing.Size(267, 21);
            this.txtCostoTotal.TabIndex = 73;
            // 
            // txtPeso
            // 
            this.txtPeso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeso.Location = new System.Drawing.Point(298, 116);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(267, 21);
            this.txtPeso.TabIndex = 74;
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtCodigoPostal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoPostal.Location = new System.Drawing.Point(20, 116);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(267, 21);
            this.txtCodigoPostal.TabIndex = 70;
            this.txtCodigoPostal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoPostal_KeyDown);
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
            // txtNoCasa
            // 
            this.txtNoCasa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtNoCasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoCasa.Location = new System.Drawing.Point(20, 182);
            this.txtNoCasa.Name = "txtNoCasa";
            this.txtNoCasa.Size = new System.Drawing.Size(267, 21);
            this.txtNoCasa.TabIndex = 77;
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
            this.gbpDireccionEnvio.Location = new System.Drawing.Point(14, 163);
            this.gbpDireccionEnvio.Name = "gbpDireccionEnvio";
            this.gbpDireccionEnvio.Size = new System.Drawing.Size(886, 225);
            this.gbpDireccionEnvio.TabIndex = 80;
            this.gbpDireccionEnvio.TabStop = false;
            this.gbpDireccionEnvio.Text = "Dirección de envío";
            // 
            // cmbColonia
            // 
            this.cmbColonia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.cmbColonia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColonia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbColonia.FormattingEnabled = true;
            this.cmbColonia.Location = new System.Drawing.Point(309, 116);
            this.cmbColonia.Name = "cmbColonia";
            this.cmbColonia.Size = new System.Drawing.Size(267, 23);
            this.cmbColonia.TabIndex = 78;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAgregarProducto);
            this.groupBox2.Controls.Add(this.lblDatosDePersonaQueEnvía);
            this.groupBox2.Controls.Add(this.gbpDireccionEnvio);
            this.groupBox2.Controls.Add(this.lblIdProducto);
            this.groupBox2.Controls.Add(this.lblCostoTotal);
            this.groupBox2.Controls.Add(this.txtPeso);
            this.groupBox2.Controls.Add(this.lblPeso);
            this.groupBox2.Controls.Add(this.txtCostoTotal);
            this.groupBox2.Controls.Add(this.txtNombreEmisor);
            this.groupBox2.Controls.Add(this.cmbProducto);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(12, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(924, 417);
            this.groupBox2.TabIndex = 81;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de envío";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAgregarProducto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProducto.Location = new System.Drawing.Point(584, 51);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(150, 34);
            this.btnAgregarProducto.TabIndex = 81;
            this.btnAgregarProducto.Text = "Añadir producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = false;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // gpbDatosDestinatario
            // 
            this.gpbDatosDestinatario.Controls.Add(this.txtNombreDestinatario);
            this.gpbDatosDestinatario.Controls.Add(this.lblNombre);
            this.gpbDatosDestinatario.Controls.Add(this.txtTelefonoDestinatario);
            this.gpbDatosDestinatario.Controls.Add(this.lblApellidoPat);
            this.gpbDatosDestinatario.Controls.Add(this.lblTelefono);
            this.gpbDatosDestinatario.Controls.Add(this.txtApellidoPatDestinatario);
            this.gpbDatosDestinatario.Controls.Add(this.txtApellidoMatDestinatario);
            this.gpbDatosDestinatario.Controls.Add(this.lblApellidoMat);
            this.gpbDatosDestinatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.gpbDatosDestinatario.Location = new System.Drawing.Point(12, 482);
            this.gpbDatosDestinatario.Name = "gpbDatosDestinatario";
            this.gpbDatosDestinatario.Size = new System.Drawing.Size(866, 150);
            this.gpbDatosDestinatario.TabIndex = 82;
            this.gpbDatosDestinatario.TabStop = false;
            this.gpbDatosDestinatario.Text = "Datos del destinatario";
            this.gpbDatosDestinatario.Enter += new System.EventHandler(this.gpbDatosDestinatario_Enter);
            // 
            // dgvOrdenes
            // 
            this.dgvOrdenes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(69)))));
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvOrdenes.Location = new System.Drawing.Point(942, 165);
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.Size = new System.Drawing.Size(651, 362);
            this.dgvOrdenes.TabIndex = 14;
            this.dgvOrdenes.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenes_CellEndEdit);
            this.dgvOrdenes.SelectionChanged += new System.EventHandler(this.dgvOrdenes_SelectionChanged);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportarExcel.Location = new System.Drawing.Point(942, 545);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(209, 30);
            this.btnExportarExcel.TabIndex = 89;
            this.btnExportarExcel.Text = "Exportar ordenes a Excel";
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Brown;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(1157, 545);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(96, 30);
            this.btnEliminar.TabIndex = 105;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmEnvíos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(1364, 749);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.gpbDatosDestinatario);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAñadir);
            this.Controls.Add(this.dgvOrdenes);
            this.Name = "frmEnvíos";
            this.Text = "Ordenes";
            this.Load += new System.EventHandler(this.frmRegistroEnvío_Load);
            this.gbpDireccionEnvio.ResumeLayout(false);
            this.gbpDireccionEnvio.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gpbDatosDestinatario.ResumeLayout(false);
            this.gpbDatosDestinatario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblDatosDePersonaQueEnvía;
        private System.Windows.Forms.Label lblIdProducto;
        private System.Windows.Forms.Label lblCostoTotal;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.Label lblCodigoPostal;
        private System.Windows.Forms.Label lblColoni;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.Label lblNoCasa;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAñadir;
        private System.Windows.Forms.TextBox txtNombreEmisor;
        private System.Windows.Forms.TextBox txtNombreDestinatario;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtApellidoPatDestinatario;
        private System.Windows.Forms.Label lblApellidoPat;
        private System.Windows.Forms.TextBox txtApellidoMatDestinatario;
        private System.Windows.Forms.Label lblApellidoMat;
        private System.Windows.Forms.ComboBox cmbPaís;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.ComboBox cmbMunicipio;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.TextBox txtCostoTotal;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtNoCasa;
        private System.Windows.Forms.TextBox txtTelefonoDestinatario;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.GroupBox gbpDireccionEnvio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gpbDatosDestinatario;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.DataGridView dgvOrdenes;
        private System.Windows.Forms.ComboBox cmbColonia;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnEliminar;
    }
}