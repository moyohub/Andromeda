using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using DAL;

namespace BLL
{
    public class BLLClass
    {
        DataTable vdtProcedureItems;
        DALClass DC;

        public BLLClass()
        {
            DC = new DALClass("mysql5006.site4now.net", "a41be6_andro01", "wording", "root1234");
            //DC = new DALClass("localhost", "apq", "root", "");

        }

        public void ProcedimientoAlmacenado(string ProcedimientoAlmacenado, params object[] parametros)
        {
            List<MySqlParameter> parametrosentrada = new List<MySqlParameter>();
            List<MySqlParameter> parametrossalida = new List<MySqlParameter>();
            vdtProcedureItems = new DataTable();

            vdtProcedureItems = DC.Sql("select", "information_schema.parameters", "PARAMETER_NAME", "SPECIFIC_NAME = '" + ProcedimientoAlmacenado + "' and PARAMETER_MODE = 'IN' and SPECIFIC_SCHEMA = 'db_a299f8_aqp';");
            //vdtProcedureItems = DC.Sql("select", "information_schema.parameters", "PARAMETER_NAME", "SPECIFIC_NAME = '" + ProcedimientoAlmacenado + "' and PARAMETER_MODE = 'IN' and SPECIFIC_SCHEMA = 'apq';");

            if (Convert.ToInt32(parametros.Count()) == vdtProcedureItems.Rows.Count)
            {
                for (int i = 0; i < parametros.Count(); i++)
                {
                    parametrosentrada.Add(new MySqlParameter(vdtProcedureItems.Rows[i]["PARAMETER_NAME"].ToString(), parametros[i].ToString()));
                }
                parametrossalida.Add(new MySqlParameter("$respuesta", ""));
                DC.ProcedimientoAlmacenado(ProcedimientoAlmacenado, parametrosentrada, parametrossalida);
                MessageBox.Show(parametrossalida[0].Value.ToString());
            }
            else
            {
                MessageBox.Show("El numero de parametros no es el correcto");
            }
        }

        public DataTable Consulta(string ProcedimientoAlmacenado, params object[] parametros)
        {
            List<MySqlParameter> parametrosentrada = new List<MySqlParameter>();
            List<MySqlParameter> parametrossalida = new List<MySqlParameter>();

            for (int i = 0; i < parametros.Count(); i++)
            {
                parametrosentrada.Add(new MySqlParameter("$para" + i, parametros[i].ToString()));
            }

            return DC.Consulta(ProcedimientoAlmacenado, parametrosentrada);
        }
    }
}
