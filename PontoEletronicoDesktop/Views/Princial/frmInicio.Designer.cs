
namespace PontoEletronicoDesktop.Views.Princial
{
    partial class frmInicio
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMensagemQuatro = new System.Windows.Forms.Label();
            this.lblMensagemTres = new System.Windows.Forms.Label();
            this.lblMensagemDois = new System.Windows.Forms.Label();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.pnlCentral.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCentral
            // 
            this.pnlCentral.Controls.Add(this.panel1);
            this.pnlCentral.Size = new System.Drawing.Size(780, 371);
            this.pnlCentral.Controls.SetChildIndex(this.panel1, 0);
            // 
            // lblBottom
            // 
            this.lblBottom.Location = new System.Drawing.Point(257, 5);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblMensagemQuatro);
            this.panel1.Controls.Add(this.lblMensagemTres);
            this.panel1.Controls.Add(this.lblMensagemDois);
            this.panel1.Controls.Add(this.lblMensagem);
            this.panel1.Location = new System.Drawing.Point(9, 6);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(9);
            this.panel1.Size = new System.Drawing.Size(762, 119);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::PontoEletronicoDesktop.Properties.Resources.Logo1;
            this.pictureBox1.Location = new System.Drawing.Point(518, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(243, 71);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lblMensagemQuatro
            // 
            this.lblMensagemQuatro.AutoSize = true;
            this.lblMensagemQuatro.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMensagemQuatro.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagemQuatro.ForeColor = System.Drawing.Color.DimGray;
            this.lblMensagemQuatro.Location = new System.Drawing.Point(9, 82);
            this.lblMensagemQuatro.Name = "lblMensagemQuatro";
            this.lblMensagemQuatro.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblMensagemQuatro.Size = new System.Drawing.Size(0, 21);
            this.lblMensagemQuatro.TabIndex = 4;
            // 
            // lblMensagemTres
            // 
            this.lblMensagemTres.AutoSize = true;
            this.lblMensagemTres.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMensagemTres.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagemTres.ForeColor = System.Drawing.Color.DimGray;
            this.lblMensagemTres.Location = new System.Drawing.Point(9, 61);
            this.lblMensagemTres.Name = "lblMensagemTres";
            this.lblMensagemTres.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblMensagemTres.Size = new System.Drawing.Size(183, 21);
            this.lblMensagemTres.TabIndex = 3;
            this.lblMensagemTres.Text = "Licença Demo - 31/07/2021";
            // 
            // lblMensagemDois
            // 
            this.lblMensagemDois.AutoSize = true;
            this.lblMensagemDois.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMensagemDois.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagemDois.ForeColor = System.Drawing.Color.DimGray;
            this.lblMensagemDois.Location = new System.Drawing.Point(9, 25);
            this.lblMensagemDois.Name = "lblMensagemDois";
            this.lblMensagemDois.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.lblMensagemDois.Size = new System.Drawing.Size(109, 36);
            this.lblMensagemDois.TabIndex = 2;
            this.lblMensagemDois.Text = "Versão Beta 1.0\r\n";
            // 
            // lblMensagem
            // 
            this.lblMensagem.AutoSize = true;
            this.lblMensagem.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMensagem.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagem.ForeColor = System.Drawing.Color.DimGray;
            this.lblMensagem.Location = new System.Drawing.Point(9, 9);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(406, 16);
            this.lblMensagem.TabIndex = 1;
            this.lblMensagem.Text = "Seja Bem Vindo ao PoloTech Solutions - Ponto Eletrônico";
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 446);
            this.Name = "FormInicio";
            this.Text = "FormInicio";
            this.pnlCentral.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblMensagem;
        public System.Windows.Forms.Label lblMensagemTres;
        public System.Windows.Forms.Label lblMensagemDois;
        public System.Windows.Forms.Label lblMensagemQuatro;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}