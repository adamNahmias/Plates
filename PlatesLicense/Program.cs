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
            //string filepath = @"..\..\..\Test Images\public3.png";
            //string plate = GetImageTextService.getText(filepath);
            string platenum1 = "GHJKLM";
            string platenum2 = "GHJKLL";
            string platenum3 = "GHJKL6";
            string platenum4 = "GHJKLG";
            string platenum5 = "GHJKLF";
            string platenum6 = "";
            DBService.insertPlateToDB("a", "b", true ,"d");
            //GateService.isVenichleAllowed(platenum1);
            //GateService.isVenichleAllowed(platenum2);
            //GateService.isVenichleAllowed(platenum3);
            //GateService.isVenichleAllowed(platenum4);
            //GateService.isVenichleAllowed(platenum5);
            //GateService.isVenichleAllowed(platenum6);

        }
    }
}
