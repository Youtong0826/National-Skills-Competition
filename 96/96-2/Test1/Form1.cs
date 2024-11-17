namespace Test1
{
    public partial class Form1 : Form
    {
        int ptr = 5, end = 1;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button[] btns = {
                new Button(),
                button1,
                button2,
                button3,
                button4,
                button5,
                button6,
            };

            bool flag = true;
            for (int i = 1; i <= 6; i++)
            {
                if (btns[i].Text != "")
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                textBox1.Text = "Can't remove anymore.";
                return;
            }

            textBox1.Text = $"removed {btns[ptr].Text}";
            btns[ptr].Text = "";
            ptr = ptr % 6 + 1;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Button[] btns = {
                new Button(),
                button1, 
                button2, 
                button3, 
                button4, 
                button5, 
                button6,
            };

            bool flag = true;
            for (int i = 1; i <= 6; i++)
            {
                
                if (btns[i].Text == "") {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                textBox1.Text = "Can't add anymore.";
                return;
            }

            int n = new Random().Next(1, 999);
            btns[end].Text = $"{n}";
            end = end % 6 + 1;
            textBox1.Text = $"Added {n}";
        }
    }
}