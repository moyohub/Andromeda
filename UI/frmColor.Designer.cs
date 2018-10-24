namespace UI
{
    partial class frmColor
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
            this.ssmWait = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::UI.frmEspera), true, true, true);
            this.gcGrid = new DevExpress.XtraGrid.GridControl();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvVista = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id_color = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nombre_color = new DevExpress.XtraGrid.Columns.GridColumn();
            this.estado_color = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            this.cmsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvVista)).BeginInit();
            this.SuspendLayout();
            // 
            // ssmWait
            // 
            this.ssmWait.ClosingDelay = 500;
            // 
            // gcGrid
            // 
            this.gcGrid.ContextMenuStrip = this.cmsMenu;
            this.gcGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcGrid.Location = new System.Drawing.Point(0, 0);
            this.gcGrid.LookAndFeel.SkinMaskColor = System.Drawing.Color.Transparent;
            this.gcGrid.MainView = this.gvVista;
            this.gcGrid.Name = "gcGrid";
            this.gcGrid.Size = new System.Drawing.Size(759, 392);
            this.gcGrid.TabIndex = 0;
            this.gcGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvVista});
            // 
            // cmsMenu
            // 
            this.cmsMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.cmsMenu.Name = "contextMenuStrip1";
            this.cmsMenu.Size = new System.Drawing.Size(180, 110);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = global::UI.Properties.Resources.nuevo_menu;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Image = global::UI.Properties.Resources.modificar_menu;
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::UI.Properties.Resources.borrar_menu;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // gvVista
            // 
            this.gvVista.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id_color,
            this.nombre_color,
            this.estado_color});
            this.gvVista.GridControl = this.gcGrid;
            this.gvVista.Name = "gvVista";
            this.gvVista.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvVista.OptionsBehavior.Editable = false;
            // 
            // id_color
            // 
            this.id_color.Caption = "id";
            this.id_color.FieldName = "id_color";
            this.id_color.Name = "id_color";
            // 
            // nombre_color
            // 
            this.nombre_color.Caption = "Color";
            this.nombre_color.FieldName = "nombre_color";
            this.nombre_color.Name = "nombre_color";
            this.nombre_color.Visible = true;
            this.nombre_color.VisibleIndex = 0;
            // 
            // estado_color
            // 
            this.estado_color.Caption = "Estado";
            this.estado_color.FieldName = "estado_color";
            this.estado_color.Name = "estado_color";
            // 
            // frmColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 392);
            this.Controls.Add(this.gcGrid);
            this.Name = "frmColor";
            this.Text = "Color";
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            this.cmsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvVista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gvVista;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn id_color;
        private DevExpress.XtraGrid.Columns.GridColumn nombre_color;
        private DevExpress.XtraGrid.Columns.GridColumn estado_color;
        private DevExpress.XtraSplashScreen.SplashScreenManager ssmWait;
    }
}