using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bound_in_Steel
{
    abstract class Entity
    {
        private Coordinate coordinate;
        protected char icon;
        public Entity(Coordinate coordinate, char icon)
        {
            this.coordinate = coordinate;
            this.icon = icon;
        }

        public char GetIcon()
        {
            return icon;
        }
    }
}
