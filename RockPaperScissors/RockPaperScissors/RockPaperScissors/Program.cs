using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter a number. 1 = Rock, 2 = Paper, 3 = Scissors");
            string userInput = Console.ReadLine();
            int userHand = int.Parse(userInput);

            Random random = new Random();
            int computerHand = random.Next(1, 3);

            switch (computerHand)
            {
                case 1:
                    Console.WriteLine("The computer chooses: Rock");
                    break;
                case 2:
                    Console.WriteLine("The computer chooses: Paper");
                    break;
                case 3:
                    Console.WriteLine("The computer chooses: Scissors");
                    break;
            }

            string result = CompareHands(computerHand, userHand);
            Console.WriteLine(result);

            Console.ReadLine();
        }

        static string CompareHands(int computerHand, int userHand)
        {

            const string PLAYER_WINS = "The player wins!";
            const string COMPUTER_WINS = "The computer wins!";
            const string DRAW = "It's a draw!";

            string result = string.Empty;

            if (userHand == 1)  //player chose rock
            {
                switch (computerHand)
                {
                    case 1: //computer chose rock
                        result = DRAW;
                        break;
                    case 2: //computer chose paper
                        result = COMPUTER_WINS;
                        break;
                    case 3: //computer chose scissors
                        result = PLAYER_WINS;
                        break;
                }
            }
            else if (userHand == 2)  //player chose paper
            {
                switch (computerHand)
                {
                    case 1: //computer chose rock
                        result = PLAYER_WINS;
                        break;
                    case 2: //computer chose paper
                        result = DRAW;
                        break;
                    case 3: //computer chose scissors
                        result = COMPUTER_WINS;
                        break;
                }
            }
            else if (userHand == 3)  //player chose scissors
            {
                switch (computerHand)
                {
                    case 1: //computer chose rock
                        result = COMPUTER_WINS;
                        break;
                    case 2: //computer chose paper
                        result = PLAYER_WINS;
                        break;
                    case 3: //computer chose scissors
                        result = DRAW;
                        break;
                }
            }

            return result;
        }
    }
}
