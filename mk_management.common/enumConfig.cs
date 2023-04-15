using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mk_management.common
{
    public enum enumConfig
    {
        [Description("COM_NAME")]
        COM_NAME = 0,

        [Description("COM_DIR")]
        COM_DIR = 1,

        [Description("COM_CONTACTS")]
        COM_CONTACTS = 2,

        [Description("COM_LOGO")]
        COM_LOGO = 3,

        [Description("SYS_LOGO")]
        SYS_LOGO = 4,

        [Description("SYS_OPEN_DASH")]
        SYS_OPEN_DASH = 5,

        [Description("COM_LOGO_SIZE_MODE")]
        COM_LOGO_SIZE_MODE = 6,

        [Description("SYS_PRINT_USER_CRED_WIFI")]
        SYS_PRINT_USER_CRED_WIFI = 7,

        [Description("SYS_GEN_ROUTER_STATS")]
        SYS_GEN_ROUTER_STATS = 8,

        [Description("SYS_PROXY_URL")]
        SYS_PROXY_URL = 9,

        [Description("SYS_PROXY_PORT")]
        SYS_PROXY_PORT = 10,

        [Description("SYS_PROXY_ENABLE")]
        SYS_PROXY_ENABLE = 11,

        [Description("COM_RTN")]
        COM_RTN = 12,
    }
}
