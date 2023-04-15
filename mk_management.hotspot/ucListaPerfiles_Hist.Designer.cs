namespace mk_management.hotspot
{
    partial class ucListaPerfiles_Hist
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
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucListaPerfiles_Hist));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.wBtnAgregar = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.grdDatos = new DevExpress.XtraGrid.GridControl();
            this.gvdatos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKb_Descarga = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKb_Subida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdServer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHP_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPcHost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsuarioCreo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaCreo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDispositivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repDisabled = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvdatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDisabled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.wBtnAgregar);
            this.dataLayoutControl1.Controls.Add(this.grdDatos);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(825, 465);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // wBtnAgregar
            // 
            this.wBtnAgregar.BackColor = System.Drawing.Color.Transparent;
            windowsUIButtonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions1.SvgImage")));
            windowsUIButtonImageOptions1.SvgImageSize = new System.Drawing.Size(25, 25);
            this.wBtnAgregar.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Actualizar", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, "Ver", -1, false)});
            this.wBtnAgregar.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.wBtnAgregar.Location = new System.Drawing.Point(34, 59);
            this.wBtnAgregar.Name = "wBtnAgregar";
            this.wBtnAgregar.Size = new System.Drawing.Size(757, 55);
            this.wBtnAgregar.TabIndex = 5;
            this.wBtnAgregar.Text = "Opciones";
            this.wBtnAgregar.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.wBtnAgregar_ButtonClick);
            // 
            // grdDatos
            // 
            this.grdDatos.Location = new System.Drawing.Point(34, 126);
            this.grdDatos.MainView = this.gvdatos;
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repDisabled});
            this.grdDatos.Size = new System.Drawing.Size(757, 305);
            this.grdDatos.TabIndex = 4;
            this.grdDatos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvdatos});
            // 
            // gvdatos
            // 
            this.gvdatos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colDescripcion,
            this.colKb_Descarga,
            this.colKb_Subida,
            this.colIdServer,
            this.colHP_Id,
            this.colPcHost,
            this.colUsuarioCreo,
            this.colFechaCreo,
            this.colDispositivo});
            this.gvdatos.GridControl = this.grdDatos;
            this.gvdatos.Name = "gvdatos";
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.ReadOnly = true;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 0;
            // 
            // colKb_Descarga
            // 
            this.colKb_Descarga.Caption = "Mb. Descarga";
            this.colKb_Descarga.FieldName = "str_mb_descarga";
            this.colKb_Descarga.Name = "colKb_Descarga";
            this.colKb_Descarga.Visible = true;
            this.colKb_Descarga.VisibleIndex = 1;
            // 
            // colKb_Subida
            // 
            this.colKb_Subida.Caption = "Mb Subida";
            this.colKb_Subida.FieldName = "str_mb_subida";
            this.colKb_Subida.Name = "colKb_Subida";
            this.colKb_Subida.Visible = true;
            this.colKb_Subida.VisibleIndex = 2;
            // 
            // colIdServer
            // 
            this.colIdServer.Caption = "Id. Server";
            this.colIdServer.FieldName = "IdServer";
            this.colIdServer.Name = "colIdServer";
            this.colIdServer.OptionsColumn.ReadOnly = true;
            // 
            // colHP_Id
            // 
            this.colHP_Id.Caption = "Id. HotSpot";
            this.colHP_Id.FieldName = "HP_Id";
            this.colHP_Id.Name = "colHP_Id";
            this.colHP_Id.OptionsColumn.ReadOnly = true;
            this.colHP_Id.Width = 103;
            // 
            // colPcHost
            // 
            this.colPcHost.Caption = "Creado En";
            this.colPcHost.FieldName = "PcHost";
            this.colPcHost.Name = "colPcHost";
            this.colPcHost.OptionsColumn.ReadOnly = true;
            this.colPcHost.Visible = true;
            this.colPcHost.VisibleIndex = 4;
            this.colPcHost.Width = 125;
            // 
            // colUsuarioCreo
            // 
            this.colUsuarioCreo.Caption = "Creado Por";
            this.colUsuarioCreo.FieldName = "UsuarioCreo";
            this.colUsuarioCreo.Name = "colUsuarioCreo";
            this.colUsuarioCreo.OptionsColumn.ReadOnly = true;
            this.colUsuarioCreo.Visible = true;
            this.colUsuarioCreo.VisibleIndex = 5;
            this.colUsuarioCreo.Width = 125;
            // 
            // colFechaCreo
            // 
            this.colFechaCreo.Caption = "Fecha Creó";
            this.colFechaCreo.DisplayFormat.FormatString = "g";
            this.colFechaCreo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFechaCreo.FieldName = "FechaCreo";
            this.colFechaCreo.GroupFormat.FormatString = "g";
            this.colFechaCreo.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFechaCreo.Name = "colFechaCreo";
            this.colFechaCreo.OptionsColumn.ReadOnly = true;
            this.colFechaCreo.Visible = true;
            this.colFechaCreo.VisibleIndex = 6;
            this.colFechaCreo.Width = 133;
            // 
            // colDispositivo
            // 
            this.colDispositivo.Caption = "Dispositivo";
            this.colDispositivo.FieldName = "Dispositivo";
            this.colDispositivo.Name = "colDispositivo";
            this.colDispositivo.OptionsColumn.ReadOnly = true;
            this.colDispositivo.Visible = true;
            this.colDispositivo.VisibleIndex = 3;
            this.colDispositivo.Width = 129;
            // 
            // repDisabled
            // 
            this.repDisabled.AutoHeight = false;
            this.repDisabled.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.repDisabled.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repDisabled.Name = "repDisabled";
            this.repDisabled.OffText = "Si";
            this.repDisabled.OnText = "No";
            this.repDisabled.ReadOnly = true;
            this.repDisabled.ValueOff = true;
            this.repDisabled.ValueOn = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20);
            this.Root.Size = new System.Drawing.Size(825, 465);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(785, 425);
            this.layoutControlGroup1.Text = "Historial de Perfiles";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.wBtnAgregar;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.layoutControlItem2.Size = new System.Drawing.Size(761, 67);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdDatos;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 67);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(761, 309);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ucListaPerfiles_Hist
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "ucListaPerfiles_Hist";
            this.Size = new System.Drawing.Size(825, 465);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvdatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDisabled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl grdDatos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvdatos;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel wBtnAgregar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch repDisabled;
        private DevExpress.XtraGrid.Columns.GridColumn colIdServer;
        private DevExpress.XtraGrid.Columns.GridColumn colHP_Id;
        private DevExpress.XtraGrid.Columns.GridColumn colPcHost;
        private DevExpress.XtraGrid.Columns.GridColumn colUsuarioCreo;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaCreo;
        private DevExpress.XtraGrid.Columns.GridColumn colDispositivo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colKb_Descarga;
        private DevExpress.XtraGrid.Columns.GridColumn colKb_Subida;
    }
}