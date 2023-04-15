namespace mk_management.hotspot
{
    partial class ucDashBoard
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement8 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement9 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement10 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement11 = new DevExpress.XtraEditors.TileItemElement();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdConexiones = new DevExpress.XtraGrid.GridControl();
            this.gvConexiones = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltiempoAct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEnviado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecibido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chart_uso_megas = new DevExpress.XtraCharts.ChartControl();
            this.lbCantConexiones = new DevExpress.XtraEditors.LabelControl();
            this.tileBar1 = new DevExpress.XtraBars.Navigation.TileBar();
            this.tlBar = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.tlBarItem_CPU = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tlBarItem_Memoria = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tlBarItem_Disco = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tlBarItem_Tiempo = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tlBarItem_Usuarios = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tlBarItem_InfoDev = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.lbError = new DevExpress.XtraEditors.LabelControl();
            this.tlConexiones = new DevExpress.XtraBars.Navigation.TileBar();
            this.tlBarGrupoConexiones = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbTitulo = new DevExpress.XtraEditors.LabelControl();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdConexiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConexiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_uso_megas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.panel4);
            this.groupControl1.Controls.Add(this.tileBar1);
            this.groupControl1.Controls.Add(this.lbError);
            this.groupControl1.Location = new System.Drawing.Point(20, 158);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1201, 427);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Tablero Informativo";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.panel4.Controls.Add(this.splitContainerControl1);
            this.panel4.Controls.Add(this.lbCantConexiones);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(2, 154);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1197, 243);
            this.panel4.TabIndex = 4;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl1.Location = new System.Drawing.Point(12, 34);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grdConexiones);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.chart_uso_megas);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            //this.splitContainerControl1.spli = DevExpress.Utils.DefaultBoolean.False;
            this.splitContainerControl1.Size = new System.Drawing.Size(1182, 203);
            this.splitContainerControl1.SplitterPosition = 557;
            this.splitContainerControl1.TabIndex = 4;
            // 
            // grdConexiones
            // 
            this.grdConexiones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdConexiones.Location = new System.Drawing.Point(0, 0);
            this.grdConexiones.MainView = this.gvConexiones;
            this.grdConexiones.Name = "grdConexiones";
            this.grdConexiones.Padding = new System.Windows.Forms.Padding(10);
            this.grdConexiones.Size = new System.Drawing.Size(557, 203);
            this.grdConexiones.TabIndex = 2;
            this.grdConexiones.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvConexiones});
            // 
            // gvConexiones
            // 
            this.gvConexiones.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.gvConexiones.Appearance.Row.Options.UseFont = true;
            this.gvConexiones.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNum,
            this.colUser,
            this.colIP,
            this.coltiempoAct,
            this.colEnviado,
            this.colRecibido});
            this.gvConexiones.GridControl = this.grdConexiones;
            this.gvConexiones.Name = "gvConexiones";
            this.gvConexiones.OptionsView.ColumnAutoWidth = false;
            this.gvConexiones.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gvConexiones.OptionsView.ShowGroupPanel = false;
            this.gvConexiones.OptionsView.ShowIndicator = false;
            // 
            // colNum
            // 
            this.colNum.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNum.AppearanceHeader.Options.UseFont = true;
            this.colNum.AppearanceHeader.Options.UseTextOptions = true;
            this.colNum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNum.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNum.Caption = "#";
            this.colNum.FieldName = "#";
            this.colNum.Name = "colNum";
            this.colNum.OptionsColumn.ReadOnly = true;
            this.colNum.Width = 81;
            // 
            // colUser
            // 
            this.colUser.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colUser.AppearanceHeader.Options.UseFont = true;
            this.colUser.AppearanceHeader.Options.UseTextOptions = true;
            this.colUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUser.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colUser.Caption = "Usuario";
            this.colUser.FieldName = "user";
            this.colUser.Name = "colUser";
            this.colUser.OptionsColumn.ReadOnly = true;
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 0;
            this.colUser.Width = 120;
            // 
            // colIP
            // 
            this.colIP.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colIP.AppearanceHeader.Options.UseFont = true;
            this.colIP.AppearanceHeader.Options.UseTextOptions = true;
            this.colIP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIP.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colIP.Caption = "IP";
            this.colIP.FieldName = "address";
            this.colIP.Name = "colIP";
            this.colIP.OptionsColumn.ReadOnly = true;
            this.colIP.Visible = true;
            this.colIP.VisibleIndex = 1;
            this.colIP.Width = 119;
            // 
            // coltiempoAct
            // 
            this.coltiempoAct.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.coltiempoAct.AppearanceHeader.Options.UseFont = true;
            this.coltiempoAct.AppearanceHeader.Options.UseTextOptions = true;
            this.coltiempoAct.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coltiempoAct.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.coltiempoAct.Caption = "Tiempo Act.";
            this.coltiempoAct.FieldName = "uptime";
            this.coltiempoAct.Name = "coltiempoAct";
            this.coltiempoAct.OptionsColumn.ReadOnly = true;
            this.coltiempoAct.Visible = true;
            this.coltiempoAct.VisibleIndex = 2;
            this.coltiempoAct.Width = 116;
            // 
            // colEnviado
            // 
            this.colEnviado.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colEnviado.AppearanceHeader.Options.UseFont = true;
            this.colEnviado.AppearanceHeader.Options.UseTextOptions = true;
            this.colEnviado.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEnviado.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colEnviado.Caption = "Mb Enviados";
            this.colEnviado.FieldName = "bytes_in";
            this.colEnviado.Name = "colEnviado";
            this.colEnviado.OptionsColumn.ReadOnly = true;
            this.colEnviado.Visible = true;
            this.colEnviado.VisibleIndex = 3;
            this.colEnviado.Width = 84;
            // 
            // colRecibido
            // 
            this.colRecibido.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colRecibido.AppearanceHeader.Options.UseFont = true;
            this.colRecibido.AppearanceHeader.Options.UseTextOptions = true;
            this.colRecibido.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRecibido.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRecibido.Caption = "Mb Recibidos";
            this.colRecibido.FieldName = "bytes_out";
            this.colRecibido.Name = "colRecibido";
            this.colRecibido.OptionsColumn.ReadOnly = true;
            this.colRecibido.Visible = true;
            this.colRecibido.VisibleIndex = 4;
            this.colRecibido.Width = 95;
            // 
            // chart_uso_megas
            // 
            this.chart_uso_megas.BorderOptions.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chart_uso_megas.BorderOptions.Thickness = 5;
            xyDiagram1.AxisX.Title.Text = "Hora";
            xyDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Title.Text = "Megas";
            xyDiagram1.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chart_uso_megas.Diagram = xyDiagram1;
            this.chart_uso_megas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart_uso_megas.Legend.Border.Color = System.Drawing.Color.Black;
            this.chart_uso_megas.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.chart_uso_megas.Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBoxAndMarker;
            this.chart_uso_megas.Legend.MarkerSize = new System.Drawing.Size(10, 10);
            this.chart_uso_megas.Legend.Name = "Default Legend";
            this.chart_uso_megas.Legend.Title.Text = "Usuarios";
            this.chart_uso_megas.Legend.Title.Visible = true;
            this.chart_uso_megas.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.chart_uso_megas.Location = new System.Drawing.Point(0, 0);
            this.chart_uso_megas.Name = "chart_uso_megas";
            series1.Name = "Series 1";
            lineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.View = lineSeriesView1;
            series2.Name = "Series 2";
            series2.View = lineSeriesView2;
            this.chart_uso_megas.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.chart_uso_megas.Size = new System.Drawing.Size(615, 203);
            this.chart_uso_megas.TabIndex = 3;
            // 
            // lbCantConexiones
            // 
            this.lbCantConexiones.Appearance.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lbCantConexiones.Appearance.ForeColor = System.Drawing.Color.White;
            this.lbCantConexiones.Appearance.Options.UseFont = true;
            this.lbCantConexiones.Appearance.Options.UseForeColor = true;
            this.lbCantConexiones.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbCantConexiones.Location = new System.Drawing.Point(0, 0);
            this.lbCantConexiones.Name = "lbCantConexiones";
            this.lbCantConexiones.Size = new System.Drawing.Size(190, 28);
            this.lbCantConexiones.TabIndex = 1;
            this.lbCantConexiones.Text = "  Usuarios conectados";
            // 
            // tileBar1
            // 
            this.tileBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileBar1.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileBar1.Groups.Add(this.tlBar);
            this.tileBar1.GroupTextToItemsIndent = 0;
            this.tileBar1.ItemSize = 80;
            this.tileBar1.Location = new System.Drawing.Point(2, 23);
            this.tileBar1.MaxId = 6;
            this.tileBar1.Name = "tileBar1";
            this.tileBar1.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.tileBar1.SelectionColor = System.Drawing.Color.DarkGreen;
            this.tileBar1.Size = new System.Drawing.Size(1197, 131);
            this.tileBar1.TabIndex = 6;
            this.tileBar1.Text = "Tablero";
            this.tileBar1.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tileBar1.WideTileWidth = 192;
            // 
            // tlBar
            // 
            this.tlBar.Items.Add(this.tlBarItem_CPU);
            this.tlBar.Items.Add(this.tlBarItem_Memoria);
            this.tlBar.Items.Add(this.tlBarItem_Disco);
            this.tlBar.Items.Add(this.tlBarItem_Tiempo);
            this.tlBar.Items.Add(this.tlBarItem_Usuarios);
            this.tlBar.Items.Add(this.tlBarItem_InfoDev);
            this.tlBar.Name = "tlBar";
            // 
            // tlBarItem_CPU
            // 
            this.tlBarItem_CPU.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(244)))));
            this.tlBarItem_CPU.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.tlBarItem_CPU.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tlBarItem_CPU.AppearanceItem.Normal.Options.UseFont = true;
            this.tlBarItem_CPU.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement1.Text = "3%";
            tileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            tileItemElement2.Text = "Tráfico CPU";
            tileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tlBarItem_CPU.Elements.Add(tileItemElement1);
            this.tlBarItem_CPU.Elements.Add(tileItemElement2);
            this.tlBarItem_CPU.Id = 0;
            this.tlBarItem_CPU.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tlBarItem_CPU.Name = "tlBarItem_CPU";
            // 
            // tlBarItem_Memoria
            // 
            this.tlBarItem_Memoria.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.tlBarItem_Memoria.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.tlBarItem_Memoria.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tlBarItem_Memoria.AppearanceItem.Normal.Options.UseFont = true;
            this.tlBarItem_Memoria.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement3.Text = "8.5 mb";
            tileItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            tileItemElement4.Text = "Memoria Libre";
            tileItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tlBarItem_Memoria.Elements.Add(tileItemElement3);
            this.tlBarItem_Memoria.Elements.Add(tileItemElement4);
            this.tlBarItem_Memoria.Id = 1;
            this.tlBarItem_Memoria.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tlBarItem_Memoria.Name = "tlBarItem_Memoria";
            // 
            // tlBarItem_Disco
            // 
            this.tlBarItem_Disco.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.tlBarItem_Disco.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.tlBarItem_Disco.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tlBarItem_Disco.AppearanceItem.Normal.Options.UseFont = true;
            this.tlBarItem_Disco.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement5.Text = "80.6 mb";
            tileItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            tileItemElement6.Text = "Almacenamiento";
            tileItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tlBarItem_Disco.Elements.Add(tileItemElement5);
            this.tlBarItem_Disco.Elements.Add(tileItemElement6);
            this.tlBarItem_Disco.Id = 2;
            this.tlBarItem_Disco.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tlBarItem_Disco.Name = "tlBarItem_Disco";
            // 
            // tlBarItem_Tiempo
            // 
            this.tlBarItem_Tiempo.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.tlBarItem_Tiempo.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.tlBarItem_Tiempo.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tlBarItem_Tiempo.AppearanceItem.Normal.Options.UseFont = true;
            this.tlBarItem_Tiempo.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement7.Text = "5d 4m 3s";
            tileItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            tileItemElement8.Text = "Tiempo Actividad";
            tileItemElement8.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tlBarItem_Tiempo.Elements.Add(tileItemElement7);
            this.tlBarItem_Tiempo.Elements.Add(tileItemElement8);
            this.tlBarItem_Tiempo.Id = 3;
            this.tlBarItem_Tiempo.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tlBarItem_Tiempo.Name = "tlBarItem_Tiempo";
            // 
            // tlBarItem_Usuarios
            // 
            this.tlBarItem_Usuarios.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.tlBarItem_Usuarios.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.tlBarItem_Usuarios.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tlBarItem_Usuarios.AppearanceItem.Normal.Options.UseFont = true;
            this.tlBarItem_Usuarios.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement9.Text = "5";
            tileItemElement9.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            tileItemElement10.Text = "Total Usuarios";
            tileItemElement10.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tlBarItem_Usuarios.Elements.Add(tileItemElement9);
            this.tlBarItem_Usuarios.Elements.Add(tileItemElement10);
            this.tlBarItem_Usuarios.Id = 4;
            this.tlBarItem_Usuarios.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tlBarItem_Usuarios.Name = "tlBarItem_Usuarios";
            // 
            // tlBarItem_InfoDev
            // 
            this.tlBarItem_InfoDev.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(244)))));
            this.tlBarItem_InfoDev.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tlBarItem_InfoDev.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement11.ImageOptions.Image = global::mk_management.hotspot.Properties.Resources.chip;
            tileItemElement11.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileItemElement11.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement11.Text = "Info. Dispositivo";
            tileItemElement11.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tlBarItem_InfoDev.Elements.Add(tileItemElement11);
            this.tlBarItem_InfoDev.Id = 5;
            this.tlBarItem_InfoDev.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tlBarItem_InfoDev.Name = "tlBarItem_InfoDev";
            this.tlBarItem_InfoDev.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tlBarItem_InfoDev_ItemClick);
            // 
            // lbError
            // 
            this.lbError.Appearance.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lbError.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbError.Appearance.Options.UseFont = true;
            this.lbError.Appearance.Options.UseForeColor = true;
            this.lbError.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbError.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbError.Location = new System.Drawing.Point(2, 397);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(1197, 28);
            this.lbError.TabIndex = 2;
            this.lbError.Text = "Trafico CPU";
            // 
            // tlConexiones
            // 
            this.tlConexiones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlConexiones.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tlConexiones.Groups.Add(this.tlBarGrupoConexiones);
            this.tlConexiones.Location = new System.Drawing.Point(20, 29);
            this.tlConexiones.MaxId = 5;
            this.tlConexiones.Name = "tlConexiones";
            this.tlConexiones.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.tlConexiones.ShowGroupText = false;
            this.tlConexiones.Size = new System.Drawing.Size(1198, 123);
            this.tlConexiones.TabIndex = 8;
            this.tlConexiones.Text = "Dispositivos";
            // 
            // tlBarGrupoConexiones
            // 
            this.tlBarGrupoConexiones.Name = "tlBarGrupoConexiones";
            this.tlBarGrupoConexiones.Text = "Dispositivo:";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbTitulo
            // 
            this.lbTitulo.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbTitulo.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbTitulo.Appearance.Options.UseFont = true;
            this.lbTitulo.Appearance.Options.UseForeColor = true;
            this.lbTitulo.Location = new System.Drawing.Point(23, 5);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(137, 21);
            this.lbTitulo.TabIndex = 9;
            this.lbTitulo.Text = "Tablero Informativo";
            // 
            // ucDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.tlConexiones);
            this.Controls.Add(this.groupControl1);
            this.Name = "ucDashBoard";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Size = new System.Drawing.Size(1241, 593);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdConexiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConexiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_uso_megas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.LabelControl lbCantConexiones;
        private DevExpress.XtraBars.Navigation.TileBar tlConexiones;
        private DevExpress.XtraBars.Navigation.TileBarGroup tlBarGrupoConexiones;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.LabelControl lbError;
        private DevExpress.XtraGrid.GridControl grdConexiones;
        private DevExpress.XtraGrid.Views.Grid.GridView gvConexiones;
        private DevExpress.XtraGrid.Columns.GridColumn colNum;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colIP;
        private DevExpress.XtraGrid.Columns.GridColumn coltiempoAct;
        private DevExpress.XtraGrid.Columns.GridColumn colEnviado;
        private DevExpress.XtraGrid.Columns.GridColumn colRecibido;
        private DevExpress.XtraEditors.LabelControl lbTitulo;
        private DevExpress.XtraBars.Navigation.TileBar tileBar1;
        private DevExpress.XtraBars.Navigation.TileBarGroup tlBar;
        private DevExpress.XtraBars.Navigation.TileBarItem tlBarItem_CPU;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraBars.Navigation.TileBarItem tlBarItem_Memoria;
        private DevExpress.XtraBars.Navigation.TileBarItem tlBarItem_Disco;
        private DevExpress.XtraBars.Navigation.TileBarItem tlBarItem_Tiempo;
        private DevExpress.XtraBars.Navigation.TileBarItem tlBarItem_Usuarios;
        private DevExpress.XtraBars.Navigation.TileBarItem tlBarItem_InfoDev;
        private DevExpress.XtraCharts.ChartControl chart_uso_megas;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    }
}
