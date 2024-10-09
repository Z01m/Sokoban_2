using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{

    public partial class Form1 : Form
    {
        private Image texture_box = Image.FromFile("D:\\4 курс\\Системы искусственного интеллекта\\Lab1\\Lab1\\texture\\box.png");
        private Image texture_empty = Image.FromFile("D:\\4 курс\\Системы искусственного интеллекта\\Lab1\\Lab1\\texture\\empty.png");
        private Image texture_player = Image.FromFile("D:\\4 курс\\Системы искусственного интеллекта\\Lab1\\Lab1\\texture\\player.png");
        private Image texture_point = Image.FromFile("D:\\4 курс\\Системы искусственного интеллекта\\Lab1\\Lab1\\texture\\point.png");
        private Image texture_wall = Image.FromFile("D:\\4 курс\\Системы искусственного интеллекта\\Lab1\\Lab1\\texture\\wall.png");
        private int size_texture = 100;
        public int countIndexStep = 1;
        bfs bfs = initBFS(false);//в ширину
        dfs dfs = initDFS(false);//в глубину
        iddfs iddfs = initIDDFS(false);//в глубину с итерацией
        //сделать инициализацию правильно!!!!
        bis bis = new bis();

        public bool checkBFS = false;//какой алгоритм сейчас работает для вызова шага в них
        public bool checkDFS = false;
        public bool checkIDDFS = false;
        public bool checkBIS = false;

        public static bfs initBFS(bool check)
        {
            if (check)
            {
                bfs bfs = new bfs();
                return bfs;
            }
            else return null;
        }//++

        public static dfs initDFS(bool check)
        {
            if (check)
            {
                dfs dfs = new dfs();
                return dfs;
            }
            else return null;
        }//++

        public static iddfs initIDDFS(bool check)
        {
            if (check)
            {
                iddfs iddfs = new iddfs();
                return iddfs;
            }
            else return null;
        }//++

        public static bis initBIS(bool check)
        {
            if (check)
            {
                bis bis= new bis();
                return bis;
            }
            else return null;
        }//++

        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(1500, 1000);
            this.Invalidate();

        }
        public int CheckChar(char c)
        {
            if (c == '#')
                return 1;//wall
            else if (c == '.')
                return 2;//empty
            else if (c == '@')
                return 3;//box
            else if (c == '*')
                return 4;//point
            else return 5;//player
        }

        public Image GetTexture(int id)
        {
            if (id == 1)
                return texture_wall;
            else if (id == 2)
                return texture_empty;
            else if (id == 3)
                return texture_box;
            else if (id == 4)
                return texture_point;
            else return texture_player;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //Map.Instance.DrawMap(Map.LevelMap);

            int texture_id;
            for (int y = 0; y < Map.LevelMap.Length; y++)//кол-во строк Y
            {
                for (int x = 0; x < Map.LevelMap[y].Length; x++)//кол-во символов в строке X
                {
                    char c = Map.LevelMap[y][x];//полуение символа
                    texture_id = CheckChar(c);//получение номера текстуры

                    e.Graphics.DrawImage(GetTexture(texture_id), x * size_texture, y * size_texture, size_texture, size_texture);
                    base.OnPaint(e);//отрисовка
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button_NextStep.Enabled = false;
            button_PrevStep.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button_DFS.Enabled = false;
            buttonBIS.Enabled = false;
        }


        private void button1_Click(object sender, EventArgs e)//обновление экрана(необязательная кнопка)
        {

            this.Invalidate();//обновления OnPaint
                              // Click(true);
        }

        private void button2_Click(object sender, EventArgs e)//Поиск в ширину
        {
            bfs._BFS_();
            countIndexStep = 1;
            checkBFS = true;
            checkDFS = false;
            button_NextStep.Enabled = true;
            labelCountNode.Text = bfs.GetCountNode().ToString();
            labelCountSteps.Text = bfs.GetCountSteps().ToString();
            labelCountIteration.Text = bfs.GetCountIteration().ToString();
            button_DFS.Enabled = false;
            button2.Enabled = false;
            buttonBIS.Enabled = false;
            button3.Enabled = false;
        }

        private void button_NextStep_Click(object sender, EventArgs e)//Отобразить следующий шаг
        {

            if (checkBFS)
            {
                //проверка на последний шаг
                if (bfs.NumberNextStep(countIndexStep))
                {
                    bfs.DrawNextStep(countIndexStep);
                    labelState.Text = $"Ход: {countIndexStep}";
                    button_NextStep.Enabled = true;
                    button_PrevStep.Enabled = true;
                    countIndexStep++;
                }
                else
                {
                    bfs.DrawNextStep(countIndexStep);
                    labelState.Text = "WIN!";
                    button_NextStep.Enabled = false; // блокировать если следующего шага нет (достигнут позиции WIN)
                    button_PrevStep.Enabled = true;

                }
            }
            else if (checkDFS)
            {
                //проверка на последний шаг
                if (dfs.NumberNextStep(countIndexStep))
                {
                    dfs.DrawNextStep(countIndexStep);
                    labelState.Text = $"Ход: {countIndexStep}";
                    button_NextStep.Enabled = true;
                    button_PrevStep.Enabled = true;
                    countIndexStep++;
                }
                else
                {
                    dfs.DrawNextStep(countIndexStep);
                    labelState.Text = "WIN!";
                    button_NextStep.Enabled = false; // блокировать если следующего шага нет (достигнут позиции WIN)
                    button_PrevStep.Enabled = true;

                }
            }
            else if (checkIDDFS)
            {
                //проверка на последний шаг
                if (iddfs.NumberNextStep(countIndexStep))
                {
                    iddfs.DrawNextStep(countIndexStep);
                    labelState.Text = $"Ход: {countIndexStep}";
                    button_NextStep.Enabled = true;
                    button_PrevStep.Enabled = true;
                    countIndexStep++;
                }
                else
                {
                    iddfs.DrawNextStep(countIndexStep);
                    labelState.Text = "WIN!";
                    button_NextStep.Enabled = false; // блокировать если следующего шага нет (достигнут позиции WIN)
                    button_PrevStep.Enabled = true;

                }
            }
            else if(checkBIS)
            {
                if (bis.NumberNextStep(countIndexStep))
                {
                    bis.DrawNextStep(countIndexStep);
                    labelState.Text = $"Ход: {countIndexStep}";
                    button_NextStep.Enabled = true;
                    button_PrevStep.Enabled = true;
                    countIndexStep++;
                }
                else
                {
                    bis.DrawNextStep(countIndexStep);
                    labelState.Text = "WIN!";
                    button_NextStep.Enabled = false; // блокировать если следующего шага нет (достигнут позиции WIN)
                    button_PrevStep.Enabled = true;

                }
            }


            this.Invalidate();
        }
        //Отобразить предыдущий шаг
        private void button_PrevStep_Click(object sender, EventArgs e)//возможно стоит удалить первую позицию из двуз массивов
        {
            if (checkBFS)
            {
                if (countIndexStep != 0)
                {
                    countIndexStep--;
                    bfs.DrawPrevStep(countIndexStep);
                    labelState.Text = $"Ход: {countIndexStep}";
                    button_NextStep.Enabled = true;
                }
                else
                {
                    bfs.DrawPrevStep(countIndexStep);
                    labelState.Text = $"Ход: стартовая позиция";
                    button_NextStep.Enabled = true;
                    button_PrevStep.Enabled = false;
                }
            }
            else if (checkDFS)
            {
                if (countIndexStep != 0)
                {
                    countIndexStep--;
                    dfs.DrawPrevStep(countIndexStep);
                    labelState.Text = $"Ход: {countIndexStep}";
                    button_NextStep.Enabled = true;
                }
                else
                {
                    dfs.DrawPrevStep(countIndexStep);
                    labelState.Text = $"Ход: стартовая позиция";
                    button_NextStep.Enabled = true;
                    button_PrevStep.Enabled = false;
                }
                
            }
            else if(checkIDDFS)
            {
                if (countIndexStep != 0)
                {
                    countIndexStep--;
                    iddfs.DrawPrevStep(countIndexStep);
                    labelState.Text = $"Ход: {countIndexStep}";
                    button_NextStep.Enabled = true;
                }
                else
                {
                    iddfs.DrawPrevStep(countIndexStep);
                    labelState.Text = $"Ход: стартовая позиция";
                    button_NextStep.Enabled = true;
                    button_PrevStep.Enabled = false;
                }

            }
            else if(checkBIS)
            {
                if (countIndexStep != 0)
                {
                    countIndexStep--;
                    bis.DrawPrevStep(countIndexStep);
                    labelState.Text = $"Ход: {countIndexStep}";
                    button_NextStep.Enabled = true;
                }
                else
                {
                    bis.DrawPrevStep(countIndexStep);
                    labelState.Text = $"Ход: стартовая позиция";
                    button_NextStep.Enabled = true;
                    button_PrevStep.Enabled = false;
                }

            }
            this.Invalidate();

        }

        private void button_DFS_Click(object sender, EventArgs e)//DFS
        {
            dfs._DFS_();
            countIndexStep = 1;
            checkDFS = true;
            checkBFS = false;
            labelCountNode.Text = dfs.GetCountNode().ToString();
            labelCountSteps.Text = dfs.GetCountSteps().ToString();
            labelCountIteration.Text = dfs.GetCountIteration().ToString();
            button_NextStep.Enabled = true;
            button_DFS.Enabled = false;
            button2.Enabled = false;
            buttonBIS.Enabled = false;
            button3.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)//IDDFS
        {
            iddfs._IDDFS_();
            countIndexStep = 1;
            checkDFS = false;
            checkBFS = false;
            checkIDDFS = true;
            labelCountNode.Text = iddfs.GetCountNode().ToString();
            labelCountSteps.Text = iddfs.GetCountSteps().ToString();
            labelCountIteration.Text = iddfs.GetCountIteration().ToString();
            button_NextStep.Enabled = true;
            button_DFS.Enabled = false;
            button2.Enabled = false;
            buttonBIS.Enabled = false;
            button3.Enabled = false;
        }

        private void buttonLevel1_Click(object sender, EventArgs e)
        {
            ReadMap("level1.txt");
            bfs = initBFS(true);
            dfs = initDFS(true);
            iddfs = initIDDFS(true);
            button2.Enabled = true;
            button_DFS.Enabled = true;
            buttonBIS.Enabled = true;
            button3.Enabled = true;
            this.Invalidate();
        }

        private void buttonLevel2_Click(object sender, EventArgs e)
        {
            ReadMap("level2.txt");
            bfs = initBFS(true);
            dfs = initDFS(true);
            iddfs = initIDDFS(true);
            button2.Enabled = true;
            button_DFS.Enabled = true;
            buttonBIS.Enabled = true;
            button3.Enabled = true;
            this.Invalidate();
        }

        public void ReadMap(string name)
        {
            string path = @"D:\4 курс\Системы искусственного интеллекта\Lab1\Lab1\level\";
            string[] map = File.ReadAllLines(path + name);
            Console.WriteLine("map");
            foreach (var i in map)
                Console.WriteLine(i);
            Map.LevelMap = map;
            Map.Instance.GetBoxPosition();
            Map.Instance.GetPointPosition();
            Map.Instance.GetPlayerPos();
        }

        private void buttonBIS_Click(object sender, EventArgs e)
        {
            bis._BIS_();
            countIndexStep = 1;
            checkDFS = false;
            checkBFS = false;
            checkIDDFS = false;
            checkBIS = true;
            labelCountNode.Text = bis.GetCountNode().ToString();
            labelCountSteps.Text = bis.GetCountSteps().ToString();
            labelCountIteration.Text = bis.GetCountIteration().ToString();
            button_NextStep.Enabled = true;
            button_DFS.Enabled = false;
            button2.Enabled = false;
            buttonBIS.Enabled = false;
            button3.Enabled = false;
        }
    }
}
