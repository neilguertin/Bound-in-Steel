using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bound_in_Steel
{
    class DeepWater : MapElement
    {
        public DeepWater(Coordinate coordinate) : base(coordinate, 'V')
        {
            this.traversable = false;
        }
    }
}
