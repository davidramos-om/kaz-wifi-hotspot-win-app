using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace mk_management.common
{
    public class DataHelper
    {
        public static DataTable Obt_PrimerReg(string tabla, string campo)
        {

            var sql = $"select * from {tabla} t where t.Activo = 1 order by t.{campo} asc limit 1";

            var resultado = MDB.FillDataTable(Link.ConnectionString, sql);

            return resultado;
        }

        public static int Obt_AnteriorReg(string tabla, string campo, int IdActual)
        {
            var sql = $"select t.{campo} from {tabla} t where t.{campo} < {IdActual} and t.Activo = 1 order by t.{campo} desc limit 1";

            var resultado = Convert.ToInt32(Utilerias.NullValue(MDB.ExecuteScalar(Link.ConnectionString, sql), -1));

            return resultado;
        }

        public static int Obt_SiguienteReg(string tabla, string campo, int IdActual)
        {
            var sql = $"select t.{campo} from {tabla} t where t.{campo} > {IdActual} and t.Activo = 1 order by t.{campo} asc limit 1";

            var resultado = Convert.ToInt32(Utilerias.NullValue(MDB.ExecuteScalar(Link.ConnectionString, sql), -1));

            return resultado;
        }

        public static DataTable Obt_UltimoReg(string tabla, string campo)
        {
            var sql = $"select * from {tabla} t where t.Activo = 1 order by t.{campo} desc limit 1";

            var resultado = MDB.FillDataTable(Link.ConnectionString, sql);

            return resultado;
        }

        public static bool ExisteDescRegistro(string tabla, string FieldNameId, string ValorId, string FieldNameDesc, string ValorDesc)
        {
            var sql = $"select {FieldNameDesc} from {tabla} t where t.Activo = 1 and {FieldNameDesc} ='{ValorDesc}' and {FieldNameId} <> '{ValorId}'";

            var dtResultado = MDB.FillDataTable(Link.ConnectionString, sql);

            return dtResultado.Rows.Count > 0;
        }

        public static bool EliminarRegistro(string Tabla, string FieldNameKey, object IdRegistro)
        {
            var apostrofes = @"'";
            //var esTexto = true;
            if (Utilerias.isNumber(IdRegistro))
            {
                //esTexto = false;
                apostrofes = "";
            }

            var sql = $@"   update {Tabla}
                               set Activo               = 0, 
                                   FechaElimino         = now(),
                                   UsuarioElimino       = '{Link.IdUsuario}'
                             where {FieldNameKey}       = {apostrofes}{IdRegistro}{apostrofes}
                               and Activo               = 1
                        ";

            return MDB.ExecuteNonQuery(Link.ConnectionString, sql, null);
        }

        public static int CantRegistros(string tabla, string IdExcluir, bool filtrarActivos = false)
        {
            var filtro = filtrarActivos ? " and Activo = 1" : "";

            var sql = $" select count(1) from {tabla} where Id <> '{IdExcluir}' " + filtro;

            var items = MDB.ExecuteScalar(Link.ConnectionString, sql);

            if (Utilerias.isNumber(items))
                return Convert.ToInt32(items);

            return 0;
        }

        public static DataTable ConsultarRegistro(string tabla, string campoId, string IdValorRegistro, bool limit_1 = true, string OrderBy = "")
        {
            var filtroId = "";
            var limit = "";

            if (Utilerias.EsValorValido(IdValorRegistro))
            {
                filtroId = $" and t.{campoId} = '{IdValorRegistro}'";

                if (limit_1)
                    limit = "limit 1";
            }

            var sql = $"select * from {tabla} t where 1=1 {filtroId} and t.Activo = 1 {limit} {OrderBy}";

            var resultado = MDB.FillDataTable(Link.ConnectionString, sql);

            return resultado;
        }

        public static string Dateformat_YYYMMDD_SQLCAST(object value)
        {
            var _value = Dateformat_YYYYMMDD(value).Trim().ToString();
            var apostrophe = _value == "NULL" ? "" : "'";

            return " cast (" + apostrophe + _value + apostrophe + " as date)";
        }

        public static object ObtenerConfiguracion(enumConfig cf, bool binary)
        {
            var str = Enum.GetName(typeof(enumConfig), cf);

            var dt = ConsultarRegistro("sys_config", "config", str);

            if (Utilerias.TablaTieneRows(dt))
            {
                var val = dt.Rows[0][binary ? "value_bin" : "value"];

                return val;
            }

            return null;
        }

        public static string Dateformat_YYYYMMDD(object value)
        {
            if (!Utilerias.IsNullOrEmpty(value))
            {
                if (value.ToString().ToUpper() == "NULL")
                    return value.ToString();
            }

            if (!Utilerias.DateValueValid(value))
                return " NULL ";

            var dt = Convert.ToDateTime(value);
            return dt.Year + dt.Month.ToString().PadLeft(2, '0') + dt.Day.ToString().PadLeft(2, '0');
        }

        public static bool ActualizarDispositivosPredeterminados()
        {
            var query = "update server set Predeterminado = 'N' where Activo = 1";

            var r = MDB.ExecuteNonQuery(Link.ConnectionString, query, null);

            return r;
        }

        public static bool ActualizarRegistro_Tabla(string Tabla, string CampoLlave, object IdRegistro, params object[] valores)
        {
            var columnas_update = new List<string>();

            var parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter($@"{CampoLlave}", IdRegistro));
             
            if (valores.Length > 0)
            {
                for (int i = 0; i < valores.Length; i += 2)
                {
                    var campo = valores[i].ToString();
                    var valor = valores[i + 1];



                    var p = new MySqlParameter();

                    if (valor.GetType() == typeof(System.IO.MemoryStream))
                    {
                        columnas_update.Add($"{campo}= @{campo}_blob");

                        p.ParameterName = "@" + campo + "_blob";
                        //p.Value = valor;
                        //p.DbType = DbType.Object;
                        //p.MySqlDbType = MySqlDbType.Blob;
                        var ms = valor as System.IO.MemoryStream;
                        //p.Value = ms;
                        //p.Size = (int)ms.Length;

                        p.Value = ms.ToArray();
                    }
                    else
                    {
                        columnas_update.Add($"{campo}= @{campo}");
                        p.ParameterName = "@" + campo;
                        p.Value = valor;
                    }

                    parametros.Add(p);
                }
            }

            var str_columnas_update = string.Join(",", columnas_update);

            var sql = $@"   update {Tabla} set
                                   {str_columnas_update}
                             where {CampoLlave} = @{CampoLlave}
                        ";

            return MDB.ExecuteNonQuery(Link.ConnectionString, sql, parametros);
        }

        public static bool AgregarBitacoraSistema(string titulo, string observacion, bool EsError)
        {
            try
            {
                if (Utilerias.IsNullOrEmpty(Link.ConnectionString))
                    return false;

                var columnas_insert = new List<string>();
                var parametros_insert = new List<string>();

                var parametros = new List<MySqlParameter>();

                parametros.Add(new MySqlParameter(@"Titulo", titulo));
                parametros.Add(new MySqlParameter(@"Observacion", observacion));
                parametros.Add(new MySqlParameter(@"EsError", EsError));


                parametros.Add(new MySqlParameter(@"AppVersion", Utilerias.VersionSistema()));
                parametros.Add(new MySqlParameter(@"AppId", Link.AppId));
                parametros.Add(new MySqlParameter(@"PcHost", Utilerias.ObtenerPcHost()));
                parametros.Add(new MySqlParameter(@"UsuarioCreo", Link.IdUsuario));

                var str_columnas = string.Join(",", columnas_insert);
                var str_parametros = string.Join(",", parametros_insert);

                var sql = $@"insert into bitacora_sistema(Titulo,Observacion,EsError,AppVersion,AppId,PcHost,FechaCreo,UsuarioCreo,Activo) 
                                     values (@Titulo,@Observacion,@EsError,@AppVersion,@AppId,@PcHost,now(),@UsuarioCreo,1)";

                return MDB.ExecuteNonQuery(Link.ConnectionString, sql, parametros);
            }
            catch
            {
                return false;
            }
        }

        public static bool CrearRegistro_Tabla(string Tabla, params object[] valores)
        {

            var columnas_insert = new List<string>();
            var parametros_insert = new List<string>();

            var parametros = new List<MySqlParameter>();

            var id = Utilerias.GenerateDateId();
            bool generateId = true;

            if (valores.Length > 0)
            {
                for (int i = 0; i < valores.Length; i += 2)
                {
                    var f = valores[i].ToString().ToUpper();
                    if (f == "ID")
                    {
                        id = Utilerias.SafeToString(valores[i + 1]);
                        generateId = false;
                        break;
                    }
                }
            }


            if (generateId)
            {
                parametros.Add(new MySqlParameter(@"Id", id));
            }

            parametros.Add(new MySqlParameter(@"AppVersion", Utilerias.VersionSistema()));
            parametros.Add(new MySqlParameter(@"AppId", Link.AppId));
            parametros.Add(new MySqlParameter(@"PcHost", Utilerias.ObtenerPcHost()));
            parametros.Add(new MySqlParameter(@"UsuarioCreo", Link.IdUsuario));

            var generarToken = false;

            if (Tabla == "perfil_hotspot" ||
               Tabla == "perfil_sistema" ||
               Tabla == "usuario_hotspot" ||
               Tabla == "usuario_sistema" ||
               Tabla == "server" ||
               Tabla == "app_setting" ||
               Tabla == "routeros_usage_stats"
               )
            {
                generarToken = true;

            }


            if (generarToken)
            {
                var token = Utilerias.GetRandomString(10) + "|" + id + "|" + Utilerias.GetRandomString(10);
                token = Crypto.Encrypt(token, "kmz-wf-app");
                parametros.Add(new MySqlParameter(@"Token", token));


                columnas_insert.Add("Token");
                parametros_insert.Add("@Token");
            }

            if (valores.Length > 0)
            {
                for (int i = 0; i < valores.Length; i += 2)
                {
                    var f = valores[i].ToString();
                    var v = valores[i + 1];

                    columnas_insert.Add(f);
                    parametros_insert.Add($"@{f}");

                    var p = new MySqlParameter();
                    p.ParameterName = "@" + f;
                    p.Value = v;

                    parametros.Add(p);
                }
            }
            var str_columnas = string.Join(",", columnas_insert);
            var str_parametros = string.Join(",", parametros_insert);

            var sql = "";

            if (generateId)
            {
                sql = $@"insert into {Tabla}(Id,AppVersion,AppId,PcHost,FechaCreo,UsuarioCreo,{str_columnas},Activo) 
                                     values (@Id,@AppVersion,@AppId,@PcHost,now(),@UsuarioCreo,{str_parametros},1)";
            }
            else
            {
                sql = $@"insert into {Tabla}(AppVersion,AppId,PcHost,FechaCreo,UsuarioCreo,{str_columnas},Activo) 
                                     values (@AppVersion,@AppId,@PcHost,now(),@UsuarioCreo,{str_parametros},1)";
            }

            return MDB.ExecuteNonQuery(Link.ConnectionString, sql, parametros);
        }

        public static DateTime getServerDate()
        {
            var fecha = MDB.ExecuteScalar(Link.ConnectionString, "select now()");

            return Convert.ToDateTime(fecha);
        }

        public static bool ConexionValida(string cnn, ref string error)
        {
            try
            {
                error = "";
                //var fecha = MDB.ExecuteScalar(cnn, "select now()");
                var fecha = MDB.ExecuteScalar(cnn, "SELECT NOW()");
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}
