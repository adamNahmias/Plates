using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateLicense
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath1 = @"..\..\Test Images\public3.png";
            string filepath2 = @"..\..\Test Images\public.png";
            string filepath3 = @"..\..\Test Images\public2.png";

            //string plate = GetImageTextService.getText(filepath);
            string platenum1 = GetImageTextService.getText(filepath1);
            string platenum2 = GetImageTextService.getText(filepath2);
            string platenum3 = GetImageTextService.getText(filepath3);
            string platenum4 = "GHJKLG";
            string platenum5 = "GHJKLF";
            string platenum6 = "";
            string platenum7 = "TYUHG4";
            GateService.isVenichleAllowed(platenum1);
            GateService.isVenichleAllowed(platenum2);
            GateService.isVenichleAllowed(platenum3);
            GateService.isVenichleAllowed(platenum4);
            GateService.isVenichleAllowed(platenum5);
            GateService.isVenichleAllowed(platenum6);
            GateService.isVenichleAllowed(platenum7);

        }
    }
}
