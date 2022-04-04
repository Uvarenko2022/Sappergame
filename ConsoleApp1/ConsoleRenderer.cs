using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace ConsoleApp1
{
    public class ConsoleRenderer:Renderer
    {
        public ConsoleRenderer(Player player, Field field) : base(player, field) { }

        public override void Render(bool isfinished)
        {
            Console.Clear();

            string line = "";

            for (int i = 0; i < field.Height; i++)
            {
                for (int j = 0; j < field.Width; j++)
                {
                    if (i == player.Position.Y && j == player.Position.X && !isfinished) line += player.GetNearBombs(field).ToString();
                    else line += field.GetCell(new Point(j, i)).val;
                }

                Console.WriteLine(line);
                line = "";
            }
        }
    }
}
