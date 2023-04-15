using System;
using System.Drawing;
using System.Windows.Forms;

namespace mk_management.common
{
    public class Utilerias
    {
        public static bool IsInDesignMode()
        {
            if (System.ComponentModel.LicenseUsageMode.Designtime == System.ComponentModel.LicenseManager.UsageMode)
            {
                //Utilerias.msjAlert("IsInDesignMode");
                return true;
            }

            var procName = System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower();


            //Utilerias.msjAlert("procName : " + procName);

            return "devenv" == procName;
        }

        public static string VersionSistema()
        {
            return Application.ProductVersion;
        }

        public static Color GetWebColor(string hex)
        {
            var c = System.Drawing.ColorTranslator.FromHtml(hex);

            return c;
        }

        public static string ObtenerPcHost()
        {
            return Environment.MachineName;
        }

        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            System.Net.NetworkInformation.Ping pinger = null;

            try
            {
                pinger = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == System.Net.NetworkInformation.IPStatus.Success;
            }
            catch (System.Net.NetworkInformation.PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }

        public static string TiempoTranscurrido(int minutos)
        {
            if (minutos <= 0)
                minutos = 0;

            int tot_mins = minutos;
            int days = tot_mins / 1440;
            int hours = (tot_mins % 1440) / 60;
            int mins = tot_mins % 60;

            var msj = $"{days} d, {hours} h, {mins} m";

            return msj;
        }

        public static bool Valor_SI(object valor)
        {
            var val = SafeToString(valor).ToUpper();

            if (val == "S" || val == "SI" || val == "Y" || val == "YES" || val == "TRUE" || val == "T" || val == "1")
                return true;

            return false;
        }

        public static Icon ObtenerIconoApp()
        {
            //return common.Properties.Resources.icon_app;
            //return common.Properties.Resources.net_icon;
            return common.Properties.Resources.logo_icon_app;
        }

        public static string ObtenerPath_AppSetting()
        {
            var AppPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            AppPath = AppPath.Replace(@"file:\", "");

            //var ConfigFile = System.IO.Path.Combine(AppPath, "AppSettings.config");
            var ConfigFile = System.IO.Path.Combine(AppPath, "AppSettings.config.txt");


            return ConfigFile;
        }

        public static string SafeToString(object value)
        {
            if (IsNullOrEmpty(value))
                return "";

            return value.ToString();
        }

        public static string SafeToStringId(object value)
        {
            if (IsNullOrEmpty(value))
                return "-1";

            return value.ToString();
        }

        public static bool IsNullOrEmpty(object value)
        {
            if (value == null) return true;

            if (DBNull.Value.Equals(value)) return true;

            if (typeof(DateTime) == value.GetType())
                if (DateValueIsNull(value))
                    return true;

            if (typeof(string) == value.GetType())
                if (string.IsNullOrEmpty(Convert.ToString(value)) || string.Equals(value, "(None)"))
                    return true;

            return false;
        }

        internal static string CapitalLetter(string word)
        {
            var r = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word.ToLower());
            return r;
        }

        public static bool EsValorValido(object value)
        {
            if (IsNullOrEmpty(value))
                return false;

            return true;
        }

        public static bool DateValueValid(object date)
        {
            if (Convert.IsDBNull(date))
                return false;

            if (date == null)
                return false;
            if (DBNull.Value.Equals(date))
                return false;
            if (object.Equals(date, (DateTime)System.Data.SqlTypes.SqlDateTime.Null))
                return false;

            if (String.IsNullOrEmpty(date.ToString()))
                return false;

            if (((DateTime)date) == DateTime.MinValue)
                return false;

            return true;
        }

        public static string EasyDate(DateTime date)
        {
            try
            {
                string mes = date.ToString("MMM", System.Globalization.CultureInfo.CreateSpecificCulture("es"));
                var str = PadLeft(date.Day, 2, '0') + " " + mes + " " + date.Year.ToString();
                return str;
            }
            catch (Exception )
            {
                return date.ToShortDateString();
            }
        }

        public static bool DateValueIsNull(object date)
        {
            if (Convert.IsDBNull(date))
                return true;

            if (date == null)
                return true;

            if (String.IsNullOrEmpty(date.ToString()))
                return true;

            if (DBNull.Value.Equals(date))
                return true;
            if (object.Equals(date, (DateTime)System.Data.SqlTypes.SqlDateTime.Null))
                return true;
            return false;
        }

        public static object NullValue(object value1, object value2)
        {
            if (IsNullOrEmpty(value1))
                return value2;

            return value1;
        }

        public static long ToInt64(object value)
        {
            return Convert.ToInt64(NullValue(value, long.MinValue));
        }

        public static int ToInt(object value)
        {
            return Convert.ToInt32(NullValue(value, int.MinValue));
        }

        public static string ToString(object value)
        {
            if (IsNullOrEmpty(value))
                return "";

            return Convert.ToString(value).Trim();
        }

        public static bool isNumber(object value)
        {
            if (IsNullOrEmpty(value))
                return false;

            Int64 result = 1;
            if (!Int64.TryParse(ToString(value), out result))
                return false;

            return true;
        }

        public static string GenerateDateId()
        {
            var f = DateTime.Now;

            var id = f.Year + PadLeft(f.Month, 2, '0') + PadLeft(f.Day, 2, '0') + "_" +
                     PadLeft(f.Hour, 2, '0') + PadLeft(f.Minute, 2, '0') + PadLeft(f.Second, 2, '0') + "_" +
                     PadLeft(f.Millisecond, 4, '0');

            return id;
        }

        public static string CustomDate_YYYYMMYY_HHMMSS(DateTime f)
        {
            var rest = f.Year + PadLeft(f.Month, 2, '0') + PadLeft(f.Day, 2, '0') + "_" +
                     PadLeft(f.Hour, 2, '0') +
                     PadLeft(f.Minute, 2, '0') +
                     PadLeft(f.Second, 2, '0');

            return rest;
        }

        internal static string GetRandomString(int lenOfTheNewStr)
        {
            string output = string.Empty;
            while (true)
            {
                output = output + System.IO.Path.GetRandomFileName().Replace(".", string.Empty);

                if (output.Length > lenOfTheNewStr)
                {
                    output = output.Substring(0, lenOfTheNewStr);
                    break;
                }
            }
            return output;
        }

        public static string PadLeft(object valor, int Cant, char caracter)
        {
            var str = NullValue(valor, "").ToString().PadLeft(Cant, caracter);

            return str;
        }

        public static string PadLeftNumericos(object valor)
        {
            var str = NullValue(valor, "").ToString().PadLeft(10, '0');

            return str;
        }

        public static bool TablaTieneRows(System.Data.DataTable tabla)
        {
            if (IsNullOrEmpty(tabla))
                return false;

            if (tabla.Rows.Count <= 0 || tabla.Columns.Count <= 0)
                return false;

            return true;
        }

        public static void msjInfo(string msj)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(msj, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void msjAlert(string msj)
        {
            //MessageBox.Show(msj, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            DevExpress.XtraEditors.XtraMessageBox.Show(msj, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void msjAlert_TI(string msj)
        {
            //MessageBox.Show(msj, "Comunicarse con Soporte Técnico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            DevExpress.XtraEditors.XtraMessageBox.Show(msj, "Comunicarse con Soporte Técnico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void msjError(string msj)
        {
            //MessageBox.Show(msj, "Ha ocurrido un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);

            DevExpress.XtraEditors.XtraMessageBox.Show(msj, "Ha ocurrido un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void msjErrorEx(Exception ex)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Ha ocurrido un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool msjConfirm(string msj)
        {
            //var r = MessageBox.Show(msj, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //return r == DialogResult.Yes;
            var r = DevExpress.XtraEditors.XtraMessageBox.Show(msj, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return r == DialogResult.Yes;
        }


        public static void LimpiarValidationProvider(DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider ErrorProvider)
        {

            try
            {
                var controlConErrores = ErrorProvider.GetInvalidControls();

                while (controlConErrores.Count > 0)
                {
                    ErrorProvider.RemoveControlError(controlConErrores[0]);
                }
            }
            catch (Exception ex)
            {
                DataHelper.AgregarBitacoraSistema("Utilerias.LimpiarErrorProvider", ex.Message, true);
            }
        }


        public static void ConfigurarGrid_Totales_NR(DevExpress.XtraGrid.Views.Grid.GridView gridview, string RowsCount_FieldName, string GroupCount_FieldName, bool ShowAutoFilterRow = true, DevExpress.XtraGrid.Columns.AutoFilterCondition _AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains)
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridview.Columns)
            {
                col.OptionsFilter.AutoFilterCondition = _AutoFilterCondition;
            }

            gridview.OptionsView.ShowAutoFilterRow = ShowAutoFilterRow;
            gridview.OptionsView.ShowFooter = true;

            //Totales
            var FieldName = RowsCount_FieldName;
            gridview.GroupSummary.Clear();
            gridview.Columns[FieldName].Summary.Clear();
            gridview.Columns[FieldName].Summary.Add(DevExpress.Data.SummaryItemType.Count, FieldName, "Núm. Registros= {0}");

            gridview.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;

            DevExpress.XtraGrid.GridGroupSummaryItem itemGroupSummaryItem = new DevExpress.XtraGrid.GridGroupSummaryItem
            {
                FieldName = GroupCount_FieldName,
                DisplayFormat = "Núm. Registros {0}",
                SummaryType = DevExpress.Data.SummaryItemType.Count,
                ShowInGroupColumnFooter = gridview.Columns[GroupCount_FieldName]
            };

            gridview.GroupSummary.Add(itemGroupSummaryItem);
        }

        public static void ConfigurarGrid_Totales(DevExpress.XtraGrid.Views.Grid.GridView gridview, string RowsCount_FieldName, string GroupCount_FieldName, bool ShowAutoFilterRow = true, bool ReadOnlyColumns = true, DevExpress.XtraGrid.Columns.AutoFilterCondition _AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains)
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridview.Columns)
            {
                col.OptionsFilter.AutoFilterCondition = _AutoFilterCondition;
                col.OptionsColumn.ReadOnly = ReadOnlyColumns;
            }

            gridview.OptionsView.ShowAutoFilterRow = ShowAutoFilterRow;
            gridview.OptionsView.ShowFooter = true;

            //Totales
            var FieldName = RowsCount_FieldName;
            gridview.GroupSummary.Clear();
            gridview.Columns[FieldName].Summary.Clear();
            gridview.Columns[FieldName].Summary.Add(DevExpress.Data.SummaryItemType.Count, FieldName, "Núm. Registros= {0}");
            gridview.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;

            DevExpress.XtraGrid.GridGroupSummaryItem itemGroupSummaryItem = new DevExpress.XtraGrid.GridGroupSummaryItem
            {
                FieldName = GroupCount_FieldName,
                DisplayFormat = "Total {0}",
                SummaryType = DevExpress.Data.SummaryItemType.Count,
                ShowInGroupColumnFooter = gridview.Columns[GroupCount_FieldName]
            };

            gridview.GroupSummary.Add(itemGroupSummaryItem);
        }

        public static wOverlaySplash ShowOverlay(Control parent, string caption = "")
        {
            var opt = new DevExpress.XtraSplashScreen.OverlayWindowOptions();
            opt.FadeIn = true;
            opt.FadeOut = true;
            opt.Opacity = 0.25;
            opt.BackColor = Color.FromArgb(31, 73, 125);


            var handle = new wOverlaySplash(parent, opt);

            //Timer timer = new Timer() { Interval = 4000 };
            //timer.Tick += (ss, ee) => {
            //    handle.Close();
            //    timer.Dispose();
            //};
            //timer.Start();
            return handle;
        }

        public static System.IO.Stream getStreamFromByteArray(Object array)
        {
            if (IsNullOrEmpty(array))
                return null;

            byte[] buffer = (array as byte[]);

            var stream = new System.IO.MemoryStream(buffer);

            return stream;
        }

        public static System.IO.Stream getStreamFromObject(object oStream)
        {
            if (IsNullOrEmpty(oStream))
                return null;

            byte[] buffer = (oStream as byte[]);

            var stream = new System.IO.MemoryStream(buffer);

            return stream;
        }

        public static string betweenStrings(string text, string start, string end)
        {
            int p1 = text.IndexOf(start) + start.Length;


            if (p1 <= 0)
                return "";

            int p2 = text.IndexOf(end, p1);

            if (p2 <= 0)
                return "";

            if (end == "")
                return (text.Substring(p1));
            else
                return text.Substring(p1, p2 - p1);
        }


        public static bool PreCheck_IsValidJson<T>(string jsonFormat)
        {
            if (IsNullOrEmpty(jsonFormat))
                return false;

            jsonFormat = jsonFormat.Trim();

            if ((jsonFormat.StartsWith("{") && jsonFormat.EndsWith("}")) ||// object
                (jsonFormat.StartsWith("[") && jsonFormat.EndsWith("]"))) // array
            {
                try
                {
                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonFormat);
                    return true;
                }
                catch // not valid
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static string DataTableToJson (System.Data.DataTable dt)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
            return json;

        }
        public static System.Data.DataTable JsonToDT(string jsonFormat)
        {
            try
            {
                jsonFormat = Utilerias.SafeToString(jsonFormat);

                if (!jsonFormat.StartsWith("["))
                    jsonFormat = "[" + jsonFormat;

                if (!jsonFormat.EndsWith("]"))
                    jsonFormat = jsonFormat + "]";

                var dt = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(jsonFormat);

                if (Utilerias.TablaTieneRows(dt))
                {
                    return dt;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        public static DevExpress.Utils.WaitDialogForm WaitWindow(object Parent = null, string cCaption = "Buscando datos. Favor espere...", string cTitle = "Ejecutando...", bool topMost = false)
        {
            //Alias.Size ozise = new Alias.Size(cCaption.Length * 7, 45);

            System.Drawing.Size ozise = new System.Drawing.Size(400, 75);
            var frmWait = new DevExpress.Utils.WaitDialogForm(cCaption, cTitle, ozise, (System.Windows.Forms.Form)Parent) { TopMost = topMost };
            frmWait.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            frmWait.Refresh();
            return frmWait;

            //var f = new fPOS.Forms.Base.dxWaitForm();
            //f.SetDescription(cCaption)
            //f.SetCaption(cTitle);
            //f.TopLevel = topMost;

            //return f;
        }
    }
}
