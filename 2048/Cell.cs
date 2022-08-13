using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Cell
    {
        private static Cell[,] field;
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Score { get; private set; }
        /// <summary>
        /// Пустая клетка
        /// </summary>
        public Cell(Cell[,] _field)
        {
            X = -1;
            Y = -1;
            field = _field;
        }
        public Cell(int _x,int _y, Cell[,] _field)
        {
            X = _x;
            Y = _y;
            field = _field;
            //TODO score 2 || 4
            Score = 2;
        }
        
        public void Left()
        {
            field[Y, X] = new Cell(field);
            while (X >= 1 && field[Y, X - 1].X < 0)
                X--;
            if (X != 0 && field[Y, X - 1].Score == this.Score)
                field[Y, X - 1].Score *= 2;
            else
                field[Y, X] = this;
        }
        public void Right()
        {
            field[Y, X] = new Cell(field);
            while (X <= 2 && field[Y, X + 1].X < 0)
                X++;
            if (X != 3 && field[Y, X + 1].Score == this.Score)
                field[Y, X + 1].Score *= 2;
            else
                field[Y, X] = this;
        }
        public void Up()
        {
            field[Y, X] = new Cell(field);
            while (Y >= 1 && field[Y - 1, X].Y < 0)
                Y--;
            if (Y != 0 && field[Y - 1, X].Score == this.Score)
                field[Y - 1, X].Score *= 2;
            else
            field[Y, X] = this;
        }
        public void Down()
        {
            field[Y, X] = new Cell(field);
            while (Y <= 2 && field[Y + 1, X].Y < 0)
                Y++;
            if (Y != 3 && field[Y + 1, X].Score == this.Score)
                field[Y + 1, X].Score *= 2;
            else
                field[Y, X] = this;
        }

    }
}
