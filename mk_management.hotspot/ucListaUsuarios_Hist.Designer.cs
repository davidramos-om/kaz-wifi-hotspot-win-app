namespace mk_management.hotspot
{
    partial class ucListaUsuarios_Hist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucListaUsuarios_Hist));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.wBtnAgregar = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.grdDatos = new DevExpress.XtraGrid.GridControl();
            this.gvdatos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComentario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTiempo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHP_Perfil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdServer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHP_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPcHost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsuarioCreo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaCreo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDispositivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerfil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTiempoAsignado = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.wBtnAgregar.Text = "Actualizar";
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
            this.colUsuario,
            this.colClave,
            this.colComentario,
            this.colTiempo,
            this.colHP_Perfil,
            this.colIdServer,
            this.colHP_Id,
            this.colPcHost,
            this.colUsuarioCreo,
            this.colFechaCreo,
            this.colDispositivo,
            this.colPerfil,
            this.colTiempoAsignado});
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
            // colUsuario
            // 
            this.colUsuario.Caption = "Usuario";
            this.colUsuario.FieldName = "Usuario";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.OptionsColumn.ReadOnly = true;
            this.colUsuario.Visible = true;
            this.colUsuario.VisibleIndex = 0;
            this.colUsuario.Width = 131;
            // 
            // colClave
            // 
            this.colClave.Caption = "Clave";
            this.colClave.FieldName = "Clave";
            this.colClave.Name = "colClave";
            this.colClave.OptionsColumn.ReadOnly = true;
            this.colClave.Visible = true;
            this.colClave.VisibleIndex = 1;
            this.colClave.Width = 131;
            // 
            // colComentario
            // 
            this.colComentario.Caption = "Comentario";
            this.colComentario.FieldName = "Comentario";
            this.colComentario.Name = "colComentario";
            this.colComentario.OptionsColumn.ReadOnly = true;
            this.colComentario.Visible = true;
            this.colComentario.VisibleIndex = 2;
            this.colComentario.Width = 131;
            // 
            // colTiempo
            // 
            this.colTiempo.Caption = "Tiempo de Conexión";
            this.colTiempo.DisplayFormat.FormatString = "n0";
            this.colTiempo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTiempo.FieldName = "Tiempo";
            this.colTiempo.GroupFormat.FormatString = "n0";
            this.colTiempo.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTiempo.Name = "colTiempo";
            this.colTiempo.OptionsColumn.ReadOnly = true;
            this.colTiempo.Width = 107;
            // 
            // colHP_Perfil
            // 
            this.colHP_Perfil.Caption = "Perfil HotSpot";
            this.colHP_Perfil.FieldName = "HP_Perfil";
            this.colHP_Perfil.Name = "colHP_Perfil";
            this.colHP_Perfil.OptionsColumn.ReadOnly = true;
            this.colHP_Perfil.Width = 103;
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
            this.colPcHost.VisibleIndex = 6;
            this.colPcHost.Width = 125;
            // 
            // colUsuarioCreo
            // 
            this.colUsuarioCreo.Caption = "Creado Por";
            this.colUsuarioCreo.FieldName = "UsuarioCreo";
            this.colUsuarioCreo.Name = "colUsuarioCreo";
            this.colUsuarioCreo.OptionsColumn.ReadOnly = true;
            this.colUsuarioCreo.Visible = true;
            this.colUsuarioCreo.VisibleIndex = 7;
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
            this.colFechaCreo.VisibleIndex = 8;
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
            // colPerfil
            // 
            this.colPerfil.Caption = "Perfil";
            this.colPerfil.FieldName = "Perfil";
            this.colPerfil.Name = "colPerfil";
            this.colPerfil.OptionsColumn.ReadOnly = true;
            this.colPerfil.Visible = true;
            this.colPerfil.VisibleIndex = 5;
            this.colPerfil.Width = 136;
            // 
            // colTiempoAsignado
            // 
            this.colTiempoAsignado.Caption = "Tiempo de Conexión";
            this.colTiempoAsignado.FieldName = "TiempoAsignado";
            this.colTiempoAsignado.Name = "colTiempoAsignado";
            this.colTiempoAsignado.OptionsColumn.ReadOnly = true;
            this.colTiempoAsignado.Visible = true;
            this.colTiempoAsignado.VisibleIndex = 4;
            this.colTiempoAsignado.Width = 107;
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
            this.layoutControlGroup1.Text = "Historial de Usuarios";
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
            // ucListaUsuarios_Hist
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "ucListaUsuarios_Hist";
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
        private DevExpress.XtraGrid.Columns.GridColumn colUsuario;
        private DevExpress.XtraGrid.Columns.GridColumn colTiempo;
        private DevExpress.XtraGrid.Columns.GridColumn colComentario;
        private DevExpress.XtraGrid.Columns.GridColumn colClave;
        private DevExpress.XtraGrid.Columns.GridColumn colHP_Perfil;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch repDisabled;
        private DevExpress.XtraGrid.Columns.GridColumn colIdServer;
        private DevExpress.XtraGrid.Columns.GridColumn colHP_Id;
        private DevExpress.XtraGrid.Columns.GridColumn colPcHost;
        private DevExpress.XtraGrid.Columns.GridColumn colUsuarioCreo;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaCreo;
        private DevExpress.XtraGrid.Columns.GridColumn colDispositivo;
        private DevExpress.XtraGrid.Columns.GridColumn colPerfil;
        private DevExpress.XtraGrid.Columns.GridColumn colTiempoAsignado;
    }
}