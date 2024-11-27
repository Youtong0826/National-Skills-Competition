namespace 鄭宥紘_Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] ints = textBox1.Text.Split(',').Where(s => s.Length > 0).Select(s => s.Trim()).Select(int.Parse).Reverse().ToArray();
            Fractional fractional = new(ints[0], 1);
            foreach (int n in ints[1..])
            {
                fractional = fractional.GetFlipped();
                fractional = fractional.Add(n);
            }
            textBox2.Text = $"{fractional}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }

    struct Fractional(int child, int parent)
    {
        public int Child = child / GetLcm(child, parent);
        public int Parent = parent / GetLcm(child, parent);

        public Fractional GetFlipped() => new(Parent, Child);

        public Fractional Add(int n) => new(Child + n * Parent, Parent);

        public override string ToString() => $"{Child} / {Parent}";

        private static int GetLcm(int a, int b)
        {
            int r = a % b;
            while (r != 0)
            {
                a = b;
                b = r;
                r = a % b;
            }
            return b;
        }
    }
}