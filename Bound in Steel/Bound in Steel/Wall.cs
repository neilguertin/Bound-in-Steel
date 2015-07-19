using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bound_in_Steel
{
    class Wall : MapElement
    {
        public Wall(Coordinate coordinate) : base(coordinate, 'X')
        {
            this.traversable = false;
        }
    }
}
