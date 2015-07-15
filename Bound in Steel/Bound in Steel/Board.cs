using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;
using System.IO;

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

        public Board(string filename)
        {
            TextReader tr = new StreamReader(filename);
            rows = int.Parse(tr.ReadLine());
            cols = int.Parse(tr.ReadLine());
            board = new Square[rows, cols];
            string line;
            int row = 0;
            while ((line = tr.ReadLine()) != null)
            {
                int col= 0;
                foreach (char ch in line.Trim())
                {
                    Square square = new Square(new Coordinate(row, col));
                    board[row, col] = square;
                    if (ch == '#')
                    {
                        square.AddMonster(new Monster("Wall", '#'));
                    }
                    col++;
                }
                row++;
                cols = col;
            }
            rows = row;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (r > 0)
                    {
                        Square neighbor = board[r - 1, c];
                        if (!neighbor.HasMonster()) board[r, c].AddNeighbor(neighbor);
                    }
                    if (r < rows - 1)
                    {
                        Square neighbor = board[r + 1, c];
                        if (!neighbor.HasMonster()) board[r, c].AddNeighbor(neighbor);
                    }
                    if (c > 0)
                    {
                        Square neighbor = board[r, c - 1];
                        if (!neighbor.HasMonster()) board[r, c].AddNeighbor(neighbor);
                    }
                    if (c < cols - 1)
                    {
                        Square neighbor = board[r, c+ 1];
                        if (!neighbor.HasMonster()) board[r, c].AddNeighbor(neighbor);
                    }
                }
            }

            tr.Close();
        }

        public void AddMonster(Coordinate c, Monster monster)
        {
            Square square = GetSquare(c);
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
                }
                result += "\n";
            }
            return result;
        }

        public List<Coordinate> GetShortestPath(Coordinate start, Coordinate goal)
        {
            return Pathfinder.GetShortestPath(this, start, goal);
        }

        public List<Coordinate> GetNeighbors(Coordinate coordinate)
        {
            return GetSquare(coordinate).GetNeighborCoordinates();
        }

        public int MaxSize()
        {
            return rows * cols;
        }

        public Square GetSquare(Coordinate c)
        {
            return board[c.row, c.col];
        }
    }
}
