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
    public partial class frmColorMantenimiento : DevExpress.XtraEditors.XtraForm
    {
        BLLClass BC = new BLLClass();
        DataTable vdtDatos = new DataTable();
        string vIdColor;
        string[] vDevuelto = new string[2];
        public bool vBandera = false;


        public frmColorMantenimiento(string vId)
        {
            InitializeComponent();
            vIdColor = vId;
            if ((vIdColor == "0") || (vIdColor == ""))
            {

            }
            else
            {
                try
                {
                    vdtDatos = BC.Consulta("paccolor", 2, vIdColor, 0, 0);
                    vdtDatos.Rows[0]["id_color"].ToString();
                    txtColor.Text = vdtDatos.Rows[0]["nombre_color"].ToString();
                                    }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void recargarFormulario()
        {
            txtColor.Text = "";
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            vpValidar.Validate();
            if ((vIdColor == "0") || (vIdColor == ""))
            {
                //Insertar
                try
                {
                   vDevuelto = BC.ProcedimientoAlmacenado("pamcolor",1,0,txtColor.Text);
                    if (vDevuelto[1] == "1")
                    {
                        XtraMessageBox.Show(vDevuelto[0]);
                        recargarFormulario();
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
            else
            {
                //Modificar
                try
                {
                    vDevuelto = BC.ProcedimientoAlmacenado("pamcolor", 2, vIdColor, txtColor.Text);
                    if (vDevuelto[1] == "1")
                    {
                        XtraMessageBox.Show(vDevuelto[0]);
                        this.Close();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}