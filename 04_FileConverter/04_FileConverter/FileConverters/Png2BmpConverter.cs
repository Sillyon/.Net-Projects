namespace _04_FileConverter.FileConverters
{
    /// <summary>
    /// Image of class of converter Png file to Jpg file.
    /// </summary>
    public class Png2BmpConverter : IFileConverter
    {
        public string InputFileFormat => "png";

        public string OutputFileFormat => "bmp";

        public object Convert(object input) => "this is a BMP file.";   // TODO ..
    }
}
