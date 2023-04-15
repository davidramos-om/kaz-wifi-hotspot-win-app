using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mk_management.common.rpt
{
    public partial class frmPricing : DevExpress.XtraEditors.XtraForm
    {
        InfoLicencia licActual = null;
        public bool LicenseUpdated = false;
        public frmPricing(Icon icono, InfoLicencia _licActual)
        {
            InitializeComponent();

            this.Icon = icono;
            licActual = _licActual;

            GenerarInfoLicencia();
        }

        private void GenerarInfoLicencia()
        {
            grdInfo.DataSource = null;

            if (licActual == null)
                return;

            this.Text = "Licencia : " + licActual.License;
            //gvInfo.ViewCaption = "Información de la licencia : " + licActual.License;
            gvInfo.ViewCaption = "Información de la licencia";

            gvInfo.OptionsView.ShowColumnHeaders = true;
            gvInfo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            gvInfo.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gvInfo.Appearance.HeaderPanel.FontStyleDelta = FontStyle.Bold;

            //colDemo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //colDemo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

            colActivado.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            colActivado.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            colActivado.Caption = "Adquirido";

            gvInfo.Appearance.EvenRow.Reset();
            gvInfo.OptionsView.EnableAppearanceEvenRow = true;
            //gvInfo.Appearance.EvenRow.BackColor = Utilerias.GetWebColor("#E3F2FD");
            gvInfo.Appearance.EvenRow.BackColor = Utilerias.GetWebColor("#ECEFF1");
            gvInfo.Appearance.EvenRow.BackColor = Utilerias.GetWebColor("#FAFAFA");


            //gvInfo.Appearance.EvenRow.Reset();
            gvInfo.Appearance.EvenRow.FontStyleDelta = FontStyle.Bold;
            gvInfo.OptionsView.EnableAppearanceOddRow = false;

            gvInfo.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvInfo.OptionsSelection.EnableAppearanceFocusedRow = false;
            gvInfo.OptionsSelection.EnableAppearanceHideSelection = false;
            gvInfo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            gvInfo.OptionsCustomization.AllowRowSizing = false;
            gvInfo.OptionsCustomization.AllowColumnMoving = false;
            gvInfo.OptionsCustomization.AllowFilter = false;
            gvInfo.OptionsCustomization.AllowColumnResizing = false;
            gvInfo.OptionsCustomization.AllowGroup = false;
            gvInfo.OptionsCustomization.AllowQuickHideColumns = false;

            colActivado.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colActivado.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            colActivado.AppearanceCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#2E7D32");

            colActivado.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colActivado.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

            //colDemo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //colDemo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            //colDemo.AppearanceCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#607D8B");

            PrepararTabla();

            if (licActual != null)
            {
                AgregarRow("Tipo", licActual.IsDemo ? "Licencia demostrativa" : "Licencia activada");
                //AgregarRow(" ", " ");
                AgregarRow("Usuarios App", licActual.App_Users == -1 ? "Sin limites" : licActual.App_Users.ToString());
                AgregarRow("Roles App", licActual.App_Profiles == -1 ? "Sin limites" : licActual.App_Profiles.ToString());

                AgregarRow("Dispositivos de wifi", licActual.HotSpot_Devices == -1 ? "Sin limites" : licActual.HotSpot_Devices.ToString());

                AgregarRow("Usuarios HotSpot", licActual.HotSpot_Users == -1 ? "Sin limites" : licActual.HotSpot_Users.ToString());
                AgregarRow("Perfiles HotSpot", licActual.HotSpot_Profiles == -1 ? "Sin limites" : licActual.HotSpot_Profiles.ToString());

                AgregarRow("Eliminar usuarios HotSpot", licActual.AllowDeleteUser ? "SI" : "NO");
                AgregarRow("Desactivar usuarios HotSpot", licActual.AllowDisableUser ? "SI" : "NO");
                AgregarRow("Reimprimir credenciales", licActual.AllowRePrintCred ? "SI" : "NO");
                AgregarRow("Marca de agua", licActual.ShowWaterMark ? "SI" : "NO");

                AgregarRow("Inicio", Utilerias.EasyDate(licActual.Inicio) + " " + licActual.Fin.ToShortTimeString());
                AgregarRow("Finaliza", Utilerias.EasyDate(licActual.Fin) + " " + licActual.Fin.ToShortTimeString());
                //AgregarRow(" ", " ");
                AgregarRow("Licencia a :", licActual.Company);
                AgregarRow("Código Cliente:", licActual.ClientId);
                AgregarRow("Correo :", licActual.Email);
                AgregarRow("Contacto: ", licActual.Name + " " + licActual.LastName);
            }

            var menu = new common.MenuItemGridViews(ref gvInfo, "Funcionalidades");
        }

        private void PrepararTabla()
        {
            var dt = new DataTable("Funciones");

            dt.Columns.Add(colFuncionalidad.FieldName);
            dt.Columns.Add(colActivado.FieldName);

            grdInfo.DataSource = dt;
        }

        private void AgregarRow(string funcionalidad, string valor)
        {
            var dt = grdInfo.DataSource as DataTable;

            var nr = dt.NewRow();

            nr[colFuncionalidad.FieldName] = funcionalidad;
            nr[colActivado.FieldName] = valor;

            dt.Rows.Add(nr);
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (licActual == null)
                {
                    Utilerias.msjAlert("La licencia tiene un formato incorrecto.");
                    return;
                }

                if (!Utilerias.msjConfirm("¿Desea ejecutar el proceso de actualización de la licencia?"))
                    return;

                using (var w = Utilerias.ShowOverlay(this, "Conectando"))
                {
                    var errores = "";
                    var token = wOverlaySplash.GetLicenseTransform(licActual.License, licActual.ClientId, ref errores);

                    if (Utilerias.EsValorValido(errores))
                    {
                        Utilerias.msjAlert("Ocurrio un problema al consultar la licencia : " + Environment.NewLine + errores);
                        return;
                    }

                    var data = CrossCrypto.Decrypt(token, frmActivate_Offline.CROSS_KEY);

                    if (Utilerias.IsNullOrEmpty(data))
                    {
                        Utilerias.msjAlert("El código de activación es incorrecto.");
                        return;
                    }

                    var dt = Utilerias.JsonToDT(data);

                    if (!Utilerias.TablaTieneRows(dt))
                    {
                        Utilerias.msjAlert("La licencia no se pudo serializar.");
                        return;
                    }


                    var lic = Utilerias.SafeToString(dt.Rows[0]["License"]);
                    var client = Utilerias.SafeToString(dt.Rows[0]["ClientId"]);

                    if (Utilerias.IsNullOrEmpty(lic) || Utilerias.IsNullOrEmpty(client))
                    {
                        Utilerias.msjAlert("El código de activación es incorrecto.");
                        return;
                    }

                    //Actualizar licencia
                    var json = "";
                    var json_dataCrypt = "";
                    var licencia_actualizada = frmActivate.GenerarLicencia(dt.Rows[0], false, licActual.UniqueId, licActual.Inicio, null, ref json, ref json_dataCrypt);

                    if (Utilerias.IsNullOrEmpty(json_dataCrypt))
                    {
                        Utilerias.msjConfirm("La licencia no pudo ser confirmada.");
                        return;
                    }

                    var guardado = DataHelper.ActualizarRegistro_Tabla("app_setting", "Id", licActual.UniqueId, "Config", json_dataCrypt);
                    if (guardado)
                    {
                        LicenseUpdated = true;
                        Utilerias.msjInfo("Las características de la licencia han sido actualizadas.!");
                        //var frm = new frmCongrats(this.Icon, licencia_actualizada, false);
                        //frm.SetSubTitle("La licencia han sido actualizada");
                        //frm.SetBorderColor(Utilerias.GetWebColor("#4CAF50"));
                        //frm.ShowDialog();
                        //this.Refresh();
                        licActual = licencia_actualizada;
                        GenerarInfoLicencia();
                    }
                    else
                    {
                        Utilerias.msjAlert_TI("La licencia no pudo ser actualizada, quizas haya sido removida.");
                    }
                }
            }
            catch (Exception ex)
            {
                Utilerias.msjAlert(ex.Message);
            }
        }
    }
}
