using System;
using System.Data;
using System.Windows.Forms;

namespace mk_management.hotspot
{
    public partial class ucDashBoard_frm_infoDev : DevExpress.XtraEditors.XtraForm
    {
        public ucDashBoard_frm_infoDev(DataTable dt, DataTable dtProfiles)
        {
            InitializeComponent();
            this.Icon = common.Utilerias.ObtenerIconoApp();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.ControlBox = false;

            if (dtProfiles != null && dtProfiles.Rows.Count > 0 && dtProfiles.Columns.Count > 0)
                dt.Merge(dtProfiles, true, MissingSchemaAction.Add);

            vGridControl1.DataSource = dt;

            vGridControl1.OptionsBehavior.Editable = true;

            foreach (var r in vGridControl1.Rows)
            {
                r.Properties.ReadOnly = true;
            }

            layoutControlGroup1.TextVisible = false;
            layoutControlGroup1.GroupBordersVisible = false;
            vGridControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            vGridControl1.OptionsView.AutoScaleBands = true;

            vGridControl1.BestFit();

            if (dt != null && dt.Rows.Count > 0)
                RecalcWidth(dt);
        }

        private void RecalcWidth(DataTable dataTable)
        {
            int recordWidth = (vGridControl1.Width - vGridControl1.RowHeaderWidth) / dataTable.Rows.Count;
            if (recordWidth > vGridControl1.RecordMinWidth)
            {
                vGridControl1.RecordWidth = recordWidth;
                vGridControl1.ScrollVisibility = DevExpress.XtraVerticalGrid.ScrollVisibility.Vertical;
            }
            else
            {
                vGridControl1.ScrollVisibility = DevExpress.XtraVerticalGrid.ScrollVisibility.Auto;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
