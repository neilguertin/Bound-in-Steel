using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bound_in_Steel
{
    class SquareOccupiedException : System.Exception
    {
        public SquareOccupiedException(Creature intruder, Creature occupant, Coordinate coordinate) : 
            base(intruder.ToString() +"Cannot move to "+coordinate.ToString()+". Square is occupied by " + occupant.ToString() + ".")
        {

        }
    }
}
