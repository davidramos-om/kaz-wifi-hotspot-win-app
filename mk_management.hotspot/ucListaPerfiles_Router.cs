using System;
using System.Data;
using System.Drawing;
using System.Linq;
using DevExpress.XtraEditors;
using mk_management.common;

namespace mk_management.hotspot
{
    public partial class ucListaPerfiles_Router : DevExpress.XtraEditors.XtraUserControl
    {
        public ucListaPerfiles_Router()
        {
            InitializeComponent();
            tlBarGrupoConexiones.Items.Clear();
            new common.MenuItemGridViews(ref gvdatos, "Perfiles en Dispositivos");
        }


        private void CargarConexiones()
        {
            try
            {
                tlBarGrupoConexiones.Items.Clear();

                var idServidorPredeterminado = "";

                var dt = DataHelper.ConsultarRegistro("server", "Id", "");

                if (Utilerias.TablaTieneRows(dt))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        if (Utilerias.SafeToString(r["Predeterminado"]) == "S")
                            idServidorPredeterminado = Utilerias.SafeToString(r["Id"]);

                        var tl = new TileItem();
                        tl.Text = Utilerias.SafeToString(Utilerias.NullValue(r["Descripcion"], r["IP"]));
                        tl.ItemSize = TileItemSize.Wide;
                        tl.TextAlignment = TileItemContentAlignment.MiddleCenter;
                        tl.TextShowMode = TileItemContentShowMode.Always;
                        tl.AppearanceItem.Normal.BackColor = Utilerias.GetWebColor(Apariencia.BgTileViewColor);
                        tl.AppearanceItem.Hovered.BackColor = Color.FromArgb(52, 73, 94);
                        tl.AppearanceItem.Normal.BorderColor = Color.Transparent;

                        tl.Tag = r;
                        tl.ItemClick += TlConexion_ItemClick;

                        tlBarGrupoConexiones.Items.Add(tl);
                        this.Refresh();
                    }

                    if (Utilerias.EsValorValido(idServidorPredeterminado))
                    {
                        using (var w = Utilerias.WaitWindow(null, "Conectando a dispositivo predeterminado"))
                        {
                            CargarPerfiles(idServidorPredeterminado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DataHelper.AgregarBitacoraSistema(this.Name + ".CargarConexiones", ex.Message, true);
            }
        }

        private void TlConexion_ItemClick(object sender, TileItemEventArgs e)
        {
            var tl = sender as TileItem;

            if (tl == null)
                return;

            if (!(tl.Tag is DataRow row))
                return;

            CargarPerfiles(Utilerias.SafeToStringId(row["Id"]));

        }

        public void Inicializar()
        {
            CargarConexiones();
        }

        private void CargarPerfiles(string IdServidor)
        {
            try
            {
                using (var w = Utilerias.ShowOverlay(this, "Conectando"))
                {
                    grdDatos.DataSource = null;
                    layoutControlGroup1.Text = "Perfiles Activos";
                    this.Refresh();

                    var svr = hotspot.Helper.ObtenerDatosServidor(IdServidor);

                    if (svr.TieneError)
                    {
                        Utilerias.msjAlert(svr.ErrorMsj);
                        return;
                    }

                    if (!Utilerias.PingHost(svr.IP))
                    {
                        Utilerias.msjInfo("No hay conexión al dispositivo.");
                        return;
                    }

                    var mk = new MK(svr.IP, svr.Puerto, svr.VersionSO);

                    if (!mk.Login(svr.Usuario, svr.Clave))
                    {
                        mk.Close();
                        Utilerias.msjInfo("No se pudo iniciar sesion.");
                        return;
                    }

                    var source = mk.GetProfiles();
                    mk.Close();

                    if (hotspot.Helper.ProcesoMK_TieneErrores(source.ToArray()))
                    {
                        var errores = hotspot.Helper.ProcesoMK_ObtenerErrores(source.ToArray());
                        mk_management.common.Utilerias.msjAlert("No se pudo obtener." + Environment.NewLine + Environment.NewLine + errores);
                        return;
                    }

                    var dt = hotspot.Helper.DataTableFromMKArray(source);

                    layoutControlGroup1.Text = $"Mostrando Perfiles Activos en  : {svr.Nombre} ({svr.IP })";

                    grdDatos.DataSource = dt;
                    //gvdatos.PopulateColumns();
                    gvdatos.OptionsView.ColumnAutoWidth = false;

                    if (gvdatos.Columns.Count > 0)
                        Utilerias.ConfigurarGrid_Totales(gvdatos, gvdatos.Columns[0].FieldName, gvdatos.Columns[0].FieldName);

                    gvdatos.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }
    }
}