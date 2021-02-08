using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> students = new Dictionary<string, string>();
            string name;
            string grades;
            string[] splitGrades;


            while (true){

                Console.WriteLine("Input student's name, or type 'quit' to stop inputting: ");
                name = Console.ReadLine();

                if(name == "quit")
                {
                    break;
                }

                Console.WriteLine("Input " + name + "'s grades separated by spaces: ");

                students.Add(name, Console.ReadLine());

            }

            foreach (var key in students.Keys)
            {
                Console.WriteLine(key);
                grades = students[key];

                splitGrades = grades.Split(' ');

                findLowest(splitGrades);
                findHighest(splitGrades);
                average(splitGrades);

            }

            Console.ReadLine();
        }

        static void findLowest(string[] grades)
        {
            string low = grades[0];
            for (int i = 1; i < grades.Length; i++)
            {
                 if (int.Parse(grades[i]) < int.Parse(low))
                {
                    low = grades[i];
                }
            }
            Console.WriteLine("Lowest grade: " + low);
        }

        static void findHighest(string[] grades)
        {
            string high = grades[0];
            for (int i = 1; i < grades.Length; i++)
            {
                if (int.Parse(grades[i]) > int.Parse(high))
                {
                    high = grades[i];
                }
            }
            Console.WriteLine("Highest grade: " + high);
        }

        static void average(string[] grades)
        {
            double total = 0;
            
            for (int i = 0; i < grades.Length; i++)
            {
                total += int.Parse(grades[i]);
            }

            total /= grades.Length;

            Console.WriteLine("Average: " + Math.Round(total, 2, MidpointRounding.AwayFromZero));

        }
    }
}


