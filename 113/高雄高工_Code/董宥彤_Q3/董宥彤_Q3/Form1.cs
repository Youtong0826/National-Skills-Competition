using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 董宥彤_Q3
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void draw(Button[,,] btns, int idx, int[,] mp)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    btns[idx, i, j].Text = $"{mp[i, j]}";
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Button[,,] btns = new Button[8, 3, 3] {
                {{button1, button2, button3 }, {button4, button5, button6 }, {button7, button8, button9 } },
                {{button10, button11, button12 }, {button13, button14, button15 }, {button16, button17, button18 } },
                {{button19, button20, button21 }, {button22, button23, button24 }, {button25, button26, button27 } },
                {{button28, button29, button30 }, {button31, button32, button33 }, {button34, button35, button36 } },
                {{button37, button38, button39 }, {button40, button41, button42 }, {button43, button44, button45 } },
                {{button46, button47, button48 }, {button49, button50, button51 }, {button52, button53, button54 } },
                {{button55, button56, button57 }, {button58, button59, button60 }, {button61, button62, button63 } },
                {{button64, button65, button66 }, {button67, button68, button69 }, {button70, button71, button72 } },
            };
            int[,] mp = new int[3 , 3] {
                {-1, -1, -1 },
                { -1, -1, -1},
                { -1, -1, -1}
            };
            int num = 1, sx = 0, sy = 1;
            mp[0, 1] = num;
            btns[0, 0, 1].Text="1";
            while (num < 9)
            {
                num++;
                int rx = sx, ry = sy;
                sx--; sy++;

            check:
                if ((sx < 0 && sy < 0)) {
                    sx = rx+1;
                    sy = ry;
                };
                if (sx < 0)
                {
                    sx = 2;
                }
                if (sy > 2)
                {
                    sy = 0;
                }
 
                if (mp[sx, sy] != -1)
                { 
                    sx = rx+1;
                    sy = ry;
                    goto check;
                }
                mp[sx, sy] = num;
                btns[0, sx, sy].Text = $"{num}";
            }

            int[,] temp = new int[3, 3], temp3 = new int[3, 3];
            for (int i = 0; i < 3; i++) for (int j = 0; j < 3; j++) temp[i, j] = mp[i, j];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    mp[i, j] = temp[i, 3 - j - 1];
                    mp[i, 3 - j - 1] = temp[i, j];
                }
            }

            draw(btns, 1, mp);
            for (int i = 0; i < 3; i++) for (int j = 0; j < 3; j++) {temp3[i, j] = mp[i, j]; mp[i, j] = temp[i, j]; }
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    mp[i, j] = temp[3 - i - 1, j];
                    mp[3 - i - 1, j] = temp[i, j];
                }
            }
            
            draw(btns, 2, mp);
            int[,] temp2 = new int[3, 3];
            for (int i = 0; i < 3; i++) for (int j = 0; j < 3; j++) temp2[i, j] = mp[i, j];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    mp[i, j] = temp2[i, 3 - j - 1];
                    mp[i, 3 - j - 1] = temp2[i, j];
                }
            }
            draw(btns, 3, mp);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    mp[i, j] = temp3[j, 3 - i - 1];
                    // mp[3 - j - 1, i] = temp3[i, j];
                }
            }
            draw(btns, 4, mp);
            for (int i = 0; i < 3; i++) for (int j = 0; j < 3; j++) temp[i, j] = mp[i, j];
            var t = mp[1, 0];
            mp[1, 0] = mp[1, 2];
            mp[1, 2] = t;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    mp[i, j] = temp[i, 3 - j - 1];
                    mp[i, 3 - j - 1] = temp[i, j];
                }
            }
            draw(btns, 5, mp);
            for (int i = 0; i < 3; i++) for (int j = 0; j < 3; j++) temp2[i, j] = mp[i, j];
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    mp[i, j] = temp2[3 - i - 1, j];
                    mp[3 - i - 1, j] = temp2[i, j];
                }
            }
            draw(btns, 7, mp);
            
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    mp[i, j] = temp[3 - i - 1, j];
                    mp[3 - i - 1, j] = temp[i, j];
                }
            }
            
            t = mp[1, 0];
            mp[1, 0] = mp[1, 2];
            mp[1, 2] = t;

            draw(btns, 6, mp);
        }
    }
}
