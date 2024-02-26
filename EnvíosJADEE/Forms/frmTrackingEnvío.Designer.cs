namespace EnvíosJADEE.Forms
{
    partial class frmTrackingEnvío
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
            this.lblClaveOrden = new System.Windows.Forms.Label();
            this.txtClaveDeOrden = new System.Windows.Forms.TextBox();
            this.lblEstatusDeOrden = new System.Windows.Forms.Label();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblClaveOrden
            // 
            this.lblClaveOrden.AutoSize = true;
            this.lblClaveOrden.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClaveOrden.Location = new System.Drawing.Point(12, 73);
            this.lblClaveOrden.Name = "lblClaveOrden";
            this.lblClaveOrden.Size = new System.Drawing.Size(117, 21);
            this.lblClaveOrden.TabIndex = 61;
            this.lblClaveOrden.Text = "Clave de Orden";
            // 
            // txtClaveDeOrden
            // 
            this.txtClaveDeOrden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.txtClaveDeOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClaveDeOrden.Location = new System.Drawing.Point(16, 107);
            this.txtClaveDeOrden.Name = "txtClaveDeOrden";
            this.txtClaveDeOrden.Size = new System.Drawing.Size(228, 26);
            this.txtClaveDeOrden.TabIndex = 60;
            // 
            // lblEstatusDeOrden
            // 
            this.lblEstatusDeOrden.AutoSize = true;
            this.lblEstatusDeOrden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(69)))));
            this.lblEstatusDeOrden.Font = new System.Drawing.Font("Yu Gothic UI", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstatusDeOrden.Location = new System.Drawing.Point(12, 235);
            this.lblEstatusDeOrden.Name = "lblEstatusDeOrden";
            this.lblEstatusDeOrden.Size = new System.Drawing.Size(0, 89);
            this.lblEstatusDeOrden.TabIndex = 62;
            // 
            // dgvOrdenes
            // 
            this.dgvOrdenes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(69)))));
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvOrdenes.Location = new System.Drawing.Point(543, 73);
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.Size = new System.Drawing.Size(488, 443);
            this.dgvOrdenes.TabIndex = 63;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(133, 139);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(111, 41);
            this.btnCancelar.TabIndex = 65;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnMostrar
            // 
            this.btnMostrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrar.ForeColor = System.Drawing.Color.White;
            this.btnMostrar.Location = new System.Drawing.Point(16, 139);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(111, 41);
            this.btnMostrar.TabIndex = 64;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = false;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // frmTrackingEnvío
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(1043, 537);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.dgvOrdenes);
            this.Controls.Add(this.lblEstatusDeOrden);
            this.Controls.Add(this.lblClaveOrden);
            this.Controls.Add(this.txtClaveDeOrden);
            this.Name = "frmTrackingEnvío";
            this.Text = "Tracking";
            this.Load += new System.EventHandler(this.frmTrackingEnvío_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClaveOrden;
        private System.Windows.Forms.TextBox txtClaveDeOrden;
        private System.Windows.Forms.Label lblEstatusDeOrden;
        private System.Windows.Forms.DataGridView dgvOrdenes;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnMostrar;
    }
}