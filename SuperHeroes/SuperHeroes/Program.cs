using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> human = new List<Person>();

            human.Add(new Person("William", "Bill"));
            human.Add(new Person("Susie", "Sue"));
            human.Add(new Superhero("Invisible Guy", "George", "Invisibility"));
            human.Add(new Superhero("Strong Girl", "Tina", "Super Strength"));
            human.Add(new Villain("Joker", "Batman"));
            human.Add(new Villain("Evil Boy", "Strong Girl"));

            foreach (Person x in human)
            {
                Console.WriteLine(x.PrintGreeting());
            }

            Console.ReadLine();
        }

        public class Person
        {

            public string Name { get; set; }
            public string Nickname { get; set; }

            public Person(string name, string nickname)
            {
                this.Name = name;
                this.Nickname = nickname;
            }

            public override string ToString()
            {
                return Name;
            } 

            public virtual string PrintGreeting()
            {
                return $"Hi, my name is {Name}. You can call me {Nickname}.";
            }
        }

        public class Superhero : Person
        {
            public string RealName { get; set; }
            public string SuperPower { get; set; }

            public Superhero(string name, string realname, string superpower) :
                base(name, null)

            {
                this.RealName = realname;
                this.SuperPower = superpower;

            }

            public override string PrintGreeting()
            {
                return $"I am {RealName}. When I am {Name}, my super power is {SuperPower}";
            }
        }

        public class Villain : Person
        {
            public string Nemesis { get; set; }

            public Villain(string name, string nemesis) :
                base(name, null)

            {
                this.Nemesis = nemesis;

            }

            public override string PrintGreeting()
            {
                return $"I am {Name}! Have you seen {Nemesis}?";
            }
        }
    }
}
