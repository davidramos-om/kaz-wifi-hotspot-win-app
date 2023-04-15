using System;
using System.Data;
using System.Windows.Forms;
using mk_management.common;

namespace mk_management.hotspot
{
    public partial class frmAgregarUsuario : DevExpress.XtraEditors.XtraUserControl
    {
        public frmAgregarUsuario()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            this.Refresh();

            txtClave.EditValue = null;
            txtUsuario.EditValue = null;
            luePerfil.EditValue = null;
            lueDispositivo.EditValue = null;
            rgLimitarTiempo.EditValue = false;
            spMinutosNavegacion.EditValue = null;
            rgTipoTiempo.EditValue = null;
            mbComentario.EditValue = null;

        }

        //Funcion para generar cadena de texto y numero para usuario y contrasena
        private string generar()
        {
            this.Refresh();
            Random rdn = new Random();
            string caracteres = "abcdefghijklmnopqrstuvwxyz1234567890";
            int longitud = caracteres.Length;
            char letra;
            int longitudContrasenia = 5;
            string contraseniaAleatoria = string.Empty;

            for (int i = 0; i < longitudContrasenia; i++)
            {
                letra = caracteres[rdn.Next(longitud)];
                contraseniaAleatoria += letra.ToString();
            }

            return contraseniaAleatoria;
        }


        public void Inicializar()
        {
            Limpiar();
            CargarDispositivos();
        }

        private void EstablecerDispositivoPredeterminado()
        {
            var dt = lueDispositivo.Properties.DataSource as DataTable;

            if (Utilerias.TablaTieneRows(dt) && dt.Rows.Count > 1)
            {
                lueDispositivo.EditValue = dt.Rows[0]["Id"];
                lueDispositivo.Enabled = true;
                txtUsuario.TabIndex = 0;
                txtUsuario.Focus();
                SendKeys.Send("{tab}");
            }
            if (Utilerias.TablaTieneRows(dt) && dt.Rows.Count == 1)
            {
                lueDispositivo.ItemIndex = 0;
                lueDispositivo.Enabled = false;
                txtUsuario.TabIndex = 0;
                txtUsuario.Focus();
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

        private void CargarPerfiles(object IdServidor)
        {
            try
            {
                var dt = DataHelper.ConsultarRegistro("perfil_hotspot", "IdServer", Utilerias.SafeToStringId(IdServidor), false);
                luePerfil.Properties.DataSource = dt;
                luePerfil.Properties.DisplayMember = "Descripcion";
                luePerfil.Properties.ValueMember = "Id";
                EstablecerRolePredeterminado();
            }
            catch (Exception ex)
            {
                DataHelper.AgregarBitacoraSistema(this.Name + ".CargarDispositivos", ex.Message, true);
            }
        }

        private void EstablecerRolePredeterminado()
        {
            var dt = luePerfil.Properties.DataSource as DataTable;

            if (Utilerias.TablaTieneRows(dt) && dt.Rows.Count > 1)
            {
                luePerfil.EditValue = dt.Rows[0]["Id"];
                luePerfil.Enabled = true;
                txtUsuario.TabIndex = 0;
                txtUsuario.Focus();
                SendKeys.Send("{tab}");
            }
            if (Utilerias.TablaTieneRows(dt) && dt.Rows.Count == 1)
            {
                luePerfil.ItemIndex = 0;
                luePerfil.Enabled = false;
                txtUsuario.TabIndex = 0;
                txtUsuario.Focus();
                SendKeys.Send("{tab}");
            }
            else
            {
                txtUsuario.Focus();
            }
        }

        private void ImprimirCredenciales()
        {
            try
            {
                if (Utilerias.IsNullOrEmpty(txtUsuario.Text))
                {
                    Utilerias.msjAlert("Escribir nombre de usuario.");
                    return;
                }

                if (Utilerias.IsNullOrEmpty(txtClave.Text))
                {
                    Utilerias.msjAlert("Escribir clave de usuario.");
                    return;
                }


                //var info = "Estos accesos tienen una duración de x días. Prohibido el uso de los mismos para el uso indebido de acuerdos a nuestras políticas.";
                var ds = hotspot.Helper.GenerateUserCredentialDataToPrint(txtUsuario.Text, txtClave.Text, "");

                hotspot.Helper.PrintUserCredential(ds, "Impresión de credenciales", PrintMethod.ConfiguredPrinterName);
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }


        private void GuardarUsuario(Boolean imprimir)
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


                if (licencia.HotSpot_Users != -1)
                {
                    if (DataHelper.CantRegistros("usuario_hotspot", "-1") >= licencia.HotSpot_Users)
                    {
                        Utilerias.msjAlert_TI(wOverlaySplash.lblLimit_mjs1);
                        return;
                    }
                }

                if (Utilerias.IsNullOrEmpty(lueDispositivo.EditValue))
                {
                    Utilerias.msjInfo("Seleccionar un dispositivo.");
                    lueDispositivo.Focus();
                    return;
                }


                if (Convert.ToBoolean(rgLimitarTiempo.EditValue))
                {
                    if (Utilerias.IsNullOrEmpty(rgTipoTiempo.EditValue))
                    {
                        Utilerias.msjInfo("Seleccionar el limite de tiempo.");
                        rgTipoTiempo.Focus();
                        return;
                    }
                }

                if (Utilerias.IsNullOrEmpty(txtUsuario.EditValue))
                {
                    Utilerias.msjInfo("Ingresar nombre de usuario");
                    txtUsuario.Focus();
                    return;
                }


                if (Utilerias.IsNullOrEmpty(txtClave.EditValue))
                {
                    Utilerias.msjInfo("Ingresar clave de usuario");
                    txtClave.Focus();
                    return;
                }


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
                        Utilerias.msjInfo("No se pudo conectar al dispositivo seleccionado.");
                        return;
                    }
                }

                if (mk == null || svr == null)
                    return;

                var tiempo = -1;
                var msj = "";

                if (Convert.ToBoolean(rgLimitarTiempo.EditValue))
                {
                    var multiplicador = 1;

                    if (Utilerias.SafeToString(rgTipoTiempo.EditValue).ToUpper() == "M")
                        multiplicador = 60;

                    if (Utilerias.SafeToString(rgTipoTiempo.EditValue).ToUpper() == "H")
                        multiplicador = 3600;

                    if (Utilerias.SafeToString(rgTipoTiempo.EditValue).ToUpper() == "D")
                        multiplicador = 86400;

                    tiempo = Convert.ToInt32(spMinutosNavegacion.Value) * multiplicador;
                }

                var HP_Id = mk.AddUser(txtUsuario.Text.Trim(), txtClave.Text.Trim(), tiempo, luePerfil.Text.Trim());
                mk.Close();

                if (Utilerias.EsValorValido(HP_Id))
                {
                    msj = "El usuario creado en el dispositivo.";

                    var resp = DataHelper.CrearRegistro_Tabla("usuario_hotspot",
                                                              "IdServer", svr.Id,
                                                              "IdPerfil", luePerfil.EditValue,
                                                              "Usuario", Crypto.Encrypt(txtUsuario.Text),
                                                              "Clave", Crypto.Encrypt(txtClave.Text),
                                                              "Tiempo", tiempo,
                                                              "Comentario", mbComentario.Text,
                                                              "HP_Perfil", luePerfil.Text,
                                                              "HP_Id", HP_Id,
                                                              "TipoTiempo", rgTipoTiempo.EditValue
                                                             );

                    if (!resp)
                    {
                        msj = "El usuario ha sido creado en el dispositivo, no se ha podido crear la bitacora.";
                    }

                    if (imprimir)
                    {
                        var cf_impr_cred = Utilerias.Valor_SI(DataHelper.ObtenerConfiguracion(enumConfig.SYS_PRINT_USER_CRED_WIFI, false));

                        if (cf_impr_cred)
                        {
                            ImprimirCredenciales();
                        }
                    }

                    Utilerias.msjInfo(msj);
                    if (Utilerias.Valor_SI(switchLimpiar.EditValue))
                        Limpiar();

                    lueDispositivo.Focus();
                    EstablecerDispositivoPredeterminado();
                }
                else
                {
                    Utilerias.msjAlert("No se pudo agregar el usuario.");
                }
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }


        private void txtUsuario_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //generar automaticamente letra y numero
            txtUsuario.EditValue = generar();
        }

        private void rgLimitarTiempo_EditValueChanged(object sender, EventArgs e)
        {
            var status = Convert.ToBoolean(Utilerias.NullValue(rgLimitarTiempo.EditValue, false));
            spMinutosNavegacion.Enabled = status;
            rgTipoTiempo.Enabled = status;
        }

        private void spMinutosNavegacion_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (Utilerias.EsValorValido(e.NewValue) && Convert.ToDecimal(e.NewValue) < 0)
            {
                e.Cancel = true;
            }
        }

        private void lueDispositivo_EditValueChanged(object sender, EventArgs e)
        {
            luePerfil.EditValue = null;
            CargarPerfiles(lueDispositivo.EditValue);
        }

        private void txtClave_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //generar automaticamente letra y numero
            txtClave.EditValue = generar();
        }

        private void btnGuardar_Click(object sender, EventArgs e) => GuardarUsuario(false);

        private void btnImprimir_Click(object sender, EventArgs e) => GuardarUsuario(true);
    }
}