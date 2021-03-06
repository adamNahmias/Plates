using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateLicense
{
    public class GateService
    {
        public static GateService gateService;
        public static string reason;
        private bool allowed;

        public static GateService GetInstance()
        {
            if (gateService == null)
            {
                gateService = new GateService();
            }
            else
            {
                reason = "";
            }
            return gateService;
        }
        private GateService()
        {
            reason = "";
        }
        public bool isVenichleAllowed(string plateNumber)
        {
            allowed = true;
            reason = "Allowed";
            //case API ERROR
            if (plateNumber == "API ERROR")
            {
                LoggerService.GetInstance().ERROR("There was some problem to recognize your plate, please take a ticket to enter.");
                reason = "There was some problem to recognize your plate, please take a ticket to enter.";
                throw new Exception("API ERROR");
            }
            //case emptyPlate
            if (plateNumber == "")
            {
                reason = "Plate numbers which have no letters at all, cannot enter.";
                allowed = false;
                LoggerService.GetInstance().WARNING(string.Format("Plate Number: {0} NOT ALLOWED TO ENTER, Reason: {1}", plateNumber, reason));
            }
            //Military case
            if(plateNumber.EndsWith("L") || plateNumber.EndsWith("M"))
            {
                reason = "Military and law enforcement vehicles are prohibited";
                allowed = false;
                LoggerService.GetInstance().WARNING(string.Format("Plate Number: {0} NOT ALLOWED TO ENTER, Reason: {1}", plateNumber, reason));
            }
            //Public case
            if (plateNumber.EndsWith("6") || plateNumber.EndsWith("G"))
            {
                reason = "Public transportation vehicles cannot enter the parking lot";
                allowed = false;
                LoggerService.GetInstance().WARNING(string.Format("Plate Number: {0} NOT ALLOWED TO ENTER, Reason: {1}", plateNumber, reason));
            }
            DBService.GetInstance("Plates","AllowedList").insertPlateToDB(DateTime.Now ,plateNumber, allowed,reason);
            if (allowed)
            {
                LoggerService.GetInstance().INFO(string.Format("Plate Number: [{0}] ENTER TO THE PARKING", plateNumber));
            }
            else
            {
                LoggerService.GetInstance().INFO(string.Format("Plate Number: [{0}] NOT ALLOWED TO ENTER THE PARKING", plateNumber));
            }
            return allowed;
        }
    }
}
