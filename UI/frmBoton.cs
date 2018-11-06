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
using DevExpress.XtraBars;
using System.ComponentModel.DataAnnotations;
using BLL;

namespace UI
{
    public partial class frmBoton : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BLLClass BC = new BLLClass();
        Funciones FC = new Funciones();
        DataTable vdtGrid = new DataTable();
        public frmBoton()
        {
            InitializeComponent();
            CargarGrid();
        }
        private void CargarGrid()
        {
            FC.openWaitForm(ssmWait);
            try
            {
                vdtGrid = BC.Consulta("pacboton", 1, 1, 0, 0);
                gcGrid.DataSource = vdtGrid;
                gcGrid.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            bsiRecordsCount.Caption = "RECORDS : " + vdtGrid.Rows.Count.ToString();
            FC.closeWaitForm(ssmWait);
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gcGrid.ShowRibbonPrintPreview();
        }
        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBotonMant frm = new frmBotonMant("");
            frm.ShowDialog();
            
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBotonMant frm = new frmBotonMant(gvVista.GetRowCellValue(gvVista.FocusedRowHandle, "id_boton").ToString());
            frm.ShowDialog();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("¿Desea eliminar este elemento?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string[] vDevuelto = new string[2];
                    vDevuelto = BC.ProcedimientoAlmacenado("pamboton", 3, gvVista.GetRowCellValue(gvVista.FocusedRowHandle, "id_boton"), 0);
                    if (vDevuelto[1] == "1")
                    {
                        acNoti.Show(this,FC.nombreSistema,vDevuelto[0]);
                        CargarGrid();
                    }
                    else
                    {
                        acNoti.Show(this, FC.nombreSistema, vDevuelto[0]);
                    }
                }
                catch (Exception ex)
                {
                    acNoti.Show(this, FC.nombreSistema, ex.Message);
                }
            }
        }
    }
}