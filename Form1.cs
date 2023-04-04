using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoxChiken
{
    public partial class Form1 : Form
    {
        //переменные
        Cells[,] square = new Cells[7, 7];
        public int i, j, oldi, oldj;
        public int fox1i,fox1j,fox2i,fox2j; 
        bool move;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Start();
        }



        //Класс ячейка
        public class Cells
        {
            public Button butt;
            public int status;//0-not exist
                              //1-empty
                              //2-fox
                              //3-chicken
            
            public Cells(Button newbutt, int st)
            {
                butt = newbutt;
                status = st;
            }
            public Cells(int st)
            {
                status = st;
            }
            
        }
        public void Start()
        {
            
            square[0, 0] = new Cells(0);
            square[0, 1] = new Cells(0);
            square[0, 2] = new Cells(button7, 1);
            square[0, 3] = new Cells(button14, 3);
            square[0, 4] = new Cells(button21, 3);
            square[0, 5] = new Cells(0);
            square[0, 6] = new Cells(0);

            square[1, 0] = new Cells(0);
            square[1, 1] = new Cells(0);
            square[1, 2] = new Cells(button8, 1);
            square[1, 3] = new Cells(button15,3);
            square[1, 4] = new Cells(button22,3);
            square[1, 5] = new Cells(0);
            square[1, 6] = new Cells(0);

            square[2, 0] = new Cells(button1, 1);
            square[2, 1] = new Cells(button4, 1);
            square[2, 2] = new Cells(button9, 2);////fox
            square[2, 3] = new Cells(button16,3);
            square[2, 4] = new Cells(button23,3);
            square[2, 5] = new Cells(button28,3);
            square[2, 6] = new Cells(button31,3);

            square[3, 0] = new Cells(button2, 1);
            square[3, 1] = new Cells(button5, 1);
            square[3, 2] = new Cells(button10,1);
            square[3, 3] = new Cells(button17,3);
            square[3, 4] = new Cells(button24,3);
            square[3, 5] = new Cells(button29,3);
            square[3, 6] = new Cells(button32,3);

            square[4, 0] = new Cells(button3, 1);
            square[4, 1] = new Cells(button6, 1);
            square[4, 2] = new Cells(button11, 2);///////fox
            square[4, 3] = new Cells(button18, 3);
            square[4, 4] = new Cells(button25, 3);
            square[4, 5] = new Cells(button30, 3);
            square[4, 6] = new Cells(button33, 3);

            square[5, 0] = new Cells(0);
            square[5, 1] = new Cells(0);
            square[5, 2] = new Cells(button12, 1);
            square[5, 3] = new Cells(button19, 3);
            square[5, 4] = new Cells(button26, 3);
            square[5, 5] = new Cells(0);
            square[5, 6] = new Cells(0);

            square[6, 0] = new Cells(0);
            square[6, 1] = new Cells(0);
            square[6, 2] = new Cells(button13, 1);
            square[6, 3] = new Cells(button20, 3);
            square[6, 4] = new Cells(button27, 3);
            square[6, 5] = new Cells(0);
            square[6, 6] = new Cells(0);
            Draw();
        }
        
        //ход курицы
        public void Move()
        {
            if(square[i,j].status==1 && square[oldi, oldj].status == 3 && ((i==oldi & j-oldj==-1)||(j == oldj & Math.Abs(i - oldi) == 1)))
            {
                square[i, j].status = 3;
                square[oldi, oldj].status = 1;
                move = false;
                ChooseFox();
                Draw();
                EndGame();
            }
        }
        

        //отрисовка всех элементов
        void Draw()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            bool onefox = false;
            int chicken_count = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    
                    if (square[i, j].status == 1)
                    {
                        square[i, j].butt.Image = null;
                        
                    }

                    if (square[i, j].status == 2)
                    {
                        square[i, j].butt.Image = Image.FromFile(path+@"\fox2.png");
                        if (onefox == false)
                        {
                            fox1i = i;
                            fox1j = j;
                            onefox = true;
                        }
                        else
                        {
                            fox2i = i;
                            fox2j = j;
                        }
                    }
                    if (square[i, j].status == 3)
                    {
                        chicken_count++;
                        square[i, j].butt.Image = Image.FromFile(path+@"\chicken2.png");
                    }
                }
            }
            if (chicken_count < 9)
            {
                MessageBox.Show("Foxs WIN!!!!!");
                Start();
            }
        }

       void EndGame()
        {
            
            for (int i = 2; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (square[i, j].status != 3)
                    {
                        return;
                    }
                }
            }
            MessageBox.Show("Chickens WIN!!!!!");
            Start();
        }
        

        

        void newcoards(int newi,int newj)
        {
            oldi = i;
            oldj = j;
            i = newi;
            j = newj;
        }
        //Кнопки

        private void button1_Click(object sender, EventArgs e)
        {
            newcoards(2, 0);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            newcoards(3, 0);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            newcoards(4, 0);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            newcoards(2, 1);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            newcoards(3, 1);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            newcoards(4, 1);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            newcoards(0, 2);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            newcoards(1, 2);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            newcoards(2, 2);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            newcoards(3, 2);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            newcoards(4, 2);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            newcoards(5, 2);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            newcoards(6, 2);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            newcoards(0, 3);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button15_Click(object sender, EventArgs e)
        {
            newcoards(1, 3);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            newcoards(2, 3);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button17_Click(object sender, EventArgs e)
        {
            newcoards(3, 3);
            if (square[i,j].status==1)
            {
                Move();
            }
        }
        private void button18_Click(object sender, EventArgs e)
        {
            newcoards(4, 3);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button19_Click(object sender, EventArgs e)
        {
            newcoards(5, 3);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button20_Click(object sender, EventArgs e)
        {
            newcoards(6, 3);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button21_Click(object sender, EventArgs e)
        {
            newcoards(0, 4);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button22_Click(object sender, EventArgs e)
        {
            newcoards(1, 4);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button23_Click(object sender, EventArgs e)
        {
            newcoards(2, 4);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button24_Click(object sender, EventArgs e)
        {
            newcoards(3, 4);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button25_Click(object sender, EventArgs e)
        {
            newcoards(4, 4);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button26_Click(object sender, EventArgs e)
        {
            newcoards(5, 4);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button27_Click(object sender, EventArgs e)
        {
            newcoards(6, 4);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button28_Click(object sender, EventArgs e)
        {
            newcoards(2, 5);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button29_Click(object sender, EventArgs e)
        {
            newcoards(3, 5);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button30_Click(object sender, EventArgs e)
        {
            newcoards(4, 5);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }

        

        private void button31_Click(object sender, EventArgs e)
        {
            newcoards(2, 6);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }

        

        private void button32_Click(object sender, EventArgs e)
        {
            newcoards(3, 6);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }
        private void button33_Click(object sender, EventArgs e)
        {
            newcoards(4, 6);
            if (square[i, j].status == 1)
            {
                Move();
            }
        }

        public void RandomMove(int fox1i, int fox1j)
        {
            if (fox1i + 1 < 7 && square[fox1i + 1, fox1j].status == 1)
            {
                square[fox1i, fox1j].status = 1;
                square[fox1i + 1, fox1j].status = 2;
                move = true;
                return;
            }
            if (fox1i - 1 > -1 && square[fox1i - 1, fox1j].status == 1)
            {
                square[fox1i, fox1j].status = 1;
                square[fox1i - 1, fox1j].status = 2;
                move = true;
                return;
            }
            if (fox1j + 1 < 7 && square[fox1i, fox1j + 1].status == 1)
            {
                square[fox1i, fox1j].status = 1;
                square[fox1i, fox1j + 1].status = 2;
                move = true;
                return;
            }
            if (fox1j - 1 > -1 && square[fox1i, fox1j - 1].status == 1)
            {
                square[fox1i, fox1j].status = 1;
                square[fox1i, fox1j - 1].status = 2;
                move = true;
                return;
            }

        }
        public void FoxMove(int fox1i, int fox1j)
        {
            
            if (fox1j + 2 < 7 && (square[fox1i, fox1j + 1].status == 3 && square[fox1i, fox1j + 2].status == 1))
            {
                square[fox1i, fox1j].status = 1;
                square[fox1i, fox1j + 1].status = 1;
                square[fox1i, fox1j + 2].status = 2;
                fox1j += 2;
                move = true;
                FoxMove(fox1i,fox1j);
                return;
            }
            if (fox1j - 2 > -1 && (square[fox1i, fox1j - 1].status == 3 && square[fox1i, fox1j - 2].status == 1))
            {
                square[fox1i, fox1j].status = 1;
                square[fox1i, fox1j - 1].status = 1;
                square[fox1i, fox1j - 2].status = 2;
                fox1j -= 2;
                move = true;
                FoxMove(fox1i, fox1j);
                return;
            }
            if (fox1i + 2 < 7 && (square[fox1i + 1, fox1j].status == 3 && square[fox1i + 2, fox1j].status == 1))
            {
                square[fox1i, fox1j].status = 1;
                square[fox1i + 1, fox1j].status = 1;
                square[fox1i + 2, fox1j].status = 2;
                fox1i += 2;
                move = true;
                FoxMove(fox1i, fox1j);
                return;
            }
            if (fox1i - 2 > -1 && (square[fox1i - 1, fox1j].status == 3 && square[fox1i - 2, fox1j].status == 1))
            {
                square[fox1i, fox1j].status = 1;
                square[fox1i - 1, fox1j].status = 1;
                square[fox1i - 2, fox1j].status = 2;
                fox1i -= 2;
                move = true;
                FoxMove(fox1i, fox1j);
                return;
            }
            if (move == false)
            {
                RandomMove(fox1i, fox1j);
                return;
            }
        }
        public void SquareCopy(int[,]result)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    result[i,j]=square[i,j].status;
                }
            } 
        }
        public int Chickencount(int [,] array)
        {
            int result=0;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                   if( array[i, j] == 3)
                    {
                        result++;
                    }
                }
            }
            return result;
        }
        public int TargetCount(int fox1i,int fox1j)
        {  
            int[,] target =new int[7,7]; 
            SquareCopy(target);
            int inivalue = Chickencount(target);
            Start:
            if (fox1j + 2 < 7 && (target[fox1i, fox1j + 1] == 3 && target[fox1i, fox1j + 2] == 1))
            {
                target[fox1i, fox1j] = 1;
                target[fox1i, fox1j + 1] = 1;
                target[fox1i, fox1j + 2] = 2;
                fox1j += 2;
                goto Start; 
            }
            if (fox1j - 2 > -1 && (target[fox1i, fox1j - 1] == 3 && target[fox1i, fox1j - 2] == 1))
            {
                target[fox1i, fox1j] = 1;
                target[fox1i, fox1j - 1] = 1;
                target[fox1i, fox1j - 2] = 2;
                fox1j -= 2;
                goto Start; 
            }
            if (fox1i + 2 < 7 && (target[fox1i + 1, fox1j] == 3 && target[fox1i + 2, fox1j] == 1))
            {
                target[fox1i, fox1j] = 1;
                target[fox1i + 1, fox1j] = 1;
                target[fox1i + 2, fox1j] = 2;
                fox1i += 2;
                goto Start;
            }
            if (fox1i - 2 > -1 && (target[fox1i - 1, fox1j] == 3 && target[fox1i - 2, fox1j] == 1))
            {
                target[fox1i, fox1j] = 1;
                target[fox1i - 1, fox1j] = 1;
                target[fox1i - 2, fox1j] = 2;
                goto Start;    
            }
            return inivalue - Chickencount(target);
        }

        public void ChooseFox()
        {
            int steps1 = TargetCount(fox1i, fox1j);
            int steps2 = TargetCount(fox2i, fox2j);
            if (steps1 > steps2)
            {
                FoxMove(fox1i, fox1j);
            }
            if (steps1 < steps2)
            {
                FoxMove(fox2i, fox2j);
            }
            if (steps1 == steps2)
            {
                Random rnd = new Random();
                int value = rnd.Next(0, 2);
                if (value > 0)
                {
                    FoxMove(fox1i, fox1j);
                    if (move == false)
                    {
                        FoxMove(fox2i, fox2j);
                        return;
                    }
                }
                else
                {
                    FoxMove(fox2i, fox2j);
                    if (move == false)
                    {
                        FoxMove(fox1i, fox1j);
                        return;
                    }
                }

            }
        }

    }
}
