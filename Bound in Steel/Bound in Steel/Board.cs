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
                    Coordinate coordinate = new Coordinate(r, c);
                    board[r, c] = new Square(coordinate, new Wall(coordinate));
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
                    Coordinate coordinate = new Coordinate(row, col);
                    MapElement element;
                    switch (ch)
                    {

                        case 'X':
                            element = new Wall(coordinate);
                            break;
                        case '~':
                            element = new Water(coordinate);
                            break;
                        case '.':
                            element = new Floor(coordinate);
                            break;
                        default:
                            element = new Floor(coordinate);
                            break;
                    }
                    Square square = new Square(coordinate, element);
                    board[row, col] = square;
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
                        board[r, c].AddNeighbor(neighbor);
                    }
                    if (r < rows - 1)
                    {
                        Square neighbor = board[r + 1, c];
                        board[r, c].AddNeighbor(neighbor);
                    }
                    if (c > 0)
                    {
                        Square neighbor = board[r, c - 1];
                        board[r, c].AddNeighbor(neighbor);
                    }
                    if (c < cols - 1)
                    {
                        Square neighbor = board[r, c+ 1];
                        board[r, c].AddNeighbor(neighbor);
                    }
                }
            }

            tr.Close();
        }

        public void AddCreature(Coordinate c, Creature creature)
        {
            Square square = GetSquare(c);
            if (!square.HasCreature()) square.AddCreature(creature);
        }

        public override string ToString()
        {
            string result = "";
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    result += board[r, c].GetIcon();
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

        public void AddItem(Coordinate coordinate, Item item)
        {
            GetSquare(coordinate).AddItem(item);
        }
    }
}
