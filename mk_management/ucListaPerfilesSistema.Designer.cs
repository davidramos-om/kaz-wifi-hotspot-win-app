namespace mk_management
{
    partial class ucListaPerfilesSistema
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucListaPerfilesSistema));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.grdDatos = new DevExpress.XtraGrid.GridControl();
            this.gvdatos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPcHost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsuarioCreo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaCreo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEliminar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repBtnEliminar = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colEditar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repBtnEditar = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.windowsUIButtonPanel1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvdatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repBtnEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repBtnEditar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.grdDatos);
            this.dataLayoutControl1.Controls.Add(this.windowsUIButtonPanel1);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(836, 541);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // grdDatos
            // 
            this.grdDatos.Location = new System.Drawing.Point(34, 126);
            this.grdDatos.MainView = this.gvdatos;
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repBtnEliminar,
            this.repBtnEditar});
            this.grdDatos.Size = new System.Drawing.Size(768, 381);
            this.grdDatos.TabIndex = 5;
            this.grdDatos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvdatos});
            // 
            // gvdatos
            // 
            this.gvdatos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colNombre,
            this.colPcHost,
            this.colUsuarioCreo,
            this.colFechaCreo,
            this.colEliminar,
            this.colEditar});
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
            // colNombre
            // 
            this.colNombre.Caption = "Nombre";
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.OptionsColumn.ReadOnly = true;
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 2;
            // 
            // colPcHost
            // 
            this.colPcHost.Caption = "Creado En";
            this.colPcHost.FieldName = "PcHost";
            this.colPcHost.Name = "colPcHost";
            this.colPcHost.OptionsColumn.ReadOnly = true;
            this.colPcHost.Visible = true;
            this.colPcHost.VisibleIndex = 3;
            this.colPcHost.Width = 125;
            // 
            // colUsuarioCreo
            // 
            this.colUsuarioCreo.Caption = "Creado Por";
            this.colUsuarioCreo.FieldName = "UsuarioCreo";
            this.colUsuarioCreo.Name = "colUsuarioCreo";
            this.colUsuarioCreo.OptionsColumn.ReadOnly = true;
            this.colUsuarioCreo.Visible = true;
            this.colUsuarioCreo.VisibleIndex = 4;
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
            this.colFechaCreo.VisibleIndex = 5;
            this.colFechaCreo.Width = 133;
            // 
            // colEliminar
            // 
            this.colEliminar.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colEliminar.AppearanceHeader.Options.UseFont = true;
            this.colEliminar.AppearanceHeader.Options.UseTextOptions = true;
            this.colEliminar.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEliminar.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colEliminar.Caption = "Eliminar";
            this.colEliminar.ColumnEdit = this.repBtnEliminar;
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.colEliminar.Visible = true;
            this.colEliminar.VisibleIndex = 1;
            // 
            // repBtnEliminar
            // 
            this.repBtnEliminar.AutoHeight = false;
            this.repBtnEliminar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "Eliminar", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repBtnEliminar.Name = "repBtnEliminar";
            this.repBtnEliminar.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repBtnEliminar.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repBtnEliminar_ButtonClick);
            // 
            // colEditar
            // 
            this.colEditar.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colEditar.AppearanceHeader.Options.UseFont = true;
            this.colEditar.AppearanceHeader.Options.UseTextOptions = true;
            this.colEditar.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEditar.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colEditar.Caption = "Editar";
            this.colEditar.ColumnEdit = this.repBtnEditar;
            this.colEditar.Name = "colEditar";
            this.colEditar.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.colEditar.Visible = true;
            this.colEditar.VisibleIndex = 0;
            // 
            // repBtnEditar
            // 
            this.repBtnEditar.AutoHeight = false;
            editorButtonImageOptions2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("editorButtonImageOptions2.SvgImage")));
            editorButtonImageOptions2.SvgImageSize = new System.Drawing.Size(20, 20);
            this.repBtnEditar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Editar", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repBtnEditar.Name = "repBtnEditar";
            this.repBtnEditar.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repBtnEditar.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repBtnEditar_ButtonClick);
            // 
            // windowsUIButtonPanel1
            // 
            this.windowsUIButtonPanel1.BackColor = System.Drawing.Color.Transparent;
            windowsUIButtonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions1.SvgImage")));
            windowsUIButtonImageOptions1.SvgImageSize = new System.Drawing.Size(25, 25);
            windowsUIButtonImageOptions2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions2.SvgImage")));
            windowsUIButtonImageOptions2.SvgImageSize = new System.Drawing.Size(22, 22);
            this.windowsUIButtonPanel1.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Consultar", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, "Ver", -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Agregar", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, "Add", -1, false)});
            this.windowsUIButtonPanel1.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.windowsUIButtonPanel1.Location = new System.Drawing.Point(34, 59);
            this.windowsUIButtonPanel1.Name = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel1.Size = new System.Drawing.Size(768, 55);
            this.windowsUIButtonPanel1.TabIndex = 4;
            this.windowsUIButtonPanel1.Text = "Panel";
            this.windowsUIButtonPanel1.WrapButtons = true;
            this.windowsUIButtonPanel1.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.windowsUIButtonPanel1_ButtonClick);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20);
            this.layoutControlGroup1.Size = new System.Drawing.Size(836, 541);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(796, 501);
            this.layoutControlGroup2.Text = "Perfiles de Sistema";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.windowsUIButtonPanel1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.layoutControlItem1.Size = new System.Drawing.Size(772, 67);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grdDatos;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 67);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(772, 385);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // ucListaPerfilesSistema
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "ucListaPerfilesSistema";
            this.Size = new System.Drawing.Size(836, 541);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvdatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repBtnEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repBtnEditar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraGrid.GridControl grdDatos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvdatos;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colPcHost;
        private DevExpress.XtraGrid.Columns.GridColumn colUsuarioCreo;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaCreo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colEliminar;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repBtnEliminar;
        private DevExpress.XtraGrid.Columns.GridColumn colEditar;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repBtnEditar;
    }
}
