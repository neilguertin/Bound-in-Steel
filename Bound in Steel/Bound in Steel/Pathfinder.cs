using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace Bound_in_Steel
{
    class Pathfinder
    {
        public static List<Coordinate> GetShortestPath(Board board, Coordinate start, Coordinate goal)
        {
            HashSet<Coordinate> visited = new HashSet<Coordinate>();
            Dictionary<Coordinate, Coordinate> parents = new Dictionary<Coordinate, Coordinate>();
            Dictionary<Coordinate, double> gScore = new Dictionary<Coordinate, double>();
            HeapPriorityQueue<Coordinate> fScoreQueue = new HeapPriorityQueue<Coordinate>(board.MaxSize());
            parents[start] = start;
            gScore.Add(start, 0);
            fScoreQueue.Enqueue(start, gScore[start] + Heuristic(start, goal));
            while (fScoreQueue.Count() != 0)
            {
                Coordinate current = fScoreQueue.Dequeue();
                //Console.WriteLine("Current = " + current.ToString());
                if (current.Equals(goal))
                {
                    Console.WriteLine("FOUND GOAL!!!");
                    return ReconstructPath(parents, goal);
                }

                visited.Add(current);
                List<Coordinate> neighbors = board.GetNeighbors(current);
                foreach (Coordinate neighbor in neighbors)
                {
                    if (visited.Contains(neighbor)) continue;
                    if (!board.GetSquare(neighbor).IsTraversable()) continue;
                    double newGScore = gScore[current] + Distance(current, neighbor);
                    if (!fScoreQueue.Contains(neighbor))
                    {
                        parents[neighbor] = current;
                        gScore[neighbor] = newGScore;
                        fScoreQueue.Enqueue(neighbor, newGScore + Heuristic(neighbor, goal));
                    }
                    else if (newGScore < gScore[neighbor])
                    {
                        parents[neighbor] = current;
                        gScore[neighbor] = newGScore;
                        fScoreQueue.UpdatePriority(neighbor, newGScore + Heuristic(neighbor, goal));
                    }

                }
            }

            return null;
        }

        private static List<Coordinate> ReconstructPath(Dictionary<Coordinate, Coordinate> parents, Coordinate goal)
        {
            List<Coordinate> path = new List<Coordinate>();
            path.Add(goal);
            Coordinate current = goal;
            while (!parents[current].Equals(current))
            {
                current = parents[current];
                path.Add(current);
            }
            path.Reverse();
            return path;

        }

        private static double Heuristic(Coordinate start, Coordinate goal)
        {
            return Math.Sqrt(Math.Pow(goal.row - start.row, 2) + Math.Pow(goal.col - start.col, 2));
        }

        private static double Distance(Coordinate start, Coordinate goal)
        {
            return Math.Sqrt(Math.Pow(goal.row - start.row, 2) + Math.Pow(goal.col - start.col, 2));
        }
    }
}
