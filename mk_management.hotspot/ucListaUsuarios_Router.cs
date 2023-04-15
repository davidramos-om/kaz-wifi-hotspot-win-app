using System;
using System.Data;
using System.Drawing;
using System.Linq;
using DevExpress.XtraEditors;
using mk_management.common;

namespace mk_management.hotspot
{
    //public partial class frmUsuarios : DevExpress.XtraEditors.XtraForm
    public partial class ucListaUsuarios_Router : DevExpress.XtraEditors.XtraUserControl
    {
        public ucListaUsuarios_Router()
        {
            InitializeComponent();
            tlBarGrupoConexiones.Items.Clear();
            new common.MenuItemGridViews(ref gvdatos, "Usuarios en Dispositivos");
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
                            CargarUsuarios(idServidorPredeterminado);
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

            CargarUsuarios(Utilerias.SafeToStringId(row["Id"]));

        }

        public void Inicializar()
        {
            CargarConexiones();
        }

        Model.ServerInfo svrSeleccionado = null;

        private void CargarUsuarios(string IdServidor)
        {
            try
            {
                using (var w = Utilerias.ShowOverlay(this, "Conectando"))
                {
                    grdDatos.DataSource = null;
                    layoutControlGroup1.Text = "Usuarios Activos";
                    this.Refresh();

                    svrSeleccionado = hotspot.Helper.ObtenerDatosServidor(IdServidor);

                    if (svrSeleccionado.TieneError)
                    {
                        Utilerias.msjAlert(svrSeleccionado.ErrorMsj);
                        return;
                    }

                    if (!Utilerias.PingHost(svrSeleccionado.IP))
                    {
                        Utilerias.msjInfo("No hay conexión al dispositivo.");
                        return;
                    }

                    var mk = new MK(svrSeleccionado.IP, svrSeleccionado.Puerto, svrSeleccionado.VersionSO);

                    if (!mk.Login(svrSeleccionado.Usuario, svrSeleccionado.Clave))
                    {
                        mk.Close();
                        Utilerias.msjInfo("No se pudo iniciar sesion.");
                        return;
                    }

                    var source = mk.GetUsers();
                    mk.Close();

                    if (hotspot.Helper.ProcesoMK_TieneErrores(source.ToArray()))
                    {
                        var errores = hotspot.Helper.ProcesoMK_ObtenerErrores(source.ToArray());
                        mk_management.common.Utilerias.msjAlert("No se pudo obtener." + Environment.NewLine + Environment.NewLine + errores);
                        return;
                    }

                    var dt = hotspot.Helper.DataTableFromMKArray(source);

                    if (Utilerias.TablaTieneRows(dt))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            TransformBytesToMB(dt, r, col_bytes_in.FieldName);
                            TransformBytesToMB(dt, r, col_bytes_out.FieldName);
                            TransformBytesToMB(dt, r, col_packet_in.FieldName);
                            TransformBytesToMB(dt, r, col_packets_out.FieldName);
                        }
                    }

                    layoutControlGroup1.Text = $"Mostrando Usuarios Activos en  : {svrSeleccionado.Nombre} ({svrSeleccionado.IP })";

                    grdDatos.DataSource = dt;
                    gvdatos.OptionsView.ColumnAutoWidth = false;


                    Utilerias.ConfigurarGrid_Totales(gvdatos, col_name.FieldName, col_name.FieldName);

                    //ConfigurarColumna_Eliminar();

                    //if (gvdatos.Columns[".id"] != null)
                    //    gvdatos.Columns[".id"].Visible = false;

                    //ConfigurarColumna_HabDesHab();

                    //ConfigurarColumna_ImprimirCred();
                    //col_name.VisibleIndex = 3;
                    gvdatos.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }

            void TransformBytesToMB(DataTable dt, DataRow r, string field)
            {
                if (dt.Columns[field] != null)
                {
                    decimal b_in_mb = 1024;
                    var b_in = Convert.ToDecimal(Utilerias.NullValue(r[field], 0)) / b_in_mb;
                    r[field] = decimal.Round(b_in / b_in_mb, 2) + " mb";
                }
            }
        }

        //private void ConfigurarColumna_Eliminar()
        //{
        //    try
        //    {
        //        if (gvdatos.Columns["_fn_delete_"] != null)
        //            return;

        //        var col = new DevExpress.XtraGrid.Columns.GridColumn();
        //        col.FieldName = "_fn_delete_";
        //        col.Caption = "Eliminar";
        //        col.Visible = true;
        //        col.VisibleIndex = 0;
        //        col.OptionsColumn.ShowCaption = false;
        //        col.OptionsColumn.AllowShowHide = false;
        //        col.OptionsColumn.AllowMove = false;
        //        col.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;

        //        gvdatos.Columns.Add(col);

        //        var repBtnEliminar = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
        //        var f = repBtnEliminar.Buttons[0].Appearance.Font;
        //        repBtnEliminar.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
        //        repBtnEliminar.Buttons[0].Caption = "Eliminar";
        //        repBtnEliminar.Buttons[0].Appearance.Font = new Font(f.FontFamily, f.Size, FontStyle.Bold);
        //        repBtnEliminar.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

        //        repBtnEliminar.ButtonClick += RepBtnEliminar_ButtonClick;

        //        col.ColumnEdit = repBtnEliminar;

        //        gvdatos.Columns.Add(col);

        //    }
        //    catch (Exception ex)
        //    {
        //        Utilerias.msjErrorEx(ex);
        //    }
        //}

        private void RepBtnEliminar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

                if (!licencia.AllowDeleteUser)
                {
                    Utilerias.msjAlert_TI(wOverlaySplash.lblLimit_mjs3);
                    return;
                }

                if (svrSeleccionado == null)
                    return;

                var row = gvdatos.GetFocusedDataRow();

                if (row == null)
                    return;

                var user = Utilerias.SafeToString(row["name"]);

                if (Utilerias.IsNullOrEmpty(user))
                    return;

                //var p = $"El usuario : {user} será eliminado del dispositivo y de la base de datos.\n\nEl usuario no tendrá acceso a internet\n\n¿Desea continuar? ";
                var p = $"El usuario : {user} será eliminado del dispositivo.\n\nEl usuario no tendrá acceso a internet\n\n¿Desea continuar? ";

                if (!Utilerias.msjConfirm(p))
                    return;

                var id = Utilerias.SafeToStringId(row[".id"]);

                var mk = new MK(svrSeleccionado.IP, svrSeleccionado.Puerto, svrSeleccionado.VersionSO);

                if (!mk.Login(svrSeleccionado.Usuario, svrSeleccionado.Clave))
                {
                    mk.Close();
                    Utilerias.msjInfo("No se pudo iniciar sesion.");
                    return;
                }


                var deleted = mk.DeleteUser(id);
                mk.Close();

                if (deleted)
                {
                    var msj = "El usuario ha sido eliminado del dipositivo";

                    user = common.Crypto.Encrypt(user);

                    //No eliminar de la bdd para que apareca en el historial
                    //if (common.DataHelper.EliminarRegistro("usuario_hotspot", "Usuario", user))
                    //    msj = msj + " y de la base de datos";
                    //else
                    //    msj = msj + " pero no se pudo eliminar de la base de datos";

                    Utilerias.msjInfo(msj);

                    try
                    {
                        common.DataHelper.ActualizarRegistro_Tabla("usuario_hotspot", "Id", id, "FechaElimino", DateTime.Now, "UsuarioElimino", Link.IdUsuario);
                    }
                    catch (Exception ex)
                    {
                        DataHelper.AgregarBitacoraSistema(this.Name + ".EliminarUsuarioHotSpot", ex.Message, true);
                    }

                    CargarUsuarios(svrSeleccionado.Id);
                }
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }

        //private void ConfigurarColumna_HabDesHab()
        //{
        //    try
        //    {
        //        if (gvdatos.Columns["_fn_disable_"] != null)
        //            return;

        //        var col = new DevExpress.XtraGrid.Columns.GridColumn();
        //        col.FieldName = "_fn_disable_";
        //        col.Caption = "Habiliar / Deshabilitar";
        //        col.Visible = true;
        //        col.VisibleIndex = 0;
        //        col.OptionsColumn.ShowCaption = false;
        //        col.OptionsColumn.AllowShowHide = false;
        //        col.OptionsColumn.AllowMove = false;
        //        col.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;

        //        gvdatos.Columns.Add(col);

        //        var repBtnHabilitar_DesHab = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
        //        var f = repBtnHabilitar_DesHab.Buttons[0].Appearance.Font;
        //        repBtnHabilitar_DesHab.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
        //        repBtnHabilitar_DesHab.Buttons[0].Caption = "Habiliar / Deshabilitar";
        //        repBtnHabilitar_DesHab.Buttons[0].Appearance.Font = new Font(f.FontFamily, f.Size, FontStyle.Bold);
        //        repBtnHabilitar_DesHab.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

        //        repBtnHabilitar_DesHab.ButtonClick += RepBtnHabilitar_DesHab_ButtonClick; ;

        //        col.ColumnEdit = repBtnHabilitar_DesHab;

        //        gvdatos.Columns.Add(col);

        //    }
        //    catch (Exception ex)
        //    {
        //        Utilerias.msjErrorEx(ex);
        //    }
        //}

        private void RepBtnHabilitar_DesHab_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

                if (!licencia.AllowDisableUser)
                {
                    Utilerias.msjAlert_TI(wOverlaySplash.lblLimit_mjs3);
                    return;
                }

                if (svrSeleccionado == null)
                    return;

                var row = gvdatos.GetFocusedDataRow();

                if (row == null)
                    return;

                var disabled = Utilerias.SafeToString(row["disabled"]);
                var user = Utilerias.SafeToString(row["name"]);

                if (Utilerias.IsNullOrEmpty(user))
                    return;

                var p = "";

                if (Utilerias.Valor_SI(disabled))
                    p = $"El usuario : {user} será habilitado del dispositivo y  tendrá acceso a internet\n\n¿Desea continuar?";
                else
                    p = $"El usuario : {user} será deshabitado del dispositivo\n\nEl usuario no tendrá acceso a internet\n\n¿Desea continuar?";

                if (!Utilerias.msjConfirm(p))
                    return;

                var id = Utilerias.SafeToStringId(row[".id"]);

                var mk = new MK(svrSeleccionado.IP, svrSeleccionado.Puerto, svrSeleccionado.VersionSO);

                if (!mk.Login(svrSeleccionado.Usuario, svrSeleccionado.Clave))
                {
                    mk.Close();
                    Utilerias.msjInfo("No se pudo iniciar sesion.");
                    return;
                }

                disabled = disabled == "false" ? "yes" : "no";
                var changed = mk.ChangeUserStatus(id, disabled);
                mk.Close();
                if (changed)
                {
                    if (disabled == "yes")
                        Utilerias.msjInfo("El usuario ha sido deshabitado.");
                    else
                        Utilerias.msjInfo("El usuario ha sido habilitado.");

                    CargarUsuarios(svrSeleccionado.Id);
                }
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }

        //private void ConfigurarColumna_ImprimirCred()
        //{
        //    try
        //    {
        //        if (gvdatos.Columns["_fn_print"] != null)
        //            return;

        //        var col = new DevExpress.XtraGrid.Columns.GridColumn();
        //        col.FieldName = "_fn_print";
        //        col.Caption = "Imprimir Credenciales";
        //        col.Visible = true;
        //        col.VisibleIndex = 0;
        //        col.OptionsColumn.ShowCaption = false;
        //        col.OptionsColumn.AllowShowHide = false;
        //        col.OptionsColumn.AllowMove = false;
        //        col.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;

        //        gvdatos.Columns.Add(col);

        //        var repBtnImprimirCredenciales = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
        //        var f = repBtnImprimirCredenciales.Buttons[0].Appearance.Font;
        //        repBtnImprimirCredenciales.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
        //        repBtnImprimirCredenciales.Buttons[0].Caption = "Imprimir credenciales";
        //        repBtnImprimirCredenciales.Buttons[0].Appearance.Font = new Font(f.FontFamily, f.Size, FontStyle.Bold);
        //        repBtnImprimirCredenciales.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

        //        repBtnImprimirCredenciales.ButtonClick += RepBtnImprimirCredenciales_ButtonClick;

        //        col.ColumnEdit = repBtnImprimirCredenciales;
        //        gvdatos.Columns.Add(col);

        //    }
        //    catch (Exception ex)
        //    {
        //        Utilerias.msjErrorEx(ex);
        //    }
        //}

        private void RepBtnImprimirCredenciales_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

                if (!licencia.AllowRePrintCred)
                {
                    Utilerias.msjAlert_TI(wOverlaySplash.lblLimit_mjs2);
                    return;
                }

                var row = gvdatos.GetFocusedDataRow();

                if (row == null)
                    return;

                var user = Utilerias.SafeToString(row["name"]);
                if (Utilerias.IsNullOrEmpty(user))
                    return;

                var pass = Utilerias.SafeToString(row["password"]);
                if (Utilerias.IsNullOrEmpty(pass))
                    return;

                var ds = hotspot.Helper.GenerateUserCredentialDataToPrint(user, pass, "");

                hotspot.Helper.PrintUserCredential(ds, "Imprimir credenciales", PrintMethod.ConfiguredPrinterName);
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            var accion = Utilerias.SafeToString(e?.Button?.Properties?.Tag);

            switch (accion)
            {
                case "delete":
                    {
                        RepBtnImprimirCredenciales_ButtonClick(sender, null);
                        break;
                    }
                case "hab_des":
                    {
                        RepBtnHabilitar_DesHab_ButtonClick(sender, null);
                        break;
                    }
                case "print_pass":
                    {
                        RepBtnImprimirCredenciales_ButtonClick(sender, null);
                        break;
                    }
                case "print_users":
                    {
                        grdDatos.ShowRibbonPrintPreview();
                        break;
                    }
            }
        }
    }
}