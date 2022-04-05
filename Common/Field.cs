using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Field
    {
        public Cell[,] FieldArr;
        public int BombsAmount;
        public Point[] bombs;
        public readonly int Height;
        public readonly int Width;

        public Field(int FieldHeight, int FieldWidth, int BombsAmount)
        {
            if (FieldWidth <= 1)
            {
                throw new ArgumentOutOfRangeException("Field width should be greater than 1");
            }
            if (FieldHeight <= 1)
            {
                throw new ArgumentOutOfRangeException("Field height should be greater than 1");
            }
            if (BombsAmount >= FieldHeight * FieldWidth)
            {
                throw new ArgumentOutOfRangeException("Amount of bombs should be less than product of width and height");
            }

            FieldArr = new Cell[FieldHeight, FieldWidth];
            this.BombsAmount = BombsAmount;

            Height = FieldHeight;
            Width = FieldWidth;
        }

        public void SetUpField()
        {
            bombs = GenerateBombsPosition();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (Array.FindLastIndex(bombs, x => (x.X == j && x.Y == i)) > -1) SetCell(new Point(j, i), new BombCell());
                    else if (i == 0) SetCell(new Point(j, i), new BorderCell());
                    else if (i == Height - 1) SetCell(new Point(j, i), new BorderCell());
                    else if (j == 0 && i > 0 && i < Height - 1) SetCell(new Point(j, i), new BorderCell());
                    else if (j == Width - 1 && i > 0 && i < Height - 1) SetCell(new Point(j, i), new BorderCell());
                    else SetCell(new Point(j, i), new EmptyCell());
                }
            }

        }

        private Point[] GenerateBombsPosition()
        {
            Random random = new Random();
            Point[] bombs = new Point[BombsAmount];

            for (int i = 0; i < BombsAmount; i++)
            {
                bombs[i] = new Point(random.Next(1, Width - 1), random.Next(1, Height - 1));
                if(bombs[i].X == 1 && bombs[i].Y == 1)
                {   
                    --i;
                    continue;
                }
            }

            return bombs;
        }

        public void SetFlag(Point Position)
        {
            if (FieldArr[Position.Y, Position.X].val == CellValues.Flag)
            { 
                FieldArr[Position.Y, Position.X].val = CellValues.EmptyCell;
            }
            else
            {
                FieldArr[Position.Y, Position.X].val = CellValues.Flag;
                FieldArr[Position.Y, Position.X].ishidden = true;
            }
        }

        public void OutOfBorder(Point Position, Player player)
        {
            if (FieldArr[Position.Y, Position.X].val == CellValues.BorderCell) 
                player.Position = new Point(GetNearestEmptyCell(Position).X, GetNearestEmptyCell(Position).Y);
        }
        
        public Cell GetCell(Point point)
        {
            return FieldArr[point.Y, point.X];
        }

        private void SetCell(Point point, Cell value)
        {
            FieldArr[point.Y, point.X] = value;
        }

        private Point GetNearestEmptyCell(Point Position)
        {
            Point EmptyCellPosition;
            int y = Position.Y;
            int x = Position.X;

            if (Position.Y == Height - 1) y = Position.Y - 1;
            if (Position.Y == 0) y = Position.Y + 1;
            if (Position.X == Width - 1) x = Position.X - 1;
            if (Position.X == 0) x = Position.X + 1;

            EmptyCellPosition = new Point(x, y);
            return EmptyCellPosition;
        }
        public void OpenCell(Point point)
        {
            if (GetCell(point).val == 'f') return;
    
            GetCell(point).OpenCell();
        }
        public void OpenAllCells()
        {
            for(int i  = 0; i < Height; i++)
            {
                for(int j = 0; j < Width; j++)
                {
                    GetCell(new Point(j, i)).OpenCell();
                }
            }
        }
    }
}
