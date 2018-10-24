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
using BLL;

namespace UI
{
    public partial class frmColor : DevExpress.XtraEditors.XtraForm
    {
        BLLClass BC = new BLLClass();
        DataTable vdtGrid = new DataTable();
        public frmColor()
        {

            InitializeComponent();
            CargarGrid();
        }
        
        private void CargarGrid()
        {
            waitForm(ssmWait);
            try
            {
                vdtGrid = BC.Consulta("paccolor", 1, 1, 0, 0);
                gcGrid.DataSource = vdtGrid;
                gcGrid.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ssmWait.CloseWaitForm();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmColorMantenimiento frm = new frmColorMantenimiento("");
            frm.ShowDialog();
            CargarGrid();
            
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmColorMantenimiento frm = new frmColorMantenimiento(gvVista.GetRowCellValue(gvVista.FocusedRowHandle, "id_color").ToString());
            frm.ShowDialog();
            CargarGrid();
        }

        private void waitForm(DevExpress.XtraSplashScreen.SplashScreenManager ssm)
        {
            ssm.ShowWaitForm();
            ssmWait.SetWaitFormDescription("Espere un momento...");
            ssmWait.SetWaitFormCaption("Cargando");

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("¿Desea eliminar este elemento?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string[] vDevuelto = new string[2];
                        vDevuelto = BC.ProcedimientoAlmacenado("pamcolor", 3, gvVista.GetRowCellValue(gvVista.FocusedRowHandle, "id_color"), 0);
                    if (vDevuelto[1] == "1")
                    {
                        XtraMessageBox.Show(vDevuelto[0]);
                        CargarGrid();
                    }
                    else
                    {
                        XtraMessageBox.Show(vDevuelto[0]);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }
    }
}