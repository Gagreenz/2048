using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Field
    {
        /// <summary>
        ///  Ширина поля
        /// </summary>
        public int Width { get; private set; }
        /// <summary>
        /// Высота поля
        /// </summary>
        public int Height { get; private set; }
        /// <summary>
        /// Последняя позиция клеток
        /// </summary>
        private Cell[,] LastPositions;
        /// <summary>
        /// Игровое поле
        /// </summary>
        public Cell[,] GameField { get; private set; }
        /// <summary>
        /// Инициализация поля
        /// </summary>
        public Field()
        {
            Width = 4;
            Height = 4;
            GameField = new Cell[Width, Height];
            LastPositions = new Cell[Width, Height];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    //TODO
                    GameField[i, j] = new Cell(GameField);
                }
            }
            AddCell();
            Copy(ref LastPositions, GameField);
        }
        /// <summary>
        /// Первый костыль
        /// </summary>
        /// <returns></returns>
        private void Copy(ref Cell[,] Last, Cell[,] copy)
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Last[i, j] = copy[i, j];
                }
            }
        }
        private bool Compare(Cell[,] newField, Cell[,] oldField)
        {
            var count = 0;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (newField[i, j].Score == oldField[i, j].Score)
                        count++;
                }
            }
            if (count == 16)
                return true;
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction">1-Left 2-Right 3-Up 4-Down</param>
        public void Move(int direction)
        {
            switch (direction)
            {
                case 1:
                    MoveLeft();
                    break;
                case 2:
                    MoveRight();
                    break;
                case 3:
                    MoveUp();
                    break;
                case 4:
                    MoveDown();
                    break;
                default:
                    throw new ArgumentException($"Unknowns directions");
            }
            if (!Compare(GameField, LastPositions))
            {
                AddCell();
                Copy(ref LastPositions, GameField);
            }
        }
        /// <summary>
        /// Добавление клетки в свободное место
        /// </summary>
        private void AddCell()
        {
            List<Tuple<int, int>> EmptyCells = new List<Tuple<int, int>>();
            Random rnd = new Random();
            //Поиск свободных клеток
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (GameField[i, j].Score == 0)
                    {
                        EmptyCells.Add(new Tuple<int, int>(j, i));
                    }
                }
            }
            var coords = EmptyCells[rnd.Next(0, EmptyCells.Count)];
            GameField[coords.Item2, coords.Item1] = new Cell(coords.Item1, coords.Item2, GameField);
        }
        private void MoveLeft()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (GameField[i, j].Score != 0)
                    {
                        GameField[i, j].Left();
                    }
                }
            }
        }
        private void MoveRight()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = Width - 1; j >= 0; j--)
                {
                    if (GameField[i, j].Score != 0)
                    {
                        GameField[i, j].Right();
                    }
                }
            }
        }
        private void MoveUp()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (GameField[i, j].Score != 0)
                    {
                        GameField[i, j].Up();
                    }
                }
            }
        }
        private void MoveDown()
        {
            for (int i = Height - 1; i >= 0; i--)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (GameField[i, j].Score != 0)
                    {
                        GameField[i, j].Down();
                    }
                }
            }
        }
    }
}
