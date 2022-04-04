using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class BombCell:Cell
    {
        internal override void OpenCell()
        {
            val = CellValues.BombCell;
            ishidden = false;
            
        }
    }
}
