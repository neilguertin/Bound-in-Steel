using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bound_in_Steel
{
    class Coordinate : PriorityQueueNode
    {
        public readonly int row;
        public readonly int col;

        public Coordinate(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Coordinate c = (Coordinate)obj;
            return this.row == c.row && this.col == c.col;
        }

        public override int GetHashCode()
        {
            return row * 37 + col * 41;
        }

        public override string ToString()
        {
            return "(" + row + ", " + col + ")";
        }

    }
}
