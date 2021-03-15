using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;


namespace BooksInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            // instantiate an instance of the context
            StudentsContext context = new StudentsContext();

            // makes sure that the table exists, 
            //and creates it if it does not already exist
            context.Database.EnsureCreated();

            // ask the user for a student to add
            Console.WriteLine("Enter Student full name");
            String fullName = Console.ReadLine();

            // split the input into parts, and make sure 
            // we have 2 parts only
            String[] parts = fullName.Split();
            if (parts.Length == 2)
            {
                // create a new student object, notice that we do not 
                // select an id, we let the framework handle that
                Student newStudent = new Student(parts[0], parts[1]);

                // add the newly created student instance to the context
                // notice how similar this is to adding a item to a list,
                context.students.Add(newStudent);

                // ask the context to save any changes to the database 
                context.SaveChanges();
                Console.WriteLine("Added the student.");
            }
            else
            {
                Console.WriteLine("Invalid full name, did not add student");
            }

            Console.WriteLine("The Current List of students are: ");
            // use a for each loop to loop through the students in the context
            // notice how similar this is to looping through a list
            foreach (Student s in context.students)
            {
                Console.WriteLine("{0} - {1} {2}",
                     s.Id, s.FirstName, s.LastName);
            }
        }
    }

    class Student
    {
        // notice the private set on the id
        public int Id { get; private set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Student(String FirstName, String LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
    }

    class StudentsContext : DbContext
    {

        // This property corresponds to the table in our database
        public DbSet<Student> students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the directory the code is being executed from
            DirectoryInfo ExecutionDirectory = new DirectoryInfo(AppContext.BaseDirectory);

            // get the base directory for the project
            DirectoryInfo ProjectBase = ExecutionDirectory.Parent.Parent.Parent;

            // add 'students.db' to the project directory
            String DatabaseFile = Path.Combine(ProjectBase.FullName, "students.db");

            // to check what the path of the file is, uncomment the file below
            //Console.WriteLine("using database file :"+DatabaseFile);

            optionsBuilder.UseSqlite("Data Source=" + DatabaseFile);
        }
    }
}
