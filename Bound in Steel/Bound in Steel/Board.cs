using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace Bound_in_Steel
{
    class Board
    {
        private Square[,] board;
        public readonly int rows;
        public readonly int cols;

        public Board(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            board = new Square[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    board[r, c] = new Square(new Coordinate(r, c));
                }
            }
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (r > 0) board[r, c].AddNeighbor(board[r - 1, c]);
                    if (r < rows - 1) board[r, c].AddNeighbor(board[r + 1, c]);
                    if (c > 0) board[r, c].AddNeighbor(board[r, c - 1]);
                    if (c < cols - 1) board[r, c].AddNeighbor(board[r, c + 1]);
                }
            }
        }

        public void AddMonster(Coordinate c, Monster monster)
        {
            Square square = board[c.row, c.col];
            if (!square.HasMonster()) square.AddMonster(monster);
        }

        public override string ToString()
        {
            string result = "";
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    result += board[r, c].ToString();
                    result += " ";
                }
                result += "\n";
            }
            return result;
        }

        public List<Coordinate> ShortestPath(Coordinate start, Coordinate goal)
        {
            HashSet<Coordinate> visited = new HashSet<Coordinate>();
            Dictionary<Coordinate, Coordinate> parents = new Dictionary<Coordinate, Coordinate>();
            Dictionary<Coordinate, double> gScore = new Dictionary<Coordinate, double>();
            HeapPriorityQueue<Coordinate> fScoreQueue = new HeapPriorityQueue<Coordinate>(rows * cols);
            gScore.Add(start, 0);
            fScoreQueue.Enqueue(start, gScore[start] + Heuristic(start, goal));
            while (fScoreQueue.Count() != 0)
            {
                Coordinate current = fScoreQueue.Dequeue();
                if (current == goal)
                {
                    return ReconstructPath(parents, goal);
                }

                visited.Add(start);
                foreach (Coordinate neighbor in board[current.row,current.col].GetNeighborCoordinates())
                {

                }
                

            }

            return null;
        }

        public List<Coordinate> ReconstructPath(Dictionary<Coordinate,Coordinate> parents, Coordinate goal)
        {
            Console.WriteLine("Reached goal!!");
            throw new NotImplementedException();
            return null;
        }

        public double Heuristic(Coordinate start, Coordinate goal)
        {
            return Math.Abs(goal.row - start.row) + Math.Abs(goal.col - start.col);
        }
    }
}
