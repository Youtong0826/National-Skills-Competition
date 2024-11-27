
namespace 鄭宥紘_Q6
{
    public partial class Form1 : Form
    {
        private Bitmap SourceBitmap = new(1, 1);
        private Bitmap DestBitmap = new(1, 1);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new() { Filter = "All files (*.*)|*.*" };
            if (dialog.ShowDialog() != DialogResult.OK) return;
            SourceBitmap = new Bitmap(dialog.FileName);
            pictureBox1.Image = new Bitmap(SourceBitmap, pictureBox1.Size);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new() { Filter = "JPEG Image (*.jpg)|*.jpg|PNG Image (*.png)|*.png|Bitmap Image (*.bmp)|*.bmp|TIFF Image (*.tiff)|*.tiff" };
            if (dialog.ShowDialog() != DialogResult.OK) return;
            DestBitmap.Save(dialog.FileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DestBitmap = new(SourceBitmap);
            for (int y = 0; y < DestBitmap.Height; y++)
            {
                for (int x = 0; x < DestBitmap.Width; x++)
                {
                    Color pixel = DestBitmap.GetPixel(x, y);
                    int gray = (int)double.Round(0.3 * pixel.R + 0.59 * pixel.G + 0.11 * pixel.B, MidpointRounding.AwayFromZero);
                    Color newPixel = Color.FromArgb(gray, gray, gray);
                    DestBitmap.SetPixel(x, y, newPixel);
                }
            }
            pictureBox2.Image = new Bitmap(DestBitmap, pictureBox2.Size);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[][] grayArrayArray = Enumerable.Range(0, SourceBitmap.Height).Select(y => Enumerable.Range(0, SourceBitmap.Width).Select(x =>
            {
                Color pixel = SourceBitmap.GetPixel(x, y);
                int gray = (int)double.Round(0.3 * pixel.R + 0.59 * pixel.G + 0.11 * pixel.B, MidpointRounding.AwayFromZero);
                return gray;
            }
            ).ToArray()).ToArray();
            DestBitmap = new(SourceBitmap.Width - 2, SourceBitmap.Height - 2);
            for (int y = 0; y < DestBitmap.Height; y++)
            {
                for (int x = 0; x < DestBitmap.Width; x++)
                {
                    int[][] matrix = grayArrayArray[y..(y + 3)].Select(grayArray => grayArray[x..(x + 3)]).ToArray();
                    int gx = Gx(matrix);
                    int gy = Gy(matrix);
                    int g = (int)double.Min(double.Round(double.Sqrt(double.Pow(gx, 2) + double.Pow(gy, 2)), MidpointRounding.AwayFromZero), 255);
                    Color newPixel = Color.FromArgb(g, g, g);
                    DestBitmap.SetPixel(x, y, newPixel);
                }
            }
            pictureBox2.Image = new Bitmap(DestBitmap, pictureBox2.Size);
        }

        private static int Gx(int[][] matrix) => matrix.Zip(new int[][] { [-1, 0, 1], [-2, 0, 2], [-1, 0, 1] }, (aRow, bRow) => aRow.Zip(bRow, (a, b) => a * b).Sum()).Sum();

        private static int Gy(int[][] matrix) => matrix.Zip(new int[][] { [-1, -2, -1], [0, 0, 0], [1, 2, 1] }, (aRow, bRow) => aRow.Zip(bRow, (a, b) => a * b).Sum()).Sum();
    }
}