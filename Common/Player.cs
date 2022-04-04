using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Player
    {
        public Point Position;

        public void ChangePlayerPosition(Point scale, Field field)
        {
            field.OpenCell(Position);
            Position = new Point(Position.X + scale.X, Position.Y + scale.Y);
        }

        //Gets the amount of bombs near to player
        public int GetNearBombs(Field field)
        {
            int val = 0;
            if (field.GetCell(new Point(Position.X, Position.Y + 1)) is BombCell) ++val;
            if (field.GetCell(new Point(Position.X, Position.Y - 1)) is BombCell) ++val;
            if (field.GetCell(new Point(Position.X + 1, Position.Y)) is BombCell) ++val;
            if (field.GetCell(new Point(Position.X - 1, Position.Y)) is BombCell) ++val; 
            return val;
        }
    }
}
