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
            board.AddMonster(new Coordinate(1, 1), human);
            board.AddMonster(new Coordinate(4, 4), dog);
            Console.Out.WriteLine(board);


            Console.Read();
        }
    }
}
