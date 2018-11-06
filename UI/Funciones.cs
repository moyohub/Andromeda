using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class Funciones
    {
        public void openWaitForm(DevExpress.XtraSplashScreen.SplashScreenManager ssm)
        {
            ssm.ShowWaitForm();
            ssm.SetWaitFormDescription("Espere un momento...");
            ssm.SetWaitFormCaption("Cargando");

        }
        public void closeWaitForm(DevExpress.XtraSplashScreen.SplashScreenManager ssm)
        {
            ssm.CloseWaitForm();

        }

        //Variables Globales

        public string nombreSistema = "InfoMedic";


    

    }
}
