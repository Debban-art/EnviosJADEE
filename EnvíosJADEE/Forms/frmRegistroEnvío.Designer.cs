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
            this.cmbIdCliente = new System.Windows.Forms.ComboBox();
            this.cmbIdEstatusOrden = new System.Windows.Forms.ComboBox();
            this.cmbIdProducto = new System.Windows.Forms.ComboBox();
            this.txtCostoTotal = new System.Windows.Forms.TextBox();
            this.txtNoCasa = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.txtFechaEntrega = new System.Windows.Forms.TextBox();
            this.txtFechaSalida = new System.Windows.Forms.TextBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.dgvRegistroEnvio = new System.Windows.Forms.DataGridView();
            this.lblIdCliente = new System.Windows.Forms.Label();
            this.lblIdProducto = new System.Windows.Forms.Label();
            this.lblIdEstatusOrden = new System.Windows.Forms.Label();
            this.lblCostoTotal = new System.Windows.Forms.Label();
            this.lblPeso = new System.Windows.Forms.Label();
            this.lblFechaSalida = new System.Windows.Forms.Label();
            this.lblFechaEntrega = new System.Windows.Forms.Label();
            this.lblPais = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.lblCodigoPostal = new System.Windows.Forms.Label();
            this.lblDomicilio = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lblNoCasa = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAñadir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroEnvio)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbIdCliente
            // 
            this.cmbIdCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.cmbIdCliente.FormattingEnabled = true;
            this.cmbIdCliente.Location = new System.Drawing.Point(64, 87);
            this.cmbIdCliente.Name = "cmbIdCliente";
            this.cmbIdCliente.Size = new System.Drawing.Size(228, 21);
            this.cmbIdCliente.TabIndex = 0;
            // 
            // cmbIdEstatusOrden
            // 
            this.cmbIdEstatusOrden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.cmbIdEstatusOrden.FormattingEnabled = true;
            this.cmbIdEstatusOrden.Location = new System.Drawing.Point(64, 186);
            this.cmbIdEstatusOrden.Name = "cmbIdEstatusOrden";
            this.cmbIdEstatusOrden.Size = new System.Drawing.Size(228, 21);
            this.cmbIdEstatusOrden.TabIndex = 1;
            // 
            // cmbIdProducto
            // 
            this.cmbIdProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.cmbIdProducto.FormattingEnabled = true;
            this.cmbIdProducto.Location = new System.Drawing.Point(64, 137);
            this.cmbIdProducto.Name = "cmbIdProducto";
            this.cmbIdProducto.Size = new System.Drawing.Size(228, 21);
            this.cmbIdProducto.TabIndex = 2;
            // 
            // txtCostoTotal
            // 
            this.txtCostoTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtCostoTotal.Location = new System.Drawing.Point(65, 230);
            this.txtCostoTotal.Name = "txtCostoTotal";
            this.txtCostoTotal.Size = new System.Drawing.Size(228, 20);
            this.txtCostoTotal.TabIndex = 3;
            // 
            // txtNoCasa
            // 
            this.txtNoCasa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtNoCasa.Location = new System.Drawing.Point(64, 678);
            this.txtNoCasa.Name = "txtNoCasa";
            this.txtNoCasa.Size = new System.Drawing.Size(228, 20);
            this.txtNoCasa.TabIndex = 4;
            // 
            // txtCalle
            // 
            this.txtCalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtCalle.Location = new System.Drawing.Point(64, 629);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(228, 20);
            this.txtCalle.TabIndex = 5;
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtDomicilio.Location = new System.Drawing.Point(64, 584);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(228, 20);
            this.txtDomicilio.TabIndex = 6;
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtCodigoPostal.Location = new System.Drawing.Point(65, 538);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(228, 20);
            this.txtCodigoPostal.TabIndex = 7;
            // 
            // txtCiudad
            // 
            this.txtCiudad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtCiudad.Location = new System.Drawing.Point(65, 493);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(228, 20);
            this.txtCiudad.TabIndex = 8;
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtEstado.Location = new System.Drawing.Point(64, 450);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(228, 20);
            this.txtEstado.TabIndex = 9;
            // 
            // txtPais
            // 
            this.txtPais.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtPais.Location = new System.Drawing.Point(64, 407);
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(228, 20);
            this.txtPais.TabIndex = 10;
            // 
            // txtFechaEntrega
            // 
            this.txtFechaEntrega.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtFechaEntrega.Location = new System.Drawing.Point(64, 365);
            this.txtFechaEntrega.Name = "txtFechaEntrega";
            this.txtFechaEntrega.Size = new System.Drawing.Size(228, 20);
            this.txtFechaEntrega.TabIndex = 11;
            // 
            // txtFechaSalida
            // 
            this.txtFechaSalida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtFechaSalida.Location = new System.Drawing.Point(64, 322);
            this.txtFechaSalida.Name = "txtFechaSalida";
            this.txtFechaSalida.Size = new System.Drawing.Size(228, 20);
            this.txtFechaSalida.TabIndex = 12;
            // 
            // txtPeso
            // 
            this.txtPeso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtPeso.Location = new System.Drawing.Point(64, 273);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(228, 20);
            this.txtPeso.TabIndex = 13;
            // 
            // dgvRegistroEnvio
            // 
            this.dgvRegistroEnvio.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(69)))));
            this.dgvRegistroEnvio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistroEnvio.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvRegistroEnvio.Location = new System.Drawing.Point(321, 87);
            this.dgvRegistroEnvio.Name = "dgvRegistroEnvio";
            this.dgvRegistroEnvio.Size = new System.Drawing.Size(742, 362);
            this.dgvRegistroEnvio.TabIndex = 14;
            // 
            // lblIdCliente
            // 
            this.lblIdCliente.AutoSize = true;
            this.lblIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdCliente.Location = new System.Drawing.Point(68, 64);
            this.lblIdCliente.Name = "lblIdCliente";
            this.lblIdCliente.Size = new System.Drawing.Size(58, 20);
            this.lblIdCliente.TabIndex = 17;
            this.lblIdCliente.Text = "Cliente";
            // 
            // lblIdProducto
            // 
            this.lblIdProducto.AutoSize = true;
            this.lblIdProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdProducto.Location = new System.Drawing.Point(68, 114);
            this.lblIdProducto.Name = "lblIdProducto";
            this.lblIdProducto.Size = new System.Drawing.Size(73, 20);
            this.lblIdProducto.TabIndex = 18;
            this.lblIdProducto.Text = "Producto";
            // 
            // lblIdEstatusOrden
            // 
            this.lblIdEstatusOrden.AutoSize = true;
            this.lblIdEstatusOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdEstatusOrden.Location = new System.Drawing.Point(68, 163);
            this.lblIdEstatusOrden.Name = "lblIdEstatusOrden";
            this.lblIdEstatusOrden.Size = new System.Drawing.Size(108, 20);
            this.lblIdEstatusOrden.TabIndex = 19;
            this.lblIdEstatusOrden.Text = "EstatusOrden";
            // 
            // lblCostoTotal
            // 
            this.lblCostoTotal.AutoSize = true;
            this.lblCostoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoTotal.Location = new System.Drawing.Point(68, 210);
            this.lblCostoTotal.Name = "lblCostoTotal";
            this.lblCostoTotal.Size = new System.Drawing.Size(90, 20);
            this.lblCostoTotal.TabIndex = 20;
            this.lblCostoTotal.Text = "Costo Total";
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeso.Location = new System.Drawing.Point(68, 253);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(45, 20);
            this.lblPeso.TabIndex = 21;
            this.lblPeso.Text = "Peso";
            // 
            // lblFechaSalida
            // 
            this.lblFechaSalida.AutoSize = true;
            this.lblFechaSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaSalida.Location = new System.Drawing.Point(66, 299);
            this.lblFechaSalida.Name = "lblFechaSalida";
            this.lblFechaSalida.Size = new System.Drawing.Size(124, 20);
            this.lblFechaSalida.TabIndex = 22;
            this.lblFechaSalida.Text = "Fecha de Salida";
            // 
            // lblFechaEntrega
            // 
            this.lblFechaEntrega.AutoSize = true;
            this.lblFechaEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaEntrega.Location = new System.Drawing.Point(66, 342);
            this.lblFechaEntrega.Name = "lblFechaEntrega";
            this.lblFechaEntrega.Size = new System.Drawing.Size(137, 20);
            this.lblFechaEntrega.TabIndex = 23;
            this.lblFechaEntrega.Text = "Fecha de Entrega";
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPais.Location = new System.Drawing.Point(68, 388);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(39, 20);
            this.lblPais.TabIndex = 24;
            this.lblPais.Text = "País";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(67, 430);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(60, 20);
            this.lblEstado.TabIndex = 25;
            this.lblEstado.Text = "Estado";
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCiudad.Location = new System.Drawing.Point(66, 473);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(59, 20);
            this.lblCiudad.TabIndex = 26;
            this.lblCiudad.Text = "Ciudad";
            // 
            // lblCodigoPostal
            // 
            this.lblCodigoPostal.AutoSize = true;
            this.lblCodigoPostal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoPostal.Location = new System.Drawing.Point(68, 516);
            this.lblCodigoPostal.Name = "lblCodigoPostal";
            this.lblCodigoPostal.Size = new System.Drawing.Size(107, 20);
            this.lblCodigoPostal.TabIndex = 27;
            this.lblCodigoPostal.Text = "Codigo Postal";
            // 
            // lblDomicilio
            // 
            this.lblDomicilio.AutoSize = true;
            this.lblDomicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomicilio.Location = new System.Drawing.Point(68, 561);
            this.lblDomicilio.Name = "lblDomicilio";
            this.lblDomicilio.Size = new System.Drawing.Size(72, 20);
            this.lblDomicilio.TabIndex = 28;
            this.lblDomicilio.Text = "Domicilio";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalle.Location = new System.Drawing.Point(68, 607);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(44, 20);
            this.lblCalle.TabIndex = 29;
            this.lblCalle.Text = "Calle";
            // 
            // lblNoCasa
            // 
            this.lblNoCasa.AutoSize = true;
            this.lblNoCasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoCasa.Location = new System.Drawing.Point(67, 655);
            this.lblNoCasa.Name = "lblNoCasa";
            this.lblNoCasa.Size = new System.Drawing.Size(92, 20);
            this.lblNoCasa.TabIndex = 30;
            this.lblNoCasa.Text = "No de Casa";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(438, 657);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(111, 41);
            this.btnCancelar.TabIndex = 32;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnAñadir
            // 
            this.btnAñadir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnAñadir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAñadir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadir.ForeColor = System.Drawing.Color.White;
            this.btnAñadir.Location = new System.Drawing.Point(321, 657);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(111, 41);
            this.btnAñadir.TabIndex = 31;
            this.btnAñadir.Text = "Añadir";
            this.btnAñadir.UseVisualStyleBackColor = false;
            // 
            // frmEnvíos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(1161, 736);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAñadir);
            this.Controls.Add(this.lblNoCasa);
            this.Controls.Add(this.lblCalle);
            this.Controls.Add(this.lblDomicilio);
            this.Controls.Add(this.lblCodigoPostal);
            this.Controls.Add(this.lblCiudad);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblPais);
            this.Controls.Add(this.lblFechaEntrega);
            this.Controls.Add(this.lblFechaSalida);
            this.Controls.Add(this.lblPeso);
            this.Controls.Add(this.lblCostoTotal);
            this.Controls.Add(this.lblIdEstatusOrden);
            this.Controls.Add(this.lblIdProducto);
            this.Controls.Add(this.lblIdCliente);
            this.Controls.Add(this.dgvRegistroEnvio);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.txtFechaSalida);
            this.Controls.Add(this.txtFechaEntrega);
            this.Controls.Add(this.txtPais);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtCiudad);
            this.Controls.Add(this.txtCodigoPostal);
            this.Controls.Add(this.txtDomicilio);
            this.Controls.Add(this.txtCalle);
            this.Controls.Add(this.txtNoCasa);
            this.Controls.Add(this.txtCostoTotal);
            this.Controls.Add(this.cmbIdProducto);
            this.Controls.Add(this.cmbIdEstatusOrden);
            this.Controls.Add(this.cmbIdCliente);
            this.Name = "frmEnvíos";
            this.Text = "Ordenes";
            this.Load += new System.EventHandler(this.frmRegistroEnvío_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroEnvio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbIdCliente;
        private System.Windows.Forms.ComboBox cmbIdEstatusOrden;
        private System.Windows.Forms.ComboBox cmbIdProducto;
        private System.Windows.Forms.TextBox txtCostoTotal;
        private System.Windows.Forms.TextBox txtNoCasa;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.TextBox txtFechaEntrega;
        private System.Windows.Forms.TextBox txtFechaSalida;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.DataGridView dgvRegistroEnvio;
        private System.Windows.Forms.Label lblIdCliente;
        private System.Windows.Forms.Label lblIdProducto;
        private System.Windows.Forms.Label lblIdEstatusOrden;
        private System.Windows.Forms.Label lblCostoTotal;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Label lblFechaSalida;
        private System.Windows.Forms.Label lblFechaEntrega;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.Label lblCodigoPostal;
        private System.Windows.Forms.Label lblDomicilio;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.Label lblNoCasa;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAñadir;
    }
}