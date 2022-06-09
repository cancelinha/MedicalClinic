using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application
{
    public class RegisterLog
    {
        private static string path = string.Empty;
        private static string directoryName = @"C:\LOG\MedicalGroup\";

        public static bool Log(string ex, string fileName = "fileLog")
        {
            try
            {

                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }

                string message = ex;

                path = Path.GetDirectoryName(directoryName);
                string filePath = Path.Combine(path, fileName + DateTime.Now.ToString("ddMMyyyy") + ".txt");
                if (!File.Exists(filePath))
                {
                    FileStream file = File.Create(filePath);
                    file.Close();
                }
                using (StreamWriter w = File.AppendText(filePath))
                {
                    AppendLog(message, w);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private static void AppendLog(string logMensagem, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine($"{logMensagem}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}