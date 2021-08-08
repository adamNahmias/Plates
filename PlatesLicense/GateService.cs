using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateLicense
{
    class GateService
    {
        public static bool isVenichleAllowed(string plateNumber)
        {
            string reason = "Allowed";
            bool allowed = true;
            //case API ERROR
            if (plateNumber == "API ERROR")
            {
                LoggerService.GetInstance().ERROR("There was some problem to recognize your plate, please take a ticket to enter.");
                return false;
            }
            //case emptyPlate
            if (plateNumber == "" || plateNumber == null)
            {
                LoggerService.GetInstance().WARNING("Plate numbers which have no letters at all, cannot enter.");
                return false;
            }
            //Military case
            if(plateNumber.EndsWith("L") || plateNumber.EndsWith("M"))
            {
                reason = "Military and law enforcement vehicles are prohibited";
                allowed = false;
                LoggerService.GetInstance().WARNING(string.Format("Plate Number: {0} NOT ALLOWED TO ENTER Reason: {1}", plateNumber, reason));
            }
            //Public case
            if (plateNumber.EndsWith("6") || plateNumber.EndsWith("G"))
            {
                reason = "Public transportation vehicles cannot enter the parking lot";
                allowed = false;
                LoggerService.GetInstance().WARNING(string.Format("Plate Number: {0} NOT ALLOWED TO ENTER Reason: {1}", plateNumber, reason));
            }
            DBService.GetInstance("Plates","AllowedList").insertPlateToDB(DateTime.Now ,plateNumber, allowed,reason);
            LoggerService.GetInstance().INFO(string.Format("Plate Number: {0} ENTER TO THE PARKING", plateNumber, reason));
            return allowed;
        }
    }
}
