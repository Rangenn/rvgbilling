using System;
using System.IO;

namespace ExcelConnector
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = @"C:\Users\е\Desktop\test.xls";
            //if (args[0] != null) filename = args[0]; 

            System.Console.WriteLine("Создаю Excel application...");
            ExcelConnector _ExcelClient = new ExcelConnector(false);

            try
            {
                //System.Console.WriteLine("Создаю файл...");
                //System.Console.WriteLine(filename);
                //FileStream fs = new FileStream(filename, FileMode.Create);
                //fs.Close();
                                                
                System.Console.WriteLine("Загружаю книгу " + filename + "...");
                _ExcelClient.OpenExcelWorkBook(filename);
                System.Console.WriteLine("Работаю с листом №1...");
                _ExcelClient.SelectExcelWorkSheet(1);
                _ExcelClient.SetCellValue("B", 3, "emana!");
                //_ExcelClient.CutNPasteRange("B3", "D8", "I6");
            }
            catch (Exception ex) { System.Console.WriteLine(ex.ToString()); }
            finally
            {
                System.Console.WriteLine("Закрываю Excel application...");
                _ExcelClient.Close();
                System.Console.WriteLine("Программа завершила работу, нажмите любую клавишу для выхода...");
                System.Console.ReadKey();
            }
        }
    }
}
