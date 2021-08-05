using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateLicense
{
    class GateService
    {
        public static void isVenichleAllowed(string plateNumber)
        {
            string time = DateTime.Now.ToString("hh:mm:ss.fff tt");
            //case emptyPlate
            string reason = "Allowed";
            bool allowed = true;
            if(plateNumber == "" || plateNumber == null)
            {
                reason = "Plate numbers which have no letters at all, cannot enter.";
                allowed = false;
            }
            //Military case
            if(plateNumber.EndsWith("L") || plateNumber.EndsWith("M"))
            {
                reason = "Military and law enforcement vehicles are prohibited";
                allowed = false;
            }
            //Public case
            if (plateNumber.EndsWith("6") || plateNumber.EndsWith("G"))
            {
                reason = "Public transportation vehicles cannot enter the parking lot";
                allowed = false;
            }
            DBService.insertPlateToDB(time,plateNumber,allowed,reason);
        }
    }
}
