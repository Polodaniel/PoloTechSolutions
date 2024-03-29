﻿
namespace PontoEletronicoDesktop.Views.MarcarPonto
{
    partial class frmMarcarPonto
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
            this.components = new System.ComponentModel.Container();
            this.bkwBiometria = new System.ComponentModel.BackgroundWorker();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.lblHora = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.pgbLoad = new System.Windows.Forms.ProgressBar();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.ImgDigitos = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlBiometria = new System.Windows.Forms.Panel();
            this.pnlImagemBiometria = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbBiometria = new System.Windows.Forms.PictureBox();
            this.pnlLinhaSuperior = new System.Windows.Forms.Panel();
            this.pnlBotaoBiometria = new System.Windows.Forms.Panel();
            this.btnBiometria = new System.Windows.Forms.Button();
            this.pnlTituloBiometria = new System.Windows.Forms.Panel();
            this.lblBiometria = new System.Windows.Forms.Label();
            this.bkwLoad = new System.ComponentModel.BackgroundWorker();
            this.bkwSalvar = new System.ComponentModel.BackgroundWorker();
            this.pnlCentral.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlBiometria.SuspendLayout();
            this.pnlImagemBiometria.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBiometria)).BeginInit();
            this.pnlBotaoBiometria.SuspendLayout();
            this.pnlTituloBiometria.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCentral
            // 
            this.pnlCentral.Controls.Add(this.panel2);
            this.pnlCentral.Controls.Add(this.panel8);
            this.pnlCentral.Size = new System.Drawing.Size(756, 412);
            this.pnlCentral.Controls.SetChildIndex(this.panel8, 0);
            this.pnlCentral.Controls.SetChildIndex(this.panel2, 0);
            // 
            // lblBottom
            // 
            this.lblBottom.Location = new System.Drawing.Point(245, 5);
            // 
            // bkwBiometria
            // 
            this.bkwBiometria.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkwBiometria_DoWork);
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.panel10);
            this.panel8.Location = new System.Drawing.Point(9, 6);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(488, 376);
            this.panel8.TabIndex = 8;
            this.panel8.Resize += new System.EventHandler(this.panel8_Resize);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel12);
            this.panel10.Controls.Add(this.panel15);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(486, 374);
            this.panel10.TabIndex = 5;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.lblHora);
            this.panel12.Controls.Add(this.panel14);
            this.panel12.Controls.Add(this.pgbLoad);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 29);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(486, 345);
            this.panel12.TabIndex = 6;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Arial", 80F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.Color.DimGray;
            this.lblHora.Location = new System.Drawing.Point(1, 92);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(482, 124);
            this.lblHora.TabIndex = 8;
            this.lblHora.Text = "00:00:00";
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.DimGray;
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 5);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(486, 1);
            this.panel14.TabIndex = 7;
            // 
            // pgbLoad
            // 
            this.pgbLoad.Dock = System.Windows.Forms.DockStyle.Top;
            this.pgbLoad.Location = new System.Drawing.Point(0, 0);
            this.pgbLoad.Name = "pgbLoad";
            this.pgbLoad.Size = new System.Drawing.Size(486, 5);
            this.pgbLoad.TabIndex = 9;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel15.Controls.Add(this.label10);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(486, 29);
            this.panel15.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(6, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 15);
            this.label10.TabIndex = 3;
            this.label10.Text = "Relógio";
            // 
            // ImgDigitos
            // 
            this.ImgDigitos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImgDigitos.ImageSize = new System.Drawing.Size(16, 16);
            this.ImgDigitos.TransparentColor = System.Drawing.Color.White;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pnlBiometria);
            this.panel2.Location = new System.Drawing.Point(503, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(243, 375);
            this.panel2.TabIndex = 9;
            // 
            // pnlBiometria
            // 
            this.pnlBiometria.Controls.Add(this.pnlImagemBiometria);
            this.pnlBiometria.Controls.Add(this.pnlBotaoBiometria);
            this.pnlBiometria.Controls.Add(this.pnlTituloBiometria);
            this.pnlBiometria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBiometria.Location = new System.Drawing.Point(0, 0);
            this.pnlBiometria.Name = "pnlBiometria";
            this.pnlBiometria.Size = new System.Drawing.Size(241, 373);
            this.pnlBiometria.TabIndex = 5;
            // 
            // pnlImagemBiometria
            // 
            this.pnlImagemBiometria.Controls.Add(this.panel4);
            this.pnlImagemBiometria.Controls.Add(this.panel3);
            this.pnlImagemBiometria.Controls.Add(this.pnlLinhaSuperior);
            this.pnlImagemBiometria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImagemBiometria.Location = new System.Drawing.Point(0, 29);
            this.pnlImagemBiometria.Name = "pnlImagemBiometria";
            this.pnlImagemBiometria.Size = new System.Drawing.Size(241, 310);
            this.pnlImagemBiometria.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 309);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(241, 1);
            this.panel4.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pbBiometria);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(241, 309);
            this.panel3.TabIndex = 8;
            // 
            // pbBiometria
            // 
            this.pbBiometria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBiometria.Location = new System.Drawing.Point(0, 0);
            this.pbBiometria.Name = "pbBiometria";
            this.pbBiometria.Size = new System.Drawing.Size(241, 309);
            this.pbBiometria.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbBiometria.TabIndex = 0;
            this.pbBiometria.TabStop = false;
            // 
            // pnlLinhaSuperior
            // 
            this.pnlLinhaSuperior.BackColor = System.Drawing.Color.DimGray;
            this.pnlLinhaSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLinhaSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlLinhaSuperior.Name = "pnlLinhaSuperior";
            this.pnlLinhaSuperior.Size = new System.Drawing.Size(241, 1);
            this.pnlLinhaSuperior.TabIndex = 7;
            // 
            // pnlBotaoBiometria
            // 
            this.pnlBotaoBiometria.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBotaoBiometria.Controls.Add(this.btnBiometria);
            this.pnlBotaoBiometria.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotaoBiometria.Location = new System.Drawing.Point(0, 339);
            this.pnlBotaoBiometria.Name = "pnlBotaoBiometria";
            this.pnlBotaoBiometria.Padding = new System.Windows.Forms.Padding(3);
            this.pnlBotaoBiometria.Size = new System.Drawing.Size(241, 34);
            this.pnlBotaoBiometria.TabIndex = 7;
            // 
            // btnBiometria
            // 
            this.btnBiometria.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnBiometria.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBiometria.FlatAppearance.BorderSize = 0;
            this.btnBiometria.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnBiometria.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnBiometria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBiometria.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBiometria.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBiometria.Image = global::PontoEletronicoDesktop.Properties.Resources.iconBiometria;
            this.btnBiometria.Location = new System.Drawing.Point(202, 3);
            this.btnBiometria.Name = "btnBiometria";
            this.btnBiometria.Size = new System.Drawing.Size(36, 28);
            this.btnBiometria.TabIndex = 13;
            this.btnBiometria.UseVisualStyleBackColor = false;
            this.btnBiometria.Click += new System.EventHandler(this.btnBiometria_Click);
            // 
            // pnlTituloBiometria
            // 
            this.pnlTituloBiometria.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTituloBiometria.Controls.Add(this.lblBiometria);
            this.pnlTituloBiometria.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloBiometria.Location = new System.Drawing.Point(0, 0);
            this.pnlTituloBiometria.Name = "pnlTituloBiometria";
            this.pnlTituloBiometria.Size = new System.Drawing.Size(241, 29);
            this.pnlTituloBiometria.TabIndex = 5;
            // 
            // lblBiometria
            // 
            this.lblBiometria.AutoSize = true;
            this.lblBiometria.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBiometria.ForeColor = System.Drawing.Color.DimGray;
            this.lblBiometria.Location = new System.Drawing.Point(6, 6);
            this.lblBiometria.Name = "lblBiometria";
            this.lblBiometria.Size = new System.Drawing.Size(62, 15);
            this.lblBiometria.TabIndex = 3;
            this.lblBiometria.Text = "Biometria";
            // 
            // bkwLoad
            // 
            this.bkwLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkwLoad_DoWork);
            // 
            // bkwSalvar
            // 
            this.bkwSalvar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkwSalvar_DoWork);
            // 
            // frmMarcarPonto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 487);
            this.Name = "frmMarcarPonto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMarcador";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMarcador_FormClosing);
            this.Load += new System.EventHandler(this.frmMarcarPonto_Load);
            this.Shown += new System.EventHandler(this.frmMarcarPonto_Shown);
            this.pnlCentral.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlBiometria.ResumeLayout(false);
            this.pnlImagemBiometria.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBiometria)).EndInit();
            this.pnlBotaoBiometria.ResumeLayout(false);
            this.pnlTituloBiometria.ResumeLayout(false);
            this.pnlTituloBiometria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bkwBiometria;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ImageList ImgDigitos;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlBiometria;
        private System.Windows.Forms.Panel pnlImagemBiometria;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pbBiometria;
        private System.Windows.Forms.Panel pnlLinhaSuperior;
        private System.Windows.Forms.Panel pnlBotaoBiometria;
        public System.Windows.Forms.Button btnBiometria;
        private System.Windows.Forms.Panel pnlTituloBiometria;
        private System.Windows.Forms.Label lblBiometria;
        private System.ComponentModel.BackgroundWorker bkwLoad;
        private System.Windows.Forms.ProgressBar pgbLoad;
        private System.ComponentModel.BackgroundWorker bkwSalvar;
    }
}