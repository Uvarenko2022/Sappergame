using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    abstract public class Cell
    {
        public char val = CellValues.UnopenedCell;
        public bool ishidden = true;
        internal virtual void OpenCell() { }
    }
}
