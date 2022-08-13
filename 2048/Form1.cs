using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {
        Dictionary<int, Brush> Coloraizer = new Dictionary<int, Brush>()
        {
            [2] = Brushes.Red,
            [4] = Brushes.Green,
            [8] = Brushes.Indigo,
            [16] = Brushes.Purple,
            [32] = Brushes.Black,
            [64] = Brushes.Blue,
            [128] = Brushes.Orange,
            [256] = Brushes.DarkRed,
            [512] = Brushes.Pink,
            [1024] = Brushes.Gold,
        };
        Field field = new Field();
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            Invalidate();
        }      
        public void DrawMap(Graphics g)
        {
            //TODO Score 
            int score = 0;
            for (int i = 0; i < field.Height; i++)
            {
                for (int j = 0; j < field.Width; j++)
                {
                    if (field.GameField[i, j].Score > 0)
                    {
                        Brush brush;
                        Coloraizer.TryGetValue(field.GameField[i, j].Score,out brush);
                        g.FillRectangle(brush, new Rectangle(12 + j * 100, 12 + i * 100, 96, 96));
                        Font font = new Font(FontFamily.GenericSansSerif, 24); 

                        g.DrawString(field.GameField[i, j].Score.ToString(), font, Brushes.White, 42 + j * 100, 42 + i * 100);
                        score += field.GameField[i, j].Score;
                    }
                }
            }
            ScoreLabel.Text = "Счет:" + score.ToString();
        }
        public void DrawGrid(Graphics g)
        {
            for (int i = 0; i < field.Height + 1; i++)
            {
                g.DrawLine(Pens.Black, new Point(10, 10 + i * 100), new Point(410, 10 + i * 100));
                g.DrawLine(Pens.Black, new Point(10 + i * 100, 10), new Point(10 + i * 100, 410));
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
            DrawMap(e.Graphics);
        }

        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up:
                    field.Move(3);
                    break;
                case Keys.Down:
                    field.Move(4);
                    break;
                case Keys.Left:
                    field.Move(1);
                    break;
                case Keys.Right:
                    field.Move(2);
                    break;
            }
            Invalidate();
        }
    }
}
