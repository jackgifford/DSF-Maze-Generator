using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS
{
    class Program
    {

         static void Main(string[] args)
        {
            Console.WriteLine("DFS Maze Generator"); 
            int[,] mazeArray;
            mazeArray = generateMaze();
            printMaze(mazeArray);
        }


        private static int[,] generateMaze()
        {
            int height = 13;
            int length = 13;
            int[,] maze = new int[height,length];

            //intialise array with open fields
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    maze[i, j] = 0;
                }
            }

            Random rnd = new Random();
            //Generate random starting x
            int startingX = rnd.Next(length);

            //Generate random starting y
            int startingY = rnd.Next(height);

            maze = recursion(startingX, startingY, maze, length, height);

            
            return maze;

        }

        private static int[] generateRandomDirections()
        {
            int[] randoms = new int[4];
            for (int i = 0; i < 4; i++)
            {
                randoms[i] = i;
            }

            Random fisherYates = new Random();

            //using fisher yates
            for (int i = (randoms.Length); i > 1; i--)
            {
                int a = fisherYates.Next(i);
                int tmp = randoms[a];
                randoms[a] = randoms[i - 1];
                randoms[i - 1] = tmp;
            }
            
            return randoms.ToArray();
            
        }
        
        private static int[,] recursion(int x, int y, int[,] maze, int width, int height)
        {
            int[] randDirections = generateRandomDirections();

            for (int i = 0; i < randDirections.Length; i++)
            {
                switch (randDirections[i])
                {
                    case 0: //Up
                        if (x - 2 <= 0)
                        {
                            continue;
                        }
                        
                        if (maze[x-2,y] != 1) //If node has not been previously "discovered"
                        {
                            maze[x - 2, y] = 1;
                            maze[x - 1, y] = 1;

                            recursion(x - 2, y, maze, width, height);
                        }
                        break;

                    case 1: //Right
                        if (y + 2 >= width - 1)//Out by one error
                        {
                            continue;
                        }

                        if (maze[x,y+2] != 1)
                        {
                            maze[x, y + 2] = 1;
                            maze[x, y + 1] = 1;

                            recursion(x, y + 2, maze, width, height);
                        }
                        break;

                    case 2: //Down
                        if (x + 2 >= height - 1)
                        {
                            continue;
                        }

                        if (maze[x+2,y] != 1)
                        {
                            maze[x + 2, y] = 1;
                            maze[x + 1, y] = 1;

                            recursion(x + 2, y, maze, width, height);
                        }
                        break;

                    case 3: //Left
                        if (y - 2 <= 0)
                        {
                            continue;
                        }

                        if (maze[x,y-2] != 1)
                        {
                            maze[x, y - 2] = 1;
                            maze[x, y - 1] = 1;

                            recursion(x, y - 2, maze, width, height);
                        }
                        break;

                }
            }

            return maze;
        }

        static void printMaze(int[,] maze)
        {
            int rowCount = maze.GetLength(0);
            int colCount = maze.GetLength(1);

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    Console.Write(String.Format("{0}\t", maze[i, j]));   
                }
                Console.WriteLine();
                
            }
            Console.Read();
        }

    }
}
