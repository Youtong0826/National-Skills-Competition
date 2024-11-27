namespace 鄭宥紘_Q3
{
    static class Program
    {
        static void Main()
        {
            int[][] matrix = new object[3].Select(_ => new int[3]).ToArray();
            int x = 1;
            int y = 0;
            for (int i = 1; i <= 9; i++)
            {
                if (matrix[y][x] != 0)
                {
                    x--;
                    if (x == -1)
                    {
                        x = 2;
                    }
                    y += 2;
                    y %= 3;
                }
                matrix[y][x] = i;
                y--;
                if (y == -1)
                {
                    y = 2;
                }
                x++;
                x %= 3;
            }
            PrintMatrix(matrix);
            PrintMatrix(HorizontalFlip(matrix));
            PrintMatrix(VerticalFlip(matrix));
            PrintMatrix(VerticalFlip(HorizontalFlip(matrix)));
            PrintMatrix(Flip(matrix));
            PrintMatrix(HorizontalFlip(Flip(matrix)));
            PrintMatrix(VerticalFlip(Flip(matrix)));
            PrintMatrix(VerticalFlip(HorizontalFlip(Flip(matrix))));
            Console.ReadKey();
        }

        static int[][] HorizontalFlip(int[][] matrix) => matrix.Select(row => row.Reverse().ToArray()).ToArray();

        static int[][] VerticalFlip(int[][] matrix) => matrix.Reverse().ToArray();

        static int[][] Flip(int[][] matrix) => Enumerable.Range(0, 3).Select(i => matrix.Select(row => row[i]).ToArray()).ToArray();

        static void PrintMatrix(int[][] matrix)
        {
            foreach (int[] row in matrix)
            {
                Console.WriteLine(string.Join(' ', row));
            }
            Console.WriteLine();
        }
    }
}