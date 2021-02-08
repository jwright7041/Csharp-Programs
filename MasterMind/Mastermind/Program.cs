using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] colors = new string[] { "red", "yellow", "blue" };
            List<string> computerColors = new List<string>();
            List<string> userColors = new List<string>();
            Random random = new Random();
            computerColors.Add(colors[random.Next(0, 3)]);
            computerColors.Add(colors[random.Next(0, 3)]);

            //The following code was used to verify that the randomization was properly set up
            /*
            string test = "temp";
            int blue = 0, red = 0, yellow = 0;
            for (int i = 0; i <= 1000; i++)
            {
                test = colors[random.Next(0, 3)];
                switch (test)
                {
                    case "red":
                        red++;
                        break;
                    case "blue":
                        blue++;
                        break;
                    case "yellow":
                        yellow++;
                        break;
                }
            }
            Console.WriteLine(red +  " " + yellow + " " + blue);
            Console.ReadLine();
            */

            bool isPlaying = true;
            while (isPlaying)
            {
                Console.Clear();  //clear the console
                userColors.Clear();  //clear the previous choices

                //The following line is is for testing purposes
                //Console.WriteLine($"{computerColors[0]} - {computerColors[1]}");

                Console.WriteLine("Welcome to Mastermind!");
                Console.WriteLine("Guess two colors in the correct position. Choices are red, yellow, and blue. Enter 'exit' to stop playing.");
                Console.WriteLine("Enter your first color: ");
                userColors.Add(Console.ReadLine().ToLower().Trim());

                if (userColors.Contains("exit"))
                {
                    break;
                }

                Console.WriteLine("Enter your second color: ");
                userColors.Add(Console.ReadLine().ToLower().Trim());

                if (userColors.Contains("exit"))
                {
                    break;
                }

                if (userColors[0] == computerColors[0])
                {
                    if (userColors[1] == computerColors[1])
                    {
                        Console.WriteLine("You Won!");   //Both correct
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Your hint is 0-1");  //first color correct
                    }
                }
                else if (userColors[1] == computerColors[1])
                {
                    Console.WriteLine("Your hint is 0-1");   //second color correct
                }
                else if (userColors[0] == computerColors[1])
                {
                    if (userColors[1] == computerColors[0])
                    {
                        Console.WriteLine("Your hint is 2-0");  //Both colors correct, but in the wrong order
                    }
                    else
                    {
                        Console.WriteLine("Your hint is 1-0");   //first color correct, but in the wrong position
                    }
                }
                else if (userColors[1] == computerColors[0])
                {
                    Console.WriteLine("Your hint is 1-0");  //second color correct, but in the wrong position
                }
                else
                {
                    Console.WriteLine("Your hint is 0-0");  //Neither color correct
                }

                Console.ReadLine();
            }
        }
    }
}
