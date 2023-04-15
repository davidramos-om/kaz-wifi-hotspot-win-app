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

namespace mk_management.hotspot
{
    public partial class uc_formato_rpt_credenciales : DevExpress.XtraEditors.XtraUserControl
    {
        string id = "";
        string descripcion = "Credenciales de acceso a internet";
        System.IO.Stream formato = null;

        public const string CODIGO_RPT = "frm_rpt_cred_acc";

        public uc_formato_rpt_credenciales()
        {
            InitializeComponent();
            btnEditar.Text = "Crear";
            txtImpresora.Text = "";
        }

        public void Inicializar()
        {
            try
            {
                var dt = DataHelper.ConsultarRegistro("formatos_rpt", "Codigo", CODIGO_RPT);

                btnEditar.Text = "Crear";
                txtImpresora.Text = "";

                if (Utilerias.TablaTieneRows(dt))
                {
                    id = Utilerias.SafeToString(dt.Rows[0]["Id"]);
                    descripcion = Utilerias.SafeToString(dt.Rows[0]["Nombre"]);
                    txtImpresora.Text = Utilerias.SafeToString(dt.Rows[0]["Impresora"]);

                    var frm = dt.Rows[0]["Formato"];

                    if (Utilerias.EsValorValido(frm))
                        formato = Utilerias.getStreamFromObject(dt.Rows[0]["Formato"]);

                    lbTituloReporte.Text = descripcion;
                    btnEditar.Text = "Editar";
                }
            }
            catch (Exception ex)
            {
                DataHelper.AgregarBitacoraSistema(this.Name + ".Inicializar", ex.Message, true);
                Utilerias.msjErrorEx(ex);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Utilerias.IsNullOrEmpty(formato))
                {
                    Utilerias.msjAlert("Se debe establecer un formato de impresión.");
                    return;
                }

                if (Utilerias.EsValorValido(id))
                {
                    DataHelper.ActualizarRegistro_Tabla("formatos_rpt", "Id", id
                                                        , "Codigo", CODIGO_RPT
                                                        , "Nombre", descripcion
                                                        , "Impresora", txtImpresora.Text
                                                        , "Formato", formato
                                                        );

                    Utilerias.msjInfo("El formato ha sido actualizado.");
                }

                else
                {
                    var r = DataHelper.CrearRegistro_Tabla("formatos_rpt"
                                                          , "Nombre", "Credenciales de acceso a internet"
                                                          , "Impresora", txtImpresora.Text
                                                          , "Codigo", CODIGO_RPT
                                                          , "Formato", formato
                                                        );

                    if (r)
                    {
                        Utilerias.msjInfo("El formato ha sido creado.");
                        Inicializar();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            { 

                var info = "Estos accesos tienen una duración de x días. Prohibido el uso de los mismos para el uso indebido de acuerdos a nuestras políticas.";
                var ds = hotspot.Helper.GenerateUserCredentialDataToPrint("Ejmp_usu", "Ejmp_pwd", info);

                hotspot.Helper.PrintUserCredential(ds, descripcion, PrintMethod.OpenDesigner, ref formato);
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            try
            {
                using (var w = Utilerias.ShowOverlay(this, "Cargando..."))
                {
                    var info = "Estos accesos tienen una duración de x días. Prohibido el uso de los mismos para el uso indebido de acuerdos a nuestras políticas.";
                    var ds = hotspot.Helper.GenerateUserCredentialDataToPrint("ejmp-usu", "ejmp-pwd", info);

                    hotspot.Helper.PrintUserCredential(ds, descripcion, PrintMethod.InvokeDialog, ref formato);
                }
            }
            catch (Exception ex)
            {
                Utilerias.msjErrorEx(ex);
            }
        }
    }
}
