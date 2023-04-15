using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mk_management.common
{
    public partial class ucInfoComp : DevExpress.XtraEditors.XtraUserControl
    {
        const int ROW_INF_EM = 250;
        const int COL_INFO_EM = 8;

        public ucInfoComp()
        {
            InitializeComponent();
        }


        private void Limpiar()
        {
            txtNombre.EditValue = "";
            txtRtn.EditValue = "";
            txtCorreo.EditValue = "";
            pcLogo.EditValue = null;
        }

        public void Inicializar()
        {
            try
            {
                txtCorreo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                //txtCorreo.Properties.Mask.EditMask = @"(\w|[\.\-])+@(\w|[\-]+\.)*(\w|[\-]){2,63}\.[a-zA-Z]{2,4}\.[a-zA-Z]{2,4}"; 
                txtCorreo.Properties.Mask.EditMask = @"[0-9.a-zA-Z_-]*\@[0-9.a-zA-Z_-]*\.[a-zA-Z]+{2,100}";
                txtCorreo.Properties.Mask.UseMaskAsDisplayFormat = true;

                Limpiar();
                var info = wOverlaySplash.GetCompanyInformation(common.ConfigurationSettings.Obtener_CadenaConexion());

                if (info.IsValid)
                {
                    txtNombre.EditValue = info.Nombre;
                    txtRtn.EditValue = info.RTN;
                    txtCorreo.EditValue = info.Correo;

                    txtNombre.Properties.ReadOnly = true;
                    txtRtn.Properties.ReadOnly = true;
                    txtCorreo.Properties.ReadOnly = true;

                }
                else
                {
                    txtNombre.EditValue = DataHelper.ObtenerConfiguracion(enumConfig.COM_NAME, false);
                    txtRtn.EditValue = DataHelper.ObtenerConfiguracion(enumConfig.COM_RTN, false);
                    txtCorreo.EditValue = info.Correo;

                    txtNombre.Properties.ReadOnly = false;
                    txtRtn.Properties.ReadOnly = false;
                    txtCorreo.Properties.ReadOnly = false;
                }

                mbDir.EditValue = common.DataHelper.ObtenerConfiguracion(enumConfig.COM_DIR, false);
                mbInfoCtt.EditValue = common.DataHelper.ObtenerConfiguracion(enumConfig.COM_CONTACTS, false);

                var pic_size_mode = Convert.ToInt32(Utilerias.NullValue(common.DataHelper.ObtenerConfiguracion(enumConfig.COM_LOGO_SIZE_MODE, false), 0));
                pcLogo.Properties.SizeMode = (DevExpress.XtraEditors.Controls.PictureSizeMode)pic_size_mode;
                pcLogo.EditValue = common.DataHelper.ObtenerConfiguracion(enumConfig.COM_LOGO, true);
            }
            catch (Exception ex)
            {

                Utilerias.msjAlert_TI(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate())
                    return;

                using (var w = Utilerias.ShowOverlay(this, "Guardando..."))
                {

                    var cf_key_logo = enumConfig.COM_LOGO.ToString();
                    var cf_key_nombre = enumConfig.COM_NAME.ToString();
                    var cf_key_dir = enumConfig.COM_DIR.ToString();
                    var cf_key_contacts = enumConfig.COM_CONTACTS.ToString();
                    var cf_key_rtn = enumConfig.COM_RTN.ToString();
                    var cf_key_logo_sm = enumConfig.COM_LOGO_SIZE_MODE.ToString();

                    var res = DataHelper.ActualizarRegistro_Tabla("sys_config", "config", cf_key_nombre, "value", txtNombre.Text);
                    if (!res)
                        DataHelper.CrearRegistro_Tabla("sys_config", "config", cf_key_nombre, "value", txtNombre.Text, "value_bin", null, "Activo", true);

                    res = DataHelper.ActualizarRegistro_Tabla("sys_config", "config", cf_key_dir, "value", mbDir.Text);
                    if (!res)
                        DataHelper.CrearRegistro_Tabla("sys_config", "config", cf_key_dir, "value", mbDir.Text, "value_bin", null, "Activo", true);

                    res = DataHelper.ActualizarRegistro_Tabla("sys_config", "config", cf_key_contacts, "value", mbInfoCtt.Text);
                    if (!res)
                        DataHelper.CrearRegistro_Tabla("sys_config", "config", cf_key_contacts, "value", mbInfoCtt.Text, "value_bin", null, "Activo", true);

                    res = DataHelper.ActualizarRegistro_Tabla("sys_config", "config", cf_key_rtn, "value", txtRtn.Text);
                    if (!res)
                        DataHelper.CrearRegistro_Tabla("sys_config", "config", cf_key_rtn, "value", txtRtn.Text, "value_bin", null, "Activo", true);

                    res = DataHelper.ActualizarRegistro_Tabla("sys_config", "config", cf_key_logo, "value_bin", pcLogo.EditValue);
                    if (!res)
                        DataHelper.CrearRegistro_Tabla("sys_config", "config", cf_key_logo, "value",null, "value_bin", pcLogo.EditValue, "Activo", true);

                    res = DataHelper.ActualizarRegistro_Tabla("sys_config", "config", cf_key_logo_sm, "value", (int)pcLogo.Properties.SizeMode);
                    if (!res)
                        DataHelper.CrearRegistro_Tabla("sys_config", "config", cf_key_logo_sm, "value", null, "value_bin", (int)pcLogo.Properties.SizeMode, "Activo", true);

                    Utilerias.msjInfo("Los datos han sido guardados.");
                    //wOverlaySplash.SyncRouteros(cnn);
                }
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }
    }
}
