namespace Unipam.TCC.Windows
{
    partial class AlunoForm
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
            this.groupBoxNovoAluno = new System.Windows.Forms.GroupBox();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.comboBoxCurso = new System.Windows.Forms.ComboBox();
            this.textBoxAluno = new System.Windows.Forms.TextBox();
            this.labelCurso = new System.Windows.Forms.Label();
            this.labelAluno = new System.Windows.Forms.Label();
            this.groupBoxNovoAluno.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxNovoAluno
            // 
            this.groupBoxNovoAluno.Controls.Add(this.buttonSalvar);
            this.groupBoxNovoAluno.Controls.Add(this.comboBoxCurso);
            this.groupBoxNovoAluno.Controls.Add(this.textBoxAluno);
            this.groupBoxNovoAluno.Controls.Add(this.labelCurso);
            this.groupBoxNovoAluno.Controls.Add(this.labelAluno);
            this.groupBoxNovoAluno.Location = new System.Drawing.Point(0, 0);
            this.groupBoxNovoAluno.Name = "groupBoxNovoAluno";
            this.groupBoxNovoAluno.Size = new System.Drawing.Size(283, 166);
            this.groupBoxNovoAluno.TabIndex = 1;
            this.groupBoxNovoAluno.TabStop = false;
            this.groupBoxNovoAluno.Text = "Novo Aluno";
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Location = new System.Drawing.Point(197, 137);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(75, 23);
            this.buttonSalvar.TabIndex = 4;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = true;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // comboBoxCurso
            // 
            this.comboBoxCurso.FormattingEnabled = true;
            this.comboBoxCurso.Location = new System.Drawing.Point(97, 45);
            this.comboBoxCurso.Name = "comboBoxCurso";
            this.comboBoxCurso.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCurso.TabIndex = 3;
            this.comboBoxCurso.SelectedIndexChanged += new System.EventHandler(this.comboBoxCurso_SelectedIndexChanged);
            // 
            // textBoxAluno
            // 
            this.textBoxAluno.Location = new System.Drawing.Point(97, 20);
            this.textBoxAluno.Name = "textBoxAluno";
            this.textBoxAluno.Size = new System.Drawing.Size(121, 20);
            this.textBoxAluno.TabIndex = 2;
            // 
            // labelCurso
            // 
            this.labelCurso.AutoSize = true;
            this.labelCurso.Location = new System.Drawing.Point(11, 45);
            this.labelCurso.Name = "labelCurso";
            this.labelCurso.Size = new System.Drawing.Size(65, 13);
            this.labelCurso.TabIndex = 1;
            this.labelCurso.Text = "Nome Curso";
            // 
            // labelAluno
            // 
            this.labelAluno.AutoSize = true;
            this.labelAluno.Location = new System.Drawing.Point(11, 20);
            this.labelAluno.Name = "labelAluno";
            this.labelAluno.Size = new System.Drawing.Size(64, 13);
            this.labelAluno.TabIndex = 0;
            this.labelAluno.Text = "Nome aluno";
            // 
            // AlunoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.groupBoxNovoAluno);
            this.IsMdiContainer = true;
            this.Name = "AlunoForm";
            this.Text = "AlunoForm";
            this.Load += new System.EventHandler(this.AlunoForm_Load);
            this.groupBoxNovoAluno.ResumeLayout(false);
            this.groupBoxNovoAluno.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxNovoAluno;
        private System.Windows.Forms.Label labelCurso;
        private System.Windows.Forms.Label labelAluno;
        private System.Windows.Forms.ComboBox comboBoxCurso;
        private System.Windows.Forms.TextBox textBoxAluno;
        private System.Windows.Forms.Button buttonSalvar;
    }
}