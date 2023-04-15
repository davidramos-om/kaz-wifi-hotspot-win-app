using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace mk_management.common
{
    public class MDB
    {

        public static bool ExecuteProcedure(string connectionString, string storedProcedure, List<MySqlParameter> parameters)
        {
            using (var cmd = new MySqlCommand())
            {
                using (var cnn = new MySqlConnection(connectionString))
                {
                    cnn.Open();

                    cmd.CommandText = storedProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters.ToArray());

                    cmd.Connection = cnn;
                    var resultado = cmd.ExecuteNonQuery();


                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();

                    return resultado > 0;
                }
            }
        }


        public static object ExecuteScalar(string ConnectionStringData, string sql)
        {
            return ExecuteScalar(ConnectionStringData, sql, null);
        }


        public static object ExecuteScalar(string connectionString, string sql, List<MySqlParameter> parameters)
        {
            using (var cmd = new MySqlCommand())
            {
                using (var cnn = new MySqlConnection(connectionString))
                {
                    cnn.Open();

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cnn;

                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters.ToArray());

                    var resultado = cmd.ExecuteScalar();

                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();

                    return resultado;
                }
            }
        }


        public static bool ExecuteNonQuery(string connectionString, string sql, List<MySqlParameter> parameters)
        {
            using (var cmd = new MySqlCommand())
            {
                using (var cnn = new MySqlConnection(connectionString))
                {
                    cnn.Open();

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cnn;

                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters.ToArray());

                    var resultado = cmd.ExecuteNonQuery();

                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();

                    return resultado > 0;
                }
            }
        }


        public static DataTable FillDataTable(string connectionString, string sql)
        {
            var t1 = new DataTable("data");

            return FillDataTable(connectionString, sql, t1, null);
        }

        public static DataTable FillDataTable(string connectionString, string sql, List<MySqlParameter> parametros)
        {
            var t1 = new DataTable("data");

            return FillDataTable(connectionString, sql, t1, parametros);
        }

        public static DataTable FillDataTable_SP(string connectionString, string SP, List<MySqlParameter> parameters, DataTable t1)
        {
            using (var cmd = new MySqlCommand())
            {
                using (var cnn = new MySqlConnection(connectionString))
                {
                    cnn.Open();

                    cmd.CommandText = SP;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = cnn;

                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters.ToArray());

                    if (t1 == null)
                        t1 = new DataTable("Datos");

                    using (var a = new MySqlDataAdapter(cmd))
                    {
                        a.Fill(t1);
                    }

                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();

                    return t1;
                }
            }
        }

        public static DataTable FillDataTable(string connectionString, string sql, DataTable t1, List<MySqlParameter> parametros)
        {
            using (var cmd = new MySqlCommand())
            {
                using (var cnn = new MySqlConnection(connectionString))
                {
                    cnn.Open();

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cnn;
                    
                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros.ToArray());

                    if (t1 == null)
                        t1 = new DataTable("Datos");

                    using (var a = new MySqlDataAdapter(cmd))
                    {
                        a.Fill(t1);
                    }

                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();

                    return t1;
                }
            }
        }

        internal static void UpdateBulkTable(string cnn, string tableName, DataTable rawData)
        {
            using (var conn = new MySqlConnection(cnn))
            {
                conn.Open();

                using (MySqlTransaction tran = conn.BeginTransaction(System.Data.IsolationLevel.Serializable))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.Transaction = tran;
                        cmd.CommandText = $"select * from {tableName}";

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.UpdateBatchSize = 1000;

                            using (MySqlCommandBuilder cb = new MySqlCommandBuilder(da))
                            {
                                da.Update(rawData);
                                tran.Commit();
                            }
                        }

                        if (conn.State == ConnectionState.Open)
                            conn.Close();
                    }
                }
            }

        }

    }
}
