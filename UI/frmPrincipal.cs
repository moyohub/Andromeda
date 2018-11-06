using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace UI
{
    public partial class frmPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void cargarForm(Form frmForm)
        {
          
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBoton frm = new frmBoton();
            cargarForm(frm);

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }
    }
}