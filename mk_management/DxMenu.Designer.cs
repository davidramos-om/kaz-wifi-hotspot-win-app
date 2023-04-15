namespace mk_management
{
    partial class DxMenu
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
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DxMenu));
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem7 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem7 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip8 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem8 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem8 = new DevExpress.Utils.ToolTipItem();
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.actrlMenu = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.acgConfiguracion = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceParametrosApp = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceLicencia = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acePerfilesSistema = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceUsuariosSistema = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceFormatoImpresion = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acgHotSpot = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceDispositivos = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acePerfilesInternet = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceUsuariosInternet = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acgReportes = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceTablero = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acePerfilesActivos = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceUsuariosActivos = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceReporteGenerales = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceHistorialPerfiles = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceHistorialUsuarios = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlSeparator1 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            this.aceInfoApp = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceCerrarSesion = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceAyuda_Setting = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceSalirApp = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.lcInfoSistema = new DevExpress.XtraEditors.LabelControl();
            this.tm_lic_demo_revision = new System.Windows.Forms.Timer(this.components);
            this.tm_router_usage_stats = new System.Windows.Forms.Timer(this.components);
            this.tm_lic_trace_stats = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.actrlMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Appearance.BackColor = System.Drawing.Color.White;
            this.fluentDesignFormContainer1.Appearance.Options.UseBackColor = true;
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(260, 56);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(792, 517);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // actrlMenu
            // 
            this.actrlMenu.AccessibleName = "Kaz WiFi HotSpot";
            this.actrlMenu.Appearance.ItemWithContainer.Normal.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actrlMenu.Appearance.ItemWithContainer.Normal.Options.UseFont = true;
            this.actrlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.actrlMenu.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.acgConfiguracion,
            this.acgHotSpot,
            this.acgReportes,
            this.aceReporteGenerales,
            this.aceInfoApp,
            this.aceCerrarSesion,
            this.aceAyuda_Setting,
            this.aceSalirApp});
            this.actrlMenu.Location = new System.Drawing.Point(0, 31);
            this.actrlMenu.Name = "actrlMenu";
            this.actrlMenu.OptionsMinimizing.AllowFooterResizing = false;
            this.actrlMenu.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.True;
            this.actrlMenu.OptionsMinimizing.NormalWidth = 260;
            //this.actrlMenu.res = DevExpress.XtraBars.Navigation.AccordionControlResizeMode.InnerResizeZone;
            this.actrlMenu.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Auto;
            this.actrlMenu.Size = new System.Drawing.Size(260, 542);
            this.actrlMenu.TabIndex = 2;
            this.actrlMenu.Text = "Buscar";
            this.actrlMenu.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // acgConfiguracion
            // 
            this.acgConfiguracion.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceParametrosApp,
            this.aceLicencia,
            this.acePerfilesSistema,
            this.aceUsuariosSistema,
            this.aceFormatoImpresion});
            this.acgConfiguracion.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("acgConfiguracion.ImageOptions.Image")));
            this.acgConfiguracion.Name = "acgConfiguracion";
            toolTipTitleItem5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem5.Text = "Configuración de la aplicación";
            toolTipItem5.LeftIndent = 6;
            toolTipItem5.Text = "Configuración de usuarios y perfiles del sistema, formatos de impresión y licenci" +
    "as.";
            superToolTip5.Items.Add(toolTipTitleItem5);
            superToolTip5.Items.Add(toolTipItem5);
            this.acgConfiguracion.SuperTip = superToolTip5;
            this.acgConfiguracion.Text = "Configuración";
            // 
            // aceParametrosApp
            // 
            this.aceParametrosApp.HeaderIndent = -5;
            this.aceParametrosApp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceParametrosApp.ImageOptions.Image")));
            this.aceParametrosApp.Name = "aceParametrosApp";
            this.aceParametrosApp.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceParametrosApp.Text = "     Preferencias";
            this.aceParametrosApp.Click += new System.EventHandler(this.aceParametrosApp_Click);
            // 
            // aceLicencia
            // 
            this.aceLicencia.HeaderIndent = -5;
            this.aceLicencia.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceLicencia.ImageOptions.Image")));
            this.aceLicencia.Name = "aceLicencia";
            this.aceLicencia.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceLicencia.Text = "     Licencia";
            this.aceLicencia.Click += new System.EventHandler(this.aceLicencia_Click);
            // 
            // acePerfilesSistema
            // 
            this.acePerfilesSistema.HeaderIndent = -5;
            this.acePerfilesSistema.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("acePerfilesSistema.ImageOptions.Image")));
            this.acePerfilesSistema.Name = "acePerfilesSistema";
            this.acePerfilesSistema.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acePerfilesSistema.Text = "     Perfiles de Sistema";
            this.acePerfilesSistema.Click += new System.EventHandler(this.acePerfilesSistema_Click);
            // 
            // aceUsuariosSistema
            // 
            this.aceUsuariosSistema.HeaderIndent = -5;
            this.aceUsuariosSistema.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceUsuariosSistema.ImageOptions.Image")));
            this.aceUsuariosSistema.Name = "aceUsuariosSistema";
            this.aceUsuariosSistema.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceUsuariosSistema.Text = "     Usuarios de Sistema";
            this.aceUsuariosSistema.Click += new System.EventHandler(this.aceUsuariosSistema_Click);
            // 
            // aceFormatoImpresion
            // 
            this.aceFormatoImpresion.HeaderIndent = -5;
            this.aceFormatoImpresion.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceFormatoImpresion.ImageOptions.Image")));
            this.aceFormatoImpresion.Name = "aceFormatoImpresion";
            this.aceFormatoImpresion.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceFormatoImpresion.Text = "     Formato Impresión";
            this.aceFormatoImpresion.Click += new System.EventHandler(this.aceFormatoImpresion_Click);
            // 
            // acgHotSpot
            // 
            this.acgHotSpot.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceDispositivos,
            this.acePerfilesInternet,
            this.aceUsuariosInternet});
            this.acgHotSpot.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("acgHotSpot.ImageOptions.Image")));
            this.acgHotSpot.Name = "acgHotSpot";
            toolTipTitleItem6.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipTitleItem6.Text = "Conexiones al dispositivos";
            toolTipItem6.LeftIndent = 6;
            toolTipItem6.Text = resources.GetString("toolTipItem6.Text");
            superToolTip6.Items.Add(toolTipTitleItem6);
            superToolTip6.Items.Add(toolTipItem6);
            this.acgHotSpot.SuperTip = superToolTip6;
            this.acgHotSpot.Text = "HotsPot Wifi";
            // 
            // aceDispositivos
            // 
            this.aceDispositivos.HeaderIndent = -5;
            this.aceDispositivos.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceDispositivos.ImageOptions.Image")));
            this.aceDispositivos.Name = "aceDispositivos";
            this.aceDispositivos.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceDispositivos.Text = "     Dispositivos de Red";
            this.aceDispositivos.Click += new System.EventHandler(this.aceDispositivos_Click);
            // 
            // acePerfilesInternet
            // 
            this.acePerfilesInternet.Appearance.Normal.Image = ((System.Drawing.Image)(resources.GetObject("acePerfilesInternet.Appearance.Normal.Image")));
            this.acePerfilesInternet.Appearance.Normal.Options.UseImage = true;
            this.acePerfilesInternet.HeaderIndent = -5;
            this.acePerfilesInternet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("acePerfilesInternet.ImageOptions.Image")));
            this.acePerfilesInternet.Name = "acePerfilesInternet";
            this.acePerfilesInternet.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acePerfilesInternet.Text = "     Crear Perfiles";
            this.acePerfilesInternet.Click += new System.EventHandler(this.acePerfilesHotSpot_Click);
            // 
            // aceUsuariosInternet
            // 
            this.aceUsuariosInternet.Appearance.Normal.Image = ((System.Drawing.Image)(resources.GetObject("aceUsuariosInternet.Appearance.Normal.Image")));
            this.aceUsuariosInternet.Appearance.Normal.Options.UseImage = true;
            this.aceUsuariosInternet.HeaderIndent = -5;
            this.aceUsuariosInternet.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.aceUsuariosInternet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceUsuariosInternet.ImageOptions.Image")));
            this.aceUsuariosInternet.Name = "aceUsuariosInternet";
            this.aceUsuariosInternet.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceUsuariosInternet.Text = "     Crear Usuarios";
            this.aceUsuariosInternet.Click += new System.EventHandler(this.aceUsuariosHotSpot_Click);
            // 
            // acgReportes
            // 
            this.acgReportes.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceTablero,
            this.acePerfilesActivos,
            this.aceUsuariosActivos});
            this.acgReportes.Expanded = true;
            this.acgReportes.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("acgReportes.ImageOptions.Image")));
            this.acgReportes.Name = "acgReportes";
            toolTipTitleItem7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            toolTipTitleItem7.Text = "Reportes en tiempo real";
            toolTipItem7.LeftIndent = 6;
            toolTipItem7.Text = "En esta sección podrá revisar los usuarios, consumo y perfiles del dispositivo en" +
    " tiempo real.";
            superToolTip7.Items.Add(toolTipTitleItem7);
            superToolTip7.Items.Add(toolTipItem7);
            this.acgReportes.SuperTip = superToolTip7;
            this.acgReportes.Text = "Reporteria Dispositivo";
            // 
            // aceTablero
            // 
            this.aceTablero.HeaderIndent = -5;
            this.aceTablero.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceTablero.ImageOptions.Image")));
            this.aceTablero.Name = "aceTablero";
            this.aceTablero.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceTablero.Text = "     Tablero Informativo";
            this.aceTablero.Click += new System.EventHandler(this.aceTablero_Click);
            // 
            // acePerfilesActivos
            // 
            this.acePerfilesActivos.HeaderIndent = -5;
            this.acePerfilesActivos.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("acePerfilesActivos.ImageOptions.Image")));
            this.acePerfilesActivos.Name = "acePerfilesActivos";
            this.acePerfilesActivos.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acePerfilesActivos.Text = "     Perfiles en Dispositivos";
            this.acePerfilesActivos.Click += new System.EventHandler(this.acePerfilesActivos_Click);
            // 
            // aceUsuariosActivos
            // 
            this.aceUsuariosActivos.HeaderIndent = -5;
            this.aceUsuariosActivos.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceUsuariosActivos.ImageOptions.Image")));
            this.aceUsuariosActivos.Name = "aceUsuariosActivos";
            this.aceUsuariosActivos.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceUsuariosActivos.Text = "     Usuarios en Dispositivo";
            this.aceUsuariosActivos.Click += new System.EventHandler(this.aceUsuariosActivosHotSpot_Click);
            // 
            // aceReporteGenerales
            // 
            this.aceReporteGenerales.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceHistorialPerfiles,
            this.aceHistorialUsuarios,
            this.accordionControlSeparator1});
            this.aceReporteGenerales.Expanded = true;
            this.aceReporteGenerales.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceReporteGenerales.ImageOptions.Image")));
            this.aceReporteGenerales.Name = "aceReporteGenerales";
            toolTipTitleItem8.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            toolTipTitleItem8.Text = "Información histórica";
            toolTipItem8.LeftIndent = 6;
            toolTipItem8.Text = "La información creada en todo el tiempo de uso, ya que los dispositivos no almace" +
    "n información por mucho tiempo.";
            superToolTip8.Items.Add(toolTipTitleItem8);
            superToolTip8.Items.Add(toolTipItem8);
            this.aceReporteGenerales.SuperTip = superToolTip8;
            this.aceReporteGenerales.Text = "Reporteria Histórica";
            // 
            // aceHistorialPerfiles
            // 
            this.aceHistorialPerfiles.HeaderIndent = -5;
            this.aceHistorialPerfiles.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceHistorialPerfiles.ImageOptions.Image")));
            this.aceHistorialPerfiles.Name = "aceHistorialPerfiles";
            this.aceHistorialPerfiles.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceHistorialPerfiles.Text = "     Historial de Perfiles";
            this.aceHistorialPerfiles.Click += new System.EventHandler(this.aceHistorialPerfiles_Click);
            // 
            // aceHistorialUsuarios
            // 
            this.aceHistorialUsuarios.HeaderIndent = -5;
            this.aceHistorialUsuarios.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceHistorialUsuarios.ImageOptions.Image")));
            this.aceHistorialUsuarios.Name = "aceHistorialUsuarios";
            this.aceHistorialUsuarios.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceHistorialUsuarios.Text = "     Historial de Usuarios";
            this.aceHistorialUsuarios.Click += new System.EventHandler(this.aceHistorialUsuariosHotSpot_Click);
            // 
            // accordionControlSeparator1
            // 
            this.accordionControlSeparator1.Name = "accordionControlSeparator1";
            // 
            // aceInfoApp
            // 
            this.aceInfoApp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceInfoApp.ImageOptions.Image")));
            this.aceInfoApp.Name = "aceInfoApp";
            this.aceInfoApp.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceInfoApp.Text = "Acerca";
            this.aceInfoApp.Click += new System.EventHandler(this.aceInfoApp_Click);
            // 
            // aceCerrarSesion
            // 
            this.aceCerrarSesion.Appearance.Disabled.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.aceCerrarSesion.Appearance.Disabled.Options.UseFont = true;
            this.aceCerrarSesion.Appearance.Hovered.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.aceCerrarSesion.Appearance.Hovered.Options.UseFont = true;
            this.aceCerrarSesion.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.aceCerrarSesion.Appearance.Normal.Image = ((System.Drawing.Image)(resources.GetObject("aceCerrarSesion.Appearance.Normal.Image")));
            this.aceCerrarSesion.Appearance.Normal.Options.UseFont = true;
            this.aceCerrarSesion.Appearance.Normal.Options.UseImage = true;
            this.aceCerrarSesion.Appearance.Pressed.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.aceCerrarSesion.Appearance.Pressed.Options.UseFont = true;
            this.aceCerrarSesion.Expanded = true;
            this.aceCerrarSesion.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceCerrarSesion.ImageOptions.Image")));
            this.aceCerrarSesion.Name = "aceCerrarSesion";
            this.aceCerrarSesion.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceCerrarSesion.Text = "Cerrar Sesión";
            this.aceCerrarSesion.Click += new System.EventHandler(this.aceCerrarSesion_Click);
            // 
            // aceAyuda_Setting
            // 
            this.aceAyuda_Setting.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceAyuda_Setting.ImageOptions.Image")));
            this.aceAyuda_Setting.Name = "aceAyuda_Setting";
            this.aceAyuda_Setting.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceAyuda_Setting.Text = "Mejoras";
            this.aceAyuda_Setting.Click += new System.EventHandler(this.aceAyuda_Setting_Click);
            // 
            // aceSalirApp
            // 
            this.aceSalirApp.Appearance.Disabled.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.aceSalirApp.Appearance.Disabled.Options.UseFont = true;
            this.aceSalirApp.Appearance.Hovered.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.aceSalirApp.Appearance.Hovered.Options.UseFont = true;
            this.aceSalirApp.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.aceSalirApp.Appearance.Normal.Image = ((System.Drawing.Image)(resources.GetObject("aceSalirApp.Appearance.Normal.Image")));
            this.aceSalirApp.Appearance.Normal.Options.UseFont = true;
            this.aceSalirApp.Appearance.Normal.Options.UseImage = true;
            this.aceSalirApp.Appearance.Pressed.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.aceSalirApp.Appearance.Pressed.Options.UseFont = true;
            this.aceSalirApp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceSalirApp.ImageOptions.Image")));
            this.aceSalirApp.Name = "aceSalirApp";
            this.aceSalirApp.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceSalirApp.Text = "Salir";
            this.aceSalirApp.Click += new System.EventHandler(this.aceSalirApp_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1052, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.Text = "Kaz | Hotspot Wifi";
            // 
            // lcInfoSistema
            // 
            this.lcInfoSistema.Appearance.BackColor = System.Drawing.Color.White;
            this.lcInfoSistema.Appearance.BorderColor = System.Drawing.Color.LightGray;
            this.lcInfoSistema.Appearance.Options.UseBackColor = true;
            this.lcInfoSistema.Appearance.Options.UseBorderColor = true;
            this.lcInfoSistema.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcInfoSistema.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lcInfoSistema.Dock = System.Windows.Forms.DockStyle.Top;
            this.lcInfoSistema.Location = new System.Drawing.Point(260, 31);
            this.lcInfoSistema.Name = "lcInfoSistema";
            this.lcInfoSistema.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lcInfoSistema.Size = new System.Drawing.Size(792, 25);
            this.lcInfoSistema.TabIndex = 3;
            this.lcInfoSistema.Text = "Información de la aplicación";
            this.lcInfoSistema.Click += new System.EventHandler(this.lcInfoSistema_Click);
            // 
            // tm_lic_demo_revision
            // 
            this.tm_lic_demo_revision.Interval = 5000;
            this.tm_lic_demo_revision.Tick += new System.EventHandler(this.tm_lic_demo_revision_Tick);
            // 
            // tm_router_usage_stats
            // 
            this.tm_router_usage_stats.Interval = 600000;
            this.tm_router_usage_stats.Tick += new System.EventHandler(this.tm_router_usage_stats_Tick);
            // 
            // tm_lic_trace_stats
            // 
            this.tm_lic_trace_stats.Interval = 600000;
            this.tm_lic_trace_stats.Tick += new System.EventHandler(this.tm_lic_trace_stats_Tick);
            // 
            // DxMenu
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 573);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.lcInfoSistema);
            this.Controls.Add(this.actrlMenu);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            //this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("DxMenu.IconOptions.Icon")));
            //this.IconOptions.Image = global::mk_management.Properties.Resources.logo_icon;
            //this.IconOptions.LargeImage = global::mk_management.Properties.Resources.logo_icon;
            this.Name = "DxMenu";
            this.NavigationControl = this.actrlMenu;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kaz WiFi HotSpot";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DxMenu_Load);
            this.Shown += new System.EventHandler(this.DxMenu_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.actrlMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acgConfiguracion;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceDispositivos;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acgHotSpot;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acePerfilesInternet;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceUsuariosInternet;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acgReportes;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceTablero;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceUsuariosActivos;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceHistorialUsuarios;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acePerfilesSistema;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceUsuariosSistema;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceFormatoImpresion;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceHistorialPerfiles;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acePerfilesActivos;
        public DevExpress.XtraBars.Navigation.AccordionControl actrlMenu;
        public DevExpress.XtraBars.Navigation.AccordionControlElement aceCerrarSesion;
        public DevExpress.XtraBars.Navigation.AccordionControlElement aceSalirApp;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceReporteGenerales;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraEditors.LabelControl lcInfoSistema;
        private System.Windows.Forms.Timer tm_lic_demo_revision;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceParametrosApp;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceLicencia;
        private System.Windows.Forms.Timer tm_router_usage_stats;
        private System.Windows.Forms.Timer tm_lic_trace_stats;
        public DevExpress.XtraBars.Navigation.AccordionControlElement aceInfoApp;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceAyuda_Setting;
    }
}