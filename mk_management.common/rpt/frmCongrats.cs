using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mk_management.common.rpt
{
    public partial class frmCongrats : DevExpress.XtraEditors.XtraForm
    {
        InfoLicencia licencia;
        bool OpenFeatures = true;

        public frmCongrats(Icon icono, InfoLicencia lic, bool _openFeatures = true)
        {
            InitializeComponent();
            this.Icon = icono;
            licencia = lic;
            OpenFeatures = _openFeatures;


            SetSubTitle("La licencia ha sido aplicada");
            var azul = Color.FromArgb(41, 182, 246);
            SetBorderColor(azul);
        }

        private void frmCongrats_Shown(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void MostrarAnimacion()
        {
            transitionManager1.StartTransition(lblTitulo);
            lblTitulo.Text = lblTitulo.Text == "Felicidades" ? "¡Muchas gracias!" : "Felicidades";
            transitionManager1.EndTransition();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            MostrarAnimacion();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetSubTitle(string text)
        {
            lbSubTitulo.Text = text;
        }

        public void SetBorderColor(Color color)
        {
            lbDerecha.BackColor = color;
            lbIqz.BackColor = color;
            lbAbajo.BackColor = color;
            lbTop.BackColor = color;
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {
            if (!OpenFeatures)
                return;

            var frm = new frmPricing(this.Icon, licencia);
            frm.ShowDialog();
        }
    }
}
