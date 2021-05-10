
namespace PontoEletronicoDesktop.Views.Base
{
    partial class BaseForm
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
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.pnlTituloCentral = new System.Windows.Forms.Panel();
            this.lblTituloForm = new System.Windows.Forms.Label();
            this.pnlLateralEsquerda = new System.Windows.Forms.Panel();
            this.pnlLatarealDireito = new System.Windows.Forms.Panel();
            this.pnlInferiot = new System.Windows.Forms.Panel();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.pnlCentral = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblBottom = new System.Windows.Forms.Label();
            this.pnlTitulo.SuspendLayout();
            this.pnlTituloCentral.SuspendLayout();
            this.pnlCentral.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Controls.Add(this.pnlTituloCentral);
            this.pnlTitulo.Controls.Add(this.pnlLateralEsquerda);
            this.pnlTitulo.Controls.Add(this.pnlLatarealDireito);
            this.pnlTitulo.Controls.Add(this.pnlInferiot);
            this.pnlTitulo.Controls.Add(this.pnlSuperior);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(10, 10);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Padding = new System.Windows.Forms.Padding(9);
            this.pnlTitulo.Size = new System.Drawing.Size(801, 55);
            this.pnlTitulo.TabIndex = 0;
            // 
            // pnlTituloCentral
            // 
            this.pnlTituloCentral.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTituloCentral.Controls.Add(this.lblTituloForm);
            this.pnlTituloCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTituloCentral.Location = new System.Drawing.Point(10, 10);
            this.pnlTituloCentral.Name = "pnlTituloCentral";
            this.pnlTituloCentral.Padding = new System.Windows.Forms.Padding(9);
            this.pnlTituloCentral.Size = new System.Drawing.Size(781, 35);
            this.pnlTituloCentral.TabIndex = 2;
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.AutoSize = true;
            this.lblTituloForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTituloForm.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloForm.ForeColor = System.Drawing.Color.DimGray;
            this.lblTituloForm.Location = new System.Drawing.Point(9, 9);
            this.lblTituloForm.Name = "lblTituloForm";
            this.lblTituloForm.Size = new System.Drawing.Size(109, 16);
            this.lblTituloForm.TabIndex = 1;
            this.lblTituloForm.Text = "Titulo do Form";
            // 
            // pnlLateralEsquerda
            // 
            this.pnlLateralEsquerda.BackColor = System.Drawing.Color.DarkGray;
            this.pnlLateralEsquerda.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLateralEsquerda.Location = new System.Drawing.Point(9, 10);
            this.pnlLateralEsquerda.Name = "pnlLateralEsquerda";
            this.pnlLateralEsquerda.Size = new System.Drawing.Size(1, 35);
            this.pnlLateralEsquerda.TabIndex = 4;
            // 
            // pnlLatarealDireito
            // 
            this.pnlLatarealDireito.BackColor = System.Drawing.Color.DarkGray;
            this.pnlLatarealDireito.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLatarealDireito.Location = new System.Drawing.Point(791, 10);
            this.pnlLatarealDireito.Name = "pnlLatarealDireito";
            this.pnlLatarealDireito.Size = new System.Drawing.Size(1, 35);
            this.pnlLatarealDireito.TabIndex = 3;
            // 
            // pnlInferiot
            // 
            this.pnlInferiot.BackColor = System.Drawing.Color.DarkGray;
            this.pnlInferiot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferiot.Location = new System.Drawing.Point(9, 45);
            this.pnlInferiot.Name = "pnlInferiot";
            this.pnlInferiot.Size = new System.Drawing.Size(783, 1);
            this.pnlInferiot.TabIndex = 2;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.DarkGray;
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(9, 9);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(783, 1);
            this.pnlSuperior.TabIndex = 1;
            // 
            // pnlCentral
            // 
            this.pnlCentral.Controls.Add(this.pnlBottom);
            this.pnlCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentral.Location = new System.Drawing.Point(10, 65);
            this.pnlCentral.Name = "pnlCentral";
            this.pnlCentral.Size = new System.Drawing.Size(801, 443);
            this.pnlCentral.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lblBottom);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 418);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(9);
            this.pnlBottom.Size = new System.Drawing.Size(801, 25);
            this.pnlBottom.TabIndex = 5;
            this.pnlBottom.Resize += new System.EventHandler(this.pnlBottom_Resize);
            // 
            // lblBottom
            // 
            this.lblBottom.AutoSize = true;
            this.lblBottom.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBottom.ForeColor = System.Drawing.Color.DimGray;
            this.lblBottom.Location = new System.Drawing.Point(244, 6);
            this.lblBottom.Name = "lblBottom";
            this.lblBottom.Size = new System.Drawing.Size(265, 14);
            this.lblBottom.TabIndex = 4;
            this.lblBottom.Text = "© Todos os Direitos Reservados a PoloTech Solutions";
            this.lblBottom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(821, 518);
            this.Controls.Add(this.pnlCentral);
            this.Controls.Add(this.pnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BaseForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "BaseForm";
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTituloCentral.ResumeLayout(false);
            this.pnlTituloCentral.PerformLayout();
            this.pnlCentral.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Panel pnlTituloCentral;
        public System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.Panel pnlLateralEsquerda;
        private System.Windows.Forms.Panel pnlLatarealDireito;
        private System.Windows.Forms.Panel pnlInferiot;
        private System.Windows.Forms.Panel pnlSuperior;
        public System.Windows.Forms.Panel pnlCentral;
        private System.Windows.Forms.Panel pnlBottom;
        public System.Windows.Forms.Label lblBottom;
    }
}