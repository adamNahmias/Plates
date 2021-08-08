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
            string param = "";
            try
            {
                param = args[0];
            }
            catch { }
            if(param == "" || param == "/help" || param == null)
            {
                Console.WriteLine("PlateLicense.exe [imagePath]");
            }
            else
            {
                string platenum = ImageToTextService.getImageText(param);
                GateService.isVenichleAllowed(platenum);
            }

            }
       
        }
    }

