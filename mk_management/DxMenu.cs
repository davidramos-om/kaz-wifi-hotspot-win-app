using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace mk_management
{
    public partial class DxMenu : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public DxMenu()
        {
            InitializeComponent();
            this.Icon = common.Utilerias.ObtenerIconoApp();
            actrlMenu.UseDirectXPaint = DevExpress.Utils.DefaultBoolean.False;

            //DevExpress.XtraBars.Localization.BarString.AccordionControlSearchBoxPromptText = "Buscar";
            //DevExpress.XtraBars.Localization.BarString.AccordionControlSearchBoxPromptText=DevExpress.XtraBars.Localization.BarString.
            //DevExpress.XtraBars.Localization.BarString = DevExpress.XtraBars.Localization.BarString.AccordionControlSearchBoxPromptText;

            var controles = actrlMenu.Controls;
            foreach (var c in controles)
            {
                if (c.GetType() == typeof(DevExpress.XtraEditors.SearchControl))
                {
                    var s = c as DevExpress.XtraEditors.SearchControl;
                    s.Text = "Buscar";
                }
            }

            lcInfoSistema.Visible = false;

            actrlMenu.Text = "Buscar";

            OcultarMenu();
            this.Refresh();

            tm_lic_demo_revision.Interval = mToms(30);//30
            tm_lic_demo_revision.Start();

            tm_router_usage_stats.Interval = mToms(5);//5
            tm_router_usage_stats.Start();

            tm_lic_trace_stats.Interval = mToms(35); //35
            tm_lic_trace_stats.Start();

        }

        int mToms(int min)
        {
            return min * 60000;
        }


        private void DxMenu_Load(object sender, EventArgs e)
        {
            tm_lic_demo_revision_Tick(null, null);
            tm_router_usage_stats_Tick(null, null);
        }

        private void Destroy()
        {
            while (fluentDesignFormContainer1.Controls.Count > 0)
            {
                var c = fluentDesignFormContainer1.Controls[0];

                if (c.GetType().BaseType == typeof(DevExpress.XtraEditors.XtraUserControl))
                {
                    c.Dispose();

                    fluentDesignFormContainer1.Controls.Remove(c);
                }

                if (c.GetType().BaseType == typeof(System.Windows.Forms.UserControl))
                {
                    c.Dispose();
                    fluentDesignFormContainer1.Controls.Remove(c);
                }
            }
        }

        private void RefrescarElementoSesion()
        {
            aceCerrarSesion.Text = common.Utilerias.EsValorValido(Modulo.IdUsuario) ? "Cerrar Sesión" : "Iniciar Sesión";
        }

        public void OcultarMenu()
        {
            try
            {
                fluentDesignFormContainer1.Controls.Clear();

                //actrlMenu.Enabled = false;
                RefrescarElementoSesion();
                var items = actrlMenu.GetElements();

                foreach (DevExpress.XtraBars.Navigation.AccordionControlElement e in items)
                {
                    //e.Image = null;

                    //if (e.Style == DevExpress.XtraBars.Navigation.ElementStyle.Group)
                    //    continue;

                    if (e.Name == aceSalirApp.Name)
                        continue;

                    if (e.Name == aceCerrarSesion.Name)
                        continue;


                    if (e.Name == aceAyuda_Setting.Name)
                        continue;

                    //if (e.Name == aceLicencia.Name)
                    //    continue;

                    if (e.Name == aceInfoApp.Name)
                        continue;

                    //e.Image = null;

                    e.Visible = false;
                }
            }
            catch (Exception ex)
            {
                common.DataHelper.AgregarBitacoraSistema(this.Name + ".OcultarMenu", ex.Message, true);
            }
        }

        private void AutenticarUsuario(string Usuario)
        {
            try
            {
                actrlMenu.Enabled = true;
                var items = actrlMenu.GetElements();

                var cnn = common.ConfigurationSettings.Obtener_CadenaConexion();
                var sql = $"select u.IdPerfil from usuario_sistema u where u.Usuario='{Usuario}'";

                var idPerfil = common.MDB.ExecuteScalar(cnn, sql);

                if (common.Utilerias.IsNullOrEmpty(idPerfil))
                    return;

                sql = $"select p.FormulariosAcceso from perfil_sistema p where p.Id='{idPerfil}' and p.Activo = 1";
                var json = common.Utilerias.SafeToString(common.MDB.ExecuteScalar(cnn, sql));

                if (common.Utilerias.IsNullOrEmpty(json))
                    return;


                //var dtAccesos = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(json);
                var dtAccesos = common.Utilerias.JsonToDT(json);

                if (!common.Utilerias.TablaTieneRows(dtAccesos))
                    return;

                foreach (DevExpress.XtraBars.Navigation.AccordionControlElement e in items)
                {
                    if (e.Style == DevExpress.XtraBars.Navigation.ElementStyle.Group)
                        continue;

                    if (e.Name == aceSalirApp.Name)
                        continue;

                    if (e.Name == aceCerrarSesion.Name)
                        continue;


                    if (e.Name == aceAyuda_Setting.Name)
                        continue;
                    //if (e.Name == aceLicencia.Name)
                    //    continue;

                    if (e.Name == aceInfoApp.Name)
                        continue;

                    var tieneAccesp = Convert.ToBoolean(common.Utilerias.NullValue(dtAccesos.Compute("max(Seleccionar)", $"Formulario = '{e.Name}'"), false));
                    var nombre_elm = e.Name;

                    e.Visible = tieneAccesp;
                    e.Enabled = tieneAccesp;

                    this.Refresh();
                }

                //Ocultar grupo padre si no tiene ningun elemento hijo
                foreach (DevExpress.XtraBars.Navigation.AccordionControlElement e in items)
                {
                    if (e.Style == DevExpress.XtraBars.Navigation.ElementStyle.Item)
                        continue;

                    var grupo = e.Text;
                    var elementosVisibles = e.Elements.AsEnumerable().Count(x => x.Visible == true);

                    e.Visible = elementosVisibles > 0;
                }

                //actrlMenu.ExpandAll();

                RefrescarElementoSesion();

                //alertControl1.Show(this, "Autenticado", "Bienvenido " + Usuario, true);
                this.Refresh();

                if (aceTablero.IsVisible)
                {
                    var open_dash = common.Utilerias.Valor_SI(common.DataHelper.ObtenerConfiguracion(common.enumConfig.SYS_OPEN_DASH, false));

                    if (open_dash)
                    {
                        aceTablero_Click(null, null);
                    }
                    else
                    {
                        AbrirInfoApp();
                    }
                }
            }
            catch (Exception ex)
            {
                common.DataHelper.AgregarBitacoraSistema(this.Name + ".OcultarMenu", ex.Message, true);
            }
        }
        private void aceLicencia_Click(object sender, EventArgs e)
        {
            //Destroy();

            //var comp = new common.rpt.ucActivate();
            //comp.Dock = DockStyle.Fill;
            //fluentDesignFormContainer1.Controls.Add(comp);
            //this.Refresh();

            //comp.CloseEvent += Comp_CloseEvent;
            //comp.Comprobar(true);

            using (var w = common.Utilerias.ShowOverlay(this, "Preparando"))
            {
                var frm = new common.rpt.frmActivate();
                frm.ShowDialog();

                if (frm.AppIsActivated())
                {
                    Comp_CloseEvent(null, null);
                }
            }
        }

        private void Comp_CloseEvent(object sender, EventArgs e)
        {
            try
            {
                using (var w = common.Utilerias.ShowOverlay(this, "Comprobando"))
                {
                    CheckLicense_Activaction();
                }
            }
            catch
            {
            }
        }

        private void aceAppSetting_Click(object sender, EventArgs e)
        {
            Destroy();

            var comp = new common.ucAppSetting();
            comp.Dock = DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(comp);
            this.Refresh();

            comp.Inicializar(false);
        }

        private void aceParametrosApp_Click(object sender, EventArgs e)
        {
            Destroy();

            var comp = new common.ucSetting();
            comp.Dock = DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(comp);
            this.Refresh();
            comp.Inicializar();
        }

        private void aceDispositivos_Click(object sender, EventArgs e)
        {
            Destroy();

            //var comp = new hotspot.ucListaDispositivos();
            var comp = new hotspot.ucListaDispositivos_gv();
            comp.Dock = DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(comp);
            this.Refresh();

            comp.Inicializar();
        }

        private void acePerfilesSistema_Click(object sender, EventArgs e)
        {
            Destroy();

            var frm = new ucListaPerfilesSistema();
            frm.Dock = DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(frm);
            this.Refresh();

            frm.Inicializar();
        }

        private void aceUsuariosSistema_Click(object sender, EventArgs e)
        {
            Destroy();

            var frm = new common.ucListaUsuariosSistema();
            frm.Dock = DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(frm);
            this.Refresh();

            frm.Inicializar();
        }


        private void acePerfilesHotSpot_Click(object sender, EventArgs e)
        {
            Destroy();

            var frm = new hotspot.frmAgregarPerfil();
            frm.Dock = DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(frm);
            this.Refresh();

            frm.Inicializar();
        }

        private void aceHistorialUsuariosHotSpot_Click(object sender, EventArgs e)
        {
            Destroy();

            var frm = new hotspot.ucListaUsuarios_Hist();
            frm.Dock = DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(frm);
            this.Refresh();
            frm.Actualizar();

        }

        private void aceUsuariosHotSpot_Click(object sender, EventArgs e)
        {
            Destroy();

            var frm = new hotspot.frmAgregarUsuario();
            frm.Dock = DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(frm);
            this.Refresh();

            frm.Inicializar();
        }

        private void aceUsuariosActivosHotSpot_Click(object sender, EventArgs e)
        {
            Destroy();

            var frm = new hotspot.ucListaUsuarios_Router();
            frm.Dock = DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(frm);
            this.Refresh();

            frm.Inicializar();

        }

        private void aceTablero_Click(object sender, EventArgs e)
        {
            Destroy();

            var frm = new hotspot.ucDashBoard();
            frm.Dock = DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(frm);
            this.Refresh();
            frm.Inicializar();
            frm.BackColor = Color.White;
        }

        private void AbrirInfoApp()
        {
            Destroy();

            var frm = new common.ucInfoApp();
            //frm.Location = new Point(120, 120);

            //frm.Location = new Point(ClientSize.Width / 2 - fluentDesignFormContainer1.Size.Width / 2, ClientSize.Height / 2 - fluentDesignFormContainer1.Size.Height / 2);
            //frm.Anchor = AnchorStyles.None;



            frm.Left = (this.fluentDesignFormContainer1.Width - frm.Width) / 2;
            frm.Top = (this.fluentDesignFormContainer1.Height - frm.Height) / 2;



            //frm.Dock = DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(frm);
            //frm.Margin = new Padding(50);
            //frm.Padding = new Padding(50);
            this.Refresh();
            frm.BackColor = Color.White;
        }

        private void acePlantillaLoginWeb_Click(object sender, EventArgs e)
        {
            Destroy();
        }

        private void aceHistorialPerfiles_Click(object sender, EventArgs e)
        {
            Destroy();

            var frm = new hotspot.ucListaPerfiles_Hist();
            frm.Dock = DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(frm);
            this.Refresh();
            frm.Actualizar();
        }

        private void acePerfilesActivos_Click(object sender, EventArgs e)
        {
            Destroy();

            var frm = new hotspot.ucListaPerfiles_Router();
            frm.Dock = DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(frm);
            this.Refresh();
            frm.Inicializar();
        }

        private void aceFormatoImpresion_Click(object sender, EventArgs e)
        {
            Destroy();

            var frm = new hotspot.uc_formato_rpt_credenciales();
            frm.Dock = DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(frm);
            this.Refresh();
            frm.Inicializar();
        }

        private void aceAyuda_Setting_Click(object sender, EventArgs e)
        {
            Destroy();

            var frm = new common.ucActualizaciones();
            frm.Dock = DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(frm);
            this.Refresh(); 
        }

        private void DxMenu_Shown(object sender, EventArgs e)
        {
            this.Refresh();
            var f = new frmLogin(this.Icon);
            f.Refresh();
            f.ShowDialog();

            if (f.LoginSuccessFull)
            {
                var cnn = common.ConfigurationSettings.Obtener_CadenaConexion();
                var infoComp = common.wOverlaySplash.GetCompanyInformation(cnn);
                //var appId = infoComp.RTN.Replace("-", "").Replace(".", "");
                var appId = "R2019-03";

                mk_management.common.Link.SetData(cnn, infoComp.Nombre, appId, f.UsuarioAutenticado);
                mk_management.hotspot.Link.SetData(cnn, infoComp.Nombre, appId, f.UsuarioAutenticado);

                AutenticarUsuario(f.UsuarioAutenticado);
            }
            else
            {
                OcultarMenu();
            }
        }


        private void aceCerrarSesion_Click(object sender, EventArgs e)
        {
            OcultarMenu();
            Modulo.IdUsuario = "";
            Modulo.NombreEmpresa = "";
            Modulo.NombreUsuario = "";
            Modulo.TokenAp = "";
            Modulo.Usuario = "";
            Modulo.IdAplicacion = "";
            lcInfoSistema.Visible = false;

            //Ultima linea antes del dialog
            DxMenu_Shown(sender, e);
        }

        private void aceSalirApp_Click(object sender, EventArgs e)
        {
            if (common.Utilerias.msjConfirm("¿Desea salir de la aplicación?"))
                Application.Exit();
        }


        private void lcInfoSistema_Click(object sender, EventArgs e)
        {
            try
            {
                tm_lic_demo_revision.Stop();

                var frm = new common.rpt.frmActivate();
                frm.ShowDialog();

                if (frm.AppIsActivated())
                {
                    lcInfoSistema.Visible = false;
                    var link = common.ConfigurationSettings.Obtener_CadenaConexion();
                    var lic = common.wOverlaySplash.GetLicenseInUse(link);
                    if (!lic.IsDemo)
                    {
                        //Mostrar mensaje de celebracion
                        lcInfoSistema.Visible = true;
                    }
                }
            }
            catch
            {
            }
            finally
            {
                tm_lic_demo_revision.Start();
            }
        }


        private void CheckLicense()
        {
            try
            {
                System.Action ejecutar = () =>
                {
                    var statusVisible = lcInfoSistema.Visible;
                    try
                    {
                        if (common.Utilerias.EsValorValido(Modulo.IdUsuario))
                        {
                            common.DataHelper.AgregarBitacoraSistema("CheckLicense", "", false);

                            var link = common.ConfigurationSettings.Obtener_CadenaConexion();
                            var lic = common.wOverlaySplash.GetLicenseInUse(link);
                            if (lic.IsDemo)
                            {
                                var msj = common.wOverlaySplash.lblLimit_msj5;

                                if (lic != null)
                                {
                                    if (lic.IsExpired())
                                    {
                                        msj = "Licencia vencida. " + msj;
                                    }
                                }

                                lcInfoSistema.ForeColor = Color.DarkOrange;
                                lcInfoSistema.Font = new Font(lcInfoSistema.Font.FontFamily, 12, FontStyle.Bold);
                                lcInfoSistema.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                                lcInfoSistema.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;


                                lcInfoSistema.Text = msj;
                                lcInfoSistema.ToolTip = msj;
                                statusVisible = true;
                            }
                            else
                                statusVisible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        common.DataHelper.AgregarBitacoraSistema("CheckLicense", ex.Message, true);
                    }
                    finally
                    {
                        lcInfoSistema.Visible = statusVisible;
                    }
                };

                if (lcInfoSistema.IsDisposed)
                    return;

                lcInfoSistema.Invoke(ejecutar);
            }
            catch
            {

            }
        }


        private void tm_router_usage_stats_Tick(object sender, EventArgs e)
        {
            //Agregar proceso de revision en un segundo plano para optimizar y no interferir con el uso normal del programa
            Thread mk = new Thread(MK_Checks.CheckUsageStats);
            mk.Start();
        }

        //private void CheckRouterUsageStats()
        //{

        //}


        private void tm_lic_demo_revision_Tick(object sender, EventArgs e)
        {
            CheckLicense_Activaction();
        }

        private void CheckLicense_Activaction()
        {
            //Agregar proceso de revision en un segundo plano para optimizar y no interferir con el uso normal del programa
            Thread chk_lic = new Thread(CheckLicense);
            chk_lic.Start();
        }

        private void tm_lic_trace_stats_Tick(object sender, EventArgs e)
        {
            Thread mk_stats = new Thread(common.wOverlaySplash.ServerTrace);
            mk_stats.Start();
        }

        private void aceInfoApp_Click(object sender, EventArgs e)
        {
            AbrirInfoApp();
        }

        
    }
}

