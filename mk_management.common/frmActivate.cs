using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace mk_management.common.rpt
{
    public partial class frmActivate : DevExpress.XtraEditors.XtraForm
    {
        private bool AppActivated = false;
        const string DEMO = "DEMO";
        const string ACTIVATED = "ACTIVATE";
        const int MAX_VRCHAR = 500;
        const string prefix = "|LC|";
        const string sufix = "|N";

        public event EventHandler CloseEvent = new EventHandler((e, a) => { });
        private static readonly string CROSS_CRYPTO_KEY = "Mb_4l.+Y_8dmIw;";

        public frmActivate()
        {
            InitializeComponent();

            this.Icon = common.Utilerias.ObtenerIconoApp();
            tlLicenciasUsadas.Groups[0].Items.Clear();
        }

        public bool AppIsActivated()
        {
            return AppActivated;
        }

        public void Comprobar(bool showOverlay = false)
        {
            if (showOverlay)
            {
                using (var w = Utilerias.ShowOverlay(this, "Verificando"))
                {
                    Verificar();
                }
            }
            else
            {
                Verificar();
            }
        }

        private void AgregarItem(InfoLicencia lic, bool isCurrentLic)
        {
            var item_licencia = new DevExpress.XtraEditors.TileItem();

            var tlp = new DevExpress.Utils.ToolTipItem();
            tlp.Text = (isCurrentLic ? "(✔ Licencia en uso). " : "") + "Doble clic para ver detalle de la licencia";

            item_licencia.SuperTip = new DevExpress.Utils.SuperToolTip();
            item_licencia.SuperTip.Items.Add(tlp);

            item_licencia.ItemDoubleClick += Item_licencia_ItemDoubleClick;
            item_licencia.Tag = lic;

            if (!lic.IsDemo && !lic.IsExpired())
            {
                item_licencia.AppearanceItem.Normal.BackColor = Color.ForestGreen;
            }
            else
            {
                item_licencia.AppearanceItem.Normal.BackColor = Color.Orange;
            }

            item_licencia.BorderVisibility = DevExpress.XtraEditors.TileItemBorderVisibility.Never;
            item_licencia.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;

            var item_tipo = new DevExpress.XtraEditors.TileItemElement();

            if (lic.IsDemo)
                item_tipo.Text = "Tipo : Demostrativa";
            else
                item_tipo.Text = "Tipo : Activada";

            item_tipo.Appearance.Normal.FontSizeDelta = 10;
            item_tipo.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            item_tipo.TextLocation = new Point(4, 0);
            item_licencia.Elements.Add(item_tipo);

            var item_desde_lb = new DevExpress.XtraEditors.TileItemElement();
            item_desde_lb.Text = "Desde";
            item_desde_lb.MaxWidth = 110;
            item_desde_lb.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            item_desde_lb.TextLocation = new Point(4, 40);
            item_licencia.Elements.Add(item_desde_lb);


            var item_desde_val = new DevExpress.XtraEditors.TileItemElement();
            item_desde_val.Text = Utilerias.EasyDate(lic.Inicio);
            item_desde_val.MaxWidth = 110;
            item_desde_val.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            item_desde_val.TextLocation = new Point(116, 40);
            item_licencia.Elements.Add(item_desde_val);

            var item_hasta_lb = new DevExpress.XtraEditors.TileItemElement();
            item_hasta_lb.Text = "Hasta";
            item_hasta_lb.MaxWidth = 110;
            item_hasta_lb.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            item_hasta_lb.TextLocation = new Point(4, 65);
            item_licencia.Elements.Add(item_hasta_lb);

            var item_hasta_val = new DevExpress.XtraEditors.TileItemElement();
            item_hasta_val.Text = Utilerias.EasyDate(lic.Fin);
            item_hasta_val.MaxWidth = 110;
            item_hasta_val.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            item_hasta_val.TextLocation = new Point(116, 65);
            item_licencia.Elements.Add(item_hasta_val);

            var item_cod_lic = new DevExpress.XtraEditors.TileItemElement();
            item_cod_lic.Text = lic.License;
            item_cod_lic.MaxWidth = 0;
            item_cod_lic.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            item_cod_lic.TextLocation = new Point(4, 0);
            item_licencia.Elements.Add(item_cod_lic);

            tlLicenciasUsadas.Groups[0].Items.Add(item_licencia);

        }

        public void Verificar()
        {
            tlLicenciasUsadas.Groups[0].Items.Clear();
            tlLicenciasUsadas.ShowToolTips = true;
            tabPrincipal.SelectedTabPage = tabLicenciasUsadas;
            this.Refresh();


            var link = common.ConfigurationSettings.Obtener_CadenaConexion();

            var licInUse = wOverlaySplash.GetLicenseInUse(link);
            var licencias = wOverlaySplash.ObtenerLicencias_PC(link);

            if (licencias != null)
            {
                foreach (var lic in licencias)
                {
                    var current = false;

                    if (licInUse != null)
                        current = lic.License == licInUse.License;

                    AgregarItem(lic, current);
                    this.Refresh();
                }
            }

            if (tlLicenciasUsadas.Groups[0].Items.Count <= 0)
            {
                tabPrincipal.SelectedTabPage = tabActivar;
                return;
            }
        }

        private void Item_licencia_ItemDoubleClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                var lic = e.Item.Tag as InfoLicencia;
                if (lic != null)
                {
                    var frm = new common.rpt.frmPricing(this.Icon, lic);
                    frm.ShowDialog();

                    if (frm.LicenseUpdated)
                        Comprobar(true);
                }
            }
        }


        public static bool LicenseAlreadyExist(string license, string clientId, ref string error)
        {
            try
            {
                var cnn = ConfigurationSettings.Obtener_CadenaConexion();

                //Incluir anulados, todo lo que este en BDD
                var sql = "select * from app_setting";
                var dt = MDB.FillDataTable(cnn, sql);

                if (Utilerias.TablaTieneRows(dt))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        var cf = Utilerias.SafeToString(r["Config"]);

                        if (Utilerias.EsValorValido(cf))
                        {
                            var decrypt = Crypto.Decrypt(cf, CROSS_CRYPTO_KEY);
                            if (Utilerias.EsValorValido(cf))
                            {
                                var lic = Newtonsoft.Json.JsonConvert.DeserializeObject<InfoLicencia>(decrypt);
                                if (lic != null)
                                {
                                    if (lic.License.ToUpper() == license.ToUpper())
                                    {
                                        error = "La licencia ya ha sido utilizada.";
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                error = "La licencia no se pudo comprobar. Error : " + ex.Message;
                return true;
            }
        }

        public static InfoLicencia GenerarLicencia(DataRow rLic, bool generarFechaVigencia, object uniqueId, object fechaInicio, object fechaFin, ref string json, ref string json_dataCrypt)
        {
            json = "";
            json_dataCrypt = "";

            var lic = new InfoLicencia();

            var tabla = rLic.Table;

            lic.Hwid = FingerPrint.Value();

            if (Utilerias.EsValorValido(uniqueId))
                lic.UniqueId = Utilerias.SafeToString(uniqueId);
            else
                lic.UniqueId = Utilerias.GenerateDateId();

            if (tabla.Columns["License"] != null)
                lic.License = Utilerias.SafeToString(rLic["License"]);

            if (tabla.Columns["ClientId"] != null)
                lic.ClientId = Utilerias.SafeToString(rLic["ClientId"]);

            if (tabla.Columns["Address"] != null)
                lic.Address = Utilerias.SafeToString(rLic["Address"]);

            if (tabla.Columns["Contact"] != null)
                lic.Contact = Utilerias.SafeToString(rLic["Contact"]);

            if (tabla.Columns["Name"] != null)
                lic.Name = Utilerias.SafeToString(rLic["Name"]);

            if (tabla.Columns["LastName"] != null)
                lic.LastName = Utilerias.SafeToString(rLic["LastName"]);

            if (tabla.Columns["Company"] != null)
                lic.Company = Utilerias.SafeToString(rLic["Company"]);

            if (tabla.Columns["Email"] != null)
                lic.Email = Utilerias.SafeToString(rLic["Email"]);

            if (tabla.Columns["CompanyEmail"] != null)
                lic.CompanyEmail = Utilerias.SafeToString(rLic["CompanyEmail"]);

            if (tabla.Columns["RTN"] != null)
                lic.RTN = Utilerias.SafeToString(rLic["RTN"]);

            if (tabla.Columns["HotSpot_Users"] != null)
                lic.HotSpot_Users = Convert.ToInt32(Utilerias.NullValue(rLic["HotSpot_Users"], lic.HotSpot_Users));

            if (tabla.Columns["HotSpot_Profiles"] != null)
                lic.HotSpot_Profiles = Convert.ToInt32(Utilerias.NullValue(rLic["HotSpot_Profiles"], lic.HotSpot_Profiles));

            if (tabla.Columns["HotSpot_Devices"] != null)
                lic.HotSpot_Devices = Convert.ToInt32(Utilerias.NullValue(rLic["HotSpot_Devices"], lic.HotSpot_Devices));

            if (tabla.Columns["App_Users"] != null)
                lic.App_Users = Convert.ToInt32(Utilerias.NullValue(rLic["App_Users"], lic.App_Users));

            if (tabla.Columns["App_Profiles"] != null)
                lic.App_Profiles = Convert.ToInt32(Utilerias.NullValue(rLic["App_Profiles"], lic.App_Profiles));

            if (tabla.Columns["DemoHours"] != null)
                lic.DemoHours = Convert.ToInt32(Utilerias.NullValue(rLic["DemoHours"], lic.DemoHours));

            if (tabla.Columns["AllowDeleteUser"] != null)
                lic.AllowDeleteUser = Convert.ToBoolean(Utilerias.NullValue(rLic["AllowDeleteUser"], lic.AllowDeleteUser));

            if (tabla.Columns["AllowDisableUser"] != null)
                lic.AllowDisableUser = Convert.ToBoolean(Utilerias.NullValue(rLic["AllowDisableUser"], lic.AllowDisableUser));

            if (tabla.Columns["AllowRePrintCred"] != null)
                lic.AllowRePrintCred = Convert.ToBoolean(Utilerias.NullValue(rLic["AllowRePrintCred"], lic.AllowRePrintCred));

            if (tabla.Columns["ShowWaterMark"] != null)
                lic.ShowWaterMark = Convert.ToBoolean(Utilerias.NullValue(rLic["ShowWaterMark"], lic.ShowWaterMark));

            if (tabla.Columns["MaxDemos"] != null)
                lic.MaxDemos = Convert.ToInt32(Utilerias.NullValue(rLic["MaxDemos"], lic.MaxDemos));

            if (tabla.Columns["Disabled"] != null)
                lic.Disabled = Convert.ToBoolean(Utilerias.NullValue(rLic["Disabled"], lic.Disabled));

            if (tabla.Columns["IsDemo"] != null)
                lic.IsDemo = Convert.ToBoolean(Utilerias.NullValue(rLic["IsDemo"], lic.IsDemo));

            //if (tabla.Columns["Activated"] != null)
            //    lic.Activated = Convert.ToBoolean(Utilerias.NullValue(rLic["Activated"], lic.Activated));
            //lic.Activated = !lic.IsDemo;

            if (generarFechaVigencia)
            {
                lic.Inicio = DataHelper.getServerDate();
                lic.Fin = lic.Inicio.AddHours(lic.DemoHours);
            }
            else
            {
                if (Utilerias.EsValorValido(fechaInicio))
                {
                    lic.Inicio = Convert.ToDateTime(fechaInicio);
                    lic.Fin = lic.Inicio.AddHours(lic.DemoHours);
                }

                if (Utilerias.EsValorValido(fechaFin))
                    lic.Fin = Convert.ToDateTime(fechaFin);
            }

            json = Newtonsoft.Json.JsonConvert.SerializeObject(lic);
            json_dataCrypt = Crypto.Encrypt(json, CROSS_CRYPTO_KEY);

            return lic;
        }

        private void Activar(DataRow rLic, string codigoActivacion, bool activacionOnline)
        {
            try
            {
                using (var w = Utilerias.ShowOverlay(this, "Procesando"))
                {
                    var cnn = common.ConfigurationSettings.Obtener_CadenaConexion();

                    var json = "";
                    var json_dataCrypt = "";
                    var lic = GenerarLicencia(rLic, true, null, null, null, ref json, ref json_dataCrypt);

                    var guardado = DataHelper.CrearRegistro_Tabla("app_setting", "Id", lic.UniqueId, "Config", json_dataCrypt);

                    if (guardado)
                    {
                        if (activacionOnline)
                        {
                            ConfirmarActivacion_Online(lic);
                        }
                    }

                    AppActivated = guardado;

                    if (AppActivated)
                    {
                        var frmCongrats = new frmCongrats(Utilerias.ObtenerIconoApp(), lic);
                        frmCongrats.ShowDialog();
                        this.Refresh();
                        Comprobar(true);
                    }
                }
            }
            catch (Exception ex)
            {
                DataHelper.AgregarBitacoraSistema("AppActivate", ex.Message, true);

                if (ex.Source == "MySql.Data")
                {
                    Utilerias.msjAlert_TI("La licencia ingresada no pudo ser procesada.");
                }
                else
                    Utilerias.msjAlert_TI("Error al activar.\n\n" + ex.Message);
            }
        }

        public static bool ConfirmarActivacion_Online(InfoLicencia lic)
        {
            try
            {
                //Confirmar si se puede enviar para aprobacion
                var error = "";
                var aplicada = wOverlaySplash.ApplyLicense(lic, ref error);
                return aplicada;
            }
            catch
            {
                return false;
            }
        }



        private bool EsCodigoValido(DataTable dt, string codigoIngresado)
        {
            try
            {
                if (!Utilerias.TablaTieneRows(dt))
                    return false;

                var row = dt.Rows[0];

                if (Utilerias.Valor_SI(row["Act"]))
                    return false;

                var pc = Utilerias.SafeToString(row["Pc"]).ToLower();
                if (pc != "none")
                    return false;

                var hwId = Utilerias.SafeToString(row["HwId"]).ToLower();
                if (hwId != "0000-ffff-0000-ffff")
                    return false;

                if (Utilerias.IsNullOrEmpty(row["Horas"]))
                    return false;

                if (!Utilerias.isNumber(row["Horas"]))
                    return false;

                var horasVig = Convert.ToInt32(row["Horas"]);
                if (horasVig <= 0)
                    return false;

                var lic = Utilerias.SafeToString(row["Lic"]);

                var iguales = lic == codigoIngresado;

                return iguales;

            }
            catch (Exception ex)
            {
                DataHelper.AgregarBitacoraSistema("AppActivate.CheckLicense", ex.Message, true);
                return false;
            }
        }

        private void rgVersion_EditValueChanged(object sender, EventArgs e)
        {
            //if (Utilerias.SafeToString(rgVersion.EditValue) == DEMO)
            //{
            //    lcgTab.Enabled = false;
            //    btnActivar.Enabled = false;
            //    lciLicencia.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //    lciLicencia.ContentVisible = true;
            //}
            //else
            //{
            //    lcgTab.Enabled = true;
            //    btnActivar.Enabled = true;
            //    lciLicencia.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //    lciLicencia.ContentVisible = true;
            //}
        }


        private void item_Online_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var frm = new frmActivate_OnLine();
            if (frm.ShowDialog() == DialogResult.OK && Utilerias.TablaTieneRows(frm.dtInfoLicencia))
            {
                Activar(frm.dtInfoLicencia.Rows[0], "", true);
            }
        }

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var frm = new frmActivate_Offline();
            if (frm.ShowDialog() == DialogResult.OK && Utilerias.TablaTieneRows(frm.dtInfoLicencia))
            {
                Activar(frm.dtInfoLicencia.Rows[0], "", false);
            }
        }

        private void frmActivate_Shown(object sender, EventArgs e)
        {
            Comprobar(true);
        }

        private void tileItem2_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {

        }
    }
}
