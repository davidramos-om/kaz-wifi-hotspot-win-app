namespace mk_management.common.rpt
{
    partial class frmCongrats
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCongrats));
            DevExpress.Utils.Animation.Transition transition2 = new DevExpress.Utils.Animation.Transition();
            DevExpress.Utils.Animation.DissolveTransition dissolveTransition2 = new DevExpress.Utils.Animation.DissolveTransition();
            this.lblTitulo = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbSubTitulo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.transitionManager1 = new DevExpress.Utils.Animation.TransitionManager(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btncerrar = new DevExpress.XtraEditors.SimpleButton();
            this.lbTop = new System.Windows.Forms.Label();
            this.lbDerecha = new System.Windows.Forms.Label();
            this.lbIqz = new System.Windows.Forms.Label();
            this.lbAbajo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.lblTitulo.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblTitulo.Appearance.Options.UseFont = true;
            this.lblTitulo.Appearance.Options.UseForeColor = true;
            this.lblTitulo.Appearance.Options.UseTextOptions = true;
            this.lblTitulo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTitulo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblTitulo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTitulo.Location = new System.Drawing.Point(118, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(252, 42);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Felicidades";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(118, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(252, 198);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lbSubTitulo
            // 
            this.lbSubTitulo.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            //this.lbSubTitulo.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.ControlText;
            this.lbSubTitulo.Appearance.Options.UseFont = true;
            this.lbSubTitulo.Appearance.Options.UseForeColor = true;
            this.lbSubTitulo.Appearance.Options.UseTextOptions = true;
            this.lbSubTitulo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbSubTitulo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbSubTitulo.Location = new System.Drawing.Point(118, 277);
            this.lbSubTitulo.Name = "lbSubTitulo";
            this.lbSubTitulo.Size = new System.Drawing.Size(252, 21);
            this.lbSubTitulo.TabIndex = 2;
            this.lbSubTitulo.Text = "La licencia ha sido aplicada";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl3.AutoEllipsis = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(21, 309);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(429, 47);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Ahora puede utilizar las funcionalidades\r\n adquiridas";
            this.labelControl3.DoubleClick += new System.EventHandler(this.labelControl3_Click);
            // 
            // transitionManager1
            // 
            this.transitionManager1.FrameInterval = 5000;
            this.transitionManager1.ShowWaitingIndicator = false;
            transition2.BarWaitingIndicatorProperties.Caption = "";
            transition2.BarWaitingIndicatorProperties.Description = "";
            transition2.Control = this.lblTitulo;
            transition2.EasingMode = DevExpress.Data.Utils.EasingMode.EaseInOut;
            transition2.LineWaitingIndicatorProperties.AnimationElementCount = 5;
            transition2.LineWaitingIndicatorProperties.Caption = "";
            transition2.LineWaitingIndicatorProperties.Description = "";
            transition2.RingWaitingIndicatorProperties.AnimationElementCount = 5;
            transition2.RingWaitingIndicatorProperties.Caption = "";
            transition2.RingWaitingIndicatorProperties.Description = "";
            transition2.ShowWaitingIndicator = DevExpress.Utils.DefaultBoolean.False;
            transition2.TransitionType = dissolveTransition2;
            transition2.WaitingIndicatorProperties.Caption = "";
            transition2.WaitingIndicatorProperties.Description = "";
            this.transitionManager1.Transitions.Add(transition2);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btncerrar
            // 
            this.btncerrar.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btncerrar.Appearance.Options.UseFont = true;
            this.btncerrar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btncerrar.ImageOptions.Image")));
            this.btncerrar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btncerrar.Location = new System.Drawing.Point(169, 364);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btncerrar.Size = new System.Drawing.Size(129, 59);
            this.btncerrar.TabIndex = 4;
            this.btncerrar.Text = "Cerrar";
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // lbTop
            // 
            this.lbTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.lbTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTop.Location = new System.Drawing.Point(0, 0);
            this.lbTop.Name = "lbTop";
            this.lbTop.Size = new System.Drawing.Size(474, 18);
            this.lbTop.TabIndex = 5;
            // 
            // lbDerecha
            // 
            this.lbDerecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.lbDerecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbDerecha.Location = new System.Drawing.Point(456, 18);
            this.lbDerecha.Name = "lbDerecha";
            this.lbDerecha.Size = new System.Drawing.Size(18, 432);
            this.lbDerecha.TabIndex = 6;
            // 
            // lbIqz
            // 
            this.lbIqz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.lbIqz.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbIqz.Location = new System.Drawing.Point(0, 18);
            this.lbIqz.Name = "lbIqz";
            this.lbIqz.Size = new System.Drawing.Size(18, 432);
            this.lbIqz.TabIndex = 7;
            // 
            // lbAbajo
            // 
            this.lbAbajo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.lbAbajo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbAbajo.Location = new System.Drawing.Point(18, 432);
            this.lbAbajo.Name = "lbAbajo";
            this.lbAbajo.Size = new System.Drawing.Size(438, 18);
            this.lbAbajo.TabIndex = 8;
            // 
            // frmCongrats
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 450);
            this.ControlBox = false;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lbAbajo);
            this.Controls.Add(this.lbIqz);
            this.Controls.Add(this.lbDerecha);
            this.Controls.Add(this.lbTop);
            this.Controls.Add(this.btncerrar);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lbSubTitulo);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCongrats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "La aplicación ha esta activada -   ¡Muchas gracias!";
            this.Shown += new System.EventHandler(this.frmCongrats_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.LabelControl lbSubTitulo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.Utils.Animation.TransitionManager transitionManager1;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.SimpleButton btncerrar;
        private System.Windows.Forms.Label lbTop;
        private System.Windows.Forms.Label lbDerecha;
        private System.Windows.Forms.Label lbIqz;
        private System.Windows.Forms.Label lbAbajo;
    }
}