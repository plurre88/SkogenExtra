using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skogen
{
    class Program
    {
        static void Main(string[] args)
        {
            var forest = new List<Animal>();
            var night = true;

            forest.Add(new Wolf("Varg", true, 10));
            forest.Add(new Bat("Fladdermus", true, true));
            forest.Add(new Dolfine("Delfin", false, 20));
            forest.Add(new Eagle("Örn", false, 200));
            forest.Add(new Horse("Häst", false, 15));

            while (true)
            {
                Console.WriteLine("[D]AY or [N]IGHT");
                var input = Console.ReadKey(true);
                if (input.KeyChar == 'q')
                {
                    break;
                }
                else if (input.KeyChar == 'n') 
                {
                    night = true;
                }
                else if (input.KeyChar == 'd')
                {
                    night = false;
                }

                Console.Clear();
                foreach (var animal in forest)
                {
                    Console.WriteLine(animal.ToString(night));
                }
            }
        }
    }
    class Animal
    {
        public string Name { get; set; }
        public bool Nocturnal { get; set; }

        public Animal(string name, bool nocturnal)
        {
            Name = name;
            Nocturnal = nocturnal;
        }
        public virtual string ToString(bool night)
        {
            if (night == Nocturnal)
            {
                return $"{Name}en jagar.";
            }
            else
            {
                return $"{Name}en sover.";
            }
        }
    }
    class Wolf : Animal
    {
        public int Pack { get; set; }

        public Wolf(string name, bool nocturnal, int numberPack) : base(name, nocturnal)
        {
            Pack = numberPack;
        }
        public override string ToString(bool night)
        {
            if (night == Nocturnal)
            {
                return $"{Name}en jagar i skogen med sin flock på {Pack} vargar.";
            }
            else
            {
                return $"{Name}en sover i sin lya.";
            }
        }
    }
    class Bat : Animal
    {
        public bool Vampire { get; set; }

        public Bat(string name, bool nocturnal, bool vampire) : base(name, nocturnal)
        {
            Vampire = vampire;
        }
        public override string ToString(bool night)
        {
            if (night == Nocturnal)
            {
                return $"{Name}en jagar efter insekter under natten, {(Vampire ? $"akta så {Name}en inte blir en vampyr" : $"ingen risk att {Name}en blir en vampyr")}.";
            }
            else
            {
                return $"{Name}en sover nu i en {(Vampire ? "kista":"grotta")}.";
            }
        }
    }
    class Dolfine : Animal
    {
        public int FishPerDay { get; set; }

        public Dolfine(string name, bool nocturnal, int numberOfFish) : base(name, nocturnal)
        {
            FishPerDay = numberOfFish;
        }
        public override string ToString(bool night)
        {
            if (night == Nocturnal)
            {
                return $"{Name}en Simmar i vattnet, än så länge har {Name}en ätit {FishPerDay}st fiskar.";
            }
            else
            {
                return $"{Name}en sover, idag har {Name}en ätit {FishPerDay}st fiskar.";
            }
        }
    }
    class Eagle : Animal
    {
        public int Wingspan { get; set; }

        public Eagle(string name, bool nocturnal, int wingspan) : base(name, nocturnal)
        {
            Wingspan = wingspan;
        }
        public override string ToString(bool night)
        {
            if (night == Nocturnal)
            {
                return $"{Name}en flyger i luften med sin wingbredd på {Wingspan}cm.";
            }
            else
            {
                return $"{Name}en sover i sitt bo långt upp i trädtoppen.";
            }
        }
    }
    class Horse : Animal
    {
        public int HayPerDay { get; set; }
        public Horse(string name, bool nocturnal, int numberOfHay) : base(name, nocturnal)
        {
            HayPerDay = numberOfHay;
        }
        public override string ToString(bool night)
        {
            if (night == Nocturnal)
            {
                return $"{Name}en går i hagen, har ätit {HayPerDay} portioner hö.";
            }
            else
            {
                return $"{Name}en sover på 3 ben.";
            }
        }
    }
}
