using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace eRoute.Controllers.API
{
    public class LogController
    {
        public void Log(Exception logMessage, string fileName)
        {
            try
            {
                string path = ConfigurationManager.AppSettings.Get("pathLogs");
                fileName = string.Format(@"{0}\Log{1}_{2:ddMMyyyy}.txt", path, fileName, DateTime.Now);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (!File.Exists(fileName))
                {
                    File.CreateText(fileName);
                }

                using (StreamWriter file = File.AppendText(fileName))
                {
                    file.WriteLine("\r\nLog Entry : " + DateTime.Now);
                    file.WriteLine(logMessage);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
