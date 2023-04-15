using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace mk_management.common
{
    public partial class frmActivate_OnLine : DevExpress.XtraEditors.XtraForm
    {

        private static readonly string CROSS_KEY = "KMpoZT@$VrUNf45tZ8eg^rIaZSZ^Pv%*";

        public DataTable dtInfoLicencia = null;

        public frmActivate_OnLine()
        {
            InitializeComponent();
            this.Icon = Utilerias.ObtenerIconoApp();
            txtCodigoCliente.Text = "";
            txtLicencia.Text = "";
            this.Text = "Activación con conexión a Internet";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.None;

                if (!dxValidationProvider1.Validate())
                    return;

                if (txtLicencia.Text.Length < 25)
                {
                    Utilerias.msjInfo("El código de licencia es incorrecto.");
                    return;
                }

                if (txtCodigoCliente.Text.Length < 8)
                {
                    Utilerias.msjInfo("El código de cliente es incorrecto.");
                    return;
                }

                var razon = "";
                if (mk_management.common.rpt.frmActivate.LicenseAlreadyExist(txtLicencia.Text, txtCodigoCliente.Text, ref razon))
                {
                    var msj = "No se puede utilizar esta licencia\n\nMotivo :\n{0}.";
                    msj = string.Format(msj, razon);
                    Utilerias.msjInfo(msj);
                    return;
                }

                using (var w = Utilerias.ShowOverlay(this, "Verificando"))
                {
                    var error = "";
                    var codigo = common.wOverlaySplash.GetLicenseCode(txtLicencia.Text, txtCodigoCliente.Text, ref error);

                    if (Utilerias.EsValorValido(error))
                    {
                        if (error.Contains("No es posible conectar con el servidor remoto"))
                            Utilerias.msjAlert("No se pudo conectar, por favor revise su conexión a internet o use opción de activar sin conexión a internet.");
                        else
                            Utilerias.msjAlert(error);

                        return;
                    }

                    var data = CrossCrypto.Decrypt(codigo, CROSS_KEY);

                    var dt = Utilerias.JsonToDT(data);

                    if (Utilerias.TablaTieneRows(dt))
                    {
                        var maxDemos = new InfoLicencia().MaxDemos;
                        if (dt.Columns["MaxDemos"] != null)
                            maxDemos = Convert.ToInt32(dt.Rows[0]["MaxDemos"]);

                        var licenciasAplicadas = wOverlaySplash.ObtenerLicencias_PC(ConfigurationSettings.Obtener_CadenaConexion());
                        if (licenciasAplicadas != null)
                        {
                            var licenciasDemos = licenciasAplicadas.Where(x => x.IsDemo == true);
                            if (licenciasDemos != null)
                            {
                                if (licenciasDemos.Count() >= maxDemos)
                                {
                                    var msj = "No se puede utilizar esta licencia\n\nMotivo :\n{0}.";
                                    msj = string.Format(msj, "Ha superado el limite máximo de licencias demostrativas permitidas.");
                                    Utilerias.msjInfo(msj);
                                }
                            }
                        }

                        dtInfoLicencia = dt;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        Utilerias.msjAlert_TI("La licencia tiene un formato incorrecto.");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Source == "Newtonsoft.Json")
                {
                    Utilerias.msjError("La licencia no puso ser procesada.");
                }
                else
                    Utilerias.msjErrorEx(ex);
            }
        }
    }
}
