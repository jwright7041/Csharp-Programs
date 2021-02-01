using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program

    {
        static void Main(string[] args)
        {
            InitializeBoard();
            bool isPlaying = true;
            string playerLetter = "X";

            while (isPlaying)
            {
                PrintBoard();
                Console.WriteLine($"\n\nPlayer {playerLetter}. Enter the number of the square.");
                string answer = Console.ReadLine();
                if (!int.TryParse(answer, out int number) || number > 9 || number < 1)
                {
                    Console.WriteLine("You did not enter a valid square. Press any key to try again.");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    if (PlaceMark(answer, playerLetter))
                    {
                        PrintBoard();
                        if (HasWon(playerLetter))
                        {
                            Console.WriteLine($"Player {playerLetter} wins!");
                            if (PlayAgain())
                            {
                                InitializeBoard();
                                playerLetter = "X";
                                continue;
                            }
                            else break;
                        }
                        else if (IsTie())
                        {
                            Console.WriteLine("No winner.");
                            if (PlayAgain())
                            {
                                InitializeBoard();
                                playerLetter = "X";
                                continue;
                            }
                            else break;
                        }
                        else
                        {
                            playerLetter = playerLetter == "X" ? "O" : "X";
                        } 
                    }
                    else
                    {
                        Console.WriteLine($"Player {playerLetter} cannot place a mark there. Press any key to continue.");
                        Console.ReadKey();
                        continue;
                    }
                }
            }
        }
        static void PrintBoard()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\t" + Board[i, 0] + " | " + Board[i, 1] + " | " + Board[i, 2]);
                if (i < 2)
                {
                    Console.WriteLine("\t----------");
                }
            }
        }

        static void InitializeBoard()
        {
            Board = new string[3, 3]
            {
                // (0,0), (0,1), (0,2)
                { "1", "2", "3" },

                // (1,0), (1,1), (1,2)
                { "4", "5", "6" },

                // (2,0), (2,1), (2,2)
                { "7", "8", "9" },
            };
        }
        static bool PlaceMark(string square, string player)
        {
            string otherPlayer = player == "X" ? "O" : "X";
            // find the selected square
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    if (Board[i, j].Equals(square) &&
                    (!Board[i, j].Equals(otherPlayer) || !Board[i, j].Equals(player)))
                    {
                        Board[i, j] = player;
                        return true;
                    }
                }
            }

            return false;
        }

        static bool HasWon(string player)
        {
            if (isHorizontalWin(player))
            {
                return true;
            }
            else if (isVerticalWin(player))
            {
                return true;
            } 
            else if (isDiagonalWin(player))
            {
                return true;
            }

            return false;
        }

        static bool IsTie()
        {
            for(int i = 0; i <= 2; i++)
            {
                for(int j = 0; j <= 2; j++)
                {
                    if (!((Board[i,j] == "X") || (Board[i, j] == "O")))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static bool PlayAgain()
        {
            Console.WriteLine("Play again? y/n:");
            return (Console.ReadLine().ToLower() == "y");
        }

        static bool isVerticalWin(string player) 
        {
            for (int i = 0; i <= 2; i++)
            {
                if ((Board[0, i] == player) && (Board[1, i] == player) && (Board[2, i] == player))
                {
                    return true;
                }
            }
            return false;
        }

        static bool isHorizontalWin(string player) 
        {
            for (int i = 0; i <= 2; i++)
            {
                if ((Board[i, 0] == player) && (Board[i, 1] == player) && (Board[i, 2] == player))
                {
                    return true;
                }
            }
            return false;
        }

        static bool isDiagonalWin(string player) 
        {
                if ((Board[0, 0] == player) && (Board[1, 1] == player) && (Board[2, 2] == player))
                {
                    return true;
                }

            if ((Board[2, 0] == player) && (Board[1, 1] == player) && (Board[0, 2] == player))
            {
                return true;
            }

            return false;
        }

        public static string[,] Board;
    }
}
