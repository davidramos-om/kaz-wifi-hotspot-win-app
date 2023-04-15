using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mk_management.common
{
    public partial class frmActivate_Offline : DevExpress.XtraEditors.XtraForm
    {
        public static readonly string CROSS_KEY = "KMpoZT@$VrUNf45tZ8eg^rIaZSZ^Pv%*";
        public DataTable dtInfoLicencia = null;

        public frmActivate_Offline()
        {
            InitializeComponent();
            this.Icon = Utilerias.ObtenerIconoApp();
            mbLicencia.Text = "";
            this.Text = "Activación sin conexión a Internet";
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

                if (Utilerias.IsNullOrEmpty(mbLicencia.Text))
                {
                    Utilerias.msjInfo("Escribir código de activación.");
                    return;
                }



                using (var w = Utilerias.ShowOverlay(this, "Verificando"))
                {
                    var codigo = mbLicencia.Text;

                    var data = CrossCrypto.Decrypt(codigo, CROSS_KEY);

                    if (Utilerias.IsNullOrEmpty(data))
                    {
                        Utilerias.msjAlert("El código de activación es incorrecto.");
                        return;
                    }

                    var dt = Utilerias.JsonToDT(data);

                    if (Utilerias.TablaTieneRows(dt))
                    {
                        var lic = Utilerias.SafeToString(dt.Rows[0]["License"]);
                        var client = Utilerias.SafeToString(dt.Rows[0]["ClientId"]);

                        if (Utilerias.IsNullOrEmpty(lic) || Utilerias.IsNullOrEmpty(client))
                        {
                            Utilerias.msjAlert("El código de activación es incorrecto.");
                            return;
                        }

                        var razon = "";
                        if (mk_management.common.rpt.frmActivate.LicenseAlreadyExist(lic, client, ref razon))
                        {
                            var msj = "No se puede utilizar esta licencia\n\nMotivo :\n{0}.";
                            msj = string.Format(msj, razon);
                            Utilerias.msjInfo(msj);
                            return;
                        }

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
