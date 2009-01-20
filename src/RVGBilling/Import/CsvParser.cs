using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RVGBilling.Import
{
    /// <summary>
    /// Парсер для формата CSV
    /// </summary>
    public class CsvParser
    {
        public static string separator = ";";
        private static string pattern= string.Format("{0}(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))",separator);

        public static string[] Split(string input)
        {
            return Regex.Split(input, pattern);
        }
    }
}
