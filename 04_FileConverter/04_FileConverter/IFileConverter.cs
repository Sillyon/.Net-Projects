namespace _04_FileConverter
{
    /// <summary>
    /// Contains a converter.
    /// </summary>
    public interface IFileConverter
    {
        string InputFileFormat { get; }
        string OutputFileFormat { get; }
        object Convert(object input);
    }
}
