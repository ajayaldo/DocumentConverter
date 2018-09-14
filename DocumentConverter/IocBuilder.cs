using Autofac;
using DocumentConverterService;

namespace DocumentConverter
{
    public static class IocBuilder
    {
        public static IContainer ConfigureIoc()
        {
            var builder = new ContainerBuilder();

            //Register the the types
            builder.RegisterType<PocoGenerator>().As<IPocoGenerator>();
            builder.RegisterType<DataSetProvider>().As<IDataSetProvider>();
            builder.RegisterType<CsvWriter>().As<ICsvWriter>();
            builder.RegisterType<Converter>().As<IConverter>();

            return builder.Build();
        }
    }
}
