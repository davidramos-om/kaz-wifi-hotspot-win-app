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
    public partial class frmAgregarUsuarioSistema : DevExpress.XtraEditors.XtraForm
    {
        public const string MASCARA_USUARIO = @"(\p{Lu}|_|[0-9])+";
        string IdUsuario;

        public frmAgregarUsuarioSistema()
        {
            InitializeComponent();
            this.Icon = Utilerias.ObtenerIconoApp();
            LimpiarDatos();

            txtUsuario.Properties.CharacterCasing = CharacterCasing.Upper;
            txtUsuario.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            txtUsuario.Properties.Mask.EditMask = MASCARA_USUARIO;//Letras,numeros y guion bajo
        }

        public void CargarPerfiles()
        {
            try
            {
                var dt = DataHelper.ConsultarRegistro("perfil_sistema", "Id", "", false);

                luePerfil.Properties.DisplayMember = "Nombre";
                luePerfil.Properties.ValueMember = "Id";
                luePerfil.Properties.DataSource = dt;
            }
            catch (Exception ex)
            {
                DataHelper.AgregarBitacoraSistema(this.Name + ".CargarPerfiles", ex.Message, true);
            }
        }

        private void CargarDatos(string Id)
        {
            try
            {
                LimpiarDatos();
                this.Refresh();

                var dt = DataHelper.ConsultarRegistro("usuario_sistema", "Id", Id);

                if (Utilerias.TablaTieneRows(dt))
                {
                    IdUsuario = Id;
                    txtNombre.EditValue = dt.Rows[0]["Nombre"];
                    txtApellido.EditValue = dt.Rows[0]["Apellido"];
                    txtUsuario.EditValue = dt.Rows[0]["Usuario"];
                    luePerfil.EditValue = dt.Rows[0]["IdPerfil"];

                    var clave = Utilerias.SafeToString(dt.Rows[0]["Clave"]);
                    var deClave = Crypto.Decrypt(clave);

                    if (deClave.Contains("|"))
                        deClave = deClave.Split('|')[0];
                    else
                        deClave = "";

                    txtClave.EditValue = deClave;
                }
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }

        public void LimpiarDatos()
        {
            IdUsuario = "";
            txtNombre.EditValue = null;
            txtApellido.EditValue = null;
            txtClave.EditValue = null;
            txtUsuario.EditValue = null;
            luePerfil.EditValue = null;
            Utilerias.LimpiarValidationProvider(dxValidationProvider1);
        }

        public void Inicializar(string IdUsuario)
        {
            CargarPerfiles();
            CargarDatos(IdUsuario);
        }

        private void txtClave_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtClave.Properties.UseSystemPasswordChar = !txtClave.Properties.UseSystemPasswordChar;

            if (txtClave.Properties.Buttons.Count > 0)
                txtClave.Properties.Buttons[0].Caption = txtClave.Properties.UseSystemPasswordChar ? "Mostrar" : "Ocultar";
        }

        private void frmAgregarUsuarioSistema_Load(object sender, EventArgs e)
        {
            txtClave.Properties.UseSystemPasswordChar = false;//hacer el cambio al llamar al evento
            txtClave_ButtonClick(null, null);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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

                if (licencia.App_Users != -1)
                {
                    if (DataHelper.CantRegistros("usuario_sistema", IdUsuario) >= licencia.App_Users)
                    {
                        Utilerias.msjAlert_TI(wOverlaySplash.lblLimit_mjs1);
                        return;
                    }
                }

                if (!dxValidationProvider1.Validate())
                    return;

                if (DataHelper.ExisteDescRegistro("usuario_sistema", "Id", IdUsuario, "Usuario", txtUsuario.Text))
                {
                    Utilerias.msjAlert("El nombre de usuario ya existe, intente con otro.");
                    txtUsuario.Focus();
                    return;
                }

                var claveEncriptada = "";

                if (Utilerias.EsValorValido(txtClave.EditValue))
                    claveEncriptada = Crypto.Encrypt(txtClave.Text + "|" + txtUsuario.Text);


                if (Utilerias.EsValorValido(IdUsuario))
                {
                    var resp = common.DataHelper.ActualizarRegistro_Tabla("usuario_sistema",
                                                                          "Id", IdUsuario,
                                                                          "Nombre", txtNombre.Text,
                                                                          "Apellido", txtApellido.Text,
                                                                          "Usuario", txtUsuario.Text,
                                                                          "Clave", claveEncriptada,
                                                                          "IdPerfil", luePerfil.EditValue
                                                                          );

                    if (resp)
                    {
                        Utilerias.msjInfo("Los datos han sido guardados.");
                        LimpiarDatos();
                    }
                    else
                        Utilerias.msjAlert("No se pudo guardar los datos.");
                }
                else
                {
                    var resp = common.DataHelper.CrearRegistro_Tabla("usuario_sistema",
                                                                     "Nombre", txtNombre.Text,
                                                                     "Apellido", txtApellido.Text,
                                                                     "Usuario", txtUsuario.Text,
                                                                     "Clave", claveEncriptada,
                                                                     "IdPerfil", luePerfil.EditValue
                                                                    );

                    if (resp)
                    {
                        Utilerias.msjInfo("Los datos han sido guardados.");
                        LimpiarDatos();
                    }
                    else
                        Utilerias.msjAlert("No se pudo guardar los datos.");
                }
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }
    }
}
