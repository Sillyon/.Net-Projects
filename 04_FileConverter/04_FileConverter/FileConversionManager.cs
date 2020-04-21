using _04_FileConverter.FileConverters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_FileConverter
{
    static class FileConversionManager
    {
        // fileConverterList<> holds of known IFileConverter objects.
        static List<IFileConverter> converters = new List<IFileConverter>
        {
            new Jpg2BmpConverter(),
            new Png2JpgConverter(),
            new Png2BmpConverter()
        };

        static List<string> fileTypes = new List<string>() { "png", "jpg", "bmp" };

        // a method for registering file converters.
        static void RegisterFileConveter(IFileConverter newConverter)
        {
            converters.Add(newConverter);
        }

        /// <summary> Main method of File Conversion Manager Class.
        /// Algorithms must choose png->bmp as "1 step" rather than png->jpg->bmp as "2 steps".
        /// </summary>
        /// <returns>converted output object.</returns>
        public static object Convert(object input, string inputFileFormat, string outputFileFormat)
        {
            // check of file formats are same.
            if (inputFileFormat.Equals(outputFileFormat))
            {
                throw new Exception("converter can not convert to same input format.");
            }
            // check of file formats have known formats. 
            if(!fileTypes.Contains(inputFileFormat)  || !fileTypes.Contains(outputFileFormat))
            {
                // if one of it has not found, throw exception.
                throw new Exception("file format(s) can not be found in fileConverterList.");
            }

            /* Description:
             * We will have unweighted and directed graph in huge FileConverterList.
             * To find shortest path from source to destination, we need to use modified Breadth-First Search.
             * In this sample case, i used FileConverterList as a directed graph like adjacency list representation.
             * after that; next steps are ALGORITHMS STEPS. */

            bool[] isVisited = new bool[fileTypes.Count];

            List<string> path = new List<string>();
            path.Add(inputFileFormat); // add source to path[]

            // pathlist stores list of paths that can reach from input to output.
            List<List<string>> pathList = new List<List<string>>();

            // Call a recursive function to find all paths from inputFileFormat to outputFileFormat.
            FindPaths(inputFileFormat, outputFileFormat, isVisited, path, pathList);

            if (pathList.Count == 0)
            {
                throw new Exception("requested conversion is not possible using the converters known to the manager.");
            }

            // finding possible paths is done. Next step is finding shortest path and apply convert process.
            int shortestPathIndex = 0;
            for (int i = 0; i < pathList.Count; i++)
            {
                if (pathList[i].Count < pathList[shortestPathIndex].Count)
                {
                    shortestPathIndex = i;
                }
            }

            // print paths with shortest path
            for (int i = 0; i < pathList.Count; i++)
            {
                Console.Write("Path {0} of conversion is\t",i);
                Console.WriteLine(string.Join(" -> ", pathList[i]));
            }
            Console.WriteLine("\nPath {0} is the shortest one.\t", shortestPathIndex);


            // finding shortest path is done. Last step is Apply Conversion Process.
            Console.WriteLine("\n\nConversion Process:\n");
            for(int i = 0; i < pathList[shortestPathIndex].Count - 1; i++)
            {
                // find appropriate converter
                foreach (var fileConverter in converters)
                {
                    if (fileConverter.InputFileFormat.Equals(pathList[shortestPathIndex][i]) && 
                        fileConverter.OutputFileFormat.Equals(pathList[shortestPathIndex][i + 1]))
                    {
                        // conversion step, returns output to our input object.
                        input = fileConverter.Convert(input);
                        Console.WriteLine("Step {0}: {1} to {2} conversion is done. Current object is: {3}", i,
                            pathList[shortestPathIndex][i], pathList[shortestPathIndex][i + 1], input);
                    }
                }
            }
            // finally our last input object is file output object.
            Console.WriteLine("\nFile Conversion SUCCESSFUL.");
            return input;
        }


        /// <param name="isVisited[]">keeps track of file types in current path.</param>
        /// <param name="localPath">stores actual file types in the current path.</param>
        /// <param name="pathList">stores all paths from input to output.</param>
        static void FindPaths(string source,
                              string destination,
                              bool[] isVisited,
                              List<string> localPath,
                              List<List<string>> pathList)
        {
            // Mark the current node
            isVisited[fileTypes.IndexOf(source)] = true;

            if (fileTypes.IndexOf(source).Equals(fileTypes.IndexOf(destination)))
            {
                // add path to pathlist
                pathList.Add(new List<string>(localPath));

                // if match found then no need to traverse more till depth
                isVisited[fileTypes.IndexOf(source)] = false;
                return;
            }

            // indexes are adjacent Item2 items to equals Item1 source item in fileConverterList.
            var indexes = converters.Select((t, i) => (t, i))
                                           .Where(x => x.t.InputFileFormat == source)
                                           .Select(y => y.i);
            // Recur for all the destinations adjacent to current source
            foreach (var index in indexes)
            {
                if (!isVisited[fileTypes.IndexOf(converters[index].OutputFileFormat)])
                {
                    // store current node in path[], that will be current source.
                    localPath.Add(converters[index].OutputFileFormat);

                    FindPaths(converters[index].OutputFileFormat, destination, isVisited, localPath, pathList);
                    // remove current node in path[]
                    localPath.Remove(converters[index].OutputFileFormat);
                }
            }
            // Mark the current node
            isVisited[fileTypes.IndexOf(source)] = false;
        }
    }
}