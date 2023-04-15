using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mk_management.common
{
    public partial class ucSetting : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSetting()
        {
            InitializeComponent();
            tabbedControlGroup1.SelectedTabPage = lcgConexionBdd;
        }

        public void Inicializar()
        {
            using (var w = Utilerias.ShowOverlay(this))
            {
                ucAppSetting1.Inicializar(false);

                //ucActivate1.Comprobar();

                ucInfoComp1.Inicializar();
            }
        }
    }
}
