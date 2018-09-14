using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace DocumentConverterService
{
    public sealed class CsvWriter
        : ICsvWriter
    {
        public void WriteCsv<T>(IEnumerable<T> source, string outPutFilePath, Func<ClassMap<T>> mapFunc = null)
        {
            using (StreamWriter sw = new StreamWriter(outPutFilePath))
            {
                using (var writer = new CsvHelper.CsvWriter(sw))
                {
                    if (mapFunc != null)
                    {
                        writer.Configuration.RegisterClassMap(mapFunc());
                    }

                    writer.WriteRecords(source);
                }
            }
        }
    }
}
