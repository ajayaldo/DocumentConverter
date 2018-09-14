using ExcelDataReader;
using System.Data;
using System.IO;

namespace DocumentConverterService
{
    public sealed class DataSetProvider
         : IDataSetProvider
    {
        //The dispose methodsa are called after the return statement but before the exit of the function.
        public DataSet GetDataSet(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Reading *.xlsx file
                using (IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                {
                    // DataSet - The result of each spreadsheet will be created in the result.Tables
                    return excelReader.AsDataSet();
                }
            }

        }
    }
}