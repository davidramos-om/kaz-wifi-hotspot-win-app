using System;
using System.Data;
using mk_management.common;

namespace mk_management.hotspot
{
    //public partial class frmUsuarios : DevExpress.XtraEditors.XtraForm
    public partial class ucListaPerfiles_Hist : DevExpress.XtraEditors.XtraUserControl
    {
        public ucListaPerfiles_Hist()
        {
            InitializeComponent();
            var menu = new common.MenuItemGridViews(ref gvdatos, "Historial de Perfiles");
        }


        public void Actualizar()
        {
            CargarPerfiles();
        }
        
        void CargarPerfiles()
        {
            try
            {
                var query = @"
	                            select t.*
			                           ,s.Descripcion  as Dispositivo
                                       ,cast('' as varchar(200)) as str_mb_descarga
                                       ,cast('' as varchar(200)) as str_mb_subida
                                  from perfil_hotspot t 
                                       left join server s
           	                                  on s.Id = t.IdServer
           	                                 and s.Activo = 1 
                                 where t.Activo = 1
                        ";

                using (var w = Utilerias.ShowOverlay(this, "Conectando"))
                {
                    var dt = MDB.FillDataTable(Link.ConnectionString, query);

                    if (Utilerias.TablaTieneRows(dt))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            var kb_s = Convert.ToInt32(Utilerias.NullValue(r["Kb_Subida"], 0));
                            if (kb_s <= 0)
                                r[colKb_Subida.FieldName] = "Ilimitado";
                            else
                            {
                                var div = Convert.ToDecimal(kb_s / frmAgregarPerfil.KB_in_MB);
                                r[colKb_Subida.FieldName] = decimal.Round(div, 2);
                            }

                            var kb_d = Convert.ToInt32(Utilerias.NullValue(r["Kb_Descarga"], 0));

                            if (kb_d <= 0)
                                r[colKb_Descarga.FieldName] = "Ilimitado";
                            else
                            {
                                var div = Convert.ToDecimal(kb_d / frmAgregarPerfil.KB_in_MB);
                                r[colKb_Descarga.FieldName] = decimal.Round(div, 2);
                            }
                        }
                    }

                    grdDatos.DataSource = dt;
                    gvdatos.OptionsView.ColumnAutoWidth = false;

                    Utilerias.ConfigurarGrid_Totales(gvdatos, colDescripcion.FieldName, colDescripcion.FieldName);

                    gvdatos.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }

        private void wBtnAgregar_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {

            if (Utilerias.SafeToString(e.Button.Properties.Tag) == "Ver")
            {
                CargarPerfiles();
            }
        }

        private void grdDatos_Click(object sender, EventArgs e)
        {

        }
    }
}