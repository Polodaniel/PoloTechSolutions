
namespace PontoEletronicoDesktop.Views.Atualizar
{
    partial class frmAtualizarFuncionarioConsulta
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
            this.bkwBuscar = new System.ComponentModel.BackgroundWorker();
            this.grade = new System.Windows.Forms.DataGridView();
            this.pnlBotoesCRUD.SuspendLayout();
            this.pnlBotoesBusca.SuspendLayout();
            this.pnlCentralCRUD.SuspendLayout();
            this.pnlCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grade)).BeginInit();
            this.SuspendLayout();
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
            this.pnlCentralCRUD.Controls.Add(this.grade);
            this.pnlCentralCRUD.Padding = new System.Windows.Forms.Padding(6);
            this.pnlCentralCRUD.Size = new System.Drawing.Size(726, 335);
            // 
            // btnEditar
            // 
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.AppWorkspace;
            // 
            // btnFechar
            // 
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnFechar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.AppWorkspace;
            // 
            // bkwBuscar
            // 
            this.bkwBuscar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkwBuscar_DoWork);
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
            this.grade.Location = new System.Drawing.Point(6, 6);
            this.grade.MultiSelect = false;
            this.grade.Name = "grade";
            this.grade.RowHeadersVisible = false;
            this.grade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grade.Size = new System.Drawing.Size(714, 323);
            this.grade.TabIndex = 0;
            // 
            // frmAtualizarFuncionarioConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "frmAtualizarFuncionarioConsulta";
            this.Text = "AtualizarCadastroConsulta";
            this.pnlBotoesCRUD.ResumeLayout(false);
            this.pnlBotoesBusca.ResumeLayout(false);
            this.pnlCentralCRUD.ResumeLayout(false);
            this.pnlCentral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grade)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bkwBuscar;
        private System.Windows.Forms.DataGridView grade;
    }
}