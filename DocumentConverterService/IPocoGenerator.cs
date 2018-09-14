using System;
using System.Collections.Generic;
using System.Data;

namespace DocumentConverterService
{
    public interface IPocoGenerator
    {
        /// <summary>
        /// Generates a collection of POCO class from given data set.
        /// </summary>
        /// <typeparam name="T">The type of the files in the dataset</typeparam>
        /// <param name="dataSet">The dataset which needs to be converted to the specified type</param>
        /// <param name="creatorFunc">POCO class creator func</param>
        /// <param name="tableIndex">The index of the tables which needs to processed from the data set</param>
        /// <returns>A collection of the specified type</returns>
        IEnumerable<T> GeneratePoco<T>(DataSet dataSet, Func<DataRow, T> creatorFunc, int tableIndex = 0);
    }
}
