using System;
using System.Collections.Generic;
using System.Linq;
using static ToDoApp.ConsoleUtils;


namespace ToDoApp
{
    public class ItemRepository
    {
        public static ItemContext context = new ItemContext();
        public bool success = false;
        public ItemRepository()
        {
            context.Database.EnsureCreated();
        }
      
        public List<ToDoItem> GetList(string printType)
        {
            List<ToDoItem> FilterList = new List<ToDoItem>().ToList();
            if (printType == "ALL")
            {
                FilterList = context.ToDoList.ToList();
            }
            else if (printType == "DONE")
            {
                FilterList = context.ToDoList.Where(x => x.Status == "DONE").ToList();
            }
            else if (printType == "PENDING")
            {
                FilterList = context.ToDoList.Where(x => x.Status == "PENDING").ToList();
            }
            return FilterList;
        }

        public static void AddTask()
        {
            ToDoItem newTask = new ToDoItem(AddPrompt());
            context.ToDoList.Add(newTask);
            context.SaveChanges();
            DoneReply();
        }

        public static void DeleteTask()
        {
            ToDoItem DeleteTask = context.ToDoList.Where(x => x.ID == IDPrompt()).FirstOrDefault();
            if (DeleteTask != null)
            {
                context.Remove(DeleteTask);
                context.SaveChanges();
                DoneReply();
            }
            else
            {
                FailReply();
            }
        }

        public static void DoneTask()
        {
            ToDoItem DoneTask = context.ToDoList.Where(x => x.ID == IDPrompt()).FirstOrDefault();

            if (DoneTask != null)
            {
                DoneTask.Status = DoneTask.Status == "PENDING" ? "DONE" : "PENDING";
                context.Update(DoneTask);
                context.SaveChanges();
                DoneReply();
            }
            else
            {
                FailReply();
            }
        }
    }
}

