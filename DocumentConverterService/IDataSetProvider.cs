using System.Data;

namespace DocumentConverterService
{
   public interface IDataSetProvider
    {
        DataSet GetDataSet(string filePath);
    }
}
