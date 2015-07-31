using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bound_in_Steel
{
    class Human : Humanoid
    {
        public readonly string name;
        public Human(Coordinate coordinate, string name) : base(coordinate, 'H')
        {
            this.name = name;
        }
    }
}
