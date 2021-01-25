using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            hello();
            addition();
            catDog();
            oddEven();
            inches();
            echo();
            killGrams();
            date();
            age();
            guess();

            Console.ReadLine();
        }

        static void hello()
        {

            Console.WriteLine("Hi! What's your name?");
            string name = Console.ReadLine();

            Console.WriteLine("Bye " + name);
        }

        static void addition()
        {
            Console.WriteLine("Enter a number:");
            int firstnumber = 0;
            try
            {
                firstnumber = int.Parse(Console.ReadLine());

            }
            catch (Exception)
            {
                Console.WriteLine("You did not enter a number.");
            }

            Console.WriteLine("Enter a second number:");
            string entry = Console.ReadLine();
            int secondnumber;
            if (int.TryParse(entry, out secondnumber))
            {
                Console.WriteLine(firstnumber + secondnumber);
            }
            else
            {
                Console.WriteLine("You did not enter a number.");
            }
        }

        static void catDog()
        {
            Console.WriteLine("Do you prefer cats or dogs?");
            string input;
            input = Console.ReadLine().ToLower();
            
            if(input == "dog" || input == "dogs")
            {
                Console.WriteLine("Bark");
            }
            else if(input == "cat" || input == "cats")
            {
                Console.WriteLine("Meow");
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

        static void oddEven()
        {
            Console.WriteLine("Input a number");
            int input = 0;
            input = int.Parse(Console.ReadLine());

            if ((input % 2) == 0)
            {
                Console.WriteLine("Even");
            }
            else
            {
                Console.WriteLine("Odd");
            }

        }

        static void inches()
        {
            Console.WriteLine("Give height in feet:");
            int height = int.Parse(Console.ReadLine());

            Console.WriteLine(height * 12 + " in.");
        }

        static void echo()
        {
            Console.WriteLine("Input a word:");
            string word = Console.ReadLine();

            Console.WriteLine(word.ToUpper() + '\n' + word.ToUpper() + '\n' + word.ToUpper() + '\n' + word.ToLower() + '\n' + word.ToLower());
        }

        static void killGrams()
        {
            Console.WriteLine("Input weight in lbs:");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine(weight * .45 + " kg");
        }

        static void date()
        {
            DateTime today = DateTime.Now;
            Console.WriteLine(today);
        }

        static void age()
        {
            DateTime today = DateTime.Now;
            Console.WriteLine("Enter your birth year: ");

            int birth = int.Parse(Console.ReadLine());

            Console.WriteLine("Have you had your birthday this year? y/n:");

            char response = char.Parse(Console.ReadLine().ToLower());

            if (response == 'y')
            {
                Console.WriteLine(today.Year - birth + " years old.");
            }
            else
            {
                Console.WriteLine(today.Year - birth - 1 + " years old.");
            }
        }

        static void guess()
        {
            Console.WriteLine("Guess a word: ");
            string guess = Console.ReadLine();

            if (guess == "csharp")
            {
                Console.WriteLine("CORRECT!!");
            }
            else
            {
                Console.WriteLine("WRONG");
            }
        }
    }
}
