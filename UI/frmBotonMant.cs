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
    public partial class frmBotonMant : DevExpress.XtraEditors.XtraForm
    {
        BLLClass BC = new BLLClass();
        Funciones FC = new Funciones();
        DataTable vdtDatos = new DataTable();
        string vId;
        string[] vDevuelto = new string[2];
        public frmBotonMant(string id)
        {
            InitializeComponent();
            vId = id;
            if ((vId == "0") || (vId == ""))
            {

            }
            else
            {
                try
                {
                    vdtDatos = BC.Consulta("pacboton", 2, vId, 0, 0);
                    vdtDatos.Rows[0]["id_boton"].ToString();
                    txtBoton.Text = vdtDatos.Rows[0]["nombre_boton"].ToString();
                }
                catch (Exception ex)
                {
                    acNoti.Show(this,FC.nombreSistema,ex.Message);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            vpValidar.Validate();
            if ((vId == "0") || (vId == ""))
            {
                //Insertar
                try
                {
                    vDevuelto = BC.ProcedimientoAlmacenado("pamboton", 1, 0, txtBoton.Text);
                    if (vDevuelto[1] == "1")
                    {
                        acNoti.Show(this, FC.nombreSistema, vDevuelto[0]);
                        this.Close();

                    }
                    else
                    {
                        acNoti.Show(this, FC.nombreSistema, vDevuelto[0]);
                        this.Close();

                    }
                }
                catch (Exception ex)
                {
                    acNoti.Show(this, FC.nombreSistema, ex.Message);
                }
            }
            else
            {
                //Modificar
                try
                {
                    vDevuelto = BC.ProcedimientoAlmacenado("pamboton", 2, vId, txtBoton.Text);
                    if (vDevuelto[1] == "1")
                    {
                        
                        acNoti.Show(this, FC.nombreSistema, vDevuelto[0]);
                        this.Close();
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