using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bound_in_Steel
{
    abstract class Item : Entity
    {
        public Item(Coordinate coordinate, char icon) : base(coordinate, icon)
        {

        }
    }
}
