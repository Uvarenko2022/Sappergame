using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace ConsoleApp1
{
    internal class Game
    {
        private Field field = new Field(15, 10, 40);
        private Player player = new Player();
        private Controller controller;
        private Renderer renderer;
        private bool isfinished = false;


        public void SetUpGame()
        {
            renderer = new ConsoleRenderer(player, field);
            controller = new ConsoleController(player, field);
            field.SetUpField();
            player.Position = new Point(1, 1);
        }

        public void GameLoop()
        {
            while(true)
            {
                field.OutOfBorder(player.Position, player);
                renderer.Render(isfinished);
                controller.GetPlayerInput();

                if (WinGame())
                {
                    Console.WriteLine();
                    Console.WriteLine("YOU WON!!!");
                    return;
                }
                if (LoseGame())
                {
                    Console.WriteLine();
                    Console.WriteLine("YOU LOST :(");
                    return;
                }
            }
        }

        private bool LoseGame()
        {
            for(int i = 0; i < field.BombsAmount; i++)
            {
                if (field.GetCell(new Point(field.bombs[i].X, field.bombs[i].Y)).ishidden == false)
                {
                    isfinished = true;
                    field.OpenAllCells();
                    renderer.Render(isfinished);
                    return true;
                } 
            }

            return false;
        }

        private bool WinGame()
        {
            int counter = 0;

            for (int i = 0; i < field.BombsAmount; i++)
            {
                if (field.GetCell(new Point(field.bombs[i].X, field.bombs[i].Y)).val == CellValues.Flag) counter++;
            }
            if (counter == field.BombsAmount)
            {
                isfinished = true;
                field.OpenAllCells();
                renderer.Render(isfinished);
                return true;
            }

            foreach (Cell cell in field.FieldArr)
            {
                if (cell is EmptyCell && cell.val != CellValues.EmptyCell) return false;
            }

            isfinished = true;
            field.OpenAllCells();
            renderer.Render(isfinished);
            return true;
        }

    }
}
