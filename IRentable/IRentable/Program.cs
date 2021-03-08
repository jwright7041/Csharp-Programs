using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRentable
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRentable> rentables = new List<IRentable>();
            rentables.Add(new Boat("Airboat", "A flat-bottomed watercraft propelled by an aircraft-type propeller.", 30.00m));
            rentables.Add(new Boat("Fishing Trawler", "A commercial fishing vessel designed to operate fishing trawls.", 350.00m));
            rentables.Add(new Car("Mid-Size SUV", "Holds 5 people; 4 door; Room for 1 bag", 100.00m));
            rentables.Add(new Car("Premium Crossover", "Holds 7 people; 4 door; Room for 4 bags", 120.00m));
            rentables.Add(new House("Efficiency", "1 Bedroom, 1 Bathroom, 400 sqft", 200.00m));
            rentables.Add(new House("Townhouse", "3 Bedroom, 2 Bathroom, 600 sqft", 450.00m));

            foreach (var item in rentables)
            {
                Console.WriteLine(item.GetType());
                Console.WriteLine(item.GetDescription());
                Console.WriteLine("$" + item.GetDailyRate() + " per day." + '\n');
            }
            Console.ReadLine();
        }
    }


    interface IRentable
    {
        decimal GetDailyRate();
        string GetDescription();
        string GetType();
    }

    class Boat : IRentable
    {
        string Description { get; set; }
        string Type { get; set; }
        decimal hourlyRate { get; set; }

        public Boat(string type, string description, decimal Rate)
        {
            Type = type;
            Description = description;
            hourlyRate = Rate;
        }

        public decimal GetDailyRate()
        {
            return hourlyRate * 24;
        }

        public string GetDescription()
        {
            return Description;
        }
        public string GetType()
        {
            return Type;
        }
    }

    class Car : IRentable
    {
        string Description { get; set; }
        string Type { get; set; }
        decimal dailyRate { get; set; }

        public Car(string type, string description, decimal Rate)
        {
            Type = type;
            Description = description;
            dailyRate = Rate;
        }

        public decimal GetDailyRate()
        {
            return dailyRate;
        }

        public string GetDescription()
        {
            return Description;
        }
        public string GetType()
        {
            return Type;
        }
    }

    class House : IRentable
    {
        string Description { get; set; }
        string Type { get; set; }
        decimal weeklyRate { get; set; }

        public House(string type, string description, decimal Rate)
        {
            Type = type;
            Description = description;
            weeklyRate = Rate;
        }

        public decimal GetDailyRate()
        {
            return Math.Round(weeklyRate / 7, 2);
        }

        public string GetDescription()
        {
            return Description;
        }
        public string GetType()
        {
            return Type;
        }
    }
}
