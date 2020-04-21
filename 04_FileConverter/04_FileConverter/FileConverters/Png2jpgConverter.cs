namespace _04_FileConverter.FileConverters
{
    /// <summary>
    /// Image of class of converter Png file to Jpg file.
    /// </summary>
    public class Png2JpgConverter : IFileConverter
    {
        public string InputFileFormat => "png";

        public string OutputFileFormat => "jpg";

        public object Convert(object input) => "this is a JPG file.";   // TODO ...
    }
}
