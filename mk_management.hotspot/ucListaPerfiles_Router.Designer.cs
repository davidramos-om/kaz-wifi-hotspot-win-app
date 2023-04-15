namespace mk_management.hotspot
{
    partial class ucListaPerfiles_Router
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.tlConexiones = new DevExpress.XtraBars.Navigation.TileBar();
            this.tlBarGrupoConexiones = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.grdDatos = new DevExpress.XtraGrid.GridControl();
            this.gvdatos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_idle_timeout = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_keepalive_timeout = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_status_auto_refresh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_shared_users = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_add_mac_cookie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_mac_cookie_timeout = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_address_list = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_transparent_proxy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repDisabled = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.col_default = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_rate_limit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_open_status_page = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_advertise = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvdatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDisabled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.tlConexiones);
            this.dataLayoutControl1.Controls.Add(this.grdDatos);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(825, 465);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // tlConexiones
            // 
            this.tlConexiones.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tlConexiones.Groups.Add(this.tlBarGrupoConexiones);
            this.tlConexiones.Location = new System.Drawing.Point(34, 79);
            this.tlConexiones.MaxId = 5;
            this.tlConexiones.Name = "tlConexiones";
            this.tlConexiones.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.tlConexiones.ShowGroupText = false;
            this.tlConexiones.Size = new System.Drawing.Size(757, 103);
            this.tlConexiones.TabIndex = 6;
            this.tlConexiones.Text = "Dispositivos";
            // 
            // tlBarGrupoConexiones
            // 
            this.tlBarGrupoConexiones.Name = "tlBarGrupoConexiones";
            this.tlBarGrupoConexiones.Text = "Dispositivo:";
            // 
            // grdDatos
            // 
            this.grdDatos.Location = new System.Drawing.Point(46, 219);
            this.grdDatos.MainView = this.gvdatos;
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repDisabled});
            this.grdDatos.Size = new System.Drawing.Size(733, 200);
            this.grdDatos.TabIndex = 4;
            this.grdDatos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvdatos});
            // 
            // gvdatos
            // 
            this.gvdatos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_id,
            this.col_name,
            this.col_idle_timeout,
            this.col_keepalive_timeout,
            this.col_status_auto_refresh,
            this.col_shared_users,
            this.col_add_mac_cookie,
            this.col_mac_cookie_timeout,
            this.col_address_list,
            this.col_transparent_proxy,
            this.col_default,
            this.col_rate_limit,
            this.col_open_status_page,
            this.col_advertise});
            this.gvdatos.GridControl = this.grdDatos;
            this.gvdatos.GroupPanelText = "Arrastre una columna aquí para agrupar";
            this.gvdatos.Name = "gvdatos";
            this.gvdatos.OptionsView.ShowAutoFilterRow = true;
            // 
            // col_id
            // 
            this.col_id.Caption = "Id";
            this.col_id.FieldName = ".id";
            this.col_id.Name = "col_id";
            this.col_id.OptionsColumn.ReadOnly = true;
            // 
            // col_name
            // 
            this.col_name.Caption = "Perfil";
            this.col_name.FieldName = "name";
            this.col_name.Name = "col_name";
            this.col_name.OptionsColumn.ReadOnly = true;
            this.col_name.Visible = true;
            this.col_name.VisibleIndex = 0;
            // 
            // col_idle_timeout
            // 
            this.col_idle_timeout.Caption = "Tiempo de inactividad";
            this.col_idle_timeout.FieldName = "idle_timeout";
            this.col_idle_timeout.Name = "col_idle_timeout";
            this.col_idle_timeout.OptionsColumn.ReadOnly = true;
            this.col_idle_timeout.Visible = true;
            this.col_idle_timeout.VisibleIndex = 5;
            // 
            // col_keepalive_timeout
            // 
            this.col_keepalive_timeout.Caption = "Tiempo de espera";
            this.col_keepalive_timeout.FieldName = "keepalive_timeout";
            this.col_keepalive_timeout.Name = "col_keepalive_timeout";
            this.col_keepalive_timeout.OptionsColumn.ReadOnly = true;
            this.col_keepalive_timeout.Visible = true;
            this.col_keepalive_timeout.VisibleIndex = 3;
            // 
            // col_status_auto_refresh
            // 
            this.col_status_auto_refresh.Caption = "Autorefrescar";
            this.col_status_auto_refresh.FieldName = "status_auto_refresh";
            this.col_status_auto_refresh.Name = "col_status_auto_refresh";
            this.col_status_auto_refresh.OptionsColumn.ReadOnly = true;
            this.col_status_auto_refresh.Visible = true;
            this.col_status_auto_refresh.VisibleIndex = 4;
            // 
            // col_shared_users
            // 
            this.col_shared_users.Caption = "Usuarios compartidos";
            this.col_shared_users.FieldName = "shared_users";
            this.col_shared_users.Name = "col_shared_users";
            this.col_shared_users.OptionsColumn.ReadOnly = true;
            this.col_shared_users.Visible = true;
            this.col_shared_users.VisibleIndex = 6;
            // 
            // col_add_mac_cookie
            // 
            this.col_add_mac_cookie.Caption = "Agregar mac cookie";
            this.col_add_mac_cookie.FieldName = "add_mac_cookie";
            this.col_add_mac_cookie.Name = "col_add_mac_cookie";
            this.col_add_mac_cookie.OptionsColumn.ReadOnly = true;
            this.col_add_mac_cookie.Visible = true;
            this.col_add_mac_cookie.VisibleIndex = 11;
            // 
            // col_mac_cookie_timeout
            // 
            this.col_mac_cookie_timeout.Caption = "Tiempo venc. Mac cookie";
            this.col_mac_cookie_timeout.FieldName = "mac_cookie_timeout";
            this.col_mac_cookie_timeout.Name = "col_mac_cookie_timeout";
            this.col_mac_cookie_timeout.OptionsColumn.ReadOnly = true;
            this.col_mac_cookie_timeout.Visible = true;
            this.col_mac_cookie_timeout.VisibleIndex = 7;
            // 
            // col_address_list
            // 
            this.col_address_list.Caption = "Lista Direcciones";
            this.col_address_list.FieldName = "address_list";
            this.col_address_list.Name = "col_address_list";
            this.col_address_list.OptionsColumn.ReadOnly = true;
            this.col_address_list.Visible = true;
            this.col_address_list.VisibleIndex = 10;
            // 
            // col_transparent_proxy
            // 
            this.col_transparent_proxy.Caption = "Proxy transparente";
            this.col_transparent_proxy.ColumnEdit = this.repDisabled;
            this.col_transparent_proxy.FieldName = "transparent_proxy";
            this.col_transparent_proxy.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.col_transparent_proxy.Name = "col_transparent_proxy";
            this.col_transparent_proxy.OptionsColumn.ReadOnly = true;
            this.col_transparent_proxy.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
            this.col_transparent_proxy.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.col_transparent_proxy.Visible = true;
            this.col_transparent_proxy.VisibleIndex = 9;
            // 
            // repDisabled
            // 
            this.repDisabled.AutoHeight = false;
            this.repDisabled.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.repDisabled.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repDisabled.Name = "repDisabled";
            this.repDisabled.OffText = "No";
            this.repDisabled.OnText = "Si";
            this.repDisabled.ReadOnly = true;
            this.repDisabled.ValueOff = "false";
            this.repDisabled.ValueOn = "true";
            // 
            // col_default
            // 
            this.col_default.Caption = "Predeterminado";
            this.col_default.ColumnEdit = this.repDisabled;
            this.col_default.FieldName = "default";
            this.col_default.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.col_default.Name = "col_default";
            this.col_default.OptionsColumn.ReadOnly = true;
            this.col_default.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
            this.col_default.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.col_default.Visible = true;
            this.col_default.VisibleIndex = 1;
            // 
            // col_rate_limit
            // 
            this.col_rate_limit.Caption = "Límite de tasa";
            this.col_rate_limit.FieldName = "rate_limit";
            this.col_rate_limit.Name = "col_rate_limit";
            this.col_rate_limit.OptionsColumn.ReadOnly = true;
            this.col_rate_limit.Visible = true;
            this.col_rate_limit.VisibleIndex = 2;
            // 
            // col_open_status_page
            // 
            this.col_open_status_page.Caption = "Abrir pág. estado";
            this.col_open_status_page.FieldName = "open_status_page";
            this.col_open_status_page.Name = "col_open_status_page";
            this.col_open_status_page.Visible = true;
            this.col_open_status_page.VisibleIndex = 8;
            // 
            // col_advertise
            // 
            this.col_advertise.Caption = "Anuncios";
            this.col_advertise.ColumnEdit = this.repDisabled;
            this.col_advertise.FieldName = "adversise";
            this.col_advertise.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.col_advertise.Name = "col_advertise";
            this.col_advertise.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
            this.col_advertise.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.col_advertise.Visible = true;
            this.col_advertise.VisibleIndex = 12;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20);
            this.Root.Size = new System.Drawing.Size(825, 465);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlGroup1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(785, 425);
            this.layoutControlGroup2.Text = "Perfiles registrados en los dispositivos";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.tlConexiones;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 131);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(104, 131);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(761, 131);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Dispositivos";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(84, 21);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 131);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(761, 249);
            this.layoutControlGroup1.Text = "Perfiles Activos";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdDatos;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(737, 204);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ucListaPerfiles_Router
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "ucListaPerfiles_Router";
            this.Size = new System.Drawing.Size(825, 465);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvdatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDisabled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl grdDatos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvdatos;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.Columns.GridColumn col_id;
        private DevExpress.XtraGrid.Columns.GridColumn col_name;
        private DevExpress.XtraGrid.Columns.GridColumn col_keepalive_timeout;
        private DevExpress.XtraGrid.Columns.GridColumn col_idle_timeout;
        private DevExpress.XtraGrid.Columns.GridColumn col_status_auto_refresh;
        private DevExpress.XtraGrid.Columns.GridColumn col_shared_users;
        private DevExpress.XtraGrid.Columns.GridColumn col_add_mac_cookie;
        private DevExpress.XtraGrid.Columns.GridColumn col_mac_cookie_timeout;
        private DevExpress.XtraGrid.Columns.GridColumn col_address_list;
        private DevExpress.XtraGrid.Columns.GridColumn col_transparent_proxy;
        private DevExpress.XtraGrid.Columns.GridColumn col_default;
        private DevExpress.XtraGrid.Columns.GridColumn col_rate_limit;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch repDisabled;
        private DevExpress.XtraBars.Navigation.TileBar tlConexiones;
        private DevExpress.XtraBars.Navigation.TileBarGroup tlBarGrupoConexiones;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraGrid.Columns.GridColumn col_open_status_page;
        private DevExpress.XtraGrid.Columns.GridColumn col_advertise;
    }
}