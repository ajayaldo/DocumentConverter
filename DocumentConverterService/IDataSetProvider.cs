using System.Data;

namespace DocumentConverterService
{
    public interface IDataSetProvider
    {
        /// <summary>
        /// Generate a data set of all sheets of the given xlsx file
        /// </summary>
        /// <param name="filePath">The location of the file to be read</param>
        /// <returns>All sheets as DataSet</returns>
        DataSet GetDataSet(string filePath);
    }
}
