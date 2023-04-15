using DevExpress.Export;
using DevExpress.Export.Xl;
using DevExpress.Printing.ExportHelpers;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace mk_management.common
{
    public class MenuItemGridViews
    {
        DevExpress.XtraGrid.Views.Grid.GridView gv;
        DevExpress.XtraGrid.Columns.GridColumn column;
        string descripcion = "";
        public MenuItemGridViews(ref DevExpress.XtraGrid.Views.Grid.GridView _gv, string _nombre)
        {
            gv = _gv;
            descripcion = _nombre;
            ConfigurarGrid_MenuItem_QuitarMaxWidth(_gv);
        }

        public void ConfigurarGrid_MenuItem_QuitarMaxWidth(DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            gv.PopupMenuShowing += Gv_PopupMenuShowing;
        }

        private void Gv_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            try
            {
                column = gv.FocusedColumn;
                column = e.HitInfo.Column;

                if (column != null)
                {
                    if (column.MaxWidth != 0)
                    {
                        var item_maxWidth = new DevExpress.Utils.Menu.DXMenuItem();
                        item_maxWidth.Caption = "Quitar Limite Ancho de Columna";
                        item_maxWidth.Tag = "MW";
                        item_maxWidth.Click += item_maxWidth_Click;

                        e.Menu.Items.Add(item_maxWidth);
                    }
                }

                var item_exportar = new DevExpress.Utils.Menu.DXMenuItem();
                item_exportar.Caption = "Exportar datos";
                item_exportar.Click += Item_exportar_Click;
                item_exportar.Tag = "EXP";
                item_exportar.Visible = true;

                e.Menu.Items.Add(item_exportar);
            }
            catch (Exception ex)
            {
                DataHelper.AgregarBitacoraSistema(gv.Name + ".PopupMenuShowing", ex.Message, true);
            }
        }

        private void Item_exportar_Click(object sender, EventArgs e)
        {
            try
            {
                var extensiones = Enum.GetNames(typeof(DevExpress.XtraPrinting.ExportTarget));
                //var strExt = string.Join("|*.", extensiones).ToLower();

                for (int i = 0; i < extensiones.Length; i++)
                {
                    extensiones[i] = "Archivo " + extensiones[i] + "|*." + extensiones[i].ToLower() + (i == extensiones.Length - 1 ? "" : "|");
                }

                var strExt = string.Join(" ", extensiones);

                var dialog = new SaveFileDialog
                {
                    Filter = strExt,
                    DefaultExt = "xls",
                    ValidateNames = true,
                    FileName = descripcion,
                    Title = "Exportar datos - " + descripcion
                };

                dialog.ShowDialog();

                if (dialog.FileName != "")
                {

                    var path = dialog.FileName;
                    var ext = Utilerias.CapitalLetter(System.IO.Path.GetExtension(dialog.FileName).Replace(".", ""));

                    var valido = Enum.TryParse(ext, out DevExpress.XtraPrinting.ExportTarget myStatus);

                    if (!valido)
                    {
                        Utilerias.msjAlert("Formato no válido.");
                        return;
                    }

                    if (myStatus == ExportTarget.Xlsx || myStatus == ExportTarget.Xls)
                    {
                        ExportSettings.DefaultExportType = ExportType.DataAware;
                        var options = new XlsxExportOptionsEx();
                        options.SheetName = descripcion;

                        options.CustomizeSheetHeader += options_CustomizeSheetHeader;
                        options.CustomizeSheetFooter += options_CustomizeSheetFooter;
                        options.AfterAddRow += options_AfterAddRow;
                        options.CustomizeSheetSettings += options_CustomizeSheetSettings;
                        gv.Export(myStatus, path, options);

                        System.Diagnostics.Process.Start(path);
                    }
                    else
                    {
                        gv.Export(myStatus, path);
                        System.Diagnostics.Process.Start(path);
                    }
                }
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
                DataHelper.AgregarBitacoraSistema(gv.Name + ".Exportar", ex.Message, true);
            }
        }



        delegate void AddCells(ContextEventArgs e, XlFormattingObject formatFirstCell, XlFormattingObject formatSecondCell);

        Dictionary<int, AddCells> methods = CreateMethodSet();

        static Dictionary<int, AddCells> CreateMethodSet()
        {
            var dictionary = new Dictionary<int, AddCells>();
            dictionary.Add(11, Add_CompanyName);
            return dictionary;
        }

        static void Add_CompanyName(ContextEventArgs e, XlFormattingObject formatFirstCell, XlFormattingObject formatSecondCell)
        {
            var cell_name = CreateCell("Propiedtario :", formatFirstCell);
            var cell_value = CreateCell(Link.CompanyName, formatSecondCell);
            e.ExportContext.AddRow(new[] { cell_name, null, cell_value });
        }

        static CellObject CreateCell(object value, XlFormattingObject formatCell)
        {
            return new CellObject { Value = value, Formatting = formatCell };
        }

        static void MergeCells(ContextEventArgs e, int left, int top, int right, int bottom)
        {
            e.ExportContext.MergeCells(new XlCellRange(new XlCellPosition(left, top), new XlCellPosition(right, bottom)));
        }

        static void MergeCells(ContextEventArgs e)
        {
            MergeCells(e, 2, 9, 5, 9);
            MergeCells(e, 0, 9, 1, 10);
            MergeCells(e, 2, 10, 5, 10);
            MergeCells(e, 0, 11, 1, 11);
            MergeCells(e, 2, 11, 5, 11);
            MergeCells(e, 0, 12, 1, 12);
            MergeCells(e, 2, 12, 5, 12);
            MergeCells(e, 0, 13, 1, 13);
            MergeCells(e, 2, 13, 5, 13);
            MergeCells(e, 0, 14, 5, 14);
        }


        void options_AfterAddRow(AfterAddRowEventArgs e)
        {
            if (e.DataSourceRowIndex < 0)
            {
                e.ExportContext.MergeCells(new XlCellRange(new XlCellPosition(0, e.DocumentRow - 1), new XlCellPosition(5, e.DocumentRow - 1)));
            }
        }

        void options_CustomizeSheetHeader(ContextEventArgs e)
        {

            var formatFirstCell = CreateXlFormattingObject(true, 24);
            var formatSecondCell = CreateXlFormattingObject(true, 18);

            for (var i = 0; i < 15; i++)
            {
                AddCells addCellMethod;

                if (methods.TryGetValue(i, out addCellMethod))
                    addCellMethod(e, formatFirstCell, formatSecondCell);
                else
                    e.ExportContext.AddRow();
            }


            MergeCells(e);

            // Add an image to the top of the document. 
            //var file = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("GridDataAwareExportCustomization.Resources.1.jpg");
            //if (file != null)
            //{
            var imageToHeader = common.Properties.Resources.logo;
            var imageToHeaderRange = new XlCellRange(new XlCellPosition(0, 0), new XlCellPosition(5, 7));
            e.ExportContext.MergeCells(imageToHeaderRange);
            e.ExportContext.InsertImage(imageToHeader, imageToHeaderRange);

            e.ExportContext.MergeCells(new XlCellRange(new XlCellPosition(0, 8), new XlCellPosition(5, 8)));
        }

        void options_CustomizeSheetFooter(ContextEventArgs e)
        {
            e.ExportContext.AddRow();

            var firstRow = new CellObject();
            firstRow.Value = @"Este reporte ha sido generado desde Kaz HotSpot Wifi";

            var rowFormatting = CreateXlFormattingObject(true, 18);
            rowFormatting.Alignment.HorizontalAlignment = XlHorizontalAlignment.Left;
            firstRow.Formatting = rowFormatting;

            e.ExportContext.AddRow(new[] { firstRow });


            var secondRow = new CellObject();
            secondRow.Value = @"Exportado por : @" + Link.IdUsuario + " - " + Link.CompanyName;
            rowFormatting.Font.Size = 14;
            rowFormatting.Font.Bold = false;
            rowFormatting.Font.Italic = true;
            secondRow.Formatting = rowFormatting;
            e.ExportContext.AddRow(new[] { secondRow });
        }

        void options_CustomizeSheetSettings(CustomizeSheetEventArgs e)
        {
            // Anchor the output document's header to the top and set its fixed height.  
            const int lastHeaderRowIndex = 15;
            e.ExportContext.SetFixedHeader(lastHeaderRowIndex);
            // Add the AutoFilter button to the document's cells corresponding to the grid column headers. 
            e.ExportContext.AddAutoFilter(new XlCellRange(new XlCellPosition(0, lastHeaderRowIndex), new XlCellPosition(5, 100)));
        }

        static XlFormattingObject CreateXlFormattingObject(bool bold, double size)
        {
            var cellFormat = new XlFormattingObject
            {
                Font = new XlCellFont
                {
                    Bold = bold,
                    Size = size
                },

                Alignment = new XlCellAlignment
                {
                    RelativeIndent = 10,
                    HorizontalAlignment = XlHorizontalAlignment.Center,
                    VerticalAlignment = XlVerticalAlignment.Center
                }
            };

            return cellFormat;
        }

        private void item_maxWidth_Click(object sender, EventArgs e)
        {
            if (column != null)
            {
                column.MaxWidth = 0;
                column.BestFit();
            }
        }
    }
}
