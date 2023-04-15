namespace mk_management.common
{
    partial class frmActivate_Offline
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActivate_Offline));
            this.lbTitulo = new DevExpress.XtraEditors.LabelControl();
            this.mbLicencia = new DevExpress.XtraEditors.MemoEdit();
            this.btnActivar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.mbLicencia.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitulo.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.lbTitulo.Appearance.Options.UseFont = true;
            this.lbTitulo.Appearance.Options.UseForeColor = true;
            this.lbTitulo.Appearance.Options.UseTextOptions = true;
            this.lbTitulo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbTitulo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbTitulo.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbTitulo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbTitulo.Location = new System.Drawing.Point(12, 12);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(604, 40);
            this.lbTitulo.TabIndex = 0;
            this.lbTitulo.Text = "Por favor, pegue el código de activación proporcionado";
            // 
            // mbLicencia
            // 
            this.mbLicencia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mbLicencia.EditValue = "";
            this.mbLicencia.Location = new System.Drawing.Point(28, 75);
            this.mbLicencia.MinimumSize = new System.Drawing.Size(554, 230);
            this.mbLicencia.Name = "mbLicencia";
            this.mbLicencia.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mbLicencia.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.mbLicencia.Properties.Appearance.Options.UseFont = true;
            this.mbLicencia.Properties.Appearance.Options.UseForeColor = true;
            this.mbLicencia.Properties.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.mbLicencia.Size = new System.Drawing.Size(574, 259);
            this.mbLicencia.TabIndex = 0;
            // 
            // btnActivar
            // 
            this.btnActivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActivar.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivar.Appearance.Options.UseFont = true;
            this.btnActivar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnActivar.ImageOptions.Image")));
            this.btnActivar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnActivar.Location = new System.Drawing.Point(476, 342);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnActivar.Size = new System.Drawing.Size(126, 53);
            this.btnActivar.TabIndex = 1;
            this.btnActivar.Text = "Aceptar";
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Appearance.Options.UseFont = true;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCancelar.Location = new System.Drawing.Point(344, 342);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnCancelar.Size = new System.Drawing.Size(126, 53);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.labelControl1.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(12, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(604, 40);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "No deje espacios ni altere ningún valor.";
            // 
            // frmActivate_Offline
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(628, 407);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.mbLicencia);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.labelControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmActivate_Offline";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Activación sin conexión a Internet";
            ((System.ComponentModel.ISupportInitialize)(this.mbLicencia.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbTitulo;
        private DevExpress.XtraEditors.MemoEdit mbLicencia;
        private DevExpress.XtraEditors.SimpleButton btnActivar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}