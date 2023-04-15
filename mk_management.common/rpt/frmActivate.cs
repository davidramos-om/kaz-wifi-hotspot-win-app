using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace mk_management.common.rpt
{
    public partial class frmActivate : DevExpress.XtraEditors.XtraForm
    {
        //public event EventHandler CloseEvent = new EventHandler((e, a) => { });
        public frmActivate(Icon icon)
        {
            InitializeComponent();
            this.Icon = icon;
        }

        private void frmActivate_Load(object sender, EventArgs e)
        {
            ucActivate1.MostrarBotonCerrar();
            ucActivate1.Comprobar();
        }

        public bool AppIsActivated()
        {
            return ucActivate1.AppActivated;
        }

        private void ucActivate1_CloseEvent(object sender, EventArgs e)
        {
            //CloseEvent?.Invoke(sender, e);
            //if (AppIsActivated())
            {
                this.Close();
            }
        }
    }
}