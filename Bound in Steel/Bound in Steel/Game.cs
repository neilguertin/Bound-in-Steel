using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bound_in_Steel
{
    class Game
    {
        static void Main(string[] args)
        {
            Board board = new Board(6, 6);
            Monster human = new Monster("Human", 'h');
            Monster dog = new Monster("Dog", 'd');
            Coordinate humanLoc = new Coordinate(1, 1);
            Coordinate dogLoc = new Coordinate(4, 4);
            board.AddMonster(humanLoc, human);
            board.AddMonster(dogLoc, dog);
            Console.Out.WriteLine(board);
            Console.Out.WriteLine("Shortest path from 1,1 to 4,4:");
            List<Coordinate> path = board.GetShortestPath(humanLoc, dogLoc);
            Console.Out.WriteLine(path);

            Console.Read();
        }
    }
}
