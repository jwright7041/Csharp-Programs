using System;

namespace ToDoApp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            App newApp = new App();
            newApp.Start();
        }
    }

    public class ToDoItem
    {
        public int ID { get; private set; }
        public string Description { get; set; }
        public string Status { get; set; }
        
        public ToDoItem(string description)
        {
            this.Description = description;
            Status = "PENDING";
        }
    }
}
