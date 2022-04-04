using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace ConsoleApp1
{
    internal class ConsoleController:Controller
    {
        public ConsoleController(Player player, Field field) : base(player, field) { }
        public override void GetPlayerInput()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.W:
                    player.ChangePlayerPosition(Point.Up, field);
                    break;
                case ConsoleKey.S:
                    player.ChangePlayerPosition(Point.Down, field);
                    break;
                case ConsoleKey.A:
                    player.ChangePlayerPosition(Point.Left, field);
                    break;
                case ConsoleKey.D:
                    player.ChangePlayerPosition(Point.Right, field);
                    break;
                case ConsoleKey.F:
                    field.SetFlag(player.Position);
                    break;
            }
        }
    }
}
