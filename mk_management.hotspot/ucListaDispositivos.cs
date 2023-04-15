using System;
using System.Data;
using mk_management.common;

namespace mk_management.hotspot
{
    public partial class ucListaDispositivos : DevExpress.XtraEditors.XtraUserControl
    {
        public ucListaDispositivos()
        {
            InitializeComponent();
        }

        public void Inicializar()
        {
            ConfigurarApariencia();
            CargarDispositivos();
        }

        private void ConfigurarApariencia()
        {
            common.Apariencia.SetTileViewColor(tvDatos);
            common.Apariencia.SetGroupBoxPanelColor(layoutControlGroup1);

            this.Refresh();
        }

        private void CargarDispositivos()
        {
            try
            {
                using (var w = Utilerias.ShowOverlay(this, "Consultando"))
                {
                    var dt = DataHelper.ConsultarRegistro("server", "Id", "");
                    dt.Columns.Add(colicono.FieldName, typeof(object));

                    grdDatos.DataSource = dt;

                    if (Utilerias.TablaTieneRows(dt))
                    {
                        var img = mk_management.hotspot.Properties.Resources.mikro;

                        foreach (DataRow r in dt.Rows)
                        {
                            r[colicono.FieldName] = img;

                            var usuario = Utilerias.SafeToString(r[colUsuario.FieldName]);

                            if (Utilerias.EsValorValido(usuario))
                                r[colUsuario.FieldName] = Crypto.Decrypt(usuario);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }

        private void wBtnAgregar_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (Utilerias.SafeToString(e.Button.Properties.Tag) == "Add")
            {
                var f = new frmAgregarDispositivo();
                f.ShowDialog();
                CargarDispositivos();
            }

            if (Utilerias.SafeToString(e.Button.Properties.Tag) == "Ver")
            {
                using (var w = Utilerias.ShowOverlay(this))
                {
                    CargarDispositivos();
                }
            }
        }

        private void tvDatos_ContextButtonClick(object sender, DevExpress.Utils.ContextItemClickEventArgs e)
        {
            try
            {
                if (!(sender is DevExpress.XtraGrid.Views.Tile.TileView view))
                    return;

                if (!(e.DataItem is DevExpress.XtraGrid.Views.Tile.TileViewItem tlItem))
                    return;

                var rowHandle = tlItem.RowHandle;
                view.FocusedRowHandle = rowHandle;

                var row = view.GetFocusedDataRow();

                if (row == null)
                    return;

                if (e.Item != null && e.Item.Name == "cbEliminar")
                {
                    if (Utilerias.msjConfirm($"¿Desea eliminar el siguiente registro ?\n\n\n{ row[colDescripcion.FieldName]}\n\n\n"))
                    {
                        var idServidor = row[colId.FieldName];
                        var resp = common.DataHelper.EliminarRegistro("server", "id", idServidor);

                        if (resp)
                            CargarDispositivos();
                    }
                }


                if (e.Item != null && e.Item.Name == "cbEditar")
                {
                    var idServidor = Utilerias.SafeToString(row[colId.FieldName]);

                    var f = new frmAgregarDispositivo(idServidor);
                    f.Inicializar(idServidor);
                    f.ShowDialog();
                    CargarDispositivos();
                }
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }
    }
}
