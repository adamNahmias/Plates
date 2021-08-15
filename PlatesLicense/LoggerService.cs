using System;
using System.IO;


namespace PlateLicense
{
    public class LoggerService
    {
        private static LoggerService loggerService;
        private static string LogFolder = "C:\\Temp\\PlatesLogs";
        public string LogFile;       
        //consider move to enum
        private string DEBUG_LEVEL = "DEBUG";
        private string INFO_LEVEL = "INFO";
        private string ERROR_LEVEL = "ERROR";
        private string WARNING_LEVEL = "WARNING";

        public static LoggerService GetInstance()
        {
            if(loggerService == null)
            {
                loggerService = new LoggerService();
            }
            return loggerService;
        }
        private LoggerService()
        {
            if (!Directory.Exists(LogFolder))
            {
                Directory.CreateDirectory(LogFolder);
            }
            LogFile = Path.Combine(LogFolder, string.Format("Plates {0}.log", DateTime.Now.ToString("yyyy'-'MM'-'dd' 'HH' 'mm' 'ss")));          
        }
        public void DEBUG(string logMessage)
        {
            WriteMessegeToLog(DEBUG_LEVEL, logMessage);
        }
        public void WARNING(string logMessage)
        {
            WriteMessegeToLog(WARNING_LEVEL, logMessage);
        }
        public void INFO(string logMessage)
        {
            WriteMessegeToLog(INFO_LEVEL, logMessage);
        }
        public void ERROR(string logMessage)
        {
            WriteMessegeToLog(ERROR_LEVEL, logMessage);
        }

        private void WriteMessegeToLog(string levelType, string logMessage)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(LogFile))
                {
                    writer.WriteLine("[{0}] {1}: {2}", DateTime.Now.ToString(), levelType, logMessage);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
