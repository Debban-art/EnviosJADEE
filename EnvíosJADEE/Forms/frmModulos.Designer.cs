﻿namespace EnvíosJADEE.Forms
{
    partial class frmModulos
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAñadir = new System.Windows.Forms.Button();
            this.cmbModulo = new System.Windows.Forms.ComboBox();
            this.lblUsuarioRegistra = new System.Windows.Forms.Label();
            this.lblPerfil = new System.Windows.Forms.Label();
            this.lblModulo = new System.Windows.Forms.Label();
            this.txtUsuarioRegistra = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.dgvCategorías = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorías)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(186, 396);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(111, 41);
            this.btnCancelar.TabIndex = 52;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnAñadir
            // 
            this.btnAñadir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnAñadir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAñadir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadir.ForeColor = System.Drawing.Color.White;
            this.btnAñadir.Location = new System.Drawing.Point(69, 396);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(111, 41);
            this.btnAñadir.TabIndex = 51;
            this.btnAñadir.Text = "Añadir";
            this.btnAñadir.UseVisualStyleBackColor = false;
            // 
            // cmbModulo
            // 
            this.cmbModulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.cmbModulo.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbModulo.FormattingEnabled = true;
            this.cmbModulo.Location = new System.Drawing.Point(69, 143);
            this.cmbModulo.Name = "cmbModulo";
            this.cmbModulo.Size = new System.Drawing.Size(228, 29);
            this.cmbModulo.TabIndex = 50;
            // 
            // lblUsuarioRegistra
            // 
            this.lblUsuarioRegistra.AutoSize = true;
            this.lblUsuarioRegistra.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioRegistra.Location = new System.Drawing.Point(65, 278);
            this.lblUsuarioRegistra.Name = "lblUsuarioRegistra";
            this.lblUsuarioRegistra.Size = new System.Drawing.Size(125, 21);
            this.lblUsuarioRegistra.TabIndex = 49;
            this.lblUsuarioRegistra.Text = "Usuario Registra";
            // 
            // lblPerfil
            // 
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerfil.Location = new System.Drawing.Point(65, 191);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(68, 21);
            this.lblPerfil.TabIndex = 48;
            this.lblPerfil.Text = "Nombre";
            // 
            // lblModulo
            // 
            this.lblModulo.AutoSize = true;
            this.lblModulo.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModulo.Location = new System.Drawing.Point(65, 119);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(77, 21);
            this.lblModulo.TabIndex = 47;
            this.lblModulo.Text = "Categoría";
            // 
            // txtUsuarioRegistra
            // 
            this.txtUsuarioRegistra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtUsuarioRegistra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRegistra.Location = new System.Drawing.Point(69, 302);
            this.txtUsuarioRegistra.Name = "txtUsuarioRegistra";
            this.txtUsuarioRegistra.Size = new System.Drawing.Size(228, 26);
            this.txtUsuarioRegistra.TabIndex = 46;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(69, 215);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(228, 26);
            this.txtNombre.TabIndex = 53;
            // 
            // dgvCategorías
            // 
            this.dgvCategorías.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(69)))));
            this.dgvCategorías.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorías.Location = new System.Drawing.Point(357, 129);
            this.dgvCategorías.Name = "dgvCategorías";
            this.dgvCategorías.Size = new System.Drawing.Size(643, 322);
            this.dgvCategorías.TabIndex = 54;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 55;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 56;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // frmModulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(1043, 537);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvCategorías);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAñadir);
            this.Controls.Add(this.cmbModulo);
            this.Controls.Add(this.lblUsuarioRegistra);
            this.Controls.Add(this.lblPerfil);
            this.Controls.Add(this.lblModulo);
            this.Controls.Add(this.txtUsuarioRegistra);
            this.Name = "frmModulos";
            this.Text = "frmModulos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorías)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAñadir;
        private System.Windows.Forms.ComboBox cmbModulo;
        private System.Windows.Forms.Label lblUsuarioRegistra;
        private System.Windows.Forms.Label lblPerfil;
        private System.Windows.Forms.Label lblModulo;
        private System.Windows.Forms.TextBox txtUsuarioRegistra;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridView dgvCategorías;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}