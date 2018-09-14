using System;
using System.Collections.Generic;
using System.Data;

namespace DocumentConverterService
{
    public interface IPocoGenerator
    {
        IEnumerable<T> GeneratePoco<T>(DataSet dataSet, Func<DataRow, T> creatorFunc, int tableIndex = 0);
    }
}
