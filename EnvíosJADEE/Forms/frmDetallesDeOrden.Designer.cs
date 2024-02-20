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
            this.cmbEstatus = new System.Windows.Forms.ComboBox();
            this.lblEstatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCambiar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.dgvOrden = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrden)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(69)))));
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(351, 180);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.Size = new System.Drawing.Size(431, 322);
            this.dgvProductos.TabIndex = 20;
            // 
            // cmbEstatus
            // 
            this.cmbEstatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.cmbEstatus.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstatus.FormattingEnabled = true;
            this.cmbEstatus.Location = new System.Drawing.Point(52, 276);
            this.cmbEstatus.Name = "cmbEstatus";
            this.cmbEstatus.Size = new System.Drawing.Size(228, 29);
            this.cmbEstatus.TabIndex = 51;
            this.cmbEstatus.SelectedIndexChanged += new System.EventHandler(this.cmbEstatus_SelectedIndexChanged);
            // 
            // lblEstatus
            // 
            this.lblEstatus.AutoSize = true;
            this.lblEstatus.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstatus.Location = new System.Drawing.Point(49, 252);
            this.lblEstatus.Name = "lblEstatus";
            this.lblEstatus.Size = new System.Drawing.Size(59, 21);
            this.lblEstatus.TabIndex = 52;
            this.lblEstatus.Text = "Estatus";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 21);
            this.label1.TabIndex = 53;
            this.label1.Text = "Clave de orden";
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.Location = new System.Drawing.Point(53, 159);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(228, 26);
            this.txtClave.TabIndex = 54;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(170, 324);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(111, 29);
            this.btnCancelar.TabIndex = 56;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnCambiar
            // 
            this.btnCambiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnCambiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiar.ForeColor = System.Drawing.Color.White;
            this.btnCambiar.Location = new System.Drawing.Point(52, 324);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(111, 29);
            this.btnCambiar.TabIndex = 55;
            this.btnCambiar.Text = "Cambiar Estatus";
            this.btnCambiar.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(170, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 30);
            this.button1.TabIndex = 58;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnMostrar
            // 
            this.btnMostrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrar.ForeColor = System.Drawing.Color.White;
            this.btnMostrar.Location = new System.Drawing.Point(53, 191);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(111, 30);
            this.btnMostrar.TabIndex = 57;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = false;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // dgvOrden
            // 
            this.dgvOrden.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(69)))));
            this.dgvOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrden.Location = new System.Drawing.Point(351, 106);
            this.dgvOrden.Name = "dgvOrden";
            this.dgvOrden.ReadOnly = true;
            this.dgvOrden.Size = new System.Drawing.Size(678, 68);
            this.dgvOrden.TabIndex = 59;
            // 
            // frmDetallesDeOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(1043, 537);
            this.Controls.Add(this.dgvOrden);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCambiar);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEstatus);
            this.Controls.Add(this.cmbEstatus);
            this.Controls.Add(this.dgvProductos);
            this.Name = "frmDetallesDeOrden";
            this.Text = "Detalles de Orden";
            this.Load += new System.EventHandler(this.frmDetallesDeOrden_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrden)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.ComboBox cmbEstatus;
        private System.Windows.Forms.Label lblEstatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCambiar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.DataGridView dgvOrden;
    }
}