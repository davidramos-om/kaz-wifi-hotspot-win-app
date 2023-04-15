using System;
using System.Data;
using mk_management.common;

namespace mk_management.hotspot
{
    //public partial class frmUsuarios : DevExpress.XtraEditors.XtraForm
    public partial class ucListaUsuarios_Hist : DevExpress.XtraEditors.XtraUserControl
    {
        public ucListaUsuarios_Hist()
        {
            InitializeComponent();
            new common.MenuItemGridViews(ref gvdatos, "Historial de Usuarios");
        }


        public void Actualizar()
        {
            CargarUsuarios();
        }

        void CargarUsuarios()
        {
            try
            {
                var query = @"
	                            select t.*
			                           ,s.Descripcion  as Dispositivo
	                                   ,p.Descripcion  as Perfil     
                                       ,cast('' as varchar(200)) as TiempoAsignado
                                  from usuario_hotspot t 
                                       left join server s
           	                                  on s.Id = t.IdServer
           	                                 and s.Activo = 1 
                                       left join perfil_hotspot p
           	                                  on p.Id = t.IdPerfil
           	                                 and p.Activo = 1 
                                where t.Activo = 1
                        ";

                using (var w = Utilerias.ShowOverlay(this, "Conectando"))
                {
                    var dt = MDB.FillDataTable(Link.ConnectionString, query);

                    if (Utilerias.TablaTieneRows(dt))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            var u = Utilerias.SafeToString(r[colUsuario.FieldName]);
                            var c = Utilerias.SafeToString(r[colClave.FieldName]);

                            if (Utilerias.EsValorValido(u))
                                r[colUsuario.FieldName] = Crypto.Decrypt(u);

                            r[colClave.FieldName] = "* * * * *";
                            var m = Convert.ToInt32(Utilerias.NullValue(r[colTiempo.FieldName], 0));

                            if (m <= 0)
                                r[colTiempoAsignado.FieldName] = "Ilimitado";
                            else
                            {
                                var tipo = Utilerias.SafeToString(r["TipoTiempo"]);

                                if (tipo == "M")
                                    r[colTiempoAsignado.FieldName] = m / 60 + " Minutos";

                                if (tipo == "H")
                                    r[colTiempoAsignado.FieldName] = m / 3600 + " Horas";

                                if (tipo == "D")
                                    r[colTiempoAsignado.FieldName] = m / 86400 + " Días";
                            }
                        }
                    }

                    grdDatos.DataSource = dt;
                    gvdatos.OptionsView.ColumnAutoWidth = false;

                    Utilerias.ConfigurarGrid_Totales(gvdatos, colUsuario.FieldName, colUsuario.FieldName);

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
                Actualizar();
            }
        }
    }
}