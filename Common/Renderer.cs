using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    abstract public class Renderer
    {
        protected Player player { get; }
        protected Field field { get; }
        public Renderer(Player player, Field field) 
        {
            this.player = player;
            this.field = field;
        }

        public virtual void Render(bool isfinished) { }
    }
}
