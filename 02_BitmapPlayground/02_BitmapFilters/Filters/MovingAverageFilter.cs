using System.Drawing;
using System.Threading;

namespace _02_BitmapFilters.Filters
{
    /// <summary>
    /// Computes grayscale from an image.
    /// </summary>
    public class MovingAverageFilter : IFilter
    {
        public Color[,] Apply(Color[,] input)
        {
            int width = input.GetLength(0);
            int height = input.GetLength(1);
            Color[,] result = new Color[width, height];

            /* for-loops starts with (0+1), until (size-1). Because;
             * If the input pixel lies at the border, its value may remain the same.
             */
            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    int tempX = x;
                    int tempY = y;
                    // using thread pooling
                    ThreadPool.QueueUserWorkItem((state) => Work(tempX, tempY));
                }
            }

            void Work(int x, int y)
            {
                // Moving Average means average of RGB values of left,right,above,below and center pixels.
                var p = input[x, y];
                var pLeft = input[x - 1, y];    // left  pixel
                var pRight = input[x + 1, y];   // right pixel
                var pAbove = input[x, y - 1];   // above pixel
                var pBelow = input[x, y + 1];   // below pixel

                // Calculate average of Red, Green and Blue component of pixels.
                int avgRed = (p.R + pLeft.R + pRight.R + pAbove.R + pBelow.R) / 5;
                int avgGreen = (p.G + pLeft.G + pRight.G + pAbove.G + pBelow.G) / 5;
                int avgBlue = (p.B + pLeft.B + pRight.B + pAbove.B + pBelow.B) / 5;

                result[x, y] = Color.FromArgb(p.A, avgRed, avgGreen, avgBlue);
            }

            return result;
        }

        public string Name => "Moving average filter";

        // override project path from filter name as given above.
        public override string ToString()
            => Name;
    }
}
