using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelConnector
{
    class ExcelConnector
    {
        private Excel.Application _app;
        private Excel.Workbook _workbook;
        private Excel.Sheets _sheets;
        private Excel.Worksheet _CurrentWorksheet;
        private string _WorkbookFileName;

        public Excel.Worksheet CurrentWorksheet
        {
            get { return _CurrentWorksheet; }
            //set { _CurrentWorksheet = value; }
        }

        public ExcelConnector(bool isVisible)
        {
            Restart(isVisible);
        }

        /// <summary>
        /// Запустить Excel.Application
        /// </summary>
        public void Restart(bool isVisible)
        {
            try
            {
                Close();
            }
            catch { }
            _app = new Excel.Application();
            _app.Visible = isVisible;
        }

        /// <summary>
        /// по имени файла открыть книгу
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public Excel.Workbook OpenExcelWorkBook(string filename)
        {
            _WorkbookFileName = filename;
            //Открываем книгу(файл) и получаем на нее ссылку
            _workbook = _app.Workbooks.Open(filename,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);
            _sheets = _workbook.Worksheets;
            return _workbook;
        }

        /// <summary>
        /// выбрать лист текущей книги для работы
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public Excel.Worksheet SelectExcelWorkSheet(int num)
        {
            if (_workbook == null) throw new NullReferenceException("Workbook is null. Select workbook!");

            _CurrentWorksheet = (Excel.Worksheet)_sheets.get_Item(num);
            return _CurrentWorksheet;
        }

        /// <summary>
        /// получить массив строк из выбранного листа
        /// </summary>
        /// <param name="col">название столбца</param>
        /// <param name="RowIndex">номер строки, с которой начинать копирование</param>
        /// <param name="RowCount">кол-во строк</param>
        /// <returns></returns>
        public string[] GetCol(string ColName, int RowIndex, int RowCount)
        {
            if (_CurrentWorksheet == null) throw new NullReferenceException("Worksheet is null. Select worksheet!");
            string[] sArr = new string[RowCount];

            for (int i = 0; i < RowCount; i++)
            {
                //try
                //{
                sArr[i] = (_CurrentWorksheet.get_Range(ColName + Convert.ToString(RowIndex + i + 1), Type.Missing)).Value2.ToString();
                //}
                //catch (Exception e)
                //{
                //    System.Console.WriteLine(e.ToString());
                //}
            }
            return sArr;
        }

        /// <summary>
        /// Установить значение ячейки
        /// </summary>
        /// <param name="ColName"></param>
        /// <param name="RowIndex"></param>
        /// <param name="NewValue"></param>
        public void SetCellValue(string ColName, int RowIndex, string NewValue)
        {
            _CurrentWorksheet.get_Range(ColName + Convert.ToString(RowIndex), Type.Missing).Value2 = NewValue;
        }

        //public void SetCellValue(int ColIndex, int RowIndex, string NewValue)
        //{
        //    _CurrentWorksheet.get_Range(Convert.ToString(ColIndex) + Convert.ToString(RowIndex), Type.Missing).Value2 = NewValue;
        //}

        public void ClearCellValue(string ColName, int RowIndex)
        {
            SetCellValue(ColName, RowIndex, "");
        }

        /// <summary>
        /// Копировать значения диапазона ячеек с FromRangeStartsCellName до FromRangeEndsCellName
        /// в область, начинающуюся с ячейки ToRangeStartsCellName
        /// </summary>
        /// <param name="FromRangeStartsCellName"></param>
        /// <param name="FromRangeEndsCellName"></param>
        /// <param name="ToRangeStartsCellName"></param>
        public void CopyRange(string FromRangeStartsCellName, string FromRangeEndsCellName, string ToRangeStartsCellName)
        {
            Excel.Range FromRange = _CurrentWorksheet.get_Range(FromRangeStartsCellName, FromRangeEndsCellName);
            //получим ячейку - левый верхний край области для копирования
            Excel.Range ToRange = _CurrentWorksheet.get_Range(ToRangeStartsCellName, Type.Missing);
            for (int i = 0; i < FromRange.Columns.Count + 1; i++)
            {
                for (int j = 0; j < FromRange.Rows.Count + 1; j++)
                {
                    (ToRange.get_Offset(j - 1, i - 1)).Value2 = ((Excel.Range)FromRange.Cells[j, i]).Value2;
                }
            }

        }
        /// <summary>
        /// Вырезать значения диапазона ячеек с FromRangeStartsCellName до FromRangeEndsCellName
        /// и вставить в область, начинающуюся с ячейки ToRangeStartsCellName
        /// </summary>
        /// <param name="FromRangeStartsCellName"></param>
        /// <param name="FromRangeEndsCellName"></param>
        /// <param name="ToRangeStartsCellName"></param>
        public void CutNPasteRange(string FromRangeStartsCellName, string FromRangeEndsCellName, string ToRangeStartsCellName)
        {
            CopyRange(FromRangeStartsCellName, FromRangeEndsCellName, ToRangeStartsCellName);
            //дописать очистку FromRange 
            Excel.Range FromRange = _CurrentWorksheet.get_Range(FromRangeStartsCellName, FromRangeEndsCellName);
            FromRange.Clear();
        }

        public void DeleteRows(int RowIndex, int RowCount)
        {

        }

        /// <summary>
        /// Выйти из Excel.Application
        /// </summary>
        public void Close()
        {
            if (_workbook != null)
                _workbook.Close(true, Type.Missing, Type.Missing);
            if (_app != null)
                _app.Quit();
        }
    }
}
