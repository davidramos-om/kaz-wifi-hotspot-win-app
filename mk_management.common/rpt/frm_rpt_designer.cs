using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using DevExpress.XtraReports.UserDesigner;

namespace mk_management.common.rpt
{
    //public partial class frm_rpt_designer : DevExpress.XtraReports.UserDesigner.XRDesignRibbonForm
    public partial class frm_rpt_designer : DevExpress.XtraEditors.XtraForm
    {
        DevExpress.XtraReports.UI.XtraReport reporte;
        public bool Guardado = false;

        public frm_rpt_designer(Icon iconoApp, Stream formato, DataSet dsFields, string nombreReporte)
        {
            InitializeComponent();


            this.Icon = iconoApp;

            
            reporte = new DevExpress.XtraReports.UI.XtraReport();
            reporte.Bookmark = nombreReporte;
            reporte.Name = nombreReporte;
            reporte.DisplayName = nombreReporte;
            

            if (formato != null)
            {
                try
                {
                    reporte.LoadLayout(formato);
                }
                catch (Exception ex)
                {
                    Utilerias.msjAlert("No se pudo cargar el formato. Error : " + ex.Message);
                }
                
            }


            reporte.DataSource = dsFields;
            reporte.DataMember = dsFields.DataSetName;
            
            reportDesigner1.OpenReport(reporte);

        }

        //public Stream ObtenerBinario_Object(object objectType)
        //{
        //    var stream = new System.IO.MemoryStream();
        //    var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        //    formatter.Serialize(stream, objectType);
        //    return stream;
        //}


        public Stream msFormatoReporte = null;
        private Stream ObtenerStream()
        {
            if (reporte != null)
            {
                var ms = new MemoryStream();
                reporte.SaveLayout(ms, true);

                return ms;
                //var report = (reportDesigner1.ActiveDesignPanel as XRDesignPanel).Report;


                ////report.SaveLayout(ms, false);

                //MemoryStream stream3 = new MemoryStream();
                //report.SaveLayoutToXml(stream3);

                //stream3.Position = 0;

                //string s;
                //using (StreamReader sr = new StreamReader(stream3))
                //{
                //    //Pasar el report de stream a string  
                //    s = sr.ReadToEnd();
                //}


                //return stream3;
            }

            return null;
        }

        private void barGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnGuardarReporte_Click(object sender, EventArgs e)
        {
            if(reporte != null)
            {
                Guardado = true;
                msFormatoReporte = ObtenerStream();
                this.Close();
            }
        }

        private void bbiSaveFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            if (reporte != null)
            {
                Guardado = true;
                msFormatoReporte = ObtenerStream();
                this.Close();
            }
        }
    }
}