using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mk_management.common
{
    public class Link
    {
        internal static string ConnectionString = "";
        internal static string CompanyName = "";
        internal static string AppId = "";
        internal static string IdUsuario = "";

        public static void SetData(string _connectionString, string _companyName, string _appId,string _IdUsuario)
        {
            ConnectionString = _connectionString;
            CompanyName = _companyName;
            AppId = _appId;
            IdUsuario = _IdUsuario;
        }
    }
}
