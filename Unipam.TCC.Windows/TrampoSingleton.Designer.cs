namespace Unipam.TCC.Windows
{
    partial class TrampoSingleton
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
            this.menuBehavior = new System.Windows.Forms.MenuStrip();
            this.formularioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBehavior.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBehavior
            // 
            this.menuBehavior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formularioToolStripMenuItem});
            this.menuBehavior.Location = new System.Drawing.Point(0, 0);
            this.menuBehavior.Name = "menuBehavior";
            this.menuBehavior.Size = new System.Drawing.Size(522, 24);
            this.menuBehavior.TabIndex = 1;
            this.menuBehavior.Text = "menuStrip1";
            // 
            // formularioToolStripMenuItem
            // 
            this.formularioToolStripMenuItem.Name = "formularioToolStripMenuItem";
            this.formularioToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.formularioToolStripMenuItem.Text = "Formulario";
            this.formularioToolStripMenuItem.Click += new System.EventHandler(this.formularioToolStripMenuItem_Click);
            // 
            // TrampoSingleton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 458);
            this.Controls.Add(this.menuBehavior);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuBehavior;
            this.Name = "TrampoSingleton";
            this.Text = "TrampoSingleton";
            this.menuBehavior.ResumeLayout(false);
            this.menuBehavior.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuBehavior;
        private System.Windows.Forms.ToolStripMenuItem formularioToolStripMenuItem;
    }
}