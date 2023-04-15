using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using mk_management.common;
namespace mk_management.hotspot
{
    internal partial class frmAgregarDispositivo : DevExpress.XtraEditors.XtraForm
    {
        const int PUERTO_PREDETERMINADO = 8728;

        string IdServidor = "";

        public frmAgregarDispositivo()
        {
            InitializeComponent();
            this.Icon = common.Utilerias.ObtenerIconoApp();


            CargarVersiones();
            btnOpciones.Enabled = false;
        }

        public frmAgregarDispositivo(string _IdServidor)
        {
            InitializeComponent();
            this.Icon = common.Utilerias.ObtenerIconoApp();

            CargarVersiones();

            IdServidor = _IdServidor;
            btnOpciones.Enabled = Utilerias.EsValorValido(_IdServidor);
        }


        private void CargarVersiones()
        {
            lueVersion.Properties.Items.Clear();
            var versiones = new MK().AllVersions;
            lueVersion.Properties.Items.AddRange(versiones);
        }

        private bool ConexionValida(bool mostrarMsj)
        {
            try
            {
                if (!dxValidationProvider1.Validate())
                    return false;

                var puerto = Utilerias.EsValorValido(txtPuerto.EditValue) ? Convert.ToInt32(txtPuerto.EditValue) : PUERTO_PREDETERMINADO;

                using (var w = Utilerias.ShowOverlay(this, "Conectando"))
                {
                    var mk = new MK(txtIP.Text, puerto, lueVersion.Text);

                    if (mk.Login(txtUsuario.Text, txtClave.Text))
                    {
                        mk.Close();
                        if (mostrarMsj)
                            Utilerias.msjInfo("Conexión establecida.");

                        return true;
                    }
                    else
                    {
                        mk.Close();
                        if (mostrarMsj)
                            Utilerias.msjError("No se pudo establecer la conexión");

                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (mostrarMsj)
                    Utilerias.msjError(ex.Message);

                return false;
            }
        }

        public void Inicializar(string Id)
        {
            CargarDatos(Id);
        }

        public void LimpiarDatos()
        {
            IdServidor = "";
            txtNombre.EditValue = null;
            txtClave.EditValue = null;
            txtUsuario.EditValue = null;
            txtIP.EditValue = null;
            txtPuerto.EditValue = null;
            chkPredeterminado.Checked = false;
            lueVersion.EditValue = null;
            btnOpciones.Enabled = false;
        }

        private void CargarDatos(string Id)
        {
            try
            {
                LimpiarDatos();
                this.Refresh();

                //var dt = DataHelper.Obt_PrimerReg("server", "Id");
                var dt = DataHelper.ConsultarRegistro("server", "Id", Id);

                if (Utilerias.TablaTieneRows(dt))
                {
                    txtNombre.EditValue = dt.Rows[0]["Descripcion"];
                    txtClave.EditValue = dt.Rows[0]["Clave"];
                    txtUsuario.EditValue = dt.Rows[0]["Usuario"];
                    txtIP.EditValue = dt.Rows[0]["IP"];
                    txtPuerto.EditValue = dt.Rows[0]["Puerto"];
                    IdServidor = Utilerias.SafeToString(dt.Rows[0]["Id"]);
                    lueVersion.EditValue = Utilerias.SafeToString(dt.Rows[0]["OsVersion"]);

                    chkPredeterminado.Checked = Utilerias.Valor_SI(dt.Rows[0]["Predeterminado"]);
                    btnOpciones.Enabled = true;

                    if (Utilerias.EsValorValido(txtClave.EditValue))
                        txtClave.EditValue = Crypto.Decrypt(txtClave.Text);

                    if (Utilerias.EsValorValido(txtUsuario.EditValue))
                        txtUsuario.EditValue = Crypto.Decrypt(txtUsuario.Text);
                }
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }

        private void BtnConectar_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate())
                return;


            if (!Utilerias.msjConfirm("¿Desea probar la conexión"))
                return;

            this.Refresh();
            ConexionValida(true);
        }

        private void TxtClave_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtClave.Properties.UseSystemPasswordChar = !txtClave.Properties.UseSystemPasswordChar;

            if (txtClave.Properties.Buttons.Count > 0)
                txtClave.Properties.Buttons[0].Caption = txtClave.Properties.UseSystemPasswordChar ? "Mostrar" : "Ocultar";
        }

        private void UcRouterParam_Load(object sender, EventArgs e)
        {
            txtClave.Properties.UseSystemPasswordChar = false;//hacer el cambio al llamar al evento
            TxtClave_ButtonClick(null, null);
        }


        private void BtnGuardar_Click(object sender, EventArgs e)
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

                if (licencia.HotSpot_Devices != -1)
                {
                    if (DataHelper.CantRegistros("server", IdServidor) >= licencia.HotSpot_Devices)
                    {
                        Utilerias.msjAlert_TI(wOverlaySplash.lblLimit_mjs1);
                        return;
                    }
                }

                if (!dxValidationProvider1.Validate())
                    return;

                if (Utilerias.msjConfirm("¿Desea comprobar la conexión?"))
                {
                    if (!ConexionValida(true))
                        return;
                }

                var pass = "";
                var user = "";

                if (Utilerias.EsValorValido(txtClave.EditValue))
                    pass = Crypto.Encrypt(txtClave.Text);

                if (Utilerias.EsValorValido(txtUsuario.EditValue))
                    user = Crypto.Encrypt(txtUsuario.Text);

                if (Utilerias.EsValorValido(IdServidor))
                {
                    if (chkPredeterminado.Checked)
                        ActualizarValorPredeterminado();

                    var puerto = Utilerias.EsValorValido(txtPuerto.EditValue) ? Convert.ToInt32(txtPuerto.EditValue) : PUERTO_PREDETERMINADO;

                    var resp = common.DataHelper.ActualizarRegistro_Tabla("server",
                                                                         "Id", IdServidor,
                                                                         "Descripcion", txtNombre.Text,
                                                                         "IP", txtIP.Text,
                                                                         "Puerto", puerto,
                                                                         "Usuario", user,
                                                                         "Clave", pass,
                                                                         "OsVersion", lueVersion.Text,
                                                                         "Predeterminado", (chkPredeterminado.Checked ? "S" : "N")
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
                    if (chkPredeterminado.Checked)
                        ActualizarValorPredeterminado();

                    var resp = common.DataHelper.CrearRegistro_Tabla("server",
                                                                        "Descripcion", txtNombre.Text,
                                                                        "IP", txtIP.Text,
                                                                        "Puerto", txtPuerto.Text,
                                                                        "Usuario", user,
                                                                        "Clave", pass,
                                                                        "OsVersion", lueVersion.Text,
                                                                        "Predeterminado", (chkPredeterminado.Checked ? "S" : "N")
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

        private void ActualizarValorPredeterminado()
        {
            try
            {
                common.DataHelper.ActualizarDispositivosPredeterminados();
            }
            catch (Exception ex)
            {
                Utilerias.msjError("No se pudo actualizar los demás dispositivos predeterminados : " + ex.Message);
            }
        }

        private void txtPuerto_DoubleClick(object sender, EventArgs e)
        {
            if (Utilerias.IsNullOrEmpty(txtPuerto.Text))
            {
                txtPuerto.Text = PUERTO_PREDETERMINADO.ToString();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpciones_Click(object sender, EventArgs e)
        {
            if (Utilerias.IsNullOrEmpty(this.IdServidor))
                return;

            var frmOpciones = new FrmAccionesDispositivo(this.IdServidor);
            frmOpciones.ShowDialog();
        }
    }
}
