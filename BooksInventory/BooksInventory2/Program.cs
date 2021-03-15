using System;
using Microsoft.EntityFrameworkCore;
using System.IO;


namespace BooksInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            // instantiate an instance of the context
            BookContext context = new BookContext();

            // makes sure that the table exists, 
            //and creates it if it does not already exist
            context.Database.EnsureCreated();

            // ask the user for a title and author to add
            Console.WriteLine("Enter book title");
            String title = Console.ReadLine();

            Console.WriteLine("Enter author name");
            String author = Console.ReadLine();
            
                // create a new book object, notice that we do not 
                // select an id, we let the framework handle that
                Book newBook = new Book(title, author);

                // add the newly created book instance to the context
                // notice how similar this is to adding a item to a list,
                context.books.Add(newBook);

                // ask the context to save any changes to the database 
                context.SaveChanges();
                Console.WriteLine("Added the book.");

            

            Console.WriteLine("The Current List of books are: ");
            // use a for each loop to loop through the books in the context
            // notice how similar this is to looping through a list
            foreach (Book s in context.books)
            {
                Console.WriteLine("{0} : {1} - {2}",
                     s.Id, s.Title, s.Name);
            }
        }
    }

    class Book
    {
        // notice the private set on the id
        public int Id { get; private set; }
        public String Title { get; set; }
        public String Name { get; set; }
        public Book(String Title, String Name)
        {
            this.Title = Title;
            this.Name = Name;
        }
    }

    class BookContext : DbContext
    {

        // This property corresponds to the table in our database
        public DbSet<Book> books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the directory the code is being executed from
            DirectoryInfo ExecutionDirectory = new DirectoryInfo(AppContext.BaseDirectory);

            // get the base directory for the project
            DirectoryInfo ProjectBase = ExecutionDirectory.Parent.Parent.Parent;

            // add 'books.db' to the project directory
            String DatabaseFile = Path.Combine(ProjectBase.FullName, "books.db");

            // to check what the path of the file is, uncomment the file below
            //Console.WriteLine("using database file :"+DatabaseFile);

            optionsBuilder.UseSqlite("Data Source=" + DatabaseFile);
        }
    }
}

