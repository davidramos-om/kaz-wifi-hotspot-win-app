using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mk_management.common.tasks
{
    public partial class check_app_updates
    {
        private bool auto_update_already_checked = false;

        private string GetColumanValue(DataTable dt, string column)
        {
            return dt.Columns[column] != null ? Utilerias.SafeToString(dt.Rows[0][column]) : "";
        }

        private int str_to_int_version(string version)
        {
            var arr = version.Split('.');
            var year = arr.Length >= 0 ? int.Parse(arr[0]) : 0;
            var month = arr.Length >= 1 ? int.Parse(arr[1]) : 0;
            var day = arr.Length >= 2 ? int.Parse(arr[2]) : 0;
            var hour = arr.Length >= 3 ? int.Parse(arr[3]) : 0;

            return year + month + day + hour;
        }

        public UpdateAvailable CheckUpdates(string current_version, bool manual_check, ref string errors)
        {
            try
            {
                errors = "";

                if (!manual_check)
                {
                    //In case of a job check, do not check every time the job runs
                    if (auto_update_already_checked)
                        return null;
                }

                if (!Utilerias.EsValorValido(current_version))
                    return null;

                var info = wOverlaySplash.UpdateRevision(ref errors);

                if (Utilerias.EsValorValido(errors))
                    return null;

                if (Utilerias.EsValorValido(info))
                {
                    var dt = Utilerias.JsonToDT(info);

                    if (Utilerias.TablaTieneRows(dt))
                    {
                        var app_version = GetColumanValue(dt, "app_version");

                        //Compare strings
                        if (app_version == current_version)
                            return null;

                        //Compare INTs
                        var current_v_int = str_to_int_version(current_version);
                        var new_version_int = str_to_int_version(app_version);

                        if (new_version_int <= current_v_int)
                            return null;

                        var updateAvailable = new UpdateAvailable
                        {
                            changelog = GetColumanValue(dt, "changelog"),
                            download_url = GetColumanValue(dt, "download_url"),
                            checksum = GetColumanValue(dt, "checksum"),
                            app_version = app_version,
                            outer_app_id = GetColumanValue(dt, "outer_app_id"),
                            app_id = GetColumanValue(dt, "app_id"),
                            id = GetColumanValue(dt, "id")
                        };


                        return updateAvailable;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                errors = ex.Message;
                return null;
            }
            finally
            {
                if (!manual_check)
                    auto_update_already_checked = true;
            }
        }
    }

    public class UpdateAvailable
    {
        public string changelog;
        public string download_url;
        public string checksum;
        public string app_version;
        public string outer_app_id;
        public string app_id;
        public string id;

        public UpdateAvailable()
        {

        }

        public UpdateAvailable(string changelog, string download_url, string checksum, string app_version, string outer_app_id, string app_id, string id)
        {
            this.changelog = changelog;
            this.download_url = download_url;
            this.checksum = checksum;
            this.app_version = app_version;
            this.outer_app_id = outer_app_id;
            this.app_id = app_id;
            this.id = id;
        }
    }
}
