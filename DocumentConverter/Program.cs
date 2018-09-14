using Autofac;
using System;
using System.IO;

namespace DocumentConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter A for InputFileA or B for InputFileB");
                    string option = Console.ReadLine();

                    string filePath = "";

                    switch (option.ToUpper())
                    {
                        case "A":
                            filePath = $"{Directory.GetCurrentDirectory()} {"/data/"}{"InputFileA.xlsx"}";
                            break;
                        case "B":
                            filePath = $"{Directory.GetCurrentDirectory()} {"/data/"}{"InputFileb.xlsx"}";
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(filePath))
                    {
                        var randomFileName = $"{"OutPutFile-"}{DateTime.Now:yyyy-MM-dd_hh-mm-ss-fff}{".csv"}";
                        var outPutFilePath = $"{Directory.GetCurrentDirectory()} {"/data/"}{randomFileName}";

                        //Configure and build IOC container
                        IContainer container = IocBuilder.ConfigureIoc();

                        var converter = container.Resolve<IConverter>();
                        converter.Execute(filePath, outPutFilePath);

                        Console.WriteLine($"File stored successfully at {outPutFilePath}");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid option or filepath");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error Occurred while processing file. Error {e.Message} ");
                }
            }
        }
    }
}
