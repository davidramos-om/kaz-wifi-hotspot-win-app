using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using mk_management.common;

namespace mk_management.hotspot
{
    public partial class frmAgregarPerfil : DevExpress.XtraEditors.XtraUserControl
    {
        public const decimal KB_in_MB = 1024;

        public frmAgregarPerfil()
        {
            InitializeComponent();
            Limpiar();
        }

        private void Limpiar()
        {
            rgVelocidad.EditValue = false;
            txtNombre.EditValue = null;
            spVelocidadDescarga.EditValue = null;
            spVelocidadSubida.EditValue = null;

            dxValidationProvider1.RemoveControlError(txtNombre);
            dxValidationProvider1.RemoveControlError(rgVelocidad);
        }

        private void EstablecerDispositivoPredeterminado()
        {
            var dt = lueDispositivo.Properties.DataSource as DataTable;

            if (Utilerias.TablaTieneRows(dt) && dt.Rows.Count > 1)
            {
                lueDispositivo.EditValue = dt.Rows[0]["Id"];
                lueDispositivo.Enabled = true;
                txtNombre.TabIndex = 0;
                txtNombre.Focus();
                SendKeys.Send("{tab}");
            }
            if (Utilerias.TablaTieneRows(dt) && dt.Rows.Count == 1)
            {
                lueDispositivo.ItemIndex = 0;
                lueDispositivo.Enabled = false;
                txtNombre.TabIndex = 0;
                txtNombre.Focus();
                SendKeys.Send("{tab}");
            }
            else
            {
                lueDispositivo.Focus();
            }
        }

        private void CargarDispositivos()
        {
            try
            {
                var dt = DataHelper.ConsultarRegistro("server", "Id", "", false, "order by Predeterminado desc,Descripcion asc");
                lueDispositivo.Properties.DataSource = dt;
                lueDispositivo.Properties.DisplayMember = "Descripcion";
                lueDispositivo.Properties.ValueMember = "Id";

                EstablecerDispositivoPredeterminado();
            }
            catch (Exception ex)
            {
                DataHelper.AgregarBitacoraSistema(this.Name + ".CargarDispositivos", ex.Message, true);
            }
        }

        public void Inicializar()
        {
            Limpiar();
            CargarDispositivos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var link = ConfigurationSettings.Obtener_CadenaConexion();
                var licencia = wOverlaySplash.GetLicenseInUse(link);
                if (licencia == null)
                {
                    Utilerias.msjAlert_TI(wOverlaySplash.lblLimit_msj_no_license);
                    return;
                }

                if (licencia.HotSpot_Profiles != -1)
                {
                    if (DataHelper.CantRegistros("perfil_hotspot", "-1") >= licencia.HotSpot_Profiles)
                    {
                        Utilerias.msjAlert_TI(wOverlaySplash.lblLimit_mjs1);
                        return;
                    }
                }

                if (!dxValidationProvider1.Validate())
                    return;

                MK mk = null;
                Model.ServerInfo svr;

                using (var w = Utilerias.WaitWindow(null, "Conectando al dispositivo"))
                {
                    svr = hotspot.Helper.ObtenerDatosServidor(Utilerias.SafeToString(lueDispositivo.EditValue));

                    if (svr.TieneError)
                    {
                        Utilerias.msjAlert(svr.ErrorMsj);
                        return;
                    }

                    mk = new MK(svr.IP, svr.Puerto, svr.VersionSO);

                    if (!mk.Login(svr.Usuario, svr.Clave))
                    {
                        mk.Close();
                        Utilerias.msjInfo("No se pudo iniciar sesion.");
                        return;
                    }
                }

                if (mk == null || svr == null)
                    return;


                var kbDescarga = -1;
                var kbSubidda = -1;
                var minutos = -1; // no definido

                if (Convert.ToBoolean(rgVelocidad.EditValue))
                {
                    kbDescarga = Convert.ToInt32(spVelocidadDescarga.Value * KB_in_MB);
                    kbSubidda = Convert.ToInt32(spVelocidadSubida.Value * KB_in_MB);
                }

                var HP_Id = mk.AddProfile(txtNombre.Text, kbSubidda, kbDescarga, minutos);
                mk.Close();

                if (Utilerias.EsValorValido(HP_Id))
                {
                    var msj = "El perfil creado en el dispositivo.";

                    var resp = DataHelper.CrearRegistro_Tabla("perfil_hotspot",
                                          "IdServer", svr.Id,
                                          "Descripcion", txtNombre.Text,
                                          "Kb_Descarga", kbDescarga,
                                          "Kb_Subida", kbSubidda,
                                          "Minutos", minutos,
                                          "HP_Id", HP_Id
                                         );

                    if (!resp)
                    {
                        msj = "El perfil ha sido creado en el dispositivo, no se ha podido crear la bitacora.";
                    }

                    Utilerias.msjInfo(msj);
                    Limpiar();
                }
                else
                {
                    Utilerias.msjAlert("No se pudo agregar el perfil.");
                }
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }

        private void rgVelocidad_EditValueChanged(object sender, EventArgs e)
        {
            var status = Convert.ToBoolean(Utilerias.NullValue(rgVelocidad.EditValue, false));
            spVelocidadDescarga.Enabled = status;
            spVelocidadSubida.Enabled = status;
        }

        private void spVelocidadDescarga_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (Utilerias.EsValorValido(e.NewValue) && Convert.ToDecimal(e.NewValue) < 0)
            {
                e.Cancel = true;
            }
        }

        private void spVelocidadSubida_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (Utilerias.EsValorValido(e.NewValue) && Convert.ToDecimal(e.NewValue) < 0)
            {
                e.Cancel = true;
            }
        }
    }
}