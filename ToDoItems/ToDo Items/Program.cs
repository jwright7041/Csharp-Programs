using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_Items
{
    class Program
    {
        static void Main(string[] args)
        {
            //used to break out of the loop
            string repeat;

            //used to hold inputs until places into ToDo class:
            string description;
            string dueDate;
            string prioity;

            //list of ToDo class:
            List<ToDo> todolist = new List<ToDo>();  


            do  //receiving input for todolist
            {
                Console.WriteLine("Input a desription of the task: ");
                description = Console.ReadLine();

                Console.WriteLine("Input due date: ");
                dueDate = Console.ReadLine();

                Console.WriteLine("Input priority ");
                prioity = Console.ReadLine();

                todolist.Add(new ToDo(description, dueDate, prioity));

                Console.WriteLine("Do you want to make more entries? ");
                repeat = Console.ReadLine();

            } while (repeat.ToLower() == "yes");

            
            for (int i = 0; i < todolist.Count; i++)  //outputs 1 ToDo entry per loop; loops for list duration
            {
                Console.WriteLine(todolist[i].Description + " " + todolist[i].DueDate + " " + todolist[i].Priority);
            }

            Console.ReadLine();

        }
    }

    public class ToDo
    {
        public string Description;
        public string DueDate;
        public string Priority;

        public ToDo(string description, string dueDate, string prioity)
        {
            Description = description;
            DueDate = dueDate;
            Priority = prioity;
        }
    }
}
