using CsvHelper.Configuration;
using System;
using System.Collections.Generic;

namespace DocumentConverterService
{
    public interface ICsvWriter
    {
        void WriteCsv<T>(IEnumerable<T> source, string outPutFilePath, Func<ClassMap<T>> mapFunc = null);
    }
}
