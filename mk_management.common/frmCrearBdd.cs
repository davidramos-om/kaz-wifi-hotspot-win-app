using System;
using System.Collections.Generic;
using System.Data;

namespace mk_management.common
{
    public partial class frmCrearBdd : DevExpress.XtraEditors.XtraForm
    {
        private List<DbTabla> dbScripts = new List<DbTabla>();
        public string ConnectionStringGenerada ="";
        private readonly string URL_MARIA_DB = "https://kwh-files.nyc3.digitaloceanspaces.com/mariadb-winx64.msi";

        public frmCrearBdd()
        {
            InitializeComponent();
            this.Icon = Utilerias.ObtenerIconoApp();
            this.Text = "Crear base de datos";
        }

        private void ListaTablasDB()
        {
            var fecha = new DateTime();
            var usuario = "ADMIN";
            var pc = "PC-ADMIN";
            var AppId = $"R{fecha.Year}-{Utilerias.PadLeft(fecha.Month, 2, '0')}";
            var version = Utilerias.VersionSistema();
 
            var aaa_base = new DbTabla("aaa_base", BDD_RESX.aaa_base, "");
            dbScripts.Add(aaa_base);

            var strQuery = BDD_RESX.app_setting_data
               .Replace("@AppId", AppId)
               .Replace("@AppVersion", version)
               .Replace("@PcHost", pc)
               .Replace("@Usuario", usuario);

            var app_setting = new DbTabla("app_setting", BDD_RESX.app_setting, strQuery);
            dbScripts.Add(app_setting);

            var bitacora_sistema = new DbTabla("bitacora_sistema", BDD_RESX.bitacora_sistema, "");
            dbScripts.Add(bitacora_sistema);

            var formatos_rpt = new DbTabla("formatos_rpt", BDD_RESX.formatos_rpt, BDD_RPT_FORMAT.rpt_formato_data);
            dbScripts.Add(formatos_rpt);

            var perfil_hotspot = new DbTabla("perfil_hotspot", BDD_RESX.perfil_hotspot, "");
            dbScripts.Add(perfil_hotspot);

            strQuery = BDD_RESX.perfil_sistema_data
                .Replace("@AppId", AppId)
                .Replace("@AppVersion", version)
                .Replace("@PcHost", pc)
                .Replace("@Usuario", usuario);
            var perfil_sistema = new DbTabla("perfil_sistema", BDD_RESX.perfil_sistema, strQuery);
            dbScripts.Add(perfil_sistema);

            var routeros_usage_stats = new DbTabla("routeros_usage_stats", BDD_RESX.routeros_usage_stats, "");
            dbScripts.Add(routeros_usage_stats);

            var server = new DbTabla("server", BDD_RESX.server, "");
            dbScripts.Add(server);

            var sys_config = new DbTabla("sys_config", BDD_RESX.sys_config, BDD_RESX.sys_config_data);
            dbScripts.Add(sys_config);

            var usuario_hotspot = new DbTabla("usuario_hotspot", BDD_RESX.usuario_hotspot, "");
            dbScripts.Add(usuario_hotspot);

            strQuery = BDD_RESX.usuario_sistema_data
             .Replace("@AppId", AppId)
             .Replace("@AppVersion", version)
             .Replace("@PcHost", pc)
             .Replace("@Usuario", usuario);
            var usuario_sistema = new DbTabla("usuario_sistema", BDD_RESX.usuario_sistema, strQuery);
            dbScripts.Add(usuario_sistema);
        }

        private DataTable CrearTabla()
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn(colTabla.FieldName, typeof(string)));
            dt.Columns.Add(new DataColumn(ColObs.FieldName, typeof(string)));
            dt.Columns.Add(new DataColumn(colCreada.FieldName, typeof(bool)));
            return dt;
        }

        private DataRow AgregarRow(DataTable dt, string tabla, string obs, bool creada)
        {
            var nr = dt.NewRow();
            nr[colTabla.FieldName] = tabla;
            nr[ColObs.FieldName] = obs;
            nr[colCreada.FieldName] = creada;

            dt.Rows.Add(nr);

            return nr;
        }

        private string GenerarCnn(string bdd)
        {
            var cnn = "server={0};user id={1};password={2};persistsecurityinfo=True;database={3};characterset=utf8";
            cnn = string.Format(cnn,
                txtServidor.Text,   //0
                txtUsuario.Text,    //1
                txtClave.Text,      //2
                bdd                 //3
                );

            return cnn;
        }

        private bool PruebaConexion()
        {
            using (var w = Utilerias.ShowOverlay(this, "Conectando"))
            {
                var cnn = GenerarCnn("mysql");

                var error = "";
                var valida = common.DataHelper.ConexionValida(cnn, ref error);
                if (!valida)
                {
                    Utilerias.msjAlert("No se pudo realizar la conexión a la base de datos.\n\nError : \n" + error);
                    return false;
                }
            }

            return true;
        }

        private void btnCrearBdd_Click(object sender, System.EventArgs e)
        {
            try
            {

                if (!dxValidationProvider1.Validate())
                    return;

                if (!PruebaConexion())
                    return;

                var confirmar = Utilerias.msjConfirm("Está seguro que desea crear la base de datos?");
                if (!confirmar)
                    return;

                using (var w = Utilerias.ShowOverlay(this, "Cargando recursos"))
                {
                    ListaTablasDB();

                    if (dbScripts.Count <= 0)
                    {
                        Utilerias.msjAlert("No se pudieron definir los scripts de las tablas.");
                        return;
                    }

                    w.SetCaption("Creando tabla de logs");
                    var dt = CrearTabla();

                    //Cnn para crear la base de datos
                    var cnn = GenerarCnn("mysql");

                    AgregarRow(dt, txtBdd.Text , "Antes : Crear base de datos", false);
                    var strQuery = BDD_RESX.crear_bdd.Replace("@bdd", txtBdd.Text);
                    var bddCreada = MDB.ExecuteNonQuery(cnn, strQuery, null);
                   AgregarRow(dt, txtBdd.Text, "Resultado : Crear base de datos", bddCreada);

                    if(!bddCreada)
                    {
                        Utilerias.msjAlert("No se puede continuar ya que no se pudo crear la base de datos");
                        return;
                    }


                    //Cambiar la conexion a la nueva base de datos
                    cnn = GenerarCnn(txtBdd.Text);

                    foreach (var script in dbScripts)
                    {
                        var tabla = script.tabla;
                        w.SetCaption("Ejecutando script : " + tabla);
                        try
                        {
                            w.SetCaption("Crear tabla : " + tabla);

                            var query = script.query_crear;
                            AgregarRow(dt, tabla, "Antes : Crear tabla", false);

                            var res = MDB.ExecuteNonQuery(cnn, query, null);
                            AgregarRow(dt, tabla, "Resultado: Crear tabla", true);

                            var insert = script.query_insert;
                            if (Utilerias.EsValorValido(insert))
                            {
                                w.SetCaption("Crear rows de la tabla : " + tabla);

                                AgregarRow(dt, tabla, "Antes : Insertar registros predeterminados", false);

                                res = MDB.ExecuteNonQuery(cnn, insert, null);
                                AgregarRow(dt, tabla, "Resultado : Insertar registros predeterminados", false);
                            }
                        }
                        catch (Exception ex)
                        {
                            AgregarRow(dt, tabla, ex.Message, false);
                        }
                    }

                    grdDatos.DataSource = dt;
                }

                ConnectionStringGenerada = GenerarCnn(txtBdd.Text);
                Utilerias.msjInfo("El proceso ha finalizado, revise la bitácora y la base de datos.");

            }
            catch (System.Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }

        private void frmCrearBdd_Load(object sender, System.EventArgs e)
        {

        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            var frm = new FrmDownloadTemplates("Descargar Servicio de MariaDb", URL_MARIA_DB, false, true, true,false);
            frm.ShowDialog();
        }
    }

    public class DbTabla
    {
        public string tabla = "";
        public string query_crear = "";
        public string query_insert = "";

        public DbTabla()
        {

        }

        public DbTabla(string _tabla, string q_crear, string q_insert)
        {
            tabla = _tabla;
            query_crear = q_crear;
            query_insert = q_insert;
        }
    }
}
