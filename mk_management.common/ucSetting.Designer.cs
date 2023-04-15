namespace mk_management.common
{
    partial class ucSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSetting));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.ucInfoComp1 = new mk_management.common.ucInfoComp();
            this.ucAppSetting1 = new mk_management.common.ucAppSetting();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.lcgEmpresa = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgConexionBdd = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgEmpresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgConexionBdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.ucInfoComp1);
            this.dataLayoutControl1.Controls.Add(this.ucAppSetting1);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(484, 241, 650, 400);
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(827, 550);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // ucInfoComp1
            // 
            this.ucInfoComp1.Appearance.BackColor = System.Drawing.Color.White;
            this.ucInfoComp1.Appearance.Options.UseBackColor = true;
            this.ucInfoComp1.Location = new System.Drawing.Point(24, 66);
            this.ucInfoComp1.Name = "ucInfoComp1";
            this.ucInfoComp1.Size = new System.Drawing.Size(762, 734);
            this.ucInfoComp1.TabIndex = 6;
            // 
            // ucAppSetting1
            // 
            this.ucAppSetting1.Appearance.BackColor = System.Drawing.Color.White;
            this.ucAppSetting1.Appearance.Options.UseBackColor = true;
            this.ucAppSetting1.Location = new System.Drawing.Point(24, 66);
            this.ucAppSetting1.Name = "ucAppSetting1";
            this.ucAppSetting1.Size = new System.Drawing.Size(762, 734);
            this.ucAppSetting1.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(810, 824);
            this.Root.TextVisible = false;
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.CustomizationFormText = "Configurar";
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.lcgConexionBdd;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(790, 804);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgConexionBdd,
            this.lcgEmpresa});
            this.tabbedControlGroup1.Transition.AllowTransition = DevExpress.Utils.DefaultBoolean.True;
            this.tabbedControlGroup1.Transition.EasingMode = DevExpress.Data.Utils.EasingMode.EaseInOut;
            // 
            // lcgEmpresa
            // 
            this.lcgEmpresa.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("lcgEmpresa.CaptionImageOptions.SvgImage")));
            this.lcgEmpresa.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.lcgEmpresa.Location = new System.Drawing.Point(0, 0);
            this.lcgEmpresa.Name = "lcgEmpresa";
            this.lcgEmpresa.Size = new System.Drawing.Size(766, 738);
            this.lcgEmpresa.Text = "Información de mi empresa";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.ucInfoComp1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(766, 738);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // lcgConexionBdd
            // 
            this.lcgConexionBdd.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lcgConexionBdd.CaptionImageOptions.Image")));
            this.lcgConexionBdd.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.lcgConexionBdd.Location = new System.Drawing.Point(0, 0);
            this.lcgConexionBdd.Name = "lcgConexionBdd";
            this.lcgConexionBdd.Size = new System.Drawing.Size(766, 738);
            this.lcgConexionBdd.Text = "Configuración";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ucAppSetting1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(766, 738);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ucSetting
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "ucSetting";
            this.Size = new System.Drawing.Size(827, 550);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgEmpresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgConexionBdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private ucAppSetting ucAppSetting1;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgConexionBdd;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgEmpresa;
        private ucInfoComp ucInfoComp1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}