using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RVGBilling.Import
{
    /// <summary>
    /// Интерфейс для экспорта/импорта в файл
    /// </summary>
    interface ITransmitter
    {
        /// <summary>
        /// Импортирование из файла в массив строк
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <returns>Двумерный массив строк</returns>
        string[][] Import(string filename);

        /// <summary>
        /// Экспортирование из массива строк в файл
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <param name="data">Двумерный массив строк</param>
        void Export(string filename, string[][] data);
    }
}
