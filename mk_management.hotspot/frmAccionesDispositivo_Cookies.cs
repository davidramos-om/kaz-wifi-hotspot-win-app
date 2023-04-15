using DevExpress.XtraEditors;
using mk_management.common;
using mk_management.hotspot.Model;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace mk_management.hotspot
{
    public partial class frmAccionesDispositivo_Cookies : XtraForm
    {
        private ServerInfo server = null;
        private MK mk = null;

        public frmAccionesDispositivo_Cookies(ServerInfo _server)
        {
            InitializeComponent();
            this.Icon = Utilerias.ObtenerIconoApp();
            server = _server;
            EstablecerTituloForm();
        }

        private void EstablecerTituloForm() => Text = $"Opciones avanzadas del dispositivo : {server?.IP}:{server?.Puerto} / {server?.Nombre}";

        private void EliminarCookie(int index)
        {
            try
            {
                mk.removeCookie(index - 1);
            }
            catch
            {
                Utilerias.msjAlert($"No se puedo eliminar la cookie #{index}");
            }
        }

        public BindingList<Cookie> GetDataSource()
        {
            try
            {
                if (server == null)
                    return null;

                using (var w = Utilerias.ShowOverlay(this, "Conectanse al dispositivo"))
                {
                    mk = new MK(server.IP, server.Puerto, server.VersionSO);

                    if (!mk.Login(server.Usuario, server.Clave))
                    {
                        mk.Close();
                        Utilerias.msjInfo("No se pudo conectar al dispositivo.");
                        return null;
                    }


                    w.SetCaption("Obteniendo datos");
                    var cookies = mk.getCookies();
                    var cookies_dt = hotspot.Helper.DataTableFromMKArray(cookies);

                    if (!Utilerias.TablaTieneRows(cookies_dt))
                        return null;

                    BindingList<Cookie> result = new BindingList<Cookie>();
                    var contador = 1;
                    foreach (DataRow r in cookies_dt.Rows)
                    {
                        result.Add(new Cookie()
                        {

                            Num = contador++,
                            Id = Utilerias.SafeToString(r[".id"]),
                            Usuario = Utilerias.SafeToString(r["user"]),
                            MacAddress = Utilerias.SafeToString(r["mac_address"]),
                            ExpiraEn = Utilerias.SafeToString(r["expires_in"]),
                            MacCookie = Utilerias.SafeToString(r["mac_cookie"])
                        });
                    }

                    return result;
                }
            }
            catch
            {
                Utilerias.msjAlert_TI("No se pudo conectar al dispositivo");
                return null;
            }
        }

        private void CargarDatos() => gridControl.DataSource = GetDataSource();

        void windowsUIButtonPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {

            var accion = Utilerias.SafeToString(e?.Button?.Properties?.Tag);

            switch (accion)
            {
                case "eliminar_item":
                    {
                        if (gridView.FocusedRowHandle < 0)
                            break;

                        var selected = gridView.GetFocusedRowCellValue("Num");

                        if (!Utilerias.isNumber(selected))
                            break;

                        using (var w = Utilerias.ShowOverlay(this, "Eliminando"))
                        {
                            EliminarCookie((int)selected);
                            CargarDatos();
                        }

                        break;
                    }
                case "eliminar_todo":
                    {
                        if (!(gridControl.DataSource is BindingList<Cookie> bs))
                            break;

                        foreach (var item in bs) 
                            EliminarCookie(item.Num);

                        CargarDatos();
                        break;
                    }
                case "actualizar":
                    {
                        CargarDatos();
                        break;
                    }
            }
        }

        private void frmAccionesDispositivo_Cookies_Shown(object sender, EventArgs e) => CargarDatos();

        private void frmAccionesDispositivo_Cookies_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mk != null)
                mk.Close();
        }
    }

    public class Cookie
    {
        public int Num { get; set; }
        public string Id { get; set; }
        public string Usuario { get; set; }
        public string MacAddress { get; set; }
        public string ExpiraEn { get; set; }
        public string MacCookie { get; set; }
    }

}
