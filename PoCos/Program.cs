using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoCos
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DriversLicence jon = new DriversLicence("Jon", "Smith", "Male", "11111111");
            Console.WriteLine(jon.fullName() + ", " + jon.Gender + ", " + jon.LicenseNumber);

            DriversLicence susan = new DriversLicence("Susan", "Flowers", "Female", "12345678");
            Console.WriteLine(susan.fullName() + ", " + susan.Gender + ", " + susan.LicenseNumber);

            List<string> authors = new List<string> { "Harper Lee" };
            Book mockingbird = new Book("To Kill a Mockingbird", authors, 281, "284762387", "J.B. Lippincott & Co.", 9.95);
            Console.WriteLine(mockingbird.Title + ", " + string.Join(", ", mockingbird.Authors) + ", pages:" + mockingbird.Pages + ", SKU:" + mockingbird.SKU + ", " + mockingbird.Publisher + ", $" + mockingbird.Price);

            authors.Clear();
            authors.Add("Jon Smith");
            authors.Add("Susan Flowers");
            Book goodbook = new Book("Good Book", authors, 127, "68465454", "publishing inc.", 29.99);
            Console.WriteLine(goodbook.Title + ", " + string.Join(", ", goodbook.Authors) + ", pages:" + goodbook.Pages + ", SKU:" + goodbook.SKU + ", " + goodbook.Publisher + ", $" + goodbook.Price);

            Airplane airbus = new Airplane("Airbus", "A300", "Commercial", 300, 4);
            Console.WriteLine(airbus.Manufacturer + ", " + airbus.Model + ", " + airbus.Variant + ", capacity:" + airbus.Capacity + ", engines: " + airbus.Engines);

            Airplane boeing = new Airplane("Boeing", "B20", "Private", 10, 2);
            Console.WriteLine(boeing.Manufacturer + ", " + boeing.Model + ", " + boeing.Variant + ", capacity:" + boeing.Capacity + ", engines: " + boeing.Engines);

            Console.ReadLine();
        }
    }
    
    public class DriversLicence
    {
        public string FirstName;
        public string LastName;
        public string Gender;
        public string LicenseNumber;

        public DriversLicence(string first, string last, string gend, string number)
        {
            FirstName = first;
            LastName = last;
            Gender = gend;
            LicenseNumber = number;
        }

        public string fullName ()
        {
            return FirstName + ' ' + LastName;
        }

    }

    public class Book
    {
        public string Title;
        public List<string> Authors;
        public int Pages;
        public string SKU;
        public string Publisher;
        public double Price;

        public Book(string title, List<string> authors, int pages, string sku, string publisher, double price)
        {
        Title = title;
        Authors = authors;
        Pages = pages;
        SKU = sku;
        Publisher = publisher;
        Price = price;
    }
    }

    public class Airplane
    {
        public string Manufacturer;
        public string Model;
        public string Variant;
        public int Capacity;
        public int Engines;

        public Airplane(string manu, string mod, string vari, int cap, int eng)
        {
            Manufacturer = manu;
            Model = mod;
            Variant = vari;
            Capacity = cap;
            Engines = eng;
        }
    }
}
