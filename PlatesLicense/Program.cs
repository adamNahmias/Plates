using PlateLicense.TextImage;
using System;
using System.Threading;
using System.Windows.Forms;

namespace PlateLicense
{
    class Program
    {
        public static string openFileDialogAndReturnFilePath()
        {
            string selectedPath = "";

            Thread t = new Thread((ThreadStart)(() => {
                OpenFileDialog saveFileDialog1 = new OpenFileDialog();

                saveFileDialog1.Filter = "png Files (*.png)|*.png";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    selectedPath = saveFileDialog1.FileName;
                }
            }));

            // Run your code from a thread that joins the STA Thread
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            return selectedPath;
        }
        static void Main(string[] args)
        {

            string param = openFileDialogAndReturnFilePath();
            bool allowed;
            while (param != "exit" && param !=null && param != "")
            {
                string platenum = ImageToTextService.GetInstance(TextLanguage.English).getImageText(param);
                try
                {
                    allowed = GateService.GetInstance().isVenichleAllowed(platenum);

                }
                catch
                {
                    allowed = false;
                }
                if (allowed)
                {
                    Console.WriteLine(string.Format("PlateNumber : [{0}] enter to the parking : ", platenum));
                }
                else
                {
                    if(platenum =="API ERROR")
                    {
                        Console.WriteLine(GateService.reason);
                    }
                    else
                    {
                        Console.WriteLine(string.Format("PlateNumber :[{0}] Not Allowed to enter the parking, reason: {1}", platenum, GateService.reason));
                    }
                }
                param = openFileDialogAndReturnFilePath();
            }

        }
    }
}

