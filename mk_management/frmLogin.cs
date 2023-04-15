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

namespace mk_management
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        private bool _isLogued = false;

        public frmLogin(Icon icono)
        {
            InitializeComponent();
            this.Icon = icono;

            txtUsuario.Properties.CharacterCasing = CharacterCasing.Upper;
            txtUsuario.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            txtUsuario.Properties.Mask.EditMask = frmAgregarUsuarioSistema.MASCARA_USUARIO;//Letras,numeros y guion bajo

            //txtUsuario.Text = "ADMIN";
            //txtClave.Text = "mk_admin";

            btnIniciar.Focus();
        }


        public bool LoginSuccessFull { get { return _isLogued; } }


        public string UsuarioAutenticado { get { return _isLogued ? txtUsuario.Text : ""; } }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            _isLogued = false;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Utilerias.IsNullOrEmpty(txtUsuario.EditValue))
                    return;

                if (Utilerias.IsNullOrEmpty(txtClave.EditValue))
                    return;

                var pass = Crypto.Encrypt(txtClave.Text + "|" + txtUsuario.Text);

                var query = $@" select u.Nombre,u.Apellido,u.Id,u.Usuario 
                                  from usuario_sistema u 
                                 where u.Usuario = '{txtUsuario.EditValue}' 
                                   and u.Clave ='{pass}' 
                                   and u.Activo = 1 ";

                var cnn = ConfigurationSettings.Obtener_CadenaConexion();
                var dtUser = MDB.FillDataTable(cnn, query);

                if (Utilerias.TablaTieneRows(dtUser))
                {
                    var link = ConfigurationSettings.Obtener_CadenaConexion();
                    var comp = wOverlaySplash.GetCompanyInformation(link);

                    Modulo.IdAplicacion = "R2019-03";
                    Modulo.TokenAp = "EK2Swy0YXX4ZkNraqG5ZXHfsK1wog0k8";

                    Modulo.IdUsuario = Utilerias.SafeToString(dtUser.Rows[0]["Usuario"]);
                    Modulo.Usuario = Utilerias.SafeToString(dtUser.Rows[0]["Usuario"]);
                    Modulo.NombreUsuario = Utilerias.SafeToString(dtUser.Rows[0]["Nombre"]) + " " +
                                           Utilerias.SafeToString(dtUser.Rows[0]["Apellido"]);


                    Modulo.NombreEmpresa = comp.Nombre;
                    common.Link.SetData(cnn, comp.Nombre, Modulo.IdAplicacion, Modulo.IdUsuario);
                    hotspot.Link.SetData(cnn, comp.Nombre, Modulo.IdAplicacion, Modulo.IdUsuario);

                    _isLogued = true;
                    this.Close();
                }
                else
                {
                    txtClave.Focus();
                    Utilerias.msjInfo("Usuario o clave incorrecta.");
                }

            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }

        private void txtClave_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtClave.Properties.UseSystemPasswordChar = !txtClave.Properties.UseSystemPasswordChar;

            if (txtClave.Properties.Buttons.Count > 0)
                txtClave.Properties.Buttons[0].Caption = txtClave.Properties.UseSystemPasswordChar ? "Mostrar" : "Ocultar";
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtClave.Properties.UseSystemPasswordChar = false;//hacer el cambio al llamar al evento
            txtClave_ButtonClick(null, null);
            btnIniciar.Focus();
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIniciar.Focus();
                this.Refresh();
                btnIniciar.PerformClick();
            }

        }

        private void imgLogo_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}