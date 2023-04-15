using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mk_management.common;

namespace mk_management
{
    public partial class frmAgregarPerfilSistema : DevExpress.XtraEditors.XtraForm
    {
        string IdPerfil;

        public frmAgregarPerfilSistema()
        {
            InitializeComponent();
            this.Icon = Utilerias.ObtenerIconoApp();
            LimpiarDatos();
        }


        private void CargarDatos(string Id)
        {
            try
            {
                LimpiarDatos();
                this.Refresh();

                ConfigurarGridAccesos();

                var dt = DataHelper.ConsultarRegistro("perfil_sistema", "Id", Id);

                if (Utilerias.TablaTieneRows(dt))
                {
                    IdPerfil = Id;
                    txtNombre.EditValue = dt.Rows[0]["Nombre"];

                    var json = Utilerias.SafeToString(dt.Rows[0]["FormulariosAcceso"]);

                    if (Utilerias.EsValorValido(json))
                    {
                        var dtDetalleFormularios = grdDatos.DataSource as DataTable;
                        //var dtDetalleFormulariosGuardados = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(json);
                        var dtDetalleFormulariosGuardados = Utilerias.JsonToDT(json);

                        if (Utilerias.TablaTieneRows(dtDetalleFormulariosGuardados) && Utilerias.TablaTieneRows(dtDetalleFormularios))
                        {
                            foreach (DataRow row in dtDetalleFormulariosGuardados.Rows)
                            {
                                if (dtDetalleFormulariosGuardados.Columns[colFormulario.FieldName] != null)
                                {
                                    var filtro = $"{colFormulario.FieldName}= '{row[colFormulario.FieldName]}'";
                                    var rows = dtDetalleFormularios.Select(filtro);

                                    foreach (DataRow rf in rows)
                                    {
                                        rf[colSeleccionar.FieldName] = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }

        private void ConfigurarGridAccesos()
        {
            var dt = new DataTable("Opciones");
            dt.Columns.Add(colSeleccionar.FieldName, typeof(bool));
            dt.Columns.Add(colGrupo.FieldName, typeof(bool));
            dt.Columns.Add(colFormulario.FieldName, typeof(string));
            dt.Columns.Add(colDescripcion.FieldName, typeof(string));


            var dxMenu = new DxMenu();
            var menu = dxMenu.actrlMenu;

            var items = menu.GetElements();

            foreach (var e in items)
            {
                //if (e.Level == 0)
                //    continue;


                if (e.Name == dxMenu.aceSalirApp.Name)
                    continue;

                if (e.Name == dxMenu.aceCerrarSesion.Name)
                    continue;

                if (e.Name == dxMenu.aceInfoApp.Name)
                    continue;

                var nr = dt.NewRow();


                nr[colSeleccionar.FieldName] = false;
                nr[colGrupo.FieldName] = e.Level == 0;
                nr[colFormulario.FieldName] = e.Name;
                nr[colDescripcion.FieldName] = e.Level == 0 ? e.Text.Trim() : "   " + e.Text.Trim();

                dt.Rows.Add(nr);
            }

            grdDatos.DataSource = dt;
        }

        public void LimpiarDatos()
        {
            IdPerfil = "";
            txtNombre.EditValue = null;
            grdDatos.DataSource = null;
            Utilerias.LimpiarValidationProvider(dxValidationProvider1);
            ConfigurarGridAccesos();
        }

        public void Inicializar(string IdUsuario)
        {
            CargarDatos(IdUsuario);
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

                if (licencia.App_Profiles != -1)
                {
                    if (DataHelper.CantRegistros("perfil_sistema", IdPerfil) >= licencia.App_Profiles)
                    {
                        Utilerias.msjAlert_TI(wOverlaySplash.lblLimit_mjs1);
                        return;
                    }
                }


                if (!dxValidationProvider1.Validate())
                    return;


                if (DataHelper.ExisteDescRegistro("perfil_sistema", "Id", IdPerfil, "Nombre", txtNombre.Text))
                {
                    Utilerias.msjAlert("Ya existe un perfil con el mismo nombre, intente con otro.");
                    return;
                }

                var json = "";

                var dtAccesos = grdDatos.DataSource as DataTable;

                if (Utilerias.TablaTieneRows(dtAccesos))
                {
                    var dv = dtAccesos.AsDataView();
                    dv.RowFilter = $"{colSeleccionar.FieldName} = True";
                    dtAccesos = dv.ToTable();

                    json = Utilerias.DataTableToJson(dtAccesos);
                }


                if (Utilerias.EsValorValido(IdPerfil))
                {
                    var resp = common.DataHelper.ActualizarRegistro_Tabla("perfil_sistema",
                                                                          "Id", IdPerfil,
                                                                          "Nombre", txtNombre.Text,
                                                                          "FormulariosAcceso", json
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
                    var resp = common.DataHelper.CrearRegistro_Tabla("perfil_sistema",
                                                                     "Nombre", txtNombre.Text,
                                                                     "FormulariosAcceso", json
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

        private void gvDatos_ShowingEditor(object sender, CancelEventArgs e)
        {
            var esGrupo = Convert.ToBoolean(Utilerias.NullValue(gvDatos.GetFocusedRowCellValue(colGrupo), false));
            e.Cancel = esGrupo;
        }

        private void grdDatos_Click(object sender, EventArgs e)
        {

        }
    }
}
