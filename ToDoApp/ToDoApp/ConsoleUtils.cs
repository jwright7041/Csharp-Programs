using System;
using System.Collections.Generic;

namespace ToDoApp
{
    public class ConsoleUtils
    {

        public ConsoleUtils()
        {
        }

        public static void Menu()
        {
            Console.WriteLine("Input one of the following commands:");
            Console.WriteLine("ADD: add an item to the list.");
            Console.WriteLine("DONE: mark an item as done.");
            Console.WriteLine("DELETE: remove an item from the list.");
            Console.WriteLine("PRINT: Prints your ToDo list.");
            Console.WriteLine("QUIT: Exit the program.");
        }
   
        public static string GetInput()
        {
            string userInput = Console.ReadLine().ToUpper().Trim();
            string input = "";
            bool run;

            do
            {
                switch (userInput)
                {
                    case "ADD":
                        input = "addItem";
                        run = false;
                        break;
                    case "DELETE":
                        input = "deleteItem";
                        run = false;
                        break;
                    case "DONE":
                        input = "markDone";
                        run = false;
                        break;
                    case "PRINT":
                        input = "printList";
                        run = false;
                        break;
                    case "QUIT":
                        input = "quit";
                        run = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please choose one of the avaliable options.");
                        run = false;
                        break;
                }
            } while (run == true);
            return input;
        }
        
        public static string AddPrompt()
        {
            string task = null;
            bool validInput = false;
            do
            {
                Console.WriteLine("What do you want to add to the list?");
                string input = Console.ReadLine().Trim();
                if (input == "")
                {
                    Console.WriteLine("You must input something.");
                }
                else
                {
                    task = input;
                    validInput = true;
                }

            } while (validInput == false);
            return task;
        }

        public static int IDPrompt()
        {
            Console.WriteLine("Enter the ID of the task you want to modify:");
            string idStr = Console.ReadLine();
            Int32.TryParse(idStr, out int idTask);
            return idTask;
        }

        public static string PrintPrompt()
        {

            Console.WriteLine("What tasks would you like to see: ALL, PENDING, DONE?");
            string printType = Console.ReadLine().ToUpper().Trim();
            return printType;
        }

        public List<ToDoItem> PrintList(List<ToDoItem> ToDoList)
        {
            Console.Clear();

            Console.WriteLine();
            foreach (var i in ToDoList)
            {
                Console.WriteLine($"{i.ID} : {i.Description} , {i.Status}");
            }
            Console.WriteLine();
            return ToDoList;
        }


        public static void DoneReply()
        {
            Console.Clear();
            Console.WriteLine("Action successful.");
            Console.WriteLine();
        }

        public static void FailReply()
        {
            Console.Clear();
            Console.WriteLine("Action failed.");
            Console.WriteLine();
        }
    }
}
