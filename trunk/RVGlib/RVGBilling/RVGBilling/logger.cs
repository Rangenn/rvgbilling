using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RVGBilling
{
    /// <summary>
    /// Класс - логгер сообщений в файл
    /// </summary>
    static class logger
    {
        /// <summary>
        /// Имя лог-файла
        /// </summary>
        static string logfile = "log" + DateTime.Now.ToShortDateString() + ".txt";

        /// <summary>
        /// Записать сообщение в файл
        /// </summary>
        /// <param name="message"></param>
        public static void log(string message)
        {
            FileStream fs = new FileStream(logfile, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            if (message == "-")
            {
                //sw.WriteLine();
                sw.WriteLine("--------------------------------------------------");
            }
            else sw.WriteLine(DateTime.Now.ToShortTimeString() + ": " + message);

            sw.Close();
            fs.Close();
        }
    }
}
