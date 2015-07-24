using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bound_in_Steel
{
    class Square
    {
        public readonly Coordinate coordinate;
        private List<Square> neighbors;
        private MapElement element;
        private Creature creature;
        private List<Item> items;

        public Square(Coordinate c, MapElement element)
        {
            this.coordinate = c;
            neighbors = new List<Square>();
            this.element = element;
            items = new List<Item>();
        }

        public void AddCreature(Creature creature)
        {
            if (this.creature != null)
            {
                throw new SquareOccupiedException(creature, this.creature, coordinate);
            }
            this.creature = creature;
        }

        public bool HasCreature()
        {
            return creature != null;
        }

        public void AddNeighbor(Square neighbor)
        {
            // TODO: Error handling on neighbor already exists in list
            if (!neighbors.Contains(neighbor))
            {
                neighbors.Add(neighbor);
            }
        }

        public List<Square> GetNeighbors()
        {
            return neighbors;
        }

        public List<Coordinate> GetNeighborCoordinates()
        {
            List<Coordinate> neighborCoords = new List<Coordinate>();
            foreach (Square square in neighbors)
            {
                neighborCoords.Add(square.coordinate);
            }
            return neighborCoords;
        }

        public char GetIcon()
        {
            return HasCreature() ? creature.GetIcon() :
                    HasItem()? items[0].GetIcon() :
                        element.GetIcon();
        }

        public override string ToString()
        {
            return "[" + coordinate.row + ", " + coordinate.col + "]";
        }

        public bool IsTraversable()
        {
            return element.IsTraversable();
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public bool HasItem()
        {
            return items.Count != 0;
        }
    }
}
