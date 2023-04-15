using AltoHttp;
using System;

namespace mk_management.common
{
    public class DownloadService
    {
        private readonly HttpDownloader httpDownloader;
        private readonly string download_url;
        private readonly string target_path;

        public event onProgressChange onProgressChange;
        public event onDownloadCompleted onDownloadCompleted;

        public DownloadService(string _download_url, string _target_path)
        {
            if (string.IsNullOrEmpty(_download_url))
            {
                throw new ArgumentException($"'{nameof(_download_url)}' cannot be null or empty.", nameof(_download_url));
            }

            if (string.IsNullOrEmpty(_target_path))
            {
                throw new ArgumentException($"'{nameof(_target_path)}' cannot be null or empty.", nameof(_target_path));
            }

            download_url = _download_url;
            target_path = _target_path;
            httpDownloader = new HttpDownloader(_download_url, _target_path);
        }

        public void Start()
        {
            if (httpDownloader.State == Status.Downloading)
                return;

            httpDownloader.DownloadCompleted += HttpDownloader_DownloadCompleted;
            httpDownloader.ProgressChanged += HttpDownloader_ProgressChanged;
            httpDownloader.Start();
        }

        public void Pause()
        {
            if (httpDownloader == null)
                return;

            if (httpDownloader.State == Status.Downloading)
                httpDownloader.Pause();
        }


        public void Resume()
        {
            if (httpDownloader == null)
                return;

            if (httpDownloader.State == Status.Paused)
                httpDownloader.Resume();
        }


        private void HttpDownloader_ProgressChanged(object sender, AltoHttp.ProgressChangedEventArgs e)
        {
            onProgressChange?.Invoke(new DownloadStatus((int)e.Progress, e.SpeedInBytes, e.TotalBytesReceived, "Descargando"));
        }

        private void HttpDownloader_DownloadCompleted(object sender, EventArgs e)
        {
            onDownloadCompleted?.Invoke(download_url, target_path);
        }
    }

    public class DownloadStatus
    {
        int progress;
        int speed;
        long downloaded;
        string status;

        public DownloadStatus(int progress, int speed, long downloaded, string status)
        {
            this.progress = progress;
            this.speed = speed;
            this.downloaded = downloaded;
            this.status = status;
        }

        public int Progress { get => progress; set => progress = value; }
        public string Progress_Text { get => $"{progress:0.00} %"; }
        public string Progress_Text_RTL { get => $"% {progress:0.00}"; }

        public int Speed { get => speed; set => speed = value; }
        public string Speed_Text { get => $"{speed / 1024d / 1024d:0.00}MB/s"; }


        public long Downloaded { get => downloaded; set => downloaded = value; }
        public string Download_Text { get => $"{downloaded / 1024d / 1024d:0.00} MB"; }

        public string Status { get => status; set => status = value; }
    }

    public delegate void onProgressChange(DownloadStatus status);
    public delegate void onDownloadCompleted(string url, string path);
}
