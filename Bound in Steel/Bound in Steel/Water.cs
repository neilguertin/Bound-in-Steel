using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bound_in_Steel
{
    class Water : MapElement
    {
        public Water(Coordinate coordinate) : base(coordinate, '~')
        {
            this.traversable = true;
        }
    }
}
