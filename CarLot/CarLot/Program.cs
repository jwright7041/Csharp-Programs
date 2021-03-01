using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLot
{
    class Program
    {
        static void Main(string[] args)
        {
            CarLot carLot = new CarLot();
            carLot.Name = "Bubba's Discount Vehicles";

            carLot.Vehicles.Add(new Truck("NA291A", "Ford", "F-150", 4000, 8));
            carLot.Vehicles.Add(new Car("123ABC", "Honda", "Sedan", 1000, "Coupe", 4));
            carLot.Vehicles.Add(new Car("AG538H", "Hyundai", "Sonata", 2000, "sedan", 4));

            carLot.PrintInfo();
            foreach (var item in carLot.Vehicles)
            {
                item.PrintVehicle();
            }

            Console.WriteLine();

            CarLot carLot2 = new CarLot();
            carLot2.Name = "Vehicle Empire";

            carLot2.Vehicles.Add(new Truck("F14FHE", "Ford", "F-350", 5000, 9));
            carLot2.Vehicles.Add(new Car("A6GR43", "Jeep", "SUV", 2000, "Hatchback", 2));
            carLot2.Vehicles.Add(new Car("89H678", "Hyundai", "Sonata", 3500, "sedan", 4));
            carLot2.Vehicles.Add(new Truck("4AN461", "Chystler", "300", 4000, 7));

            carLot2.PrintInfo();
            foreach (var item in carLot2.Vehicles)
            {
                item.PrintVehicle();
            }

            Console.ReadLine();
        }
    }

    public class CarLot
    {
        public string Name { get; set; }
        public List<Vehicle> Vehicles = new List<Vehicle>();

        public virtual void PrintInfo()
        {
            Console.WriteLine($"{Name}, {Vehicles.Count} vehicles:");
        }
    }

    public abstract class Vehicle
    {
        public string LicenseNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }


        public Vehicle(string licencenumber, string make, string model, double price)
        {
            this.LicenseNumber = licencenumber;
            this.Make = make;
            this.Model = model;
            this.Price = price;
        }

        public virtual void PrintVehicle()
        {
            Console.WriteLine("Print vehicle information.");
        }
    }


    public class Car : Vehicle
    {
        public string Type { get; set; }
        public int NumberOfDoors { get; set; }
        public Car (string licencenumber, string make, string model, double price, string type, int numberofdoors):
            base(licencenumber, make, model, price)
        {
            this.Type = type;
            this.NumberOfDoors = numberofdoors;
        }

        public override void PrintVehicle()
        {
            Console.WriteLine($"{LicenseNumber}, {Make}, {Model}, {Type}, {NumberOfDoors} doors, ${Price}");
        }
    }

    
    public class Truck : Vehicle
    {
        public int Bedsize { get; set; }

        public Truck(string licencenumber, string make, string model, double price, int bedsize) :
           base(licencenumber, make, model, price)
        {
            this.Bedsize = bedsize;
        }

        public override void PrintVehicle()
        {
            Console.WriteLine($"{LicenseNumber}, {Make}, {Model}, {Bedsize}ft, ${Price}");
        }
    }

    
}
