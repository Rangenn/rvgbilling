using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using RVGlib.Framework;
using RVGlib.Domain;

namespace RVGBilling.Import
{
    /// <summary>
    /// Класс для импорта и экспорта из CSV
    /// </summary>
    public class CsvTransmitter : ITransmitter
    {

        /// <summary>
        /// Обрабатываем CSV-файл вида "вызываемый номер, исходящий номер, время, длительность"
        /// </summary>
        /// <param name="file"></param>
        public string[][] Import(string filename)
        {
            string[][] data = new string[0][];
            try
            {
                StreamReader sr = new StreamReader(filename);
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        //String[] arr = line.Split(new char[] { ',' });
                        String[] arr = CsvParser.Split(line);
                        for (int i = 0; i < arr.Length; i++)
                            arr[i] = arr[i].Trim();
                        Array.Resize(ref data, data.Length + 1);
                        data[data.Length - 1] = arr;
                    }
                }
                sr.Close();

            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return data;
        }

        public void Export(string filename,string[][] data)
        {
            try
            {
                StreamWriter sr = new StreamWriter(filename);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.Length = 0;
                    for (int j = 0; j < data[i].Length; j++)
                    {
                        sb.Append(data[i][j]);
                        sb.Append(",");
                    }
                    /*sb.Append(data[i][0]);
                    sb.Append(",");
                    sb.Append(data[i][1]);
                    sb.Append(",");
                    sb.Append(data[i][2]);
                    sb.Append(",");
                    sb.Append(data[i][3]);*/
                    Console.WriteLine(sb.ToString());
                    sr.WriteLine(sb.ToString());
                }
                sr.Close();
                Console.WriteLine("The file was written");

            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be written");
                Console.WriteLine(e.Message);
            }
        }

    }
}
