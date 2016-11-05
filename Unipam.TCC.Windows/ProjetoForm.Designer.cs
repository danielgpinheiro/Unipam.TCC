namespace Unipam.TCC.Windows
{
    partial class ProjetoForm
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
            this.tabControlProjeto = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBoxProjeto = new System.Windows.Forms.GroupBox();
            this.NomeAluno = new System.Windows.Forms.ComboBox();
            this.NomeProjetoLabel = new System.Windows.Forms.Label();
            this.NomeProjeto = new System.Windows.Forms.TextBox();
            this.NomeAlunoLabel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControlProjeto.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxProjeto.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlProjeto
            // 
            this.tabControlProjeto.Controls.Add(this.tabPage1);
            this.tabControlProjeto.Controls.Add(this.tabPage2);
            this.tabControlProjeto.Location = new System.Drawing.Point(1, 1);
            this.tabControlProjeto.Name = "tabControlProjeto";
            this.tabControlProjeto.SelectedIndex = 0;
            this.tabControlProjeto.Size = new System.Drawing.Size(283, 262);
            this.tabControlProjeto.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControlProjeto.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBoxProjeto);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(275, 236);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "cadastro";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBoxProjeto
            // 
            this.groupBoxProjeto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxProjeto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBoxProjeto.Controls.Add(this.NomeAluno);
            this.groupBoxProjeto.Controls.Add(this.NomeProjetoLabel);
            this.groupBoxProjeto.Controls.Add(this.NomeProjeto);
            this.groupBoxProjeto.Controls.Add(this.NomeAlunoLabel);
            this.groupBoxProjeto.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxProjeto.ForeColor = System.Drawing.Color.White;
            this.groupBoxProjeto.Location = new System.Drawing.Point(0, 0);
            this.groupBoxProjeto.Name = "groupBoxProjeto";
            this.groupBoxProjeto.Size = new System.Drawing.Size(275, 240);
            this.groupBoxProjeto.TabIndex = 0;
            this.groupBoxProjeto.TabStop = false;
            this.groupBoxProjeto.Text = "Cadastrar Projeto";
            // 
            // NomeAluno
            // 
            this.NomeAluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26F);
            this.NomeAluno.ForeColor = System.Drawing.Color.Black;
            this.NomeAluno.FormattingEnabled = true;
            this.NomeAluno.Location = new System.Drawing.Point(113, 47);
            this.NomeAluno.Name = "NomeAluno";
            this.NomeAluno.Size = new System.Drawing.Size(155, 21);
            this.NomeAluno.TabIndex = 3;
            this.NomeAluno.SelectedIndexChanged += new System.EventHandler(this.NomeAluno_SelectedIndexChanged);
            // 
            // NomeProjetoLabel
            // 
            this.NomeProjetoLabel.AutoSize = true;
            this.NomeProjetoLabel.BackColor = System.Drawing.Color.Sienna;
            this.NomeProjetoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26F);
            this.NomeProjetoLabel.ForeColor = System.Drawing.Color.Snow;
            this.NomeProjetoLabel.Location = new System.Drawing.Point(7, 20);
            this.NomeProjetoLabel.MinimumSize = new System.Drawing.Size(100, 20);
            this.NomeProjetoLabel.Name = "NomeProjetoLabel";
            this.NomeProjetoLabel.Size = new System.Drawing.Size(100, 20);
            this.NomeProjetoLabel.TabIndex = 1;
            this.NomeProjetoLabel.Text = "Nome Projeto";
            this.NomeProjetoLabel.Click += new System.EventHandler(this.NomeProjetoLabel_Click);
            // 
            // NomeProjeto
            // 
            this.NomeProjeto.Location = new System.Drawing.Point(113, 21);
            this.NomeProjeto.Name = "NomeProjeto";
            this.NomeProjeto.Size = new System.Drawing.Size(156, 20);
            this.NomeProjeto.TabIndex = 0;
            this.NomeProjeto.TextChanged += new System.EventHandler(this.NomeProjeto_TextChanged);
            // 
            // NomeAlunoLabel
            // 
            this.NomeAlunoLabel.AutoSize = true;
            this.NomeAlunoLabel.BackColor = System.Drawing.Color.Tan;
            this.NomeAlunoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26F);
            this.NomeAlunoLabel.ForeColor = System.Drawing.Color.Cornsilk;
            this.NomeAlunoLabel.Location = new System.Drawing.Point(7, 47);
            this.NomeAlunoLabel.MinimumSize = new System.Drawing.Size(100, 21);
            this.NomeAlunoLabel.Name = "NomeAlunoLabel";
            this.NomeAlunoLabel.Size = new System.Drawing.Size(100, 21);
            this.NomeAlunoLabel.TabIndex = 2;
            this.NomeAlunoLabel.Text = "Nome Aluno";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(275, 236);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ListaProjetos";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // ProjetoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(285, 267);
            this.Controls.Add(this.tabControlProjeto);
            this.IsMdiContainer = true;
            this.Name = "ProjetoForm";
            this.Text = "Projeto";
            this.tabControlProjeto.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBoxProjeto.ResumeLayout(false);
            this.groupBoxProjeto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlProjeto;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBoxProjeto;
        private System.Windows.Forms.TextBox NomeProjeto;
        private System.Windows.Forms.Label NomeProjetoLabel;
        private System.Windows.Forms.ComboBox NomeAluno;
        private System.Windows.Forms.Label NomeAlunoLabel;
    }
}