using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bound_in_Steel
{
    abstract class MapElement : Entity
    {
        protected bool traversable;
        public MapElement(Coordinate coordinate, char icon) : base(coordinate, icon)
        {

        }
        public bool IsTraversable()
        {
            return traversable;
        }
    }
}
