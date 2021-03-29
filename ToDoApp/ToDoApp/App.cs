using System;
using System.Collections.Generic;
using static ToDoApp.ConsoleUtils;
using static ToDoApp.ItemRepository;

namespace ToDoApp
{
    public class App
    {
        public bool isDone;
        private ItemRepository ItemRepo;
        public ConsoleUtils ConsoleUtil;

        public App()
        {
            ItemRepo = new ItemRepository();
            ConsoleUtil = new ConsoleUtils();
        }

       
        private void PrintFilter()
        {
            string filter = PrintPrompt();

            switch (filter)
            {
                case "DONE":
                    List<ToDoItem> DoneList = ItemRepo.GetList(filter);
                    ConsoleUtil.PrintList(DoneList);
                    break;

                case "PENDING":
                    List<ToDoItem> PendingList = ItemRepo.GetList(filter);
                    ConsoleUtil.PrintList(PendingList);
                    break;

                case "ALL":
                    List<ToDoItem> AllList = ItemRepo.GetList(filter);
                    ConsoleUtil.PrintList(AllList);
                    break;

                default:
                    FailReply();
                    break;
            }
        }

        private void PrintAll()
        {
            ConsoleUtil.PrintList(ItemRepo.GetList("ALL"));
        }

        public void Start()
        {
            do
            {
                Menu();
                string input = GetInput();
                switch (input)
                {
                    case "addItem":
                        AddTask();
                        break;

                    case "deleteItem":
                        Console.Clear();
                        PrintAll();
                        DeleteTask();
                        break;

                    case "markDone":
                        Console.Clear();
                        PrintAll();
                        DoneTask();
                        break;

                    case "printList":
                        PrintFilter();
                        break;

                    case "quit":
                        isDone = true;
                        break;

                    default:
                        break;
                }
            } while (isDone == false);
        }
    }
}