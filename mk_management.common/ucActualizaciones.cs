using DevExpress.XtraEditors;
using mk_management.common;
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
    public partial class ucActualizaciones : DevExpress.XtraEditors.XtraUserControl
    {
        public ucActualizaciones()
        {
            InitializeComponent();
        }


        private void SearchUpdates()
        {
            try
            {
                common.tasks.UpdateAvailable update = null;
                using (var w = Utilerias.ShowOverlay(this, "Revisando"))
                {
                    var errors = "";
                    var version_app = Utilerias.VersionSistema();
                    var rev = new common.tasks.check_app_updates();
                    update = rev.CheckUpdates(version_app, true, ref errors);

                    if (Utilerias.EsValorValido(errors))
                    {
                        Utilerias.msjAlert_TI("No se pudo revisar las actualizaciones");
                        DataHelper.AgregarBitacoraSistema("Revisar actualizaciones", errors, false);
                        return;
                    }

                    if (Utilerias.IsNullOrEmpty(update))
                    {
                        Utilerias.msjInfo("No hay actualizaciones disponibles por el momento.");
                        return;
                    }
                }

                if (Utilerias.IsNullOrEmpty(update))
                    return;

                var title = $"Nueva version de Kaz Wifi HotSpot Disponible - v{update.app_version}";
                var frmChangelog = new FrmAppChangeLog(title, update);
                frmChangelog.ShowDialog();
            }
            catch (Exception ex)
            {
                DataHelper.AgregarBitacoraSistema("Revisar actualizaciones", ex.Message, true);
            }
        }

        private void OpenTemplatesForm()
        {

        }

        private void galleryControl1_Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            if (Utilerias.SafeToString(e?.Item?.Tag) == "update")
                SearchUpdates();

            if (Utilerias.SafeToString(e?.Item?.Tag) == "templates")
                OpenTemplatesForm();
        }


    }
}
