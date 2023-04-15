using mk_management.common.tasks;
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
    public partial class FrmAppChangeLog : DevExpress.XtraEditors.XtraForm
    {
        private readonly UpdateAvailable update;

        public FrmAppChangeLog(string title, UpdateAvailable update)
        {
            InitializeComponent();
            this.Text = title;
            this.Icon = Utilerias.ObtenerIconoApp();
            this.update = update;
            this.lbCurrentVersion.Text = "Versión Actual : " + Utilerias.VersionSistema();
            this.lbNewVersion.Text = "Nueva versión : " + update.app_version;

            webBrowser1.DocumentText = ToHtml(update.changelog); ;
        }

        private string ToHtml(string md)
        {
            try
            {
                var html = Markdig.Markdown.ToHtml(md);
                return html;
            }
            catch (Exception )
            {
                return "No se pudo mostrar las novedades.";
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (Utilerias.IsNullOrEmpty(update))
                return;

            var frmDownload = new FrmDownloadTemplates(this.Text, update.download_url, false, true, true, true);
            frmDownload.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
