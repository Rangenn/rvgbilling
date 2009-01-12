using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RVGlib.Import
{
    public class CSVParser
    {
        private static string separator = ",";
        private static string pattern= string.Format("{0}(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))",separator);

        public static string[] Split(string input)
        {
            return Regex.Split(input, pattern);
        }
    }
}
