using System;
using System.Windows.Forms;

namespace mk_management.common
{
    public partial class ucInfoApp : DevExpress.XtraEditors.XtraUserControl
    {
        public ucInfoApp()
        {
            InitializeComponent();
            this.labelCopyright.Text = "Copyright © growits desde 2019 ";
            this.labelStatus.Text = "v. " + Application.ProductVersion;
        }
          

        private void peLogoGrowits_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.growits.com");
            }
            catch 
            {

            }
        }

        private void peLogoFlash_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.facebook.com/flashnethn");
            }
            catch
            { 
            }
        }

        private void peImage_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.kaz-wifi.com");
            }
            catch
            { 
            }
        }
    }
}