namespace mk_management.common.rpt
{
    partial class frmPricing
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.btnActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.btncerrar = new DevExpress.XtraEditors.SimpleButton();
            this.grdInfo = new DevExpress.XtraGrid.GridControl();
            this.gvInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFuncionalidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActivado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.btnActualizar);
            this.dataLayoutControl1.Controls.Add(this.btncerrar);
            this.dataLayoutControl1.Controls.Add(this.grdInfo);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(870, 588);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnActualizar.Appearance.Options.UseFont = true;
            this.btnActualizar.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.btnActualizar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnActualizar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnActualizar.ImageOptions.SvgImage = global::mk_management.common.Properties.Resources.upgrade;
            //this.btnActualizar.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.CommonPalette;
            this.btnActualizar.ImageOptions.SvgImageSize = new System.Drawing.Size(72, 72);
            this.btnActualizar.Location = new System.Drawing.Point(493, 508);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnActualizar.Size = new System.Drawing.Size(185, 68);
            this.btnActualizar.StyleController = this.dataLayoutControl1;
            toolTipItem1.Text = "Actualizar las características de la licencia";
            superToolTip1.Items.Add(toolTipItem1);
            this.btnActualizar.SuperTip = superToolTip1;
            this.btnActualizar.TabIndex = 6;
            this.btnActualizar.Text = "  Actualizar \r\nLicencia";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btncerrar
            // 
            this.btncerrar.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btncerrar.Appearance.Options.UseFont = true;
            this.btncerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btncerrar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btncerrar.ImageOptions.SvgImage = global::mk_management.common.Properties.Resources.close;
            this.btncerrar.ImageOptions.SvgImageSize = new System.Drawing.Size(72, 72);
            this.btncerrar.Location = new System.Drawing.Point(682, 508);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btncerrar.Size = new System.Drawing.Size(176, 68);
            this.btncerrar.StyleController = this.dataLayoutControl1;
            toolTipItem2.Text = "Cerrar esta ventana";
            superToolTip2.Items.Add(toolTipItem2);
            this.btncerrar.SuperTip = superToolTip2;
            this.btncerrar.TabIndex = 5;
            this.btncerrar.Text = "Cerrar";
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // grdInfo
            // 
            this.grdInfo.Location = new System.Drawing.Point(12, 12);
            this.grdInfo.MainView = this.gvInfo;
            this.grdInfo.Name = "grdInfo";
            this.grdInfo.Size = new System.Drawing.Size(846, 492);
            this.grdInfo.TabIndex = 4;
            this.grdInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInfo});
            // 
            // gvInfo
            // 
            this.gvInfo.Appearance.EvenRow.BackColor = System.Drawing.Color.Gainsboro;
            this.gvInfo.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvInfo.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gvInfo.Appearance.Row.Options.UseFont = true;
            this.gvInfo.Appearance.ViewCaption.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.gvInfo.Appearance.ViewCaption.Options.UseFont = true;
            this.gvInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFuncionalidad,
            this.colActivado});
            this.gvInfo.GridControl = this.grdInfo;
            this.gvInfo.Name = "gvInfo";
            this.gvInfo.OptionsBehavior.Editable = false;
            this.gvInfo.OptionsMenu.EnableColumnMenu = false;
            this.gvInfo.OptionsMenu.EnableFooterMenu = false;
            this.gvInfo.OptionsMenu.EnableGroupPanelMenu = false;
            this.gvInfo.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gvInfo.OptionsView.ShowColumnHeaders = false;
            this.gvInfo.OptionsView.ShowDetailButtons = false;
            this.gvInfo.OptionsView.ShowErrorPanel = DevExpress.Utils.DefaultBoolean.False;
            this.gvInfo.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gvInfo.OptionsView.ShowGroupPanel = false;
            this.gvInfo.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvInfo.OptionsView.ShowIndicator = false;
            this.gvInfo.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvInfo.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvInfo.OptionsView.ShowViewCaption = true;
            this.gvInfo.ViewCaption = "Funcionalidades";
            // 
            // colFuncionalidad
            // 
            this.colFuncionalidad.Caption = "Funcionalidad";
            this.colFuncionalidad.FieldName = "Funcionalidad";
            this.colFuncionalidad.Name = "colFuncionalidad";
            this.colFuncionalidad.Visible = true;
            this.colFuncionalidad.VisibleIndex = 0;
            // 
            // colActivado
            // 
            this.colActivado.Caption = "Activado";
            this.colActivado.FieldName = "Activado";
            this.colActivado.Name = "colActivado";
            this.colActivado.Visible = true;
            this.colActivado.VisibleIndex = 1;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(870, 588);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdInfo;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(850, 496);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btncerrar;
            this.layoutControlItem2.Location = new System.Drawing.Point(670, 496);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(180, 72);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(180, 72);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(180, 72);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnActualizar;
            this.layoutControlItem3.Location = new System.Drawing.Point(481, 496);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(189, 72);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(189, 72);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(189, 72);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 496);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(481, 72);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmPricing
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btncerrar;
            this.ClientSize = new System.Drawing.Size(870, 588);
            this.Controls.Add(this.dataLayoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPricing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Licencia";
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl grdInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInfo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colActivado;
        private DevExpress.XtraGrid.Columns.GridColumn colFuncionalidad;
        private DevExpress.XtraEditors.SimpleButton btncerrar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btnActualizar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}