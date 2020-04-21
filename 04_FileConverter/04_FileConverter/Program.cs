using System;

/// <author>Fatih Çomak</author>
/// <date>16.04.2020</date>
/// <time>07:55 (GMT+3)</time>

namespace _04_FileConverter
{
    class Program
    {
        /* Please enter command line parameters from:
         * Right click on the project name -> go to Properties -> go to "Debugging" -> "Command-line arguments"
         * There are already arguments as "png bmp" args[] for first use.
         */
        static void Main(string[] args)
        {
            // parameter check
            if (args == null || args.Length != 2)
            {
                Console.WriteLine("Please provide these parameters (without brackets):");
                Console.WriteLine("<inputFileFormat> <outputFileFormat>");
                Console.ReadKey();
                return;
            }

            // default input file object as only for workability.
            object input = "this is a PNG file.";

            Console.WriteLine("Before Conversion, object is: {0}\n",input);

            // Call the main method of conversion manager. Convert() method returns output file object.
            object output = FileConversionManager.Convert(input, args[0].ToLower(), args[1].ToLower());

            Console.WriteLine("\nAfter Conversion, object is: " + output);
            Console.ReadKey();
        }
    }
}
