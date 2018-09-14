using System.Data;
using System.Collections.Generic;
using System;

namespace DocumentConverterService
{
    public sealed class PocoGenerator
        : IPocoGenerator
    {
        public IEnumerable<T> GeneratePoco<T>(DataSet dataSet, Func<DataRow, T> creatorFunc, int tableIndex = 0)
        {
            var list = new List<T>();

            //Get column names
            var getColumneNames = dataSet.Tables[tableIndex].Rows[0].ItemArray;

            //Rename the column names in the dataset
            for (var i = 0; i < getColumneNames.Length; i++)
            {
                dataSet.Tables[tableIndex].Columns[i].ColumnName = getColumneNames[i].ToString();
            }

            //Remove the first row, which is the list of column names
            dataSet.Tables[tableIndex].Rows.RemoveAt(0);

            dataSet.AcceptChanges();

            foreach (DataRow item in dataSet.Tables[tableIndex].Rows)
            {
                list.Add(creatorFunc(item));
            }

            return list;
        }
    }
}
