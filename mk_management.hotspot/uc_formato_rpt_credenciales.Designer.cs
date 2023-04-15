using DevExpress.XtraEditors;

namespace mk_management.hotspot
{
    partial class uc_formato_rpt_credenciales
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_formato_rpt_credenciales));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.gcFormatoCredenciales = new DevExpress.XtraEditors.GroupControl();
            this.lbTituloReporte = new DevExpress.XtraEditors.LabelControl();
            this.pic = new DevExpress.XtraEditors.PictureEdit();
            this.btnEditar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtImpresora = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnVistaPrevia = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFormatoCredenciales)).BeginInit();
            this.gcFormatoCredenciales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImpresora.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.gcFormatoCredenciales);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(552, 436);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // gcFormatoCredenciales
            // 
            this.gcFormatoCredenciales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcFormatoCredenciales.Appearance.BackColor = System.Drawing.Color.White;
            this.gcFormatoCredenciales.Appearance.BackColor2 = System.Drawing.Color.White;
            this.gcFormatoCredenciales.Appearance.Options.UseBackColor = true;
            this.gcFormatoCredenciales.AppearanceCaption.BackColor = System.Drawing.Color.White;
            this.gcFormatoCredenciales.AppearanceCaption.BackColor2 = System.Drawing.Color.White;
            this.gcFormatoCredenciales.AppearanceCaption.Options.UseBackColor = true;
            this.gcFormatoCredenciales.Controls.Add(this.btnVistaPrevia);
            this.gcFormatoCredenciales.Controls.Add(this.labelControl1);
            this.gcFormatoCredenciales.Controls.Add(this.txtImpresora);
            this.gcFormatoCredenciales.Controls.Add(this.lbTituloReporte);
            this.gcFormatoCredenciales.Controls.Add(this.pic);
            this.gcFormatoCredenciales.Controls.Add(this.btnEditar);
            this.gcFormatoCredenciales.Controls.Add(this.btnGuardar);
            this.gcFormatoCredenciales.Location = new System.Drawing.Point(22, 22);
            this.gcFormatoCredenciales.Name = "gcFormatoCredenciales";
            this.gcFormatoCredenciales.Size = new System.Drawing.Size(508, 392);
            this.gcFormatoCredenciales.TabIndex = 4;
            this.gcFormatoCredenciales.Text = "Configurar formato de credenciales";
            // 
            // lbTituloReporte
            // 
            this.lbTituloReporte.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTituloReporte.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbTituloReporte.Appearance.Options.UseFont = true;
            this.lbTituloReporte.Appearance.Options.UseTextOptions = true;
            this.lbTituloReporte.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbTituloReporte.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbTituloReporte.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbTituloReporte.Location = new System.Drawing.Point(63, 218);
            this.lbTituloReporte.Name = "lbTituloReporte";
            this.lbTituloReporte.Size = new System.Drawing.Size(381, 20);
            this.lbTituloReporte.TabIndex = 14;
            this.lbTituloReporte.Text = "Reporte";
            // 
            // pic
            // 
            this.pic.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pic.EditValue = ((object)(resources.GetObject("pic.EditValue")));
            this.pic.Location = new System.Drawing.Point(63, 66);
            this.pic.Name = "pic";
            this.pic.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pic.Properties.SvgImageSize = new System.Drawing.Size(50, 50);
            this.pic.Size = new System.Drawing.Size(381, 147);
            this.pic.TabIndex = 13;
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEditar.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnEditar.Appearance.Options.UseFont = true;
            this.btnEditar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnEditar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnEditar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEditar.ImageOptions.SvgImage")));
            this.btnEditar.Location = new System.Drawing.Point(63, 306);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(117, 65);
            this.btnEditar.StyleController = this.dataLayoutControl1;
            this.btnEditar.TabIndex = 11;
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGuardar.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnGuardar.Appearance.Options.UseFont = true;
            this.btnGuardar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnGuardar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnGuardar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGuardar.ImageOptions.SvgImage")));
            this.btnGuardar.Location = new System.Drawing.Point(327, 306);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(117, 65);
            this.btnGuardar.StyleController = this.dataLayoutControl1;
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20);
            this.layoutControlGroup1.Size = new System.Drawing.Size(552, 436);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcFormatoCredenciales;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(512, 396);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // txtImpresora
            // 
            this.txtImpresora.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtImpresora.Location = new System.Drawing.Point(63, 266);
            this.txtImpresora.Name = "txtImpresora";
            this.txtImpresora.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtImpresora.Properties.Appearance.Options.UseFont = true;
            this.txtImpresora.Size = new System.Drawing.Size(381, 26);
            this.txtImpresora.TabIndex = 15;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(63, 243);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(381, 20);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "Impresora :";
            // 
            // btnVistaPrevia
            // 
            this.btnVistaPrevia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnVistaPrevia.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnVistaPrevia.Appearance.Options.UseFont = true;
            this.btnVistaPrevia.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnVistaPrevia.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnVistaPrevia.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.btnVistaPrevia.Location = new System.Drawing.Point(196, 306);
            this.btnVistaPrevia.Name = "btnVistaPrevia";
            this.btnVistaPrevia.Size = new System.Drawing.Size(117, 65);
            this.btnVistaPrevia.StyleController = this.dataLayoutControl1;
            this.btnVistaPrevia.TabIndex = 17;
            this.btnVistaPrevia.Text = "Visualizar";
            this.btnVistaPrevia.Click += new System.EventHandler(this.btnVistaPrevia_Click);
            // 
            // uc_formato_rpt_credenciales
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "uc_formato_rpt_credenciales";
            this.Size = new System.Drawing.Size(552, 436);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcFormatoCredenciales)).EndInit();
            this.gcFormatoCredenciales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImpresora.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.GroupControl gcFormatoCredenciales;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        private DevExpress.XtraEditors.SimpleButton btnEditar;
        private PictureEdit pic;
        private LabelControl lbTituloReporte;
        private System.Windows.Forms.ImageList imageList1;
        private TextEdit txtImpresora;
        private LabelControl labelControl1;
        private SimpleButton btnVistaPrevia;
    }
}
