using System;

namespace mk_management.common
{
    public partial class frmAppSetting : DevExpress.XtraEditors.XtraForm
        
    {
        private readonly bool reiniciar = false;
        public frmAppSetting(bool _reiniciar)
        {
            InitializeComponent();
            reiniciar = _reiniciar;
            this.Icon = Utilerias.ObtenerIconoApp(); 
        }

        public void Cargar()
        {
            ucAppSetting1.Inicializar(reiniciar); 
        }

        private void frmAppSetting_Shown(object sender, EventArgs e)
        {
            this.Refresh();
            Cargar();
        }
    }
}
