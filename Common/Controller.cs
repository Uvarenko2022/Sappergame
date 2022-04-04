using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    abstract public class Controller
    {
        protected Player player { get; }
        protected Field field { get; }
        public Controller(Player player, Field field)
        {
            this.player = player;
            this.field = field;
        }

        public abstract void GetPlayerInput();
    }
}
