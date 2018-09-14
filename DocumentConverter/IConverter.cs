namespace DocumentConverter
{
    internal interface IConverter
    {
        void Execute(string inputFilePath, string OutputFilePath);
    }
}