using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _91_1
{
    public partial class Form1 : Form
    {
        Button[,] buttons = new Button[9, 9];
        int s1, s2, t1, t2;
        public Form1()
        {
            InitializeComponent();

            buttons = new Button[,] { 
                {button1, button2, button3, button4, button5, button6, button7, button8, button9},
                {button18, button17, button16,  button15, button14, button13, button12, button11, button10},
                {button36, button35, button34,  button33, button32, button31, button30, button29, button28},
                {button27, button26, button25,  button24, button23, button22, button21, button20, button19},
                {button72, button71, button70,  button69, button68, button67, button66, button65, button64},
                {button63, button62, button61,  button60, button59, button58, button57, button56, button55},
                {button54, button53, button52,  button51, button50, button49, button48, button47, button46},
                {button45, button44, button43,  button42, button41, button40, button39, button38, button37},
                {button81, button80, button79,  button78, button77, button76, button75, button74, button73},
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void clear()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    buttons[i, j].BackColor = Color.White;
                    buttons[i, j].Text = "";
                }
            }
        }

        private void add_obs_Click(object sender, EventArgs e)
        {
            clear();
            int n = Convert.ToInt16(textBox1.Text);
            Random rnd = new Random();

            while (n > 0){
                int r = rnd.Next(81);
                if (buttons[r / 9, r % 9].BackColor == Color.White)
                {
                    buttons[r / 9, r % 9].BackColor = Color.Black;
                    n -= 1;
                }
            }
        }

        private void button82_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button83_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool inl(int x, int y)
        {
            return x >= 0 && y >= 0 && x < 9 && y < 9;
        }

        private void add_st_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    buttons[i, j].Text = "";
                    if (buttons[i, j].BackColor == Color.Gray)
                        buttons[i, j].BackColor = Color.White;
                }
            }
            bool[,] vis = new bool[9, 9];
            Random rnd = new Random();
            while (true)
            {
                int r = rnd.Next(81);
                if (!vis[r / 9, r % 9] && buttons[r/9, r % 9].BackColor == Color.White)
                {
                    Button btn = buttons[r / 9, r % 9];
                    btn.Font = new Font(btn.Font.FontFamily, 12);
                    btn.Text = "T"; 
                    vis[r / 9, r % 9] = true;
                    t1 = r / 9;
                    t2 = r % 9;
                    break;
                }
                else
                {
                    vis[r / 9, r % 9] = true;
                }
            }

            while (true)
            {
                int r = rnd.Next(81);
                if (!vis[r / 9, r % 9] && buttons[r / 9, r % 9].BackColor == Color.White)
                {
                    Button btn = buttons[r / 9, r % 9];
                    btn.Font = new Font(btn.Font.FontFamily, 12);
                    btn.Text = "S";
                    vis[r / 9, r % 9] = true;
                    s1 = r / 9;
                    s2 = r % 9;
                    break;
                }
                else
                {
                    vis[r / 9, r % 9] = true;
                }
            }
        }

        private void find_st_Click(object sender, EventArgs e)
        {
            
            int[,] dis = {{0, 1}, {1, 0}, {0, -1}, {-1, 0}};
            bool[,] vis = new bool[9, 9]; 
            Tuple<int, int>[,] from = new Tuple<int, int>[9, 9];
            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
            q.Enqueue(Tuple.Create(s1, s2));
            vis[s1, s2] = true;
            while (q.Count > 0)
            {
                (int tx, int ty) = q.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int x = tx+dis[i, 0], y = ty+dis[i, 1];
                    if (inl(x, y) && !vis[x, y] && buttons[x, y].BackColor != Color.Black)
                    {
                        vis[x, y] = true;
                        from[x, y] = Tuple.Create(tx, ty);
                        if (x == t1 && y == t2)
                            break;
                        q.Enqueue(Tuple.Create(x, y));
                    }
                }
            }

            int dx = t1, dy = t2;
            var s = Tuple.Create(s1, s2);

            Console.WriteLine(s);
            Console.WriteLine(Tuple.Create(t1, t2));

            if (from[dx, dy] == null)
            {
                MessageBox.Show("無法到達目的地");
                return;
            }

            while (from[dx, dy].Item1 != s.Item1 || from[dx, dy].Item2 != s.Item2)
            {
                buttons[dx, dy].BackColor = Color.Gray;
                Console.WriteLine(from[dx, dy]);
                (int x, int y) = from[dx, dy];
                dx = x; dy = y;
            }
            buttons[dx, dy].BackColor = Color.Gray;
            buttons[s1, s2].BackColor = Color.Gray;
        }
    }
}
