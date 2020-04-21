namespace _04_FileConverter.FileConverters
{
    /// <summary>
    /// Image of class of converter Jpg file to Bmp file.
    /// </summary>
    public class Jpg2BmpConverter : IFileConverter
    {
        public string InputFileFormat => "jpg";

        public string OutputFileFormat => "bmp";

        public object Convert(object input) => "this is a BMP file.";   // TODO ..
    }
}
