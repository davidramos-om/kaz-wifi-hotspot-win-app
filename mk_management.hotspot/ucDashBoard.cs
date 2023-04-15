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
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;

namespace mk_management.hotspot
{
    public partial class ucDashBoard : UserControl
    {
        Model.ServerInfo ServerInfo;
        bool ErrorEnDispositivo = false;

        public ucDashBoard()
        {
            InitializeComponent();
            lbError.Visible = false;

            //lblCPU.Text = "%";
            //lbMemoria.Text = "0 mb";
            //lbTiempoActividad.Text = "0m 0s";
            //lbEspacioDisco.Text = "0 mb";
            //lbCantUsuarios.Text = "0";


            LimpiarValores();

            timer1.Start();
        }

        private void LimpiarValores()
        {

            tlBarItem_CPU.Elements[0].Text = "%";
            tlBarItem_Memoria.Elements[0].Text = "0 mb";
            tlBarItem_Tiempo.Elements[0].Text = "0m 0s";
            tlBarItem_Disco.Elements[0].Text = "0 mb";
            tlBarItem_Usuarios.Elements[0].Text = "0";
        }

        private DataTable CreateChartData(int rowCount)
        {
            // Create an empty table.
            DataTable table = new DataTable("Table1");

            // Add two columns to the table.
            table.Columns.Add("Argument", typeof(Int32));
            table.Columns.Add("Value", typeof(Int32));

            // Add data rows to the table.
            Random rnd = new Random();
            DataRow row = null;
            for (int i = 0; i < rowCount; i++)
            {
                row = table.NewRow();
                row["Argument"] = i;
                row["Value"] = rnd.Next(100);
                table.Rows.Add(row);
            }

            return table;
        }

        private void Ejemplo_Grafico_2()
        {
            ChartControl chart = chart_uso_megas;

            // Create an empty Bar series and add it to the chart.
            Series series = new Series("Series1", ViewType.Bar);
            chart.Series.Add(series);

            // Generate a data table and bind the series to it.
            series.DataSource = CreateChartData(50);

            // Specify data members to bind the series.
            series.ArgumentScaleType = ScaleType.Numerical;
            series.ArgumentDataMember = "Argument";
            series.ValueScaleType = ScaleType.Numerical;
            series.ValueDataMembers.AddRange(new string[] { "Value" });

            // Set some properties to get a nice-looking chart.
            ((SideBySideBarSeriesView)series.View).ColorEach = true;
            ((XYDiagram)chart.Diagram).AxisY.Visibility = DevExpress.Utils.DefaultBoolean.False;
            chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
        }

        private void GenerarGrafico_Consumo()
        {
            try
            {
                if (ServerInfo == null)
                    return;

                DataTable dtEstadisticoConsumo = new DataTable("Datos");
                dtEstadisticoConsumo.Columns.Add("Usuario", typeof(string));
                dtEstadisticoConsumo.Columns.Add("Mb_Descarga", typeof(decimal));
                dtEstadisticoConsumo.Columns.Add("Mb_Subida", typeof(decimal));
                dtEstadisticoConsumo.Columns.Add("Hora", typeof(string));

                try
                {
                    var query = $@"  select t.json_data,t.FechaCreo 
                                from routeros_usage_stats t 
                                where t.ServerId = '{ServerInfo.Id}' 
	                                and t.FechaCreo >= DATE_SUB(NOW(),INTERVAL 1 HOUR) 
	                                and t.json_data is not null 
	                                and t.Activo = 1
                                   order by t.FechaCreo desc
                            ";


                    var dtHistoricoConsumo = MDB.FillDataTable(ConfigurationSettings.Obtener_CadenaConexion(), query);

                    if (Utilerias.TablaTieneRows(dtHistoricoConsumo))
                    {
                        foreach (DataRow rConsumo in dtHistoricoConsumo.Rows)
                        {
                            if (Utilerias.IsNullOrEmpty(rConsumo["FechaCreo"]))
                                continue;

                            var json = Utilerias.SafeToString(rConsumo["json_data"]);
                            var fechaCreo = Convert.ToDateTime(rConsumo["FechaCreo"]);

                            if (Utilerias.EsValorValido(json))
                            {
                                var dtJson = Utilerias.JsonToDT(json);
                                if (Utilerias.TablaTieneRows(dtJson))
                                {
                                    foreach (DataRow rJson in dtJson.Rows)
                                    {
                                        var nr = dtEstadisticoConsumo.NewRow();

                                        nr["Usuario"] = rJson["user"];
                                        nr["Mb_Descarga"] = Utilerias.NullValue(rJson["bytes_in"], 0);
                                        nr["Mb_Subida"] = Utilerias.NullValue(rJson["bytes_out"], 0);
                                        nr["Hora"] = Utilerias.PadLeft(fechaCreo.Hour, 2, '0') + ':' + Utilerias.PadLeft(fechaCreo.Minute, 2, '0');

                                        dtEstadisticoConsumo.Rows.Add(nr);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lbError.Text = ex.Message;
                    lbError.ToolTip = ex.Message;
                    lbError.Visible = true;
                }


                //Usuarios de prueba
                //dt.Rows.Add("Hab 101", "2", "1", "13:40");
                //dt.Rows.Add("Hab 101", "4", "1", "13:50");
                //dt.Rows.Add("Hab 101", "7", "1", "14:20");
                //dt.Rows.Add("Hab 101", "10", "1", "14:40");

                //dt.Rows.Add("Hab 105", "10", "1", "12:40");
                //dt.Rows.Add("Hab 105", "15", "1", "13:20");
                //dt.Rows.Add("Hab 105", "25", "1", "15:18");
                //dt.Rows.Add("Hab 105", "30", "1", "15:40");

                //dt.Rows.Add("Gerencia", "5", "1", "14:18");
                //dt.Rows.Add("Gerencia", "5", "1", "14:25");
                //dt.Rows.Add("Gerencia", "7", "1", "14:30");
                //dt.Rows.Add("Gerencia", "15", "1", "15:03");
                //dt.Rows.Add("Gerencia", "25", "1", "15:53");
                //dt.Rows.Add("Gerencia", "38", "1", "16:40");


                //Generar grafico
                ChartControl lineChart = chart_uso_megas;
                lineChart.Series.Clear();


                var dvEstadisticoConsumo = dtEstadisticoConsumo.AsDataView();
                var dtUsuariosUnicos = dvEstadisticoConsumo.ToTable("Usuarios", true, "Usuario");

                foreach (DataRow rUsuario in dtUsuariosUnicos.Rows)
                {
                    var usuario = Utilerias.SafeToString(rUsuario["Usuario"]);

                    //Lineas
                    Series seriesDescargarMBs = new Series(usuario, ViewType.Line);

                    //Agregar los puntos segun el consumo
                    var rows = dtEstadisticoConsumo.Select($"Usuario = '{usuario}'", "Hora asc");
                    int contador = 0;
                    foreach (DataRow rConsumo in rows)
                    {
                        var hora = Utilerias.SafeToString(rConsumo["Hora"]);
                        decimal consumoAnterior = 0;
                        var consumoActual = Convert.ToDecimal(Utilerias.NullValue(rConsumo["Mb_Descarga"], 0));


                        if (contador > 0)
                            consumoAnterior = Convert.ToDecimal(Utilerias.NullValue(rows[contador]["Mb_Descarga"], 0));
                        else
                            consumoAnterior = consumoActual; //Comenzar en el mismo punto

                        var punto = new SeriesPoint(hora, consumoAnterior, consumoActual);
                        seriesDescargarMBs.Points.Add(punto);
                        contador++;
                    }

                    //Agregar la serie del usuario
                    lineChart.Series.Add(seriesDescargarMBs);


                    //Tipo de escala
                    seriesDescargarMBs.ArgumentScaleType = ScaleType.Qualitative;

                    //Personalizar grafico
                    ((LineSeriesView)seriesDescargarMBs.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                    ((LineSeriesView)seriesDescargarMBs.View).LineMarkerOptions.Kind = MarkerKind.Circle;
                    ((LineSeriesView)seriesDescargarMBs.View).LineStyle.DashStyle = DashStyle.Solid;

                }

                // ((XYDiagram)lineChart.Diagram).EnableAxisXZooming = true;
                //((XYDiagram)lineChart.Diagram).AxisX.Title.Text = "Hora";
                //((XYDiagram)lineChart.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                //((XYDiagram)lineChart.Diagram).AxisX.VisibleInPanesSerializable = "-1";
                //((XYDiagram)lineChart.Diagram).AxisY.VisibleInPanesSerializable = "-1";

                //((XYDiagram)lineChart.Diagram).AxisY.Title.Text = "Consumo en megas";
                //((XYDiagram)lineChart.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                //((XYDiagram)lineChart.Diagram).AxisY.VisibleInPanesSerializable = "-1";
                //((XYDiagram)lineChart.Diagram).AxisY.VisibleInPanesSerializable = "-1";

                //((XYDiagram)lineChart.Diagram).Rotated = false;


                //Mostrar los usuarios en la leyenda
                lineChart.Legend.Direction = LegendDirection.BottomToTop;
                lineChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
                lineChart.Legend.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
                lineChart.Legend.EquallySpacedItems = true;
                lineChart.Legend.ItemVisibilityMode = LegendItemVisibilityMode.AutoGeneratedAndCustom;


                lineChart.Legend.Border.Color = System.Drawing.Color.LightGray;
                lineChart.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                lineChart.Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBoxAndMarker;
                lineChart.Legend.MarkerSize = new System.Drawing.Size(16, 16);
                lineChart.Legend.Name = "Default Legend";
                lineChart.Legend.Title.Text = "Usuarios";
                lineChart.Legend.Title.Visible = false;
                lineChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

                //Paleta de colores :
                lineChart.PaletteName = "Default";
                lineChart.BackColor = Color.White;
                lineChart.IndicatorsPaletteName = "Default";

                //Titulo
                lineChart.Titles.Clear();
                lineChart.Titles.Add(new ChartTitle());
                //lineChart.Titles[0].Text = $"Consumo de datos por usuario ({DateTime.Now.ToShortTimeString()})";
                var f = lineChart.Titles[0].Font;
                lineChart.Titles[0].Font = new Font(f.Name, 10, FontStyle.Regular);
                lineChart.Titles[0].Text = $"Histórico de consumo de datos por usuario ({DateTime.Now.ToString("hh:mm:ss tt")})";
            }
            catch (Exception ex)
            {
                lbError.Text = ex.Message;
                lbError.ToolTip = ex.Message;
                lbError.Visible = true;
            }
        }

        private void Ejemplo_Grafico()
        {
            try
            {
                ChartControl lineChart = chart_uso_megas;

                // Create a line series. 
                Series series1 = new Series("Hab 101", ViewType.Line);

                // Add points to it. 
                var s = new SeriesPoint();
                series1.Points.Add(new SeriesPoint(1, 2));
                series1.Points.Add(new SeriesPoint(2, 12));
                series1.Points.Add(new SeriesPoint(3, 14));
                series1.Points.Add(new SeriesPoint(4, 17));

                // Add the series to the chart. 
                lineChart.Series.Add(series1);

                // Set the numerical argument scale types for the series, 
                // as it is qualitative, by default. 
                series1.ArgumentScaleType = ScaleType.Numerical;

                // Access the view-type-specific options of the series. 
                ((LineSeriesView)series1.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                ((LineSeriesView)series1.View).LineMarkerOptions.Kind = MarkerKind.Circle;
                ((LineSeriesView)series1.View).LineStyle.DashStyle = DashStyle.Dash;

                // Access the type-specific options of the diagram. 
                ((XYDiagram)lineChart.Diagram).EnableAxisXZooming = true;

                // Hide the legend (if necessary). 
                lineChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

                // Add a title to the chart (if necessary). 
                lineChart.Titles.Add(new ChartTitle());
                lineChart.Titles[0].Text = "A Line Chart";

                // Add the chart to the form. 
                //lineChart.Dock = DockStyle.Fill;
                //this.Controls.Add(lineChart);
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }

        public void Inicializar()
        {
            chart_uso_megas.Series.Clear();

            var menu = new common.MenuItemGridViews(ref gvConexiones, "Tablero Informativo");
            this.Refresh();

            grdConexiones.Refresh();
            chart_uso_megas.Refresh();

            //Ejemplo_Grafico();
            //GenerarGrafico_Consumo();

            //Ejemplo_Grafico_2();
            CargarConexiones();
        }

        private string getRandColor()
        {

            var lista = new List<string>();
            lista.Add("#DAF7A6");
            lista.Add("#03A9F4");
            lista.Add("#FF9800");
            lista.Add("#009688");
            lista.Add("#9C27B0");
            lista.Add("#607D8B");

            var idx = new Random().Next(lista.Count);

            return lista[idx];
        }

        private void CargarInfo()
        {
            try
            {
                if (this.IsDisposed)
                    return;

                if (ErrorEnDispositivo)
                    return;

                //System.Action cargar = () =>
                {
                    timer1.Stop();


                    //using (var w = Utilerias.ShowOverlay(panelDeviceInfo, "Connectando"))
                    {
                        GenerarGrafico_Consumo();
                        chart_uso_megas.Refresh();

                        //lblCPU.Text = "%";
                        //lbMemoria.Text = "0 mb";
                        //lbTiempoActividad.Text = "0m 0s";
                        //lbEspacioDisco.Text = "0 mb";
                        //this.Refresh();

                        if (ServerInfo != null)
                        {
                            if (!Utilerias.PingHost(ServerInfo.IP))
                            {
                                ErrorEnDispositivo = true;
                                //Utilerias.msjAlert("No hay conexión al dispositivo.");
                                ErrorEnDispositivo = true;
                                lbError.Text = "No hay conexión al dispositivo.";
                                lbError.ToolTip = "No hay conexión al dispositivo.";
                                lbError.Visible = true;
                                return;
                            }

                            ErrorEnDispositivo = false;
                            var mk = new MK(ServerInfo.IP, ServerInfo.Puerto, ServerInfo.VersionSO);
                            if (!mk.Login(ServerInfo.Usuario, ServerInfo.Clave))
                            {
                                mk.Close();
                                return;
                            }

                            SetDevicesInfo(mk);
                            getActiveConnections(mk);
                        }
                    }
                };

                //lblCPU.Invoke(cargar);
            }
            catch (Exception ex)
            {
                ErrorEnDispositivo = true;
                lbError.Text = ex.Message;
                lbError.ToolTip = ex.Message;
                lbError.Visible = true;

                DataHelper.AgregarBitacoraSistema(this.Name + ".CargarInfo", ex.Message, true);
            }
            finally
            {
                timer1.Start();
            }
        }

        private void getActiveConnections(MK mk)
        {
            try
            {
                lbCantConexiones.Text = "  Usuarios conectados";

                var info = mk.getActiveConnections();
                mk.Close();

                if (hotspot.Helper.ProcesoMK_TieneErrores(info))
                {
                    lbError.Visible = true;
                    lbError.Text = Helper.ProcesoMK_ObtenerErrores(info);
                    return;
                }

                var dtInfo = hotspot.Helper.DataTableFromMKArray(info);

                if (Utilerias.TablaTieneRows(dtInfo))
                {
                    foreach (DataRow r in dtInfo.Rows)
                    {
                        decimal b_in_mb = 1024;
                        var b_in = Convert.ToDecimal(Utilerias.NullValue(r["bytes_in"], 0)) / b_in_mb;
                        var b_out = Convert.ToDecimal(Utilerias.NullValue(r["bytes_out"], 0)) / b_in_mb;

                        r["bytes_in"] = decimal.Round(b_in / b_in_mb, 2);
                        r["bytes_out"] = decimal.Round(b_out / b_in_mb, 2);

                    }

                    lbCantConexiones.Text = "  Usuarios conectados : " + dtInfo.Rows.Count;
                }

                grdConexiones.DataSource = dtInfo;

                lbError.Visible = false;
                lbError.Text = "";
            }
            catch (Exception ex)
            {
                ErrorEnDispositivo = true;
                lbError.Text = ex.Message;
                lbError.ToolTip = ex.Message;
                lbError.Visible = true;

                DataHelper.AgregarBitacoraSistema(this.Name + ".getActiveConnections", ex.Message, true);
            }
        }

        private void SetDevicesInfo(MK mk)
        {
            try
            {
                var info = mk.getDevices_Info();

                if (hotspot.Helper.ProcesoMK_TieneErrores(info))
                {
                    lbError.Visible = true;
                    lbError.Text = Helper.ProcesoMK_ObtenerErrores(info);
                    return;
                }

                var dtCpu = hotspot.Helper.DataTableFromMKArray(info);

                lbError.Visible = false;
                lbError.Text = "";

                if (Utilerias.TablaTieneRows(dtCpu))
                {
                    var txt = dtCpu.Rows[0]["cpu_load"] + "%";
                    if (txt != tlBarItem_CPU.Elements[0].Text)
                    {
                        //lblCPU.Text = txt;
                        tlBarItem_CPU.Elements[0].Text = txt;
                    }

                    //lblCPU.Refresh();

                    txt = Utilerias.SafeToString(dtCpu.Rows[0]["uptime"]);
                    if (txt != tlBarItem_Tiempo.Elements[0].Text)
                    {
                        //lbTiempoActividad.Text = txt;
                        tlBarItem_Tiempo.Elements[0].Text = txt;
                    }

                    //lbTiempoActividad.Refresh();

                    decimal b_in_mb = 1024;
                    var b_mem_free = Convert.ToDecimal(Utilerias.NullValue(dtCpu.Rows[0]["free_memory"], 0)) / b_in_mb;
                    var b_mem_total = Convert.ToDecimal(Utilerias.NullValue(dtCpu.Rows[0]["total_memory"], 0)) / b_in_mb;

                    txt = decimal.Round((b_mem_free / b_in_mb), 2) + "/" + decimal.Round((b_mem_total / b_in_mb), 2) + " mb";
                    if (txt != tlBarItem_Memoria.Elements[0].Text)
                    {
                        //lbMemoria.Text = txt;
                        tlBarItem_Memoria.Elements[0].Text = txt;
                    }

                    //lbMemoria.Refresh();

                    var b_disk_free = Convert.ToDecimal(Utilerias.NullValue(dtCpu.Rows[0]["free_hdd_space"], 0)) / b_in_mb;
                    var b_disk_total = Convert.ToDecimal(Utilerias.NullValue(dtCpu.Rows[0]["total_hdd_space"], 0)) / b_in_mb;

                    txt = decimal.Round((b_disk_free / b_in_mb), 2) + "/" + decimal.Round((b_disk_total / b_in_mb), 2) + " mb";
                    if (txt != tlBarItem_Disco.Elements[0].Text)
                    {
                        //lbEspacioDisco.Text = txt;
                        tlBarItem_Disco.Elements[0].Text = txt;
                    }

                    //lbEspacioDisco.Refresh();
                }

                var infoUsuarios = mk.GetUsers();
                if (!Helper.ProcesoMK_TieneErrores(infoUsuarios))
                {
                    var dtUsuarios = hotspot.Helper.DataTableFromMKArray(infoUsuarios);
                    var cantUsuarios = dtUsuarios.Rows.Count.ToString();
                    //lbCantUsuarios.Text = cantUsuarios;
                    tlBarItem_Usuarios.Elements[0].Text = cantUsuarios;
                }

                tlBarItem_InfoDev.Tag = dtCpu;
            }
            catch (Exception ex)
            {
                ErrorEnDispositivo = true;
                lbError.Text = ex.Message;
                lbError.Visible = true;

                DataHelper.AgregarBitacoraSistema(this.Name + ".SetDevicesInfo", ex.Message, true);
            }
        }

        //readonly Color defaultTileColor = Color.SteelBlue;
        readonly Color defaultTileColor = Utilerias.GetWebColor(Apariencia.BgTileViewColor);

        private void CargarConexiones()
        {
            try
            {
                tlBarGrupoConexiones.Items.Clear();
                this.Refresh();

                var dt = DataHelper.ConsultarRegistro("server", "Id", "", false, "order by Predeterminado desc,Descripcion asc");

                TileItem tileItem_Pred = null;

                if (Utilerias.TablaTieneRows(dt))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        var tl = new TileItem();
                        tl.Text = Utilerias.SafeToString(Utilerias.NullValue(r["Descripcion"], r["IP"]));
                        tl.ItemSize = TileItemSize.Wide;
                        tl.TextAlignment = TileItemContentAlignment.MiddleCenter;
                        tl.TextShowMode = TileItemContentShowMode.Always;

                        //var hex = getRandColor();
                        //var colorBg = System.Drawing.ColorTranslator.FromHtml(hex);

                        //colorBg = Color.SteelBlue;

                        tl.AppearanceItem.Normal.BackColor = defaultTileColor;

                        tl.AppearanceItem.Hovered.BackColor = Color.FromArgb(52, 73, 94);
                        tl.AppearanceItem.Normal.BorderColor = Color.Transparent;

                        tl.Tag = r;
                        tl.ItemClick += TlConexion_ItemClick;

                        tlBarGrupoConexiones.Items.Add(tl);
                        this.Refresh();


                        if (Utilerias.SafeToString(r["Predeterminado"]) == "S")
                            tileItem_Pred = tl;

                    }

                    this.Refresh();
                    if (tileItem_Pred != null)
                    {
                        tileItem_Pred.PerformItemClick();
                    }
                }

            }
            catch (Exception ex)
            {
                DataHelper.AgregarBitacoraSistema(this.Name + ".CargarConexiones", ex.Message, true);
            }
        }


        private void DesmarcarTiles()
        {
            var tiles = tlBarGrupoConexiones.Items;
            foreach (var tl in tiles)
            {
                tl.Appearances.Normal.BackColor = defaultTileColor;
            }
        }

        private void TlConexion_ItemClick(object sender, TileItemEventArgs e)
        {
            timer1.Stop();

            groupControl1.Text = "Tablero Informativo";
            LimpiarValores();

            var tl = sender as TileItem;

            if (tl == null)
                return;

            var row = tl.Tag as DataRow;
            if (row == null)
                return;

            DesmarcarTiles();

            this.Refresh();

            var colorBg = System.Drawing.ColorTranslator.FromHtml(Apariencia.BgSelectedTileItem);
            tl.AppearanceItem.Normal.BackColor = colorBg;

            var idServidor = Utilerias.SafeToStringId(row["Id"]);

            ServerInfo = hotspot.Helper.ObtenerDatosServidor(idServidor);
            if (ServerInfo == null)
                return;

            groupControl1.Text = $"Tablero Informativo en :  { ServerInfo.Nombre} { ServerInfo.IP }";
            this.Refresh();

            using (var w = Utilerias.ShowOverlay(grdConexiones, "Cargando"))
            {
                ErrorEnDispositivo = false;

                CargarInfo();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CargarInfo();
        }

        private void tlBarItem_InfoDev_ItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                timer1.Stop();

                if (ServerInfo == null)
                    return;

                using (var w = Utilerias.WaitWindow(null, "Conectando al dispositivo"))
                {
                    if (!Utilerias.PingHost(ServerInfo.IP))
                    {
                        Utilerias.msjAlert("No hay conexión al dispositivo.");
                        return;
                    }

                    var mk = new MK(ServerInfo.IP, ServerInfo.Puerto, ServerInfo.VersionSO);
                    if (!mk.Login(ServerInfo.Usuario, ServerInfo.Clave))
                    {
                        mk.Close();
                        return;
                    }

                    w.Caption = "Obteniendo datos";

                    var info = mk.getDevices_Info();
                    
                    if (hotspot.Helper.ProcesoMK_TieneErrores(info))
                    {
                        mk.Close();
                        lbError.Visible = true;
                        lbError.Text = Helper.ProcesoMK_ObtenerErrores(info);
                        return;
                    }

                    var infoProfiles = mk.getServerProfiles();
                    mk.Close();
                    var dtProfiles = Helper.DataTableFromMKArray(infoProfiles);
                    var dvProfiles = dtProfiles.AsDataView();
                    if (dvProfiles.Count > 0 && dtProfiles.Columns["hotspot_address"] != null)
                    {
                        dvProfiles.RowFilter = $"hotspot_address='{ServerInfo.IP}'";
                        dtProfiles = dvProfiles.ToTable();
                    }

                    var dtCpu = hotspot.Helper.DataTableFromMKArray(info);

                    lbError.Visible = false;
                    lbError.Text = "";

                    if (!Utilerias.TablaTieneRows(dtCpu))
                        return;

                    var frm = new ucDashBoard_frm_infoDev(dtCpu, dtProfiles);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
            finally
            {
                timer1.Start();
            }
        }

    }
}
