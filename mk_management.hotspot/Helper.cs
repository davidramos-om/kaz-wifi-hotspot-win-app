using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mk_management.hotspot.Model;
using System.Data;
using mk_management.common;
using DevExpress.XtraReports.UI;
using System.Net.NetworkInformation;

namespace mk_management.hotspot
{
    public class Helper
    {
        public static bool ProcesoMK_OK(object valor)
        {
            //return common.Utilerias.SafeToString(valor).ToUpper() == "!DONE";
            return common.Utilerias.SafeToString(valor).ToUpper().StartsWith("!DONE");
        }

        public static string ObtenerUltimoValorArreglo_StrList(List<string> Arreglo)
        {
            var cant = Arreglo.Count();
            if (cant <= 0)
                return "";

            var obj = Arreglo[cant - 1];

            return obj;
        }

        public static bool ProcesoMK_TieneErrores(string[] Arreglo)
        {
            foreach (string s in Arreglo)
            {
                if (s.ToUpper().StartsWith("!TRAP="))
                    return true;

                if (s.ToUpper().Contains("!FATALNOT LOGGED IN"))
                    return true;
            }

            return false;
        }

        public static string ProcesoMK_ObtenerErrores(string[] Arreglo)
        {
            var errores = new StringBuilder();
            foreach (string s in Arreglo)
            {
                if (s.ToUpper().StartsWith("!TRAP="))
                {
                    var e = s.Replace("!trap=", "");
                    if (e.Length > 0)
                        errores.AppendLine(e);
                }

                if (s.ToUpper().StartsWith("!FATALNOT LOGGED IN"))
                {
                    errores.AppendLine(s);
                }
            }

            return errores.ToString();
        }

        public static string ObtenerUltimoValorArreglo_Str(string[] Arreglo)
        {
            var cant = Arreglo.Count();
            if (cant <= 0)
                return "";

            var obj = Arreglo[cant - 1];

            return obj;
        }

        static private readonly string tk_mk = "pkcTkJqQ|KxmpW7E7*KxmpW7E7";

       

        internal static ServerInfo ObtenerDatosServidor(string ServerId)
        {
            return ObtenerDatosServidor(ServerId, tk_mk);
        }

        public static ServerInfo ObtenerDatosServidor(string ServerId, string link)
        {
            var svr = new ServerInfo();

            if (Utilerias.SafeToStringId(link) != tk_mk)
            {
                return svr;
            }

            try
            {
                var filtroSvr = "";
                // if (common.Utilerias.EsValorValido(ServerId))
                {
                    filtroSvr = $" and Id = '{ServerId}'";
                }

                var sql = $"select Descripcion,IP,Puerto,Usuario,Clave,OsVersion from server s where 1=1  {filtroSvr} and s.Activo = 1";

                var dtInfo = common.MDB.FillDataTable(Link.ConnectionString, sql);

                if (!common.Utilerias.TablaTieneRows(dtInfo))
                {
                    svr.SetError("No hay servidores registrados");
                    return svr;
                }

                svr.Id = ServerId;
                svr.Nombre = common.Utilerias.SafeToString(dtInfo.Rows[0]["Descripcion"]);

                svr.IP = common.Utilerias.SafeToString(dtInfo.Rows[0]["IP"]);
                svr.Puerto = common.Utilerias.ToInt(dtInfo.Rows[0]["Puerto"]);

                svr.VersionSO = common.Utilerias.SafeToString(dtInfo.Rows[0]["OsVersion"]);

                var clave = common.Utilerias.SafeToString(dtInfo.Rows[0]["Clave"]);
                var usuario = common.Utilerias.SafeToString(dtInfo.Rows[0]["Usuario"]);

                svr.Clave = common.Utilerias.EsValorValido(clave) ? common.Crypto.Decrypt(clave) : "";
                svr.Usuario = common.Utilerias.EsValorValido(usuario) ? common.Crypto.Decrypt(usuario) : "";

                svr.ClearError();

                return svr;
            }
            catch (Exception ex)
            {
                svr.SetError(ex.Message);
                return svr;
            }
        }

        internal static DataTable DataTableFromMKArray(string[] source)
        {
            return DataTableFromMKArray(source, tk_mk);
        }

        public static DataTable DataTableFromMKArray(string[] source, object link)
        {
            var dt = new DataTable("Datos");

            if (Utilerias.SafeToStringId(link) != tk_mk)
            {
                return dt;
            }

            //Generar columnas
            foreach (string s in source)
            {
                if (hotspot.Helper.ProcesoMK_OK(s))
                    continue;

                if (s.StartsWith("!trap="))
                    continue;

                var str = s.Replace("!re=.", "");
                str = s.Replace("!re=", "");

                var arryValues = str.Split('=');

                for (int i = 0; i < arryValues.Length; i += 2)
                {
                    var f = arryValues[i];

                    var columnName = f.Replace("-", "_");

                    if (dt.Columns[columnName] == null)
                        dt.Columns.Add(columnName);
                }
            }

            //Agregar rows
            foreach (string s in source)
            {
                if (hotspot.Helper.ProcesoMK_OK(s))
                    continue;

                if (s.StartsWith("!trap="))
                    continue;

                var str = s.Replace("!re=.", "");
                str = s.Replace("!re=", "");

                var arryValues = str.Split('=');

                var nr = dt.NewRow();

                for (int i = 0; i < arryValues.Length; i += 2)
                {
                    var f = arryValues[i];
                    var v = arryValues[i + 1];

                    var columnName = f.Replace("-", "_");

                    if (dt.Columns[columnName] != null)
                        nr[columnName] = v;
                }

                dt.Rows.Add(nr);
            }

            return dt;

        }

        public static DataSet GenerateUserCredentialDataToPrint(string userPlainText, string passPlainText, string additionalInfo)
        {
            var ds = new DataSet("dsDatos");

            var dt = new DataTable("dtInfo");
            dt.Columns.Add("Empresa");
            dt.Columns.Add("Direccion");
            dt.Columns.Add("Contacto");
            dt.Columns.Add("Usuario");
            dt.Columns.Add("Clave");
            dt.Columns.Add("IdenTributario");
            dt.Columns.Add("Correo");
            dt.Columns.Add("InfoAdicional");
            dt.Columns.Add("Logo", typeof(byte[]));
            //dt.Columns.Add("Logo", typeof(object));

            var nr = dt.NewRow();

            var infoEmp = wOverlaySplash.GetCompanyInformation(ConfigurationSettings.Obtener_CadenaConexion());

            nr["Empresa"] = DataHelper.ObtenerConfiguracion(enumConfig.COM_NAME, false);

            if (infoEmp.IsValid)
            {
                nr["Empresa"] = infoEmp.Nombre;
                nr["IdenTributario"] = infoEmp.RTN;
                nr["Correo"] = infoEmp.Correo;
            }


            nr["Direccion"] = DataHelper.ObtenerConfiguracion(enumConfig.COM_DIR, false);
            nr["Contacto"] = DataHelper.ObtenerConfiguracion(enumConfig.COM_CONTACTS, false);
            nr["Usuario"] = userPlainText;
            nr["Clave"] = passPlainText;
            nr["InfoAdicional"] = additionalInfo;

            var logo = DataHelper.ObtenerConfiguracion(enumConfig.COM_LOGO, true);

            if (logo != null)
            {
                nr["Logo"] = logo;
                //var ms = Utilerias.getStreamFromByteArray(logo);
                //if (ms != null)
                //{
                //    nr["Logo"] = new System.Drawing.Bitmap(ms);
                //}
            }

            dt.Rows.Add(nr);

            ds.Tables.Add(dt);

            return ds;
        }

        public static void PrintUserCredential(DataSet dsFields, string reportDescription, PrintMethod printing)
        {
            System.IO.Stream formato = null;

            PrintUserCredential(dsFields, reportDescription, printing, ref formato);
        }

        public static void PrintUserCredential(DataSet dsFields, string reportDescription, PrintMethod printing, ref System.IO.Stream streamFormat)
        {
            var link = ConfigurationSettings.Obtener_CadenaConexion();
            var licencia = wOverlaySplash.GetLicenseInUse(link);
            if (licencia == null)
            {
                Utilerias.msjAlert_TI(wOverlaySplash.lblLimit_msj_no_license);
                return;
            }

            string configuredPrinter = "";

            if (streamFormat == null)
            {
                var dtFormato = DataHelper.ConsultarRegistro("formatos_rpt", "Codigo", uc_formato_rpt_credenciales.CODIGO_RPT);

                if (Utilerias.TablaTieneRows(dtFormato))
                {
                    var frm = dtFormato.Rows[0]["Formato"];

                    configuredPrinter = Utilerias.SafeToString(dtFormato.Rows[0]["Impresora"]);

                    if (Utilerias.EsValorValido(frm))
                        streamFormat = Utilerias.getStreamFromObject(dtFormato.Rows[0]["Formato"]);
                }
            }

            if (streamFormat == null)
            {
                Utilerias.msjAlert_TI("No se pudo obtener el formato de impresión.");
                return;
            }


            if (printing == PrintMethod.OpenDesigner)
            {
                common.rpt.frm_rpt_designer rpt_de = null;

                rpt_de = new common.rpt.frm_rpt_designer(Utilerias.ObtenerIconoApp(), streamFormat, dsFields, reportDescription)
                {
                    StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen,
                    WindowState = System.Windows.Forms.FormWindowState.Maximized
                };


                if (rpt_de != null)
                {
                    rpt_de.ShowDialog();

                    if (rpt_de.Guardado)
                    {
                        streamFormat = rpt_de.msFormatoReporte;
                    }
                }
            }
            else
            {
                var reporte = new DevExpress.XtraReports.UI.XtraReport
                {
                    Bookmark = reportDescription,
                    Name = reportDescription,
                    DisplayName = reportDescription
                };


                reporte.LoadLayout(streamFormat);

                reporte.DataSource = dsFields;
                reporte.DataMember = dsFields.DataSetName;



                if (licencia.ShowWaterMark)
                {
                    reporte.DrawWatermark = true;
                    reporte.Watermark.Text = wOverlaySplash.lblLimit_msj4;
                    reporte.Watermark.ForeColor = System.Drawing.Color.Orange;

                    var f = reporte.Watermark.Font;
                    reporte.Watermark.Font = new System.Drawing.Font(f.FontFamily, 12, System.Drawing.FontStyle.Italic);
                    reporte.Watermark.TextDirection = DevExpress.XtraPrinting.Drawing.DirectionMode.BackwardDiagonal;
                    reporte.Watermark.TextTransparency = 50;
                }

                var printTool = new ReportPrintTool(reporte);

                if (printing == PrintMethod.InvokeDialog)
                    printTool.ShowPreviewDialog();

                if (printing == PrintMethod.DefaultPrinter)
                    printTool.Print();

                if (printing == PrintMethod.ConfiguredPrinterName)
                {
                    if (Utilerias.EsValorValido(configuredPrinter))
                    {
                        try
                        {

                            printTool.Print(configuredPrinter);
                        }
                        catch (Exception exPrinter)
                        {
                            Utilerias.msjErrorEx(exPrinter);
                            printTool.ShowPreviewDialog();
                        }
                    }
                    else
                        printTool.PrintDialog();
                }
            }
        }
    }
    public enum PrintMethod
    {
        InvokeDialog = 0,
        DefaultPrinter = 1,
        ConfiguredPrinterName = 2,
        OpenDesigner,
    }
}
