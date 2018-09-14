using ExcelDataReader;
using System;
using System.Data;
using System.IO;

namespace DocumentConverterService
{
    public sealed class DataSetProvider
         : IDataSetProvider
    {
        /// <summary>
        /// Generate a data set of all sheets of the given xlsx file
        /// </summary>
        /// <param name="filePath">The location of the file to be read</param>
        /// <returns>All sheets as DataSet</returns>
        public DataSet GetDataSet(string filePath)
        {
            if (Path.GetExtension(filePath).ToUpper() != ".XLSX")
            {
                throw new ArgumentOutOfRangeException("The file should be in xlsx format.");
            }

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