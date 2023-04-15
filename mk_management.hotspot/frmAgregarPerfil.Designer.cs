namespace mk_management.hotspot
{
    partial class frmAgregarPerfil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarPerfil));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.lueDispositivo = new DevExpress.XtraEditors.LookUpEdit();
            this.spVelocidadSubida = new DevExpress.XtraEditors.SpinEdit();
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.rgVelocidad = new DevExpress.XtraEditors.RadioGroup();
            this.spVelocidadDescarga = new DevExpress.XtraEditors.SpinEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueDispositivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spVelocidadSubida.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgVelocidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spVelocidadDescarga.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.lueDispositivo);
            this.dataLayoutControl1.Controls.Add(this.spVelocidadSubida);
            this.dataLayoutControl1.Controls.Add(this.btnGuardar);
            this.dataLayoutControl1.Controls.Add(this.txtNombre);
            this.dataLayoutControl1.Controls.Add(this.rgVelocidad);
            this.dataLayoutControl1.Controls.Add(this.spVelocidadDescarga);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(880, 554);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // lueDispositivo
            // 
            this.lueDispositivo.Location = new System.Drawing.Point(182, 110);
            this.lueDispositivo.Name = "lueDispositivo";
            this.lueDispositivo.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lueDispositivo.Properties.Appearance.Options.UseFont = true;
            this.lueDispositivo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDispositivo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripción")});
            this.lueDispositivo.Properties.NullText = "";
            this.lueDispositivo.Properties.ShowFooter = false;
            this.lueDispositivo.Properties.ShowHeader = false;
            this.lueDispositivo.Properties.ShowLines = false;
            this.lueDispositivo.Size = new System.Drawing.Size(613, 28);
            this.lueDispositivo.StyleController = this.dataLayoutControl1;
            this.lueDispositivo.TabIndex = 17;
            // 
            // spVelocidadSubida
            // 
            this.spVelocidadSubida.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spVelocidadSubida.Location = new System.Drawing.Point(725, 208);
            this.spVelocidadSubida.Name = "spVelocidadSubida";
            this.spVelocidadSubida.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.spVelocidadSubida.Properties.Appearance.Options.UseFont = true;
            this.spVelocidadSubida.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spVelocidadSubida.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.spVelocidadSubida.Properties.Mask.EditMask = "n1";
            this.spVelocidadSubida.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.spVelocidadSubida.Size = new System.Drawing.Size(72, 28);
            this.spVelocidadSubida.StyleController = this.dataLayoutControl1;
            this.spVelocidadSubida.TabIndex = 12;
            this.spVelocidadSubida.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.spVelocidadSubida_EditValueChanging);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnGuardar.Appearance.Options.UseFont = true;
            this.btnGuardar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnGuardar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnGuardar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGuardar.ImageOptions.SvgImage")));
            this.btnGuardar.Location = new System.Drawing.Point(635, 292);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(160, 65);
            this.btnGuardar.StyleController = this.dataLayoutControl1;
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(180, 160);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNombre.Properties.Appearance.Options.UseFont = true;
            this.txtNombre.Properties.MaxLength = 30;
            this.txtNombre.Size = new System.Drawing.Size(617, 28);
            this.txtNombre.StyleController = this.dataLayoutControl1;
            this.txtNombre.TabIndex = 5;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Escribir nombre del perfil";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.dxValidationProvider1.SetValidationRule(this.txtNombre, conditionValidationRule1);
            // 
            // rgVelocidad
            // 
            this.rgVelocidad.Location = new System.Drawing.Point(180, 208);
            this.rgVelocidad.Name = "rgVelocidad";
            this.rgVelocidad.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rgVelocidad.Properties.Appearance.Options.UseFont = true;
            this.rgVelocidad.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "No"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Si")});
            this.rgVelocidad.Size = new System.Drawing.Size(233, 31);
            this.rgVelocidad.StyleController = this.dataLayoutControl1;
            this.rgVelocidad.TabIndex = 6;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Seleccionar una opción";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.dxValidationProvider1.SetValidationRule(this.rgVelocidad, conditionValidationRule2);
            this.rgVelocidad.EditValueChanged += new System.EventHandler(this.rgVelocidad_EditValueChanged);
            // 
            // spVelocidadDescarga
            // 
            this.spVelocidadDescarga.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spVelocidadDescarga.Location = new System.Drawing.Point(530, 208);
            this.spVelocidadDescarga.Name = "spVelocidadDescarga";
            this.spVelocidadDescarga.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.spVelocidadDescarga.Properties.Appearance.Options.UseFont = true;
            this.spVelocidadDescarga.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spVelocidadDescarga.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.spVelocidadDescarga.Properties.Mask.EditMask = "n1";
            this.spVelocidadDescarga.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.spVelocidadDescarga.Size = new System.Drawing.Size(78, 28);
            this.spVelocidadDescarga.StyleController = this.dataLayoutControl1;
            this.spVelocidadDescarga.TabIndex = 11;
            this.spVelocidadDescarga.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.spVelocidadDescarga_EditValueChanging);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20);
            this.Root.Size = new System.Drawing.Size(880, 554);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem4,
            this.emptySpaceItem3,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(50, 50, 50, 50);
            this.layoutControlGroup1.Size = new System.Drawing.Size(840, 514);
            this.layoutControlGroup1.Text = "Crear Perfil HotSpot";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtNombre;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.layoutControlItem1.Size = new System.Drawing.Size(734, 48);
            this.layoutControlItem1.Text = "Nombre:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.rgVelocidad;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 100);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(350, 51);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(350, 51);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.layoutControlItem2.Size = new System.Drawing.Size(350, 51);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Limitar Velocidad :";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.spVelocidadDescarga;
            this.layoutControlItem7.Location = new System.Drawing.Point(350, 100);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.layoutControlItem7.Size = new System.Drawing.Size(195, 51);
            this.layoutControlItem7.Text = "Mb Descarga:";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.spVelocidadSubida;
            this.layoutControlItem8.Location = new System.Drawing.Point(545, 100);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.layoutControlItem8.Size = new System.Drawing.Size(189, 51);
            this.layoutControlItem8.Text = "Mb Subida:";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(94, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 151);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(0, 41);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(10, 41);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(734, 41);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 192);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(560, 69);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnGuardar;
            this.layoutControlItem4.Location = new System.Drawing.Point(560, 192);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(174, 69);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(174, 69);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 12, 2, 2);
            this.layoutControlItem4.Size = new System.Drawing.Size(174, 69);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 261);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(734, 122);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lueDispositivo;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(12, 12, 12, 12);
            this.layoutControlItem3.Size = new System.Drawing.Size(734, 52);
            this.layoutControlItem3.Text = "Dispositivo:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(94, 13);
            // 
            // frmAgregarPerfil
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "frmAgregarPerfil";
            this.Size = new System.Drawing.Size(880, 554);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueDispositivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spVelocidadSubida.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgVelocidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spVelocidadDescarga.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.RadioGroup rgVelocidad;
        private DevExpress.XtraEditors.SpinEdit spVelocidadDescarga;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SpinEdit spVelocidadSubida;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit lueDispositivo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}