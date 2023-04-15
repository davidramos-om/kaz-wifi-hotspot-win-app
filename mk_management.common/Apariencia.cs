using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraLayout;

namespace mk_management.common
{
    public class Apariencia
    {
        public static readonly string BgTileViewColor = "#009688";
        public static readonly string BgSelectedTileItem = "#00C853";
        public static readonly string GroupBoxPanelTitleColor = "#FF9800";

        public static void SetTileViewColor(DevExpress.XtraGrid.Views.Tile.TileView tv)
        {
            tv.Appearance.ItemNormal.BackColor = Utilerias.GetWebColor(BgTileViewColor);
        }

        public static void SetGroupBoxPanelColor(LayoutControlGroup lcg)
        {
            //lcg.AppearanceGroup
        }
    }
}
