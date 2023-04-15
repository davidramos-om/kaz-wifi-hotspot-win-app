using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mk_management.common;

namespace mk_management
{
    public partial class ucListaPerfilesSistema : DevExpress.XtraEditors.XtraUserControl
    {
        public ucListaPerfilesSistema()
        {
            InitializeComponent();
        }


        public void Inicializar()
        {
            CargarPerfiles();
            var menu = new common.MenuItemGridViews(ref gvdatos, "Perfiles de Sistema");
        }

        private void CargarPerfiles()
        {
            try
            {

                var dt = DataHelper.ConsultarRegistro("perfil_sistema", "Id", "", false);

                grdDatos.DataSource = dt;

                Utilerias.ConfigurarGrid_Totales(gvdatos, colNombre.FieldName, colNombre.FieldName);
                colEliminar.OptionsColumn.ReadOnly = false;
                colEliminar.OptionsColumn.AllowEdit = true;

                colEditar.OptionsColumn.ReadOnly = false;
                colEditar.OptionsColumn.AllowEdit = true;

                gvdatos.BestFitColumns();
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }


        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (Utilerias.SafeToString(e.Button.Properties.Tag) == "Add")
            {
                var f = new frmAgregarPerfilSistema();
                f.ShowDialog();
                CargarPerfiles();
            }

            if (Utilerias.SafeToString(e.Button.Properties.Tag) == "Ver")
            {
                using (var w = Utilerias.ShowOverlay(this))
                {
                    CargarPerfiles();
                }
            }
        }

        private void repBtnEditar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var id = Utilerias.SafeToString(gvdatos.GetFocusedRowCellValue(colId));

            if (Utilerias.IsNullOrEmpty(id))
                return;

            var frm = new frmAgregarPerfilSistema();
            frm.Inicializar(id);
            frm.ShowDialog();
            CargarPerfiles();
        }

        private void repBtnEliminar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var id = Utilerias.SafeToString(gvdatos.GetFocusedRowCellValue(colId));

                if (Utilerias.IsNullOrEmpty(id))
                    return;

                var nombrePerfil = Utilerias.SafeToString(gvdatos.GetFocusedRowCellValue(colNombre));

                if (!Utilerias.msjConfirm($"¿Desea eliminar el siguiente perfil? \n\n\n{nombrePerfil}\n\n\n"))
                    return;

                DataHelper.EliminarRegistro("perfil_sistema", "Id", id);
                CargarPerfiles();
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        } 
    }
}
