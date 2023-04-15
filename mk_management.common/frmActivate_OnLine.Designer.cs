namespace mk_management.common
{
    partial class frmActivate_OnLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActivate_OnLine));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.lbTitulo = new DevExpress.XtraEditors.LabelControl();
            this.btnActivar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.txtLicencia = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigoCliente = new DevExpress.XtraEditors.TextEdit();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtLicencia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitulo.Appearance.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.lbTitulo.Appearance.Options.UseFont = true;
            this.lbTitulo.Appearance.Options.UseForeColor = true;
            this.lbTitulo.Appearance.Options.UseTextOptions = true;
            this.lbTitulo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbTitulo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbTitulo.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbTitulo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbTitulo.Location = new System.Drawing.Point(12, 19);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(584, 40);
            this.lbTitulo.TabIndex = 5;
            this.lbTitulo.Text = "Ingrese los siguientes datos";
            // 
            // btnActivar
            // 
            this.btnActivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActivar.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivar.Appearance.Options.UseFont = true;
            this.btnActivar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnActivar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnActivar.ImageOptions.Image")));
            this.btnActivar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnActivar.Location = new System.Drawing.Point(456, 296);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnActivar.Size = new System.Drawing.Size(126, 53);
            this.btnActivar.TabIndex = 4;
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
            this.btnCancelar.Location = new System.Drawing.Point(324, 296);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnCancelar.Size = new System.Drawing.Size(126, 53);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtLicencia
            // 
            this.txtLicencia.EditValue = "U153C-YY34C-VWHC2-7BE1A-C06B8-4F675";
            this.txtLicencia.Location = new System.Drawing.Point(12, 103);
            this.txtLicencia.Name = "txtLicencia";
            this.txtLicencia.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.txtLicencia.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.txtLicencia.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(87)))), ((int)(((byte)(36)))));
            this.txtLicencia.Properties.Appearance.Options.UseBackColor = true;
            this.txtLicencia.Properties.Appearance.Options.UseFont = true;
            this.txtLicencia.Properties.Appearance.Options.UseForeColor = true;
            this.txtLicencia.Properties.Appearance.Options.UseTextOptions = true;
            this.txtLicencia.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtLicencia.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtLicencia.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLicencia.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.txtLicencia.Properties.MaxLength = 40;
            this.txtLicencia.Size = new System.Drawing.Size(584, 38);
            this.txtLicencia.TabIndex = 0;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Escribir licencia";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.txtLicencia, conditionValidationRule2);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 65);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(96, 32);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Licencia :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 171);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(201, 32);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Código de cliente :";
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.EditValue = "5D5DD9B7";
            this.txtCodigoCliente.Location = new System.Drawing.Point(12, 209);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.txtCodigoCliente.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.txtCodigoCliente.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(84)))), ((int)(((byte)(96)))));
            this.txtCodigoCliente.Properties.Appearance.Options.UseBackColor = true;
            this.txtCodigoCliente.Properties.Appearance.Options.UseFont = true;
            this.txtCodigoCliente.Properties.Appearance.Options.UseForeColor = true;
            this.txtCodigoCliente.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCodigoCliente.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCodigoCliente.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.txtCodigoCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoCliente.Properties.MaxLength = 10;
            this.txtCodigoCliente.Size = new System.Drawing.Size(584, 38);
            this.txtCodigoCliente.TabIndex = 2;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "Escribir código de cliente";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.txtCodigoCliente, conditionValidationRule3);
            // 
            // frmActivate_OnLine
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(608, 361);
            this.Controls.Add(this.txtCodigoCliente);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtLicencia);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.lbTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmActivate_OnLine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Activación sin conexión a Internet";
            ((System.ComponentModel.ISupportInitialize)(this.txtLicencia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbTitulo;
        private DevExpress.XtraEditors.SimpleButton btnActivar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.TextEdit txtLicencia;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtCodigoCliente;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}