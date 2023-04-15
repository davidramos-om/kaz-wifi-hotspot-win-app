using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace mk_management.common
{
    public partial class FrmDownloadTemplates : DevExpress.XtraEditors.XtraForm
    {
        private DownloadService downloadService;
        private readonly bool openAfterDownload;
        private readonly bool startDownloadAutomatically;
        private readonly bool closeApp;
        private string DownloasPath = "";

        public FrmDownloadTemplates(string title, string url_file_to_download, bool enableInputs, bool openAfterDownload, bool startDownloadAutomatically, bool closeApp)
        {
            InitializeComponent();
            this.Icon = Utilerias.ObtenerIconoApp();
            this.Text = title;

            btnPause.Enabled = false;
            btnResume.Enabled = false;

            txtUri.Text = url_file_to_download;
            txtUri.Enabled = enableInputs;

            this.openAfterDownload = openAfterDownload;
            this.startDownloadAutomatically = startDownloadAutomatically;
            this.closeApp = closeApp;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (downloadService == null)
                return;

            btnResume.Enabled = true;
            btnPause.Enabled = false;
            downloadService.Pause();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            if (downloadService == null)
                return;

            btnResume.Enabled = false;
            btnPause.Enabled = true;
            downloadService.Resume();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var url = txtUri.Text;
            if (url.Length <= 0)
            {
                MessageBox.Show(this, "Debe indicar la direccion del archivo que desea descargar", "Falta Uri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            btnStart.Enabled = false;
            btnPause.Enabled = true;
            btnResume.Enabled = false;
            Thread thread1 = new Thread(Download);
            thread1.Start();
        }

        public void Download(object data)
        {
            var url = txtUri.Text;
            DownloasPath = $"{Application.UserAppDataPath}\\{Path.GetFileName(url)}";

            downloadService = new DownloadService(url, DownloasPath);
            downloadService.onDownloadCompleted += DownloadService_onDownloadCompleted;
            downloadService.onProgressChange += DownloadService_onProgressChange;
            downloadService.Start();
        }

        private void DownloadService_onProgressChange(DownloadStatus status)
        {
            try
            {
                if (this.Disposing || this.IsDisposed || this == null)
                    return;

                _ = Invoke((MethodInvoker)delegate
                {
                    progressBar1.Value = status.Progress;
                    lblProgress.Text = status.Progress_Text_RTL;
                    lblSpeed.Text = status.Speed_Text;
                    lblDownloaded.Text = status.Download_Text;
                    lblStatus.Text = $"{status.Status}...";
                    btnStart.Enabled = false;
                });
            }
            catch
            {

            }
        }

        private void DownloadService_onDownloadCompleted(string url, string path)
        {
            try
            {
                if (this.Disposing || this.IsDisposed || this == null)
                    return;

                _ = Invoke((MethodInvoker)delegate
                {
                    lblStatus.Text = "Descarga finalizada!!";
                    lblProgress.Text = "100 %";
                    btnStart.Enabled = true;
                    btnPause.Enabled = false;
                    btnResume.Enabled = false;

                    if (openAfterDownload)
                    {
                        if (Utilerias.EsValorValido(DownloasPath))
                            System.Diagnostics.Process.Start(DownloasPath);
                    }

                    if (closeApp)
                        Application.Exit();
                });
            }
            catch
            {
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (downloadService != null)
                downloadService.Pause();
        }

        private void FrmDownloadTemplates_Shown(object sender, EventArgs e)
        {
            if (startDownloadAutomatically)
                btnStart.PerformClick();
        }
    }
}
