using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowersOfHanoi
{
    class Program
    {
        private static Dictionary<string, Stack<int>> board = new Dictionary<string, Stack<int>>();
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(4);
            stack.Push(3);
            stack.Push(2);
            stack.Push(1);
            board.Add("A", stack);
            board.Add("B", new Stack<int>());
            board.Add("C", new Stack<int>());

            do
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine("Enter the tower to move FROM.");
                string from = Console.ReadLine().ToUpper();
                Console.WriteLine("Enter the tower to move TO.");
                string to = Console.ReadLine().ToUpper();

                if (IsMoveValid(from, to))
                {
                   board[to].Push(board[from].Pop());  //moves the block based on the user input above
                }
                else
                {
                    Console.WriteLine("Move was not valid.");
                    Console.WriteLine("Press any key to try again.");
                    Console.ReadKey();
                }

            } while (!CheckWin());

            Console.Clear();
            PrintBoard();
            Console.WriteLine("You win!");
            Console.ReadKey();
        }

        private static bool IsMoveValid(string from, string to)   //returns true if the move is allowed, and false otherwise
        {
            // if the count is zero, it means the tower has nothing to move, and you can't move nothing
            if (board[from].Count == 0)
            {
                // nothing in this tower
                return false;
            }
            else if (to == from)
            {
                // can't move a peg from and to the same tower
                return false;
            }
            // check that the destination tower is not empty before using Peek, otherwise it will throw an error
            else if (board[to].Count != 0)
            {
                // can't move a larger number on top of a smaller number
                if (board[from].Peek() > board[to].Peek())
                {
                    return false;
                }

                // if the above expression is false, it assumes the move is legal
                return true;
            }
            else // move is legal
            {
                return true;
            }
        }

        private static bool CheckWin() //returns true if the user has won, and false otherwise
        {
            if (board["C"].Count == 4)
            {
                return true;
            }
            return false;
        }

        private static void PrintBoard()   //prints the board into the console
        {
            foreach (var item in board)
            {
                Console.Write($"\n{item.Key}: ");
                var numbers = item.Value.ToArray();
                // print values in reverse order.  You can also use Linq:  .Reverse() instead of a FOR loop
                for (int i = numbers.Length; i > 0; i--)
                {
                    Console.Write(numbers[i - 1] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

