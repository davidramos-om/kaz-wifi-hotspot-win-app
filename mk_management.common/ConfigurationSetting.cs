using System;
using System.Collections.Specialized;
using System.IO;
using System.Xml;

namespace mk_management.common
{
    public class ConfigurationSettings
    {
        static readonly string cf_CnnBDD = "cf_Cnn_BDD";
        static readonly string cf_Token = "cf_Token";
        static readonly string cf_AutoConectar = "Autoconectar";
        

        private static readonly bool archivoEncriptado = true;

        private static NameValueCollection appSettings;

        public static NameValueCollection AppSettings
        {
            get
            {
                if (appSettings == null)
                    LoadConfig();

                return appSettings;
            }
        }

        public static bool LoadConfig()
        {
            try
            {
                var path = Utilerias.ObtenerPath_AppSetting();

                if (!File.Exists(path))
                {
                    //var msj = String.Format("El archivo de confirguración {0} no existe.", path);
                    //Utilerias.msjError(msj);
                    return false;
                }

                var oXml = new XmlDocument();
                oXml.Load(path);

                var oList = oXml.GetElementsByTagName("appSettings");
                appSettings = new NameValueCollection();


                foreach (XmlNode oNode in oList)
                {
                    foreach (XmlNode oKey in oNode.ChildNodes)
                    {
                        if (Utilerias.SafeToString(oKey.Attributes["key"].Value) == cf_AutoConectar)
                        {
                            appSettings.Add(oKey.Attributes["key"].Value, oKey.Attributes["value"].Value);
                        }
                        else
                        {
                            if (archivoEncriptado)
                                appSettings.Add(Crypto.Decrypt(oKey.Attributes["key"].Value), Crypto.Decrypt(oKey.Attributes["value"].Value));
                            else
                                appSettings.Add((oKey.Attributes["key"].Value), oKey.Attributes["value"].Value);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Utilerias.msjError(ex.Message);
                return false;
            }
        }

        public static string Obtener_Token()
        {
            var apps = AppSettings;
            if (apps == null)
                return "";

            var val = apps[cf_Token];
            return Utilerias.SafeToString(val);
        }

        public static string Obtener_CadenaConexion()
        {
            var apps = AppSettings;
            if (apps == null)
                return "";

            var val = apps[cf_CnnBDD];
            return Utilerias.SafeToString(val);
        }

        public static bool Obtener_AutoConectar()
        {
            var apps = AppSettings;
            if (apps == null)
                return false;

            var val = apps[cf_AutoConectar].ToLower().Trim();
            return Utilerias.Valor_SI(val);
        }


        public static bool SaveSettings(string ConfigFilePath, string key_cnnBddDatos, string key_token, string key_Autoconectar, ref string Error, bool guardarCambios)
        {
            try
            {
                //if(AppSettings ==null)
                //{
                //    Error = "El archivo de configuración es incorrecto.";
                //    return false;
                //}

                if (AppSettings == null)
                    guardarCambios = true; //Siempre guardar si no se encontro un archivo

                Error = "";

                if (AppSettings != null)
                {
                    AppSettings.Remove(cf_CnnBDD);
                    AppSettings.Remove(cf_Token);
                    AppSettings.Remove(cf_AutoConectar);
                }

                string content = "";

                if (archivoEncriptado)
                {
                    content += AppSettings_Add(Crypto.Encrypt(cf_CnnBDD), Crypto.Encrypt(key_cnnBddDatos));
                    content += AppSettings_Add(Crypto.Encrypt(cf_Token), Crypto.Encrypt(key_token));

                    content += AppSettings_Add(cf_AutoConectar, key_Autoconectar);
                }
                else
                {
                    content += AppSettings_Add(cf_CnnBDD, key_cnnBddDatos);
                    content += AppSettings_Add(cf_Token, key_token);

                    content += AppSettings_Add(cf_AutoConectar, key_Autoconectar);
                }

                if (!guardarCambios)
                    return false; //solo cambios temporales, en memoria, no modificar el archivo

                string setting = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                                    <configuration>
                                        <appSettings>
                                        {0}
                                        </appSettings>
                                    </configuration>";

                setting = string.Format(setting
                                        , content                   // 0 
                                        );

                //if (!File.Exists(ConfigFilePath))
                //    File.Create(ConfigFilePath);

                using (TextWriter tsw = new StreamWriter(ConfigFilePath))
                {
                    tsw.Write(setting);
                    tsw.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }


        private static string AppSettings_Add(string key, string value)
        {
            var retorno = @"<add key=""{0}"" value=""{1}"" />" + Environment.NewLine;
            retorno = string.Format(retorno, key, value);

            if (AppSettings != null)
            {
                AppSettings.Add(key, value);
            }

            return retorno;
        }
    }
}

