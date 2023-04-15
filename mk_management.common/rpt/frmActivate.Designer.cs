namespace mk_management.common.rpt
{
    partial class frmActivate
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
            this.ucActivate1 = new mk_management.common.rpt.ucActivate();
            this.SuspendLayout();
            // 
            // ucActivate1
            // 
            this.ucActivate1.Appearance.BackColor = System.Drawing.Color.White;
            this.ucActivate1.Appearance.Options.UseBackColor = true;
            this.ucActivate1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucActivate1.Location = new System.Drawing.Point(0, 0);
            this.ucActivate1.Name = "ucActivate1";
            this.ucActivate1.Size = new System.Drawing.Size(843, 561);
            this.ucActivate1.TabIndex = 0;
            this.ucActivate1.CloseEvent += new System.EventHandler(this.ucActivate1_CloseEvent);
            // 
            // frmActivate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 561);
            this.ControlBox = false;
            this.Controls.Add(this.ucActivate1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmActivate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador de licencia";
            this.Load += new System.EventHandler(this.frmActivate_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucActivate ucActivate1;
    }
}