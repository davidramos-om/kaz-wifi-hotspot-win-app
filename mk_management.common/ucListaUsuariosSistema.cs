using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mk_management.common
{
    public partial class ucListaUsuariosSistema : DevExpress.XtraEditors.XtraUserControl
    {
        public ucListaUsuariosSistema()
        {
            InitializeComponent();
        }


        public void Inicializar()
        {
            CargarUsuarios();
            var menu = new common.MenuItemGridViews(ref gvdatos, "Usuarios de Sistema");
        }

        private void CargarUsuarios()
        {
            try
            {
                var query = @"
                                 select u.*,p.Nombre as Perfil
                                   from usuario_sistema u 
   	                                    left join perfil_sistema p
   	  	                                       on p.Id = u.IdPerfil
                                  where u.Activo = 1 ";

                var dt = MDB.FillDataTable(Link.ConnectionString, query);

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
                var f = new frmAgregarUsuarioSistema();
                f.CargarPerfiles();
                f.ShowDialog();
                CargarUsuarios();
            }

            if (Utilerias.SafeToString(e.Button.Properties.Tag) == "Ver")
            {
                using (var w = Utilerias.ShowOverlay(this))
                {
                    CargarUsuarios();
                }
            }
        }

        private void repBtnEditar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var id = Utilerias.SafeToString(gvdatos.GetFocusedRowCellValue(colId));

            if (Utilerias.IsNullOrEmpty(id))
                return;

            var frm = new frmAgregarUsuarioSistema();
            frm.Inicializar(id);
            frm.ShowDialog();
            CargarUsuarios();
        }

        private void repBtnEliminar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var id = Utilerias.SafeToString(gvdatos.GetFocusedRowCellValue(colId));

                if (Utilerias.IsNullOrEmpty(id))
                    return;

                var usuario = Utilerias.SafeToString(gvdatos.GetFocusedRowCellValue(colUsuario));

                if (!Utilerias.msjConfirm($"¿Desea eliminar el siguiente usuario? \n\n\n{usuario}\n\n\n"))
                    return;

                DataHelper.EliminarRegistro("usuario_sistema", "Id", id);
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }

        private void grdDatos_Click(object sender, EventArgs e)
        {

        }
    }
} 