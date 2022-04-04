using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    internal class Field
    {
        private Cell[,] FieldArr;
        private int BombsAmount;
        private int Width, Height;
        public Field(int Height, int Width, int BombsAmount)
        {
            if (Width <= 1)
            {
                throw new ArgumentOutOfRangeException("Field width should be greater than 1");
            }
            if (Height <= 1)
            {
                throw new ArgumentOutOfRangeException("Field height should be greater than 1");
            }
            if (BombsAmount >= Height * Width)
            {
                throw new ArgumentOutOfRangeException("Amount of bombs should be less than product of width and height");
            }

            FieldArr = new Cell[Height, Width];
            this.BombsAmount = BombsAmount;

            this.Height = Height;
            this.Width = Width;
        }

        public void SetUpField()
        {

        }
    }
}
