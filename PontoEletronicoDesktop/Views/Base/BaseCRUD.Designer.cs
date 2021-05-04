
namespace PontoEletronicoDesktop.Views.Base
{
    partial class BaseCRUD
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
            this.pnlCentralCRUD = new System.Windows.Forms.Panel();
            this.pnlCRUD = new System.Windows.Forms.Panel();
            this.btnFechar = new System.Windows.Forms.Button();
            this.pnlBotoesCRUD = new System.Windows.Forms.Panel();
            this.btnEditar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.pnlBotoesBusca = new System.Windows.Forms.Panel();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.pnlDivisoria = new System.Windows.Forms.Panel();
            this.btnBusca = new System.Windows.Forms.Button();
            this.pgbLoad = new System.Windows.Forms.ProgressBar();
            this.pnlCentral.SuspendLayout();
            this.pnlCRUD.SuspendLayout();
            this.pnlBotoesCRUD.SuspendLayout();
            this.pnlBotoesBusca.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCentral
            // 
            this.pnlCentral.Controls.Add(this.pnlCentralCRUD);
            this.pnlCentral.Controls.Add(this.pgbLoad);
            this.pnlCentral.Controls.Add(this.pnlCRUD);
            this.pnlCentral.Padding = new System.Windows.Forms.Padding(9, 0, 9, 9);
            this.pnlCentral.Size = new System.Drawing.Size(780, 375);
            this.pnlCentral.Controls.SetChildIndex(this.pnlCRUD, 0);
            this.pnlCentral.Controls.SetChildIndex(this.pgbLoad, 0);
            this.pnlCentral.Controls.SetChildIndex(this.pnlCentralCRUD, 0);
            // 
            // lblBottom
            // 
            this.lblBottom.Location = new System.Drawing.Point(248, 5);
            // 
            // pnlCentralCRUD
            // 
            this.pnlCentralCRUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentralCRUD.Location = new System.Drawing.Point(9, 0);
            this.pnlCentralCRUD.Name = "pnlCentralCRUD";
            this.pnlCentralCRUD.Size = new System.Drawing.Size(726, 335);
            this.pnlCentralCRUD.TabIndex = 0;
            // 
            // pnlCRUD
            // 
            this.pnlCRUD.Controls.Add(this.btnFechar);
            this.pnlCRUD.Controls.Add(this.pnlBotoesCRUD);
            this.pnlCRUD.Controls.Add(this.pnlBotoesBusca);
            this.pnlCRUD.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCRUD.Location = new System.Drawing.Point(735, 0);
            this.pnlCRUD.Name = "pnlCRUD";
            this.pnlCRUD.Size = new System.Drawing.Size(36, 341);
            this.pnlCRUD.TabIndex = 1;
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnFechar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnFechar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFechar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFechar.Image = global::PontoEletronicoDesktop.Properties.Resources.iconFechar;
            this.btnFechar.Location = new System.Drawing.Point(0, 306);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(36, 35);
            this.btnFechar.TabIndex = 17;
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // pnlBotoesCRUD
            // 
            this.pnlBotoesCRUD.Controls.Add(this.btnEditar);
            this.pnlBotoesCRUD.Controls.Add(this.panel1);
            this.pnlBotoesCRUD.Controls.Add(this.btnSalvar);
            this.pnlBotoesCRUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBotoesCRUD.Location = new System.Drawing.Point(0, 76);
            this.pnlBotoesCRUD.Name = "pnlBotoesCRUD";
            this.pnlBotoesCRUD.Size = new System.Drawing.Size(36, 265);
            this.pnlBotoesCRUD.TabIndex = 1;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnEditar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditar.Image = global::PontoEletronicoDesktop.Properties.Resources.iconEditar;
            this.btnEditar.Location = new System.Drawing.Point(0, 38);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(36, 35);
            this.btnEditar.TabIndex = 16;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(36, 3);
            this.panel1.TabIndex = 15;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnSalvar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSalvar.Image = global::PontoEletronicoDesktop.Properties.Resources.iconSave;
            this.btnSalvar.Location = new System.Drawing.Point(0, 0);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(36, 35);
            this.btnSalvar.TabIndex = 14;
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // pnlBotoesBusca
            // 
            this.pnlBotoesBusca.Controls.Add(this.btnLimpar);
            this.pnlBotoesBusca.Controls.Add(this.pnlDivisoria);
            this.pnlBotoesBusca.Controls.Add(this.btnBusca);
            this.pnlBotoesBusca.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotoesBusca.Location = new System.Drawing.Point(0, 0);
            this.pnlBotoesBusca.Name = "pnlBotoesBusca";
            this.pnlBotoesBusca.Size = new System.Drawing.Size(36, 76);
            this.pnlBotoesBusca.TabIndex = 0;
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnLimpar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLimpar.FlatAppearance.BorderSize = 0;
            this.btnLimpar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnLimpar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLimpar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLimpar.Image = global::PontoEletronicoDesktop.Properties.Resources.iconLimpar;
            this.btnLimpar.Location = new System.Drawing.Point(0, 38);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(36, 35);
            this.btnLimpar.TabIndex = 13;
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // pnlDivisoria
            // 
            this.pnlDivisoria.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDivisoria.Location = new System.Drawing.Point(0, 35);
            this.pnlDivisoria.Name = "pnlDivisoria";
            this.pnlDivisoria.Size = new System.Drawing.Size(36, 3);
            this.pnlDivisoria.TabIndex = 14;
            // 
            // btnBusca
            // 
            this.btnBusca.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnBusca.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBusca.FlatAppearance.BorderSize = 0;
            this.btnBusca.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnBusca.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnBusca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusca.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBusca.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBusca.Image = global::PontoEletronicoDesktop.Properties.Resources.iconBusca;
            this.btnBusca.Location = new System.Drawing.Point(0, 0);
            this.btnBusca.Name = "btnBusca";
            this.btnBusca.Size = new System.Drawing.Size(36, 35);
            this.btnBusca.TabIndex = 12;
            this.btnBusca.UseVisualStyleBackColor = false;
            this.btnBusca.Click += new System.EventHandler(this.btnBusca_Click);
            // 
            // pgbLoad
            // 
            this.pgbLoad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgbLoad.Location = new System.Drawing.Point(9, 335);
            this.pgbLoad.Name = "pgbLoad";
            this.pgbLoad.Size = new System.Drawing.Size(726, 6);
            this.pgbLoad.TabIndex = 2;
            this.pgbLoad.Visible = false;
            // 
            // BaseCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "BaseCRUD";
            this.Text = "BaseCRUD";
            this.pnlCentral.ResumeLayout(false);
            this.pnlCRUD.ResumeLayout(false);
            this.pnlBotoesCRUD.ResumeLayout(false);
            this.pnlBotoesBusca.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCRUD;
        private System.Windows.Forms.Panel pnlDivisoria;
        public System.Windows.Forms.Panel pnlBotoesCRUD;
        public System.Windows.Forms.Panel pnlBotoesBusca;
        public System.Windows.Forms.Button btnBusca;
        public System.Windows.Forms.Button btnSalvar;
        public System.Windows.Forms.Button btnLimpar;
        public System.Windows.Forms.Panel pnlCentralCRUD;
        public System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ProgressBar pgbLoad;
        public System.Windows.Forms.Button btnFechar;
    }
}