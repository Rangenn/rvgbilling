using System;
using System.Collections.Generic;
using System.Text;

namespace RVGlib.Import
{
    class TableData
    {
        protected string[][] data;

        public TableData()
        {
            data = new string[0][];
        }

        public void AddRow(string[] row)
        {
            Array.Resize(ref data, data.Length + 1);
            data[data.Length - 1] = row;
        }


        public void Print()
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    Console.Write(data[i][j]);
                    Console.Write('|');
                }
                Console.WriteLine();
            }
        }
    }
}
