using System;
using System.Windows.Forms;

namespace mk_management.common
{
    public partial class ucAppSetting : DevExpress.XtraEditors.XtraUserControl
    {
        private bool ReiniciarAplicacion = false;
        private bool MostrarConexion = false;
        private string ConnectionString = "";

        public ucAppSetting()
        {
            InitializeComponent();
        }


        private bool ProbarConexion()
        {
            using (var w = Utilerias.ShowOverlay(this, "Conectando"))
            {
                var error = "";
                var valida = common.DataHelper.ConexionValida(ConnectionString, ref error);
                if (!valida)
                {
                    Utilerias.msjAlert("No se pudo realizar la conexión a la base de datos.\n\nError : \n" + error);
                    return false;
                }
            }

            return true;
        }

        private void LeerCfAbrirTablero()
        {
            var cnn = ConfigurationSettings.Obtener_CadenaConexion();
            if (Utilerias.IsNullOrEmpty(cnn))
                return;

            swAbrirTablero.EditValue = Utilerias.Valor_SI(DataHelper.ObtenerConfiguracion(enumConfig.SYS_OPEN_DASH, false));
            swImprimirCredUserHotSpot.EditValue = Utilerias.Valor_SI(DataHelper.ObtenerConfiguracion(enumConfig.SYS_PRINT_USER_CRED_WIFI, false));

            swEstadisticasUso.EditValue = Utilerias.Valor_SI(DataHelper.ObtenerConfiguracion(enumConfig.SYS_GEN_ROUTER_STATS, false));
        }

        private void LeerParametros()
        {
            try
            {
                swAbrirTablero.EditValue = true;

                using (var w = Utilerias.ShowOverlay(this, "Leyendo parámetros"))
                {
                    ConnectionString = ConfigurationSettings.Obtener_CadenaConexion();
                    txtCadenaConexion.Text = new string('-', ConnectionString.Length);
                    txtCadenaConexion.Enabled = false;

                    Link.SetData(ConnectionString, "", "", "");
                    txtToken.EditValue = ConfigurationSettings.Obtener_Token();
                    tswAutoConectar.EditValue = ConfigurationSettings.Obtener_AutoConectar();

                    LeerCfAbrirTablero();
                }
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate())
                    return;

                if (!Utilerias.msjConfirm("¿Desea guardar los parámetros?"))
                    return;

                if (Utilerias.msjConfirm("¿Desea probar la cadena de conexión a la base de datos?"))
                {
                    if (!ProbarConexion())
                        return;
                }

                using (var w = Utilerias.ShowOverlay(this, "Guardando parámetros"))
                {
                    var error = "";
                    var path = Utilerias.ObtenerPath_AppSetting();
                    var autoConectar = Utilerias.Valor_SI(tswAutoConectar.EditValue);
                    var strAutoConectar = autoConectar ? "S" : "N";

                    if (!ConfigurationSettings.SaveSettings(path, ConnectionString, txtToken.Text, strAutoConectar, ref error, true))
                    {
                        Utilerias.msjError(error);
                        return;
                    }

                    ConfigurationSettings.LoadConfig();


                    if (ReiniciarAplicacion)
                    {
                        Link.ConnectionString = ConfigurationSettings.Obtener_CadenaConexion();
                    }

                    var cf_key_abrirTablero = enumConfig.SYS_OPEN_DASH.ToString();
                    var abrir = Utilerias.Valor_SI(swAbrirTablero.EditValue);
                    DataHelper.ActualizarRegistro_Tabla("sys_config", "config", cf_key_abrirTablero, "value", abrir ? "1" : "0");

                    var cf_key_print_cred = enumConfig.SYS_PRINT_USER_CRED_WIFI.ToString();
                    var imprimirCred = Utilerias.Valor_SI(swImprimirCredUserHotSpot.EditValue);
                    DataHelper.ActualizarRegistro_Tabla("sys_config", "config", cf_key_print_cred, "value", imprimirCred ? "1" : "0");

                    var cf_key_stats_usage = enumConfig.SYS_GEN_ROUTER_STATS.ToString();
                    var genEstats = Utilerias.Valor_SI(swEstadisticasUso.EditValue);
                    DataHelper.ActualizarRegistro_Tabla("sys_config", "config", cf_key_stats_usage, "value", genEstats ? "1" : "0");

                }

                Utilerias.msjInfo("Los parámetros han sido guardados.");

                if (ReiniciarAplicacion)
                {
                    Application.Exit();
                    System.Diagnostics.Process.Start("kaz_wifi.exe");
                }
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }

        public void Inicializar(bool reininicar)
        {
            this.Refresh();
            LeerParametros();
            this.ReiniciarAplicacion = reininicar;
        }

        private void UcAppSetting_Load(object sender, EventArgs e)
        {

        }

        private void btnOpcionesCnn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e != null && e.Button != null && Utilerias.SafeToString(e.Button.Tag) == "show")
            {
                                    
                MostrarConexion = !MostrarConexion;
                e.Button.Caption = MostrarConexion ? "Mostrar" : "Ocultar";

                if(MostrarConexion)
                {
                    txtCadenaConexion.Text = ConnectionString;
                    txtCadenaConexion.Enabled = true;
                }
                else
                {
                    txtCadenaConexion.Text = new string('-', ConnectionString.Length);
                    txtCadenaConexion.Enabled = false;
                }                
            }

            if (e != null && e.Button != null && Utilerias.SafeToString(e.Button.Tag) == "cnn")
            {
                var ok = ProbarConexion();
                if (ok)
                    Utilerias.msjInfo("La conexión se ha realizado");
            }

            if (e != null && e.Button != null && Utilerias.SafeToString(e.Button.Tag) == "bdd")
            {
                var frm = new frmCrearBdd();
                frm.ShowDialog();

                if( Utilerias.EsValorValido( frm.ConnectionStringGenerada))
                {
                    ConnectionString = frm.ConnectionStringGenerada;
                    if (MostrarConexion)
                        txtCadenaConexion.Text = ConnectionString;

                    Utilerias.msjInfo("Presione guardar para establecer la nueva base de datos y demas configuraciones");
                }
            }
        }

        private void txtCadenaConexion_EditValueChanged(object sender, EventArgs e)
        {
            if(MostrarConexion)
            {
                ConnectionString = (sender as DevExpress.XtraEditors.MemoEdit).Text;
            }
        }
    }
}
