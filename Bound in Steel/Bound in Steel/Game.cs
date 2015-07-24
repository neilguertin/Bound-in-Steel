using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bound_in_Steel
{
    class Game
    {
        static void Main(string[] args)
        {
            //TestPathFind();
            TestFileRead();
            Console.Read();
        }

        /*
        static void TestPathFind()
        {
            Board board = new Board(6, 6);
            Coordinate humanLoc = new Coordinate(1, 1);
            Coordinate dogLoc = new Coordinate(4, 4);
            Creature human = new Creature(humanLoc, 'h');
            Creature dog = new Creature(dogLoc, 'd');
            board.AddCreature(humanLoc, human);
            board.AddCreature(dogLoc, dog);
            Console.WriteLine(board);
            Console.WriteLine("Shortest path from 1,1 to 4,4:");
            List<Coordinate> path = board.GetShortestPath(humanLoc, dogLoc);
            foreach (Coordinate coord in path)
            {
                Console.WriteLine(coord);
                board.AddMonster(coord, new Monster("Path", '*'));
            }
            Console.WriteLine(board);
        }
        */
        
        static void TestFileRead()
        {
            string filename = "Resources\\Boards\\8x8.txt";
            Board board = new Board(filename);
            Console.WriteLine(board);
            Coordinate start = new Coordinate(1, 1);
            Coordinate end = new Coordinate(8, 7);
            List<Coordinate> path = board.GetShortestPath(start, end);
            foreach (Coordinate coord in path)
            {
                Console.WriteLine(coord);
                board.AddItem(coord, new Path(coord));
            }
            Console.WriteLine(board);

            filename = "Resources\\Boards\\15x15H.txt";
            board = new Board(filename);
            Console.WriteLine(board);
            start = new Coordinate(15, 1);
            end = new Coordinate(15, 14);
            path = board.GetShortestPath(start, end);
            foreach (Coordinate coord in path)
            {
                Console.WriteLine(coord);
                board.AddItem(coord, new Path(coord));
            }

            Console.WriteLine(board);
            filename = "Resources\\Boards\\maze.txt";
            board = new Board(filename);
            Console.WriteLine(board);
            start = new Coordinate(0, 5);
            end = new Coordinate(12,7);
            path = board.GetShortestPath(start, end);
            foreach (Coordinate coord in path)
            {
                Console.WriteLine(coord);
                board.AddItem(coord, new Path(coord));
            }
            Console.WriteLine(board);
        }
    }
}
