using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DSF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many rows, and columns");
            //generateMaze();
            //Implement this
            int[,] mazeArray;

            mazeArray = generateMaze();
            generateRandomDirections();
            
        }


        private static int[,] generateMaze()
        {
            int height = 24;
            int length = 24;
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
            int startingX = rnd.Next(24);

            //Generate random starting y
            int startingY = rnd.Next(24);

            recursion(startingX, startingY);

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
        
        private static void recursion(int x, int y, int[,] maze)
        {
            int[] randDirections = generateRandomDirections();

            for (int i = 0; i < randDirections.Length; i++)
            {
                switch (randDirections[i])
                {
                    case 0: //Up
                        if (x - 2 <= 0)
                            continue;
                        
                        if (maze[x-2,y] != 1)
                        {
                            maze[x - 2, y] = 1;
                            maze[x - 1, y] = 1;
                            
                            
                        }
                        
                        break;

                    case 1: //Right
                        if(y + 2 >=)
                        break;

                    case 2: //Down
                        break;

                    case 3: //Left
                        break;

                }
            }

        }

        //Still to implement:
        //Print to console 
        //Finish recursion method
    }
}
