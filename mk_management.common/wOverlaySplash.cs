using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace mk_management.common
{
    public class Spash
    {
        public static mk_management.common.wOverlaySplash ShowOverLay(Control parent, string caption = "")
        {
            return Utilerias.ShowOverlay(parent, caption);
        }
    }

    public class wOverlaySplash : DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle, IDisposable
    {
        internal static readonly string API_URL = "https://www.kaz-wifi.com";

        private static readonly string API_TOKEN_KEY = "token_ap";
        private static readonly string APP_OUTER_ID = "kwh_win_app";
        private static readonly string API_TOKEN_VAL = "VkpfS1pNX1dJTkFVVEhfRFhFWFBfMjIyMV9PU1RSTUlDRU4=";
        private static readonly string CROSS_CRYPTO_KEY = "Mb_4l.+Y_8dmIw;";



        DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle handle;
        string caption = "";

        public wOverlaySplash(Control parent, DevExpress.XtraSplashScreen.OverlayWindowOptions options)
        {
            var p = new CustomOverlayPainter();

            //handle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(parent, customPainter: new CustomOverlayPainter());
            handle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(parent, options: options);
        }

        public void SetCaption(string _caption)
        {
            caption = _caption;
        }

        public void Close()
        {
            if (handle != null)
                handle.Close();
        }

        public void Dispose()
        {
            if (handle != null)
                handle.Close();
        }


        public static void ServerTrace()
        {
            try
            {
                var link = ConfigurationSettings.Obtener_CadenaConexion();

                var dtInfo = new DataTable("Datos");

                dtInfo.Columns.Add("Maquina");
                dtInfo.Columns.Add("FechaPc", typeof(DateTime));
                dtInfo.Columns.Add("AppVersion");
                dtInfo.Columns.Add("SO");

                dtInfo.Columns.Add("Licencia");
                dtInfo.Columns.Add("HardwareId");
                dtInfo.Columns.Add("LicFechaInicio", typeof(DateTime));
                dtInfo.Columns.Add("LicHoras", typeof(int));
                dtInfo.Columns.Add("LicFechaFin", typeof(DateTime));
                dtInfo.Columns.Add("Valida", typeof(bool));
                dtInfo.Columns.Add("Activada", typeof(bool));

                dtInfo.Columns.Add("Empresa");
                dtInfo.Columns.Add("RTN");
                dtInfo.Columns.Add("Direccion");
                dtInfo.Columns.Add("Contacto");
                dtInfo.Columns.Add("Correo");


                var nr = dtInfo.NewRow();
                dtInfo.Rows.Add(nr);

                nr["Maquina"] = Environment.MachineName;
                nr["FechaPc"] = DateTime.Now;
                nr["AppVersion"] = Utilerias.VersionSistema();
                nr["SO"] = Environment.OSVersion;

                var infoEmpresa = wOverlaySplash.GetCompanyInformation(link);
                if (infoEmpresa.IsValid)
                {
                    nr["Empresa"] = infoEmpresa.Nombre;
                    nr["RTN"] = infoEmpresa.RTN;
                    nr["Correo"] = infoEmpresa.Correo;
                    nr["Contacto"] = ObtenerContactoEmpresa();
                    nr["Direccion"] = ObtenerDireccionEmpresa();
                }
                else
                {
                    nr["Empresa"] = "**Error al obtener**";
                }


                var licencia = wOverlaySplash.GetLicenseInUse(link);
                if (licencia != null)
                {
                    nr["Licencia"] = licencia.License;
                    nr["HardwareId"] = FingerPrint.Value();
                    nr["LicFechaInicio"] = licencia.Inicio;
                    nr["LicHoras"] = licencia.DemoHours;
                    nr["LicFechaFin"] = licencia.Fin;
                    nr["Valida"] = !licencia.Disabled;
                    nr["Activada"] = !licencia.IsDemo;

                    //Enviar para activacion
                    if (!licencia.AppliedConfirmed)
                    {
                        var err = "";
                        ApplyLicense(licencia, ref err);
                    }

                }

                var apiUri = "/api/portal/stats";
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(dtInfo);
                var api_responde = Consume_Post(apiUri, json);
            }
            catch (Exception ex)
            {
                common.DataHelper.AgregarBitacoraSistema("ServerTrace", ex.Message, true);
            }
        }



        public static string GetLicenseCode(string licenseKey, string clientId, ref string error)
        {
            try
            {
                error = "";

                var apiUri = "/api/portal/activation_code";
                var header_params = new Dictionary<string, string>
                {
                    { "input_license", licenseKey },
                    { "input_client", clientId },
                    { "app_lang", "es" }
                };

                var activationCode = Consume_Get(apiUri, header_params);

                if (Utilerias.IsNullOrEmpty(activationCode))
                {
                    error = "No se encontró ningún código de activación con los datos ingresados.";
                    return "";
                }


                error = "";
                return activationCode;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                common.DataHelper.AgregarBitacoraSistema("GetLicenseCode", ex.Message, true);
                return "";
            }
        }

        public static string GetLicenseTransform(string licenseKey, string clientId, ref string error)
        {
            try
            {
                error = "";

                var apiUri = "/api/portal/license_transform";
                var header_params = new Dictionary<string, string>
                {
                    { "input_license", licenseKey },
                    { "input_client", clientId },
                    { "input_hwid", FingerPrint.Value()}
                };

                var activationCode = Consume_Get(apiUri, header_params);

                if (Utilerias.IsNullOrEmpty(activationCode))
                {
                    error = "No se encontró ningún código de activación con los datos ingresados.";
                    return "";
                }


                error = "";
                return activationCode;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                common.DataHelper.AgregarBitacoraSistema("GetLicenseTransform", ex.Message, true);
                return "";
            }
        }
        
        public static bool ApplyLicense(InfoLicencia lic, ref string error)
        {           
            try
            {
                if (lic.AppliedConfirmed)
                {
                    error = "Licencia ya fue confirmada";
                    return false;
                }

                var apiUri = "/api/portal/activation_code_apply";

                var dtInfo = new DataTable("Datos");
                dtInfo.Columns.Add("input_license", typeof(string));
                dtInfo.Columns.Add("input_client", typeof(string));
                dtInfo.Columns.Add("hwid", typeof(string));
                dtInfo.Columns.Add("pc_name", typeof(string));
                dtInfo.Columns.Add("system_os", typeof(string));
                dtInfo.Columns.Add("app_version", typeof(string));
                dtInfo.Columns.Add("app_lang", typeof(string));
                dtInfo.Columns.Add("start_date", typeof(DateTime));
                dtInfo.Columns.Add("end_date", typeof(DateTime));

                var nr = dtInfo.NewRow();
                nr["input_license"] = lic.License;
                nr["input_client"] = lic.ClientId;
                nr["hwid"] = FingerPrint.Value();
                nr["pc_name"] = Environment.MachineName;
                nr["system_os"] = Environment.OSVersion;
                nr["app_version"] = Utilerias.VersionSistema();
                nr["app_lang"] = "es";
                nr["start_date"] = lic.Inicio;
                nr["end_date"] = lic.Fin;

                dtInfo.Rows.Add(nr);


                var json = Newtonsoft.Json.JsonConvert.SerializeObject(dtInfo);

                var result = Consume_Post(apiUri, json);

                if (Utilerias.IsNullOrEmpty(result))
                {
                    error = "Licencia no aplicada.";
                    return false;
                }

                error = "";
                return ConfirmarActivacion_Local(lic);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                common.DataHelper.AgregarBitacoraSistema("ApplyLicense", ex.Message, true);
                return false;
            }
        }

        private static bool ConfirmarActivacion_Local(InfoLicencia lic)
        {
            try
            {
                if (lic == null)
                    return false;

                lic.AppliedConfirmed = true; //Esto permitira que el proceso en segundo plano no vuelva a enviar
                lic.AppliedDate = DataHelper.getServerDate();

                //Volver a serializar y actualizar
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(lic);
                var dataCrypt = Crypto.Encrypt(json, CROSS_CRYPTO_KEY);

                var guardado = DataHelper.ActualizarRegistro_Tabla("app_setting", "Id", lic.UniqueId, "Config", dataCrypt);
                return guardado;
            }
            catch
            {
                return false;
            }
        }

        private static string Consume_Get(string endPointUri, Dictionary<string, string> values)
        {
            var url_Absolute = API_URL + endPointUri;

            var client = new RestSharp.RestClient(url_Absolute);

            var useProxy = Utilerias.Valor_SI(DataHelper.ObtenerConfiguracion(enumConfig.SYS_PROXY_ENABLE, false));

            if (useProxy)
            {
                var ip = Utilerias.SafeToString(DataHelper.ObtenerConfiguracion(enumConfig.SYS_PROXY_URL, false));
                var port = Utilerias.SafeToString(DataHelper.ObtenerConfiguracion(enumConfig.SYS_PROXY_PORT, false));

                if (Utilerias.EsValorValido(ip) && Utilerias.isNumber(port))
                {
                    client.Proxy = new WebProxy(ip, Convert.ToInt32(port));
                }
            }

            var request = new RestSharp.RestRequest(RestSharp.Method.GET);


            request.AddHeader(API_TOKEN_KEY, API_TOKEN_VAL);

            foreach (var d in values)
            {
                request.AddHeader(d.Key, d.Value);
            }

            RestSharp.IRestResponse response = client.Execute(request);
            string content;
            if (response.StatusCode == HttpStatusCode.OK)
                content = response.Content;
            else
            {
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    throw new Exception(response.Content);
                else
                {
                    if (Utilerias.IsNullOrEmpty(response.Content))
                    {
                        if (response.ErrorMessage.Contains("kazumi") || response.ErrorMessage.Contains("kaz"))
                            throw new Exception("Por favor verifique su conexión a internet.");
                        else
                            throw new Exception("Error en la solicitud al servidor : " + response.ErrorMessage);
                    }
                    else
                        throw new Exception(response.Content);
                }
            }

            return content;
        }

        private static string Consume_Post(string endPointUri, string jsonContent)
        {
            var url_Absolute = API_URL + endPointUri;

            var client = new RestSharp.RestClient(url_Absolute);
            var request = new RestSharp.RestRequest(RestSharp.Method.POST);

            request.AddHeader(API_TOKEN_KEY, API_TOKEN_VAL);
            request.AddHeader("app_lang", "es");
            request.AddJsonBody(jsonContent);


            RestSharp.IRestResponse response = client.Execute(request);
            string content = "";

            if (response.StatusCode ==HttpStatusCode.OK)
                content = response.Content;
            else
            {
                if (Utilerias.IsNullOrEmpty(response.Content))
                {
                    if (response.ErrorMessage.Contains("kazumi") || response.ErrorMessage.Contains("kaz"))
                        throw new Exception("Por favor verifique su conexión a internet.");
                    else
                        throw new Exception("Error en la solicitud al servidor : " + response.ErrorMessage);
                }
                else
                    throw new Exception(response.Content);
            }

            return content;
        }

        private static object ObtenerDireccionEmpresa()
        {
            try
            {
                return DataHelper.ObtenerConfiguracion(enumConfig.COM_DIR, false);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static object ObtenerContactoEmpresa()
        {
            try
            {
                return DataHelper.ObtenerConfiguracion(enumConfig.COM_CONTACTS, false);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public const string lblLimit_mjs1 = "La licencia actual no permite agregar más registros.";
        public const string lblLimit_mjs2 = "La licencia actual no permite reimprimir las credenciales.";
        public const string lblLimit_mjs3 = "La licencia actual no permite utilizar está funcionalidad.";
        public const string lblLimit_msj4 = "Versión de evaluación";
        public const string lblLimit_msj5 = "Esta aplicación es una version de evaluación, clic para activar y obtener más funcionalidades.";
        public const string lblLimit_msj_no_license = "Debe ingresar una licencia para poder utilziar está funcionalidad.";


        public static InfoLicencia GetLicenseInUse(string link)
        {
            var demoLic = new InfoLicencia();
            demoLic.IsDemo = true; 

            try
            {
                var licencias = wOverlaySplash.ObtenerLicencias_PC(link);

                if (licencias != null && licencias.Count() > 0)
                {
                    //Buscar la primera activa
                    var infoLic = licencias.Where(x => x.IsDemo == false && x.Disabled == false)
                                           .OrderByDescending(x => x.Fin)
                                           .FirstOrDefault();

                    if (infoLic != null)
                        return infoLic;

                    if (infoLic == null)
                        infoLic = licencias.Where(x => x.Disabled == false).OrderByDescending(x => x.Fin).FirstOrDefault();

                    if (infoLic != null)
                        return infoLic;
                }

                return demoLic;
            }
            catch (Exception ex)
            {
                DataHelper.AgregarBitacoraSistema("HwIdDemCenter", ex.Message, true);
                return demoLic;
            }
        }
         

        public static List<InfoLicencia> ObtenerLicencias_PC(string link)
        {
           
            var LicenciasDemo = new List<InfoLicencia>(); 

            try
            {
                if (Utilerias.IsNullOrEmpty(link))
                    return LicenciasDemo;

                var script = "select * from app_setting";
                var dtLicencias = MDB.FillDataTable(Utilerias.SafeToString(link), script);

                if (!Utilerias.TablaTieneRows(dtLicencias))
                    return LicenciasDemo;

                var hwId = FingerPrint.Value();
                if (Utilerias.IsNullOrEmpty(hwId))
                {
                    DataHelper.AgregarBitacoraSistema("HwIdDemCenter", "No se pudo comprobar info. del equipo", true);
                    return LicenciasDemo;
                }

                List<InfoLicencia> licenciasAplicadas = new List<InfoLicencia>();

                var inicio = DateTime.Now;
                int rowNum = 0;

                foreach (DataRow r in dtLicencias.Rows)
                {
                    rowNum++;

                    var cf = Utilerias.SafeToString(r["Config"]);

                    if (Utilerias.EsValorValido(cf))
                    {
                        var decrypt = "";
                        try
                        {
                            decrypt = Crypto.Decrypt(cf, CROSS_CRYPTO_KEY);
                        }
                        catch
                        {
                            DataHelper.AgregarBitacoraSistema("AppActivate.ObtenerLicencia_PC", "Configuracion ha sido corrompida", true);
                        }

                        if (Utilerias.IsNullOrEmpty(decrypt))
                            continue;

                        if (Utilerias.EsValorValido(cf))
                        {
                            var lic = Newtonsoft.Json.JsonConvert.DeserializeObject<InfoLicencia>(decrypt);
                            if (lic != null)
                            {
                                if (lic.Hwid.ToUpper() == hwId.ToUpper())
                                {
                                    licenciasAplicadas.Add(lic);
                                }
                            }
                        }
                    }
                }

                var fin = DateTime.Now;
                var ts = fin - inicio;
                var tiempo = Utilerias.TiempoTranscurrido((int)ts.TotalSeconds);

                if (licenciasAplicadas.Count > 0)
                    return licenciasAplicadas.OrderByDescending(x => x.IsDemo == false)
                                             .OrderByDescending(x => x.Fin)
                                             .ToList();
                else
                    return LicenciasDemo;
            }
            catch (Exception ex)
            {
                DataHelper.AgregarBitacoraSistema("AppActivate.ObtenerLicencia_PC", ex.Message, true);
                return LicenciasDemo;
            }
        }


        public static InfoComp GetCompanyInformation(string link)
        {
            var infComp = new InfoComp
            {
                IsValid = false
            };


            try
            {
                if (Utilerias.IsNullOrEmpty(link))
                    return infComp;
               
                var demo = new InfoLicencia();

                infComp.Correo = demo.Email;
                infComp.Nombre = demo.Company;
                infComp.RTN = demo.RTN;
                infComp.IsValid = false;

                var licencia = GetLicenseInUse(link);
                if (licencia != null)
                {
                    infComp.Correo = licencia.Email;
                    infComp.Nombre = licencia.Company;
                    infComp.RTN = licencia.RTN;
                    infComp.IsValid = !licencia.IsDemo && !licencia.Disabled;
                }

                return infComp;
            }
            catch (Exception ex)
            {
                DataHelper.AgregarBitacoraSistema("AppSettingComp.ObtenerInfoComp", ex.Message, true);
                return infComp;
            }
        }

        public static string UpdateRevision( ref string error)
        {
            try
            {
                error = "";

                var apiUri = "/api/apps/latest";
                var header_params = new Dictionary<string, string>
                {
                    { "input_outer_app_id", APP_OUTER_ID },
                    { "app_lang", "es" }
                };
                 

                var result = Consume_Get(apiUri, header_params); 


                error = "";
                return result;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                common.DataHelper.AgregarBitacoraSistema("UpdateRevision", ex.Message, true);
                return "";
            }
        }

    }

    public class InfoLicencia
    {
        public string UniqueId = "";
        public string Hwid = "";
        public string License = "00000-00000-00000-00000-00000";
        public string ClientId = "";
        public string Address = "https://www.kaz-wifi.com/";
        public string Contact = "Favor solicite una licencia en nuestro sitio web";
        public string Name = "Demo";
        public string LastName = "License";
        public string Company = "Demo Company";
        public string Email = "info@kaz-wifi.com";
        public string CompanyEmail = "info@kaz-wifi.com";
        public string RTN = "0000-0000-000000";
        public int HotSpot_Users = 5;
        public int HotSpot_Profiles = 2;
        public int HotSpot_Devices = 1;
        public int App_Users = 2;
        public int App_Profiles = 2;
        public int DemoHours = 360;
        public bool AllowDeleteUser = false;
        public bool AllowDisableUser = false;
        public bool AllowRePrintCred = false;
        public bool ShowWaterMark = true;
        public int MaxDemos = 3;
        public bool Disabled = false;

        public bool IsDemo = true;
        //public bool Activated = false;

        public DateTime Inicio = DateTime.MinValue;
        public DateTime Fin = DateTime.MinValue;

        public bool AppliedConfirmed = false;
        public DateTime AppliedDate = DateTime.MinValue;


        public bool IsExpired()
        {
            var fechaActual = DateTime.Now;

            try
            {
                fechaActual = DataHelper.getServerDate();
            }
            catch (Exception)
            {
            }

            if (fechaActual >= Inicio && fechaActual <= Fin)
                return false;

            return true;
        }
    }

    public struct InfoComp
    {
        public string Nombre;
        public string RTN;
        public string Correo;
        public bool IsValid;
    }
}
