using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace DocumentConverterService
{
    public sealed class CsvWriter
        : ICsvWriter
    {
        /// <summary>
        /// Writes the collection of a data in CSV to the given output file path.
        /// </summary>
        /// <typeparam name="T">The type of the data passed</typeparam>
        /// <param name="source">The data that need to be converted to CSV</param>
        /// <param name="outPutFilePath">The path to which the CSV file needs to stored</param>
        /// <param name="mapFunc">The map creator func for mapping registration of columns</param>
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
