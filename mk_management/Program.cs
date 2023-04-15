using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mk_management
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //Application.Run(new Menuprincipal());
                //Application.Run(new DxMenu());

                common.ConfigurationSettings.LoadConfig();

                if (common.ConfigurationSettings.Obtener_AutoConectar())
                {
                    CalculateHwID();

                    Application.Run(new DxMenu());
                }
                else
                {
                    var frm = new common.frmAppSetting(true);
                    Application.Run(frm);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al iniciar aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Run(new common.frmAppSetting(true));
            }
        }

        static void CalculateHwID()
        {
            //Colocar en proceso de segundo plano para optimizar
            Thread hw = new Thread(PC_HwId.Calculate);
            hw.Start();
        }
    }
}
