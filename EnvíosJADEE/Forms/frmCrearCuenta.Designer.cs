namespace EnvíosJADEE.Forms
{
    partial class frmCrearCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrearCuenta));
            this.lblPerfil = new System.Windows.Forms.Label();
            this.cmbPerfiles = new System.Windows.Forms.ComboBox();
            this.lblDirección = new System.Windows.Forms.Label();
            this.lblApMaterno = new System.Windows.Forms.Label();
            this.lblApPaterno = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnCrearCuenta = new System.Windows.Forms.Button();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.lblRegistrarse = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApPaterno = new System.Windows.Forms.TextBox();
            this.txtApMaterno = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lnklblIniciarSesión = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPerfil
            // 
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerfil.Location = new System.Drawing.Point(63, 382);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(47, 21);
            this.lblPerfil.TabIndex = 64;
            this.lblPerfil.Text = "Perfil";
            // 
            // cmbPerfiles
            // 
            this.cmbPerfiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.cmbPerfiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPerfiles.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPerfiles.FormattingEnabled = true;
            this.cmbPerfiles.Location = new System.Drawing.Point(67, 406);
            this.cmbPerfiles.Name = "cmbPerfiles";
            this.cmbPerfiles.Size = new System.Drawing.Size(300, 29);
            this.cmbPerfiles.TabIndex = 63;
            // 
            // lblDirección
            // 
            this.lblDirección.AutoSize = true;
            this.lblDirección.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirección.Location = new System.Drawing.Point(63, 325);
            this.lblDirección.Name = "lblDirección";
            this.lblDirección.Size = new System.Drawing.Size(75, 21);
            this.lblDirección.TabIndex = 62;
            this.lblDirección.Text = "Dirección";
            // 
            // lblApMaterno
            // 
            this.lblApMaterno.AutoSize = true;
            this.lblApMaterno.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApMaterno.Location = new System.Drawing.Point(63, 276);
            this.lblApMaterno.Name = "lblApMaterno";
            this.lblApMaterno.Size = new System.Drawing.Size(130, 21);
            this.lblApMaterno.TabIndex = 61;
            this.lblApMaterno.Text = "Apellido Materno";
            // 
            // lblApPaterno
            // 
            this.lblApPaterno.AutoSize = true;
            this.lblApPaterno.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApPaterno.Location = new System.Drawing.Point(63, 218);
            this.lblApPaterno.Name = "lblApPaterno";
            this.lblApPaterno.Size = new System.Drawing.Size(125, 21);
            this.lblApPaterno.TabIndex = 60;
            this.lblApPaterno.Text = "Apellido Paterno";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(63, 157);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(68, 21);
            this.lblNombre.TabIndex = 59;
            this.lblNombre.Text = "Nombre";
            // 
            // btnCrearCuenta
            // 
            this.btnCrearCuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnCrearCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearCuenta.ForeColor = System.Drawing.Color.White;
            this.btnCrearCuenta.Location = new System.Drawing.Point(67, 464);
            this.btnCrearCuenta.Name = "btnCrearCuenta";
            this.btnCrearCuenta.Size = new System.Drawing.Size(300, 36);
            this.btnCrearCuenta.TabIndex = 65;
            this.btnCrearCuenta.Text = "Crear cuenta";
            this.btnCrearCuenta.UseVisualStyleBackColor = false;
            this.btnCrearCuenta.Click += new System.EventHandler(this.btnCrearCuenta_Click);
            // 
            // pbxLogo
            // 
            this.pbxLogo.Image = global::EnvíosJADEE.Properties.Resources.package_122391;
            this.pbxLogo.Location = new System.Drawing.Point(172, 12);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(92, 89);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogo.TabIndex = 66;
            this.pbxLogo.TabStop = false;
            // 
            // lblRegistrarse
            // 
            this.lblRegistrarse.AutoSize = true;
            this.lblRegistrarse.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrarse.Location = new System.Drawing.Point(130, 115);
            this.lblRegistrarse.Name = "lblRegistrarse";
            this.lblRegistrarse.Size = new System.Drawing.Size(199, 42);
            this.lblRegistrarse.TabIndex = 67;
            this.lblRegistrarse.Text = "Registrarse";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtNombre.Location = new System.Drawing.Point(67, 181);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(300, 22);
            this.txtNombre.TabIndex = 68;
            // 
            // txtApPaterno
            // 
            this.txtApPaterno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtApPaterno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtApPaterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApPaterno.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtApPaterno.Location = new System.Drawing.Point(67, 242);
            this.txtApPaterno.Name = "txtApPaterno";
            this.txtApPaterno.Size = new System.Drawing.Size(300, 22);
            this.txtApPaterno.TabIndex = 69;
            // 
            // txtApMaterno
            // 
            this.txtApMaterno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtApMaterno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtApMaterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApMaterno.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtApMaterno.Location = new System.Drawing.Point(67, 300);
            this.txtApMaterno.Name = "txtApMaterno";
            this.txtApMaterno.Size = new System.Drawing.Size(300, 22);
            this.txtApMaterno.TabIndex = 70;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtDireccion.Location = new System.Drawing.Point(67, 349);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(300, 22);
            this.txtDireccion.TabIndex = 71;
            // 
            // lnklblIniciarSesión
            // 
            this.lnklblIniciarSesión.AutoSize = true;
            this.lnklblIniciarSesión.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.lnklblIniciarSesión.Location = new System.Drawing.Point(163, 516);
            this.lnklblIniciarSesión.Name = "lnklblIniciarSesión";
            this.lnklblIniciarSesión.Size = new System.Drawing.Size(70, 13);
            this.lnklblIniciarSesión.TabIndex = 72;
            this.lnklblIniciarSesión.TabStop = true;
            this.lnklblIniciarSesión.Text = "Iniciar Sesión";
            this.lnklblIniciarSesión.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblIniciarSesión_LinkClicked);
            // 
            // frmCrearCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(432, 538);
            this.Controls.Add(this.lnklblIniciarSesión);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtApMaterno);
            this.Controls.Add(this.txtApPaterno);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblRegistrarse);
            this.Controls.Add(this.pbxLogo);
            this.Controls.Add(this.btnCrearCuenta);
            this.Controls.Add(this.lblPerfil);
            this.Controls.Add(this.cmbPerfiles);
            this.Controls.Add(this.lblDirección);
            this.Controls.Add(this.lblApMaterno);
            this.Controls.Add(this.lblApPaterno);
            this.Controls.Add(this.lblNombre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCrearCuenta";
            this.Text = "Registrarse";
            this.Load += new System.EventHandler(this.frmCrearCuenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPerfil;
        private System.Windows.Forms.ComboBox cmbPerfiles;
        private System.Windows.Forms.Label lblDirección;
        private System.Windows.Forms.Label lblApMaterno;
        private System.Windows.Forms.Label lblApPaterno;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnCrearCuenta;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Label lblRegistrarse;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApPaterno;
        private System.Windows.Forms.TextBox txtApMaterno;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.LinkLabel lnklblIniciarSesión;
    }
}