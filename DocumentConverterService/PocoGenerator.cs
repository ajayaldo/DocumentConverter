using System.Data;
using System.Collections.Generic;
using System;

namespace DocumentConverterService
{
    public sealed class PocoGenerator
        : IPocoGenerator
    {
        /// <summary>
        /// Generates a collection of POCO class from given data set.
        /// </summary>
        /// <typeparam name="T">The type of the files in the dataset</typeparam>
        /// <param name="dataSet">The dataset which needs to be converted to the specified type</param>
        /// <param name="creatorFunc">POCO class creator func</param>
        /// <param name="tableIndex">The index of the tables which needs to processed from the data set</param>
        /// <returns>A collection of the specified type</returns>
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
