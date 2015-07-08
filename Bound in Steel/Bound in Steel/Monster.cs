using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bound_in_Steel
{
    class Monster
    {
        public readonly string name;
        public readonly char icon;
        
        public Monster(string name, char icon)
        {
            this.name = name;
            this.icon = icon;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
