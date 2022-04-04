using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class EmptyCell:Cell
    {
        internal override void OpenCell()
        {
            val = CellValues.EmptyCell;
        }
    }
}
