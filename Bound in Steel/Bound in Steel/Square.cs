using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bound_in_Steel
{
    class Square
    {
        public readonly Coordinate location;
        private List<Square> neighbors;
        private Monster occupant;

        public Square(Coordinate c)
        {
            this.location = c;
            neighbors = new List<Square>();
        }

        public void AddMonster(Monster monster)
        {
            // TODO: Error handling or return value to indicate failure
            occupant = monster;
        }

        public bool HasMonster()
        {
            return occupant != null;
        }

        public void AddNeighbor(Square neighbor)
        {
            // TODO: Error handling on neighbor already exists in list
            neighbors.Add(neighbor);
        }

        public override string ToString()
        {
            //return "[" + location.row + ", " + location.col + "]";
            return HasMonster() ? ""+occupant.icon : ".";
        }
    }
}
