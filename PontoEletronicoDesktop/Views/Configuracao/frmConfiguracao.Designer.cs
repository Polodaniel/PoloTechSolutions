
namespace PontoEletronicoDesktop.Views.Configuracao
{
    partial class frmConfiguracao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grade = new System.Windows.Forms.DataGridView();
            this.pnlCliente = new System.Windows.Forms.Panel();
            this.gbClienteSelecionado = new System.Windows.Forms.GroupBox();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLogradouro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCep = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bkwBuscar = new System.ComponentModel.BackgroundWorker();
            this.bkwSalvar = new System.ComponentModel.BackgroundWorker();
            this.bkwLoad = new System.ComponentModel.BackgroundWorker();
            this.pnlBotoesCRUD.SuspendLayout();
            this.pnlBotoesBusca.SuspendLayout();
            this.pnlCentralCRUD.SuspendLayout();
            this.pnlCentral.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grade)).BeginInit();
            this.pnlCliente.SuspendLayout();
            this.gbClienteSelecionado.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBotoesCRUD
            // 
            this.pnlBotoesCRUD.Size = new System.Drawing.Size(36, 379);
            // 
            // btnBusca
            // 
            this.btnBusca.FlatAppearance.BorderSize = 0;
            this.btnBusca.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnBusca.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.AppWorkspace;
            // 
            // btnSalvar
            // 
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.AppWorkspace;
            // 
            // btnLimpar
            // 
            this.btnLimpar.FlatAppearance.BorderSize = 0;
            this.btnLimpar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnLimpar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.AppWorkspace;
            // 
            // pnlCentralCRUD
            // 
            this.pnlCentralCRUD.Controls.Add(this.panel2);
            this.pnlCentralCRUD.Controls.Add(this.pnlCliente);
            this.pnlCentralCRUD.Size = new System.Drawing.Size(726, 449);
            // 
            // btnEditar
            // 
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.AppWorkspace;
            // 
            // pgbLoad
            // 
            this.pgbLoad.Location = new System.Drawing.Point(9, 449);
            // 
            // btnFechar
            // 
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnFechar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnFechar.Location = new System.Drawing.Point(0, 420);
            // 
            // pnlCentral
            // 
            this.pnlCentral.Size = new System.Drawing.Size(780, 489);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grade);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 181);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(726, 268);
            this.panel2.TabIndex = 0;
            // 
            // grade
            // 
            this.grade.AllowUserToResizeColumns = false;
            this.grade.AllowUserToResizeRows = false;
            this.grade.BackgroundColor = System.Drawing.Color.White;
            this.grade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(71)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grade.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grade.Location = new System.Drawing.Point(10, 10);
            this.grade.MultiSelect = false;
            this.grade.Name = "grade";
            this.grade.RowHeadersVisible = false;
            this.grade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grade.Size = new System.Drawing.Size(706, 248);
            this.grade.TabIndex = 3;
            this.grade.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grade_CellClick);
            // 
            // pnlCliente
            // 
            this.pnlCliente.Controls.Add(this.gbClienteSelecionado);
            this.pnlCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCliente.Location = new System.Drawing.Point(0, 0);
            this.pnlCliente.Name = "pnlCliente";
            this.pnlCliente.Padding = new System.Windows.Forms.Padding(10);
            this.pnlCliente.Size = new System.Drawing.Size(726, 181);
            this.pnlCliente.TabIndex = 1;
            this.pnlCliente.Resize += new System.EventHandler(this.pnlCliente_Resize);
            // 
            // gbClienteSelecionado
            // 
            this.gbClienteSelecionado.Controls.Add(this.txtPais);
            this.gbClienteSelecionado.Controls.Add(this.label8);
            this.gbClienteSelecionado.Controls.Add(this.txtCidade);
            this.gbClienteSelecionado.Controls.Add(this.label7);
            this.gbClienteSelecionado.Controls.Add(this.txtBairro);
            this.gbClienteSelecionado.Controls.Add(this.label6);
            this.gbClienteSelecionado.Controls.Add(this.txtNumero);
            this.gbClienteSelecionado.Controls.Add(this.label5);
            this.gbClienteSelecionado.Controls.Add(this.txtLogradouro);
            this.gbClienteSelecionado.Controls.Add(this.label4);
            this.gbClienteSelecionado.Controls.Add(this.txtCep);
            this.gbClienteSelecionado.Controls.Add(this.label3);
            this.gbClienteSelecionado.Controls.Add(this.txtNome);
            this.gbClienteSelecionado.Controls.Add(this.label2);
            this.gbClienteSelecionado.Controls.Add(this.txtCodigo);
            this.gbClienteSelecionado.Controls.Add(this.label1);
            this.gbClienteSelecionado.Location = new System.Drawing.Point(3, 6);
            this.gbClienteSelecionado.Name = "gbClienteSelecionado";
            this.gbClienteSelecionado.Size = new System.Drawing.Size(717, 162);
            this.gbClienteSelecionado.TabIndex = 0;
            this.gbClienteSelecionado.TabStop = false;
            this.gbClienteSelecionado.Text = "   Cliente Selecionado   ";
            // 
            // txtPais
            // 
            this.txtPais.Enabled = false;
            this.txtPais.Font = new System.Drawing.Font("Arial", 9F);
            this.txtPais.Location = new System.Drawing.Point(594, 124);
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(103, 21);
            this.txtPais.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(592, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "Pais";
            // 
            // txtCidade
            // 
            this.txtCidade.Enabled = false;
            this.txtCidade.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCidade.Location = new System.Drawing.Point(223, 124);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(365, 21);
            this.txtCidade.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(221, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "Cidade";
            // 
            // txtBairro
            // 
            this.txtBairro.Enabled = false;
            this.txtBairro.Font = new System.Drawing.Font("Arial", 9F);
            this.txtBairro.Location = new System.Drawing.Point(16, 124);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(201, 21);
            this.txtBairro.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(14, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "Bairro";
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Font = new System.Drawing.Font("Arial", 9F);
            this.txtNumero.Location = new System.Drawing.Point(594, 81);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(103, 21);
            this.txtNumero.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(592, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Numero";
            // 
            // txtLogradouro
            // 
            this.txtLogradouro.Enabled = false;
            this.txtLogradouro.Font = new System.Drawing.Font("Arial", 9F);
            this.txtLogradouro.Location = new System.Drawing.Point(223, 81);
            this.txtLogradouro.Name = "txtLogradouro";
            this.txtLogradouro.Size = new System.Drawing.Size(365, 21);
            this.txtLogradouro.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(221, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Logradouro";
            // 
            // txtCep
            // 
            this.txtCep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCep.Enabled = false;
            this.txtCep.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCep.Location = new System.Drawing.Point(15, 81);
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(202, 21);
            this.txtCep.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(13, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "CEP";
            // 
            // txtNome
            // 
            this.txtNome.Enabled = false;
            this.txtNome.Font = new System.Drawing.Font("Arial", 9F);
            this.txtNome.Location = new System.Drawing.Point(142, 38);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(555, 21);
            this.txtNome.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(140, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCodigo.Location = new System.Drawing.Point(16, 38);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(120, 21);
            this.txtCodigo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // bkwBuscar
            // 
            this.bkwBuscar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkwBuscar_DoWork);
            // 
            // bkwSalvar
            // 
            this.bkwSalvar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkwSalvar_DoWork);
            // 
            // bkwLoad
            // 
            this.bkwLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkwLoad_DoWork);
            // 
            // frmConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 564);
            this.Name = "frmConfiguracao";
            this.Text = "frmConfiguracao";
            this.pnlBotoesCRUD.ResumeLayout(false);
            this.pnlBotoesBusca.ResumeLayout(false);
            this.pnlCentralCRUD.ResumeLayout(false);
            this.pnlCentral.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grade)).EndInit();
            this.pnlCliente.ResumeLayout(false);
            this.gbClienteSelecionado.ResumeLayout(false);
            this.gbClienteSelecionado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlCliente;
        private System.ComponentModel.BackgroundWorker bkwBuscar;
        private System.Windows.Forms.DataGridView grade;
        private System.Windows.Forms.GroupBox gbClienteSelecionado;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLogradouro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.Label label8;
        private System.ComponentModel.BackgroundWorker bkwSalvar;
        private System.ComponentModel.BackgroundWorker bkwLoad;
    }
}