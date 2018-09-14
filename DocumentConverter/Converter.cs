using DocumentConverterService;
using DocumentConverterService.Model;
using CsvHelper;
using CsvHelper.Configuration;

namespace DocumentConverter
{
    internal sealed class Converter
        : IConverter
    {
        public IDataSetProvider DataSetProvider { get; }
        public IPocoGenerator PocoGenerator { get; }
        public ICsvWriter CsvWriter { get; }

        public Converter(IDataSetProvider dataSetProvider, IPocoGenerator pocoGenerator, ICsvWriter csvWriter)
        {
            DataSetProvider = dataSetProvider;
            PocoGenerator = pocoGenerator;
            CsvWriter = csvWriter;
        }

        public void Execute(string inputFilePath, string OutputFilePath)
        {
            var dataSet = DataSetProvider.GetDataSet(inputFilePath);

            var skbData = PocoGenerator.GeneratePoco(dataSet, data => new SkbData(data));

            //The Map values should be in the order we desire
            ClassMap<SkbData> classMapFun() => new Factory()
                .CreateClassMapBuilder<SkbData>()
                .Map(m => m.UserId).Name("User ID")
                .Map(m => m.Height).Name("Height")
                .Map(m => m.Age).Name("Age")
                .Map(m => m.PrimaryScore).Name("Primary Score")
                .Map(m => m.SecondaryScore).Name("Secondary Score")
                .Build();

            CsvWriter.WriteCsv(skbData, OutputFilePath, classMapFun);
        }
    }
}
