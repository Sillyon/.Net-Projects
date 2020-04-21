using System.Drawing;
using System.Threading;

namespace _02_BitmapFilters.Filters
{
    /// <summary>
    /// Computes grayscale from an image.
    /// </summary>
    public class GrayscaleFilter : IFilter
    {
        public Color[,] Apply(Color[,] input)
        {
            int width = input.GetLength(0);
            int height = input.GetLength(1);
            Color[,] result = new Color[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int tempX = x;
                    int tempY = y;
                    // using thread pooling
                    ThreadPool.QueueUserWorkItem((state) => Work(tempX, tempY));
                }
            }

            void Work(int x, int y)
            {
                var p = input[x, y];
                // Grayscale means average of RGB values of pixel.
                int avg = (p.R + p.G + p.B) / 3;
                result[x, y] = Color.FromArgb(p.A, avg, avg, avg);
            }

            return result;
        }

        public string Name => "Grayscale filter";

        // override project path from filter name as given above.
        public override string ToString()
            => Name;
    }
}
