using mk_management.common;
using System;
using System.Collections.Generic;
using System.Data;

namespace mk_management
{
    internal class MK_Checks
    {
        private static readonly string tk = "pkcTkJqQ|KxmpW7E7*KxmpW7E7";

        internal static void CheckUsageStats()
        {
            try
            {
                var generar = Utilerias.Valor_SI(DataHelper.ObtenerConfiguracion(enumConfig.SYS_GEN_ROUTER_STATS, false));

                if (!generar)
                    return;

                //using (var w = common.Utilerias.WaitWindow(this, "Revisando estadisticas"))
                //using (var w = common.Utilerias.ShowOverlay(null, "Revisando estadisticas")) 
                {
                    var cnn = common.ConfigurationSettings.Obtener_CadenaConexion();

                    var dtDisp = common.DataHelper.ConsultarRegistro("server", "Id", "", false, " order by predeterminado desc");
                    if (!common.Utilerias.TablaTieneRows(dtDisp))
                        return;

                    foreach (DataRow r in dtDisp.Rows)
                    {
                        var id = common.Utilerias.SafeToString(r["Id"]);
                        if (common.Utilerias.IsNullOrEmpty(id))
                            continue;

                        //w.Caption = "Revisando en : " + id;
                        //w.SetCaption("Revisando en : " + id);

                        common.DataHelper.AgregarBitacoraSistema("CheckUsageStats", "Ini. Estats. Device : " + id, false);

                        GetUsageStats(id);

                        common.DataHelper.AgregarBitacoraSistema("CheckUsageStats", "Fin. Estats. Device : " + id, false);
                    }
                }
            }
            catch (Exception ex)
            {
                common.DataHelper.AgregarBitacoraSistema("CheckUsageStats", ex.Message, true);
            }
        }

        internal static void GetUsageStats(string serverId)
        {
            try
            {
                var svrInfo = hotspot.Helper.ObtenerDatosServidor(serverId, tk);

                if (svrInfo != null)
                {
                    if (!Utilerias.PingHost(svrInfo.getIP))
                    {
                        common.DataHelper.AgregarBitacoraSistema("GetUsageStats : " + serverId, "No connection", true);
                        return;
                    }
                }

                var mk = new mk_management.hotspot.MK(svrInfo.getIP, svrInfo.getPort, svrInfo.getOsVersion);

                if (!mk.Login(svrInfo.getUser, svrInfo.getPwd))
                {
                    mk.Close();
                    common.DataHelper.AgregarBitacoraSistema("GetUsageStats : " + serverId, "Not logued", true);
                    return;
                }

                var info = mk.getActiveConnections();
                mk.Close();
                if (hotspot.Helper.ProcesoMK_TieneErrores(info))
                {
                    common.DataHelper.AgregarBitacoraSistema("GetUsageStats : " + serverId, "No mk info", true);
                    return;
                }

                var dtInfo = hotspot.Helper.DataTableFromMKArray(info, tk);

                if (!common.Utilerias.TablaTieneRows(dtInfo))
                {
                    common.DataHelper.AgregarBitacoraSistema("GetUsageStats : " + serverId, "No dt info", true);
                    return;
                }

                foreach (DataRow r in dtInfo.Rows)
                {
                    decimal b_in_mb = 1024;
                    var b_in = Convert.ToDecimal(common.Utilerias.NullValue(r["bytes_in"], 0)) / b_in_mb;
                    var b_out = Convert.ToDecimal(common.Utilerias.NullValue(r["bytes_out"], 0)) / b_in_mb;

                    r["bytes_in"] = decimal.Round(b_in / b_in_mb, 2);
                    r["bytes_out"] = decimal.Round(b_out / b_in_mb, 2);
                }

                //var json = Newtonsoft.Json.JsonConvert.SerializeObject(dtInfo);
                var json = Utilerias.DataTableToJson(dtInfo);
                //var id = common.Utilerias.GenerateDateId();


                //common.DataHelper.ActualizarRegistro_Tabla("routeros_usage_stats", "Id", id, "ServerId", serverId, "json_data", "json");
                common.DataHelper.CrearRegistro_Tabla("routeros_usage_stats", "ServerId", serverId, "json_data", json);
            }
            catch (Exception ex)
            {
                common.DataHelper.AgregarBitacoraSistema("GetUsageStats : " + serverId, ex.Message, true);
            }
        }
    }
}

