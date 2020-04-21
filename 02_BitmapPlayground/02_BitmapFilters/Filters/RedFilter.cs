using System.Drawing;
using System.Threading;

namespace _02_BitmapFilters.Filters
{
    /// <summary>
    /// Filters the red component from an image.
    /// </summary>
    public class RedFilter : IFilter
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
                result[x, y] = Color.FromArgb(p.A, 0, p.G, p.B);
            }

            return result;
        }

        public string Name => "Filter red component";

        public override string ToString()
            => Name;
    }
}
