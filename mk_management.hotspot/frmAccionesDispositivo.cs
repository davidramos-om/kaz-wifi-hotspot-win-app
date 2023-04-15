using DevExpress.XtraEditors;
using System;
using mk_management.common;
using mk_management.hotspot.Model;

namespace mk_management.hotspot
{
    public partial class FrmAccionesDispositivo : XtraForm
    {
        private readonly string ServerId = "";
        private ServerInfo server = null;

        public FrmAccionesDispositivo(string _serverId)
        {
            InitializeComponent();
            this.Icon = Utilerias.ObtenerIconoApp();
            ServerId = _serverId;
            EstablecerTituloForm();
        }

        private void EstablecerTituloForm() => Text = $"Opciones avanzadas del dispositivo : {server?.IP}:{server?.Puerto} / {server?.Nombre}";

        private void CargarDatos()
        {
            try
            {
                Refresh();

                var dt = DataHelper.ConsultarRegistro("server", "Id", ServerId);

                if (Utilerias.TablaTieneRows(dt))
                {
                    server = new ServerInfo
                    {
                        Id = ServerId,
                        Nombre = Utilerias.SafeToString(dt.Rows[0]["Descripcion"]),
                        Clave = Utilerias.SafeToString(dt.Rows[0]["Clave"]),
                        Usuario = Utilerias.SafeToString(dt.Rows[0]["Usuario"]),
                        IP = Utilerias.SafeToString(dt.Rows[0]["IP"]),
                        Puerto = Utilerias.ToInt(dt.Rows[0]["Puerto"]),
                        VersionSO = Utilerias.SafeToString(dt.Rows[0]["OsVersion"])
                    };

                    EstablecerTituloForm();

                    if (Utilerias.EsValorValido(server.Clave))
                        server.Clave = Crypto.Decrypt(server.Clave);

                    if (Utilerias.EsValorValido(server.Usuario))
                        server.Usuario = Crypto.Decrypt(server.Usuario);
                }
            }
            catch
            {
                Utilerias.msjAlert_TI("Ocurrió un problema al obtener los datos del dispositivo");
            }
        }

        private void frmAccionesDispositivo_Load(object sender, EventArgs e) => CargarDatos();

        private void ReiniciarDispositivo()
        {
            try
            {
                if (server == null)
                    return;

                if (!Utilerias.msjConfirm("Esta acción desconectará a todos los usuarios activos mientras se realiza el reinicio.\n\n¿Esta seguro de reiniciar el dispositivo?"))
                    return;

                var mk = new MK(server.IP, server.Puerto, server.VersionSO);
                var login = mk.Login(server.Usuario, server.Clave);

                if (!login)
                {
                    mk.Close();
                    Utilerias.msjAlert("No se pudo realizar la conexión con el dispositivo.");
                    return;
                }

                mk.reboot();
                mk.Close();
                Utilerias.msjInfo("Se ha enviado la petición de reinicio al dispositivo, por favor espere mientras se ejecuta.");
            }
            catch
            {
                Utilerias.msjAlert_TI("No se pudo conectar al dispositivo");
            }
        }

        private void AbrirFormCookies()
        {
            try
            {
                if (server == null)
                    return;

                var frm = new frmAccionesDispositivo_Cookies(server);
                frm.ShowDialog();
            }
            catch
            {
                Utilerias.msjAlert_TI("No se pudo conectar al dispositivo");
            }
        }

        private void galleryControl1_Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            if (Utilerias.SafeToString(e?.Item?.Tag) == "reboot")
                ReiniciarDispositivo();

            if (Utilerias.SafeToString(e?.Item?.Tag) == "cookies")
                AbrirFormCookies();
        }
    }
}