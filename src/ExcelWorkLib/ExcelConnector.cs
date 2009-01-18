using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelWorkLib
{
    /// <summary>
    /// Класс работы с Excel. бета-версия.
    /// </summary>
    public class ExcelConnector
    {
        #region <fields>
        private Excel.Application _app;
        private Excel.Workbook _curworkbook;
        private Excel.Sheets _sheets;
        private Excel.Worksheet _CurrentWorksheet;
        private string _WorkbookFileName;
        #endregion

        #region <props>
        /// <summary>
        /// Имя открытой рабочей книги
        /// </summary>
        public string WorkbookFileName
        {
            get { return _WorkbookFileName; }
            //set { _WorkbookFileName = value; }
        }
        /// <summary>
        /// Текущий лист
        /// </summary>
        public Excel.Worksheet CurrentWorksheet
        {
            get { return _CurrentWorksheet; }
            //set { _CurrentWorksheet = value; }
        }
        /// <summary>
        /// Текущая рабочая книга
        /// </summary>
        public Excel.Workbook CurrentWorkbook
        {
            get { return _curworkbook; }
            //set { _CurrentWorksheet = value; }
        }
        #endregion

        #region <constructors>
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="isVisible"></param>
        public ExcelConnector(bool isVisible)
        {
            Start(isVisible);
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="isVisible"></param>
        /// <param name="filename"></param>
        /// <param name="CreateOrReplace">создать книгу(в т.ч. поверх существующей)</param>
        public ExcelConnector(bool isVisible, string filename, bool CreateOrReplace)
            : this(isVisible)
        {
            OpenExcelWorkBook(filename, CreateOrReplace);
            //SelectExcelWorkSheet(1);
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="isVisible"></param>
        /// <param name="filename"></param>
        /// <param name="CreateOrReplace">создать книгу(в т.ч. поверх существующей)</param>
        /// <param name="worksheetnum"></param>
        public ExcelConnector(bool isVisible, string filename, bool CreateOrReplace, int worksheetnum)
            : this(isVisible, filename, CreateOrReplace)
        {
            SelectExcelWorkSheet(worksheetnum);
        }

        #endregion
        /// <summary>
        /// Запустить Excel.Application
        /// </summary>
        public void Start(bool isVisible)
        {
            try
            {
                Close();
                _app = new Excel.Application();
                _app.Visible = isVisible;
                _app.DisplayAlerts = true;
                //_app.SheetsInNewWorkbook = 1;
                _app.DefaultSaveFormat = Excel.XlFileFormat.xlExcel9795;
            }
            catch (Exception ex) { throw new ExcelConnectorException("Start failed.\n", ex); } 
        }
        /// <summary>
        /// Выйти из Excel.Application
        /// </summary>
        public void Close()
        {
            if (_app != null)
            {
                //_curworkbook.Saved = true; //строчка прячет диалог о сохранении изменений, но выбираент вариант "нет"
                _app.Workbooks.Close();
                _app.Quit();
            }
        }

        /// <summary>
        /// по имени файла открыть книгу
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="CreateOrReplace">создать книгу(в т.ч. поверх существующей)</param>
        /// <returns></returns>
        public void OpenExcelWorkBook(string filename, bool CreateOrReplace)
        {
            try
            {
                _WorkbookFileName = filename;
                //Открываем книгу(файл) и получаем на нее ссылку          
                if (CreateOrReplace)
                {
                    _curworkbook = _app.Workbooks.Add(Type.Missing);
                    _curworkbook.SaveAs(filename, Excel.XlFileFormat.xlExcel9795, Type.Missing, Type.Missing, Type.Missing,
                       Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing);
                    //_curworkbook.ListChangesOnNewSheet = true;
                }
                else
                {
                    _curworkbook = _app.Workbooks.Open(filename,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing);
                }               
                _sheets = _curworkbook.Worksheets;
            }
            catch (Exception ex) { Close(); throw new ExcelConnectorException("OpenExcelWorkBook failed.\n", ex); }
        }
        /// <summary>
        /// выбрать лист текущей книги для работы
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public void SelectExcelWorkSheet(int num)
        {
            try
            {
                if (_curworkbook == null) throw new NullReferenceException("Workbook is null. Select workbook!");

                _CurrentWorksheet = (Excel.Worksheet)_sheets.get_Item(num);
            }
            catch (Exception ex) { Close(); throw new ExcelConnectorException("SelectExcelWorkSheet failed.\n", ex); }
        }

        /// <summary>
        /// получить массив RowCount ячеек столбца ColName, начиная с ячейки RowIndex
        /// </summary>
        /// <param name="ColIndex">название столбца</param>
        /// <param name="RowIndex">номер строки, с которой начинать копирование</param>
        /// <param name="RCount">кол-во возвращаемых ячеек, расположенных ниже RowIndex</param>
        /// <returns></returns>
        public Object[] GetCol(int ColIndex, int RowIndex, int Count)
        {
            if (_CurrentWorksheet == null) throw new NullReferenceException("Worksheet is null. Select worksheet!");
            Object[] sArr = new Object[Count];

            for (int i = 0; i < Count; i++)
            {
                sArr[i] = _CurrentWorksheet.Cells[RowIndex, ColIndex];            
            }
            return sArr;
        }

        /// <summary>
        /// получить массив RowCount ячеек столбца ColName, начиная с ячейки RowIndex.
        /// Значения ячеек преобразованы в строковый тип.
        /// </summary>
        /// <param name="ColIndex">название столбца</param>
        /// <param name="RowIndex">номер строки, с которой начинать копирование</param>
        /// <param name="Count">кол-во возвращаемых ячеек, расположенных ниже RowIndex</param>
        /// <returns></returns>
        public string[] GetColString(int ColIndex, int RowIndex, int Count)
        {
            string[] sArr = new string[Count];
            Object[] sObjArr = GetCol(ColIndex, RowIndex, Count);

            for (int i = 0; i < Count; i++)
            {
                sArr[i] = sObjArr.ToString();
            }
            return sArr;
        }

        public Object[] GetRow(int ColIndex, int RowIndex, int Count)
        {
            if (_CurrentWorksheet == null) throw new NullReferenceException("Worksheet is null. Select worksheet!");
            Object[] sArr = new Object[Count];

            for (int i = 0; i < Count; i++)
            {
                sArr[i] = _CurrentWorksheet.Cells[RowIndex, ColIndex];
            }
            return sArr;
        }

        public string[] GetRowString(int ColName, int RowIndex, int Count)
        {
            string[] sArr = new string[Count];
            Object[] sObjArr = GetRow(ColName, RowIndex, Count);

            for (int i = 0; i < Count; i++)
            {
                sArr[i] = sObjArr.ToString();
            }
            return sArr;
        }

        /// <summary>
        /// Получить значение ячейки
        /// </summary>
        /// <param name="RowIndex"></param>
        /// <param name="ColIndex"></param>
        /// <param name="NewValue"></param>
        public Object GetCellValue(int RowIndex, int ColIndex)
        {
            return ((Excel.Range)_CurrentWorksheet.Cells[RowIndex, ColIndex]).Value2;
        }

        /// <summary>
        /// Установить значение ячейки
        /// </summary>
        /// <param name="RowIndex"></param>
        /// <param name="ColIndex"></param>
        /// <param name="NewValue"></param>
        public void SetCellValue(int RowIndex, int ColIndex, Object NewValue)
        {
            //_CurrentWorksheet.get_Range(ColName + Convert.ToString(RowIndex), Type.Missing).Value2 = NewValue;
            _CurrentWorksheet.Cells[RowIndex, ColIndex] = NewValue;
        }
        /// <summary>
        /// Очистить значение ячейки
        /// </summary>
        /// <param name="RowIndex"></param>
        /// <param name="ColIndex"></param>
        public void ClearCellValue(int RowIndex, int ColIndex)
        {
            SetCellValue(RowIndex, ColIndex, null);
        }
        /// <summary>
        /// Запись двумерного массива в диапазон ячеек.
        /// </summary>
        /// <param name="ColName"></param>
        /// <param name="RowIndex"></param>
        /// <param name="dgv"></param>
        public void SetCellRange(int RowIndex, int ColIndex, string[][] arr)
        {
            try
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < arr[i].Length; j++)
                        SetCellValue(i + RowIndex, j + ColIndex, arr[i][j]);
                }
            }
            catch (Exception ex) { Close(); throw new ExcelConnectorException("SetCellRange failed.\n", ex); }
        }
        /// <summary>
        /// Получение диапазона ячеек в виде двухмерного массива строк.
        /// Диапазон исчисляется от верхней левой ячейки [ColName,RowIndex].
        /// Внимание: см. формат результата функции
        /// </summary>
        /// <param name="ColName"></param>
        /// <param name="RowIndex"></param>
        /// <param name="ColCount"></param>
        /// <param name="RowCount"></param>
        /// <returns>string[ColNum][RowNum]</returns>
        public string[][] GetCellRange(int RowIndex, int ColIndex, int RowCount, int ColCount)
        {
            string[][] arr = new string[RowCount][];
            Object buf;
            try
            {
                for (int i = 0; i < RowCount; i++)
                {
                    arr[i] = new string[ColCount];
                    for (int j = 0; j < ColCount; j++)
                    {
                        buf = GetCellValue(i + RowIndex, ColIndex + j);
                        if (buf == null) break;
                        arr[i][j] = buf.ToString();
                    }
                }
                return arr;
            }
            catch (Exception ex) { Close(); throw new ExcelConnectorException("GetCellRange failed.\n", ex); }
        }
        public string[][] GetNotEmptyCellRange(int RowIndex, int ColIndex)
        {
            string[][] arr = new string[0][];
            Object buf = null;
            try
            {
                for (int i = 0; ; i++)
                {
                    if ((GetCellValue(i + RowIndex, ColIndex)) == null)
                        break;
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[i] = new string[0];
                    for (int j = 0; ; j++)
                    {
                        buf = GetCellValue(i + RowIndex, ColIndex + j);
                        if (buf != null)
                        {
                            Array.Resize(ref arr[i], arr[i].Length + 1);
                            arr[i][j] = buf.ToString();
                        }
                        else break;
                    }                           
                }
                return arr;
            }
            catch (Exception ex) { Close(); throw new ExcelConnectorException("GetCellRange failed.\n", ex); }
        }
        /// <summary>
        /// Очистка диапазона ячеек
        /// </summary>
        /// <param name="ColName"></param>
        /// <param name="RowIndex"></param>
        /// <param name="ColCount"></param>
        /// <param name="RowCount"></param>
        public void ClearCellRange(int RowIndex, int ColIndex, int RowCount, int ColCount)
        {
            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColCount; j++)
                    ClearCellValue(RowIndex + i, ColIndex + j);
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
            try
            {
                Excel.Range FromRange = _CurrentWorksheet.get_Range(FromRangeStartsCellName, FromRangeEndsCellName);
                //получим ячейку - левый верхний край области для копирования
                Excel.Range ToRange = _CurrentWorksheet.get_Range(ToRangeStartsCellName, Type.Missing);
                for (int i = 0; i < FromRange.Columns.Count; i++)
                {
                    for (int j = 0; j < FromRange.Rows.Count; j++)
                    {
                        ToRange.Cells[j + 1, i + 1] = FromRange.Cells[j + 1, i + 1];
                    }
                }
            }
            catch (Exception ex) { Close(); throw new ExcelConnectorException("CopyRange failed.\n", ex); }

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
            //очистка FromRange 
            Excel.Range FromRange = _CurrentWorksheet.get_Range(FromRangeStartsCellName, FromRangeEndsCellName);
            FromRange.Clear();
        }
        ///// <summary>
        ///// Удалить строки из текущего листа
        ///// </summary>
        ///// <param name="RowIndex"></param>
        ///// <param name="RowCount"></param>
        //public void DeleteRows(int RowIndex, int RowCount)
        //{

        //}
        
    }

    /// <summary>
    /// Исключение работы класса ExcelConnector
    /// </summary>
    public class ExcelConnectorException : Exception
    {
        public override String Message { get { return msg; } }
        private string msg = "Внутренняя ошибка класса работы с Microsoft.Excel.\n";

        public ExcelConnectorException()
            : base()
        {

        }

        public ExcelConnectorException(string message)
            : base(message)
        {
            this.msg += message;
        }

        public ExcelConnectorException(string message, Exception InnerException)
            : base(message, InnerException)
        {
            this.msg += message;
        }
    }
}
