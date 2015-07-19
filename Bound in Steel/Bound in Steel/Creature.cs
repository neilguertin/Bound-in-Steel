using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bound_in_Steel
{
    abstract class Creature : Entity
    {
        public Creature(Coordinate coordinate, char icon) : base(coordinate, icon)
        {

        }
    }
}
