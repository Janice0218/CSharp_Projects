using System;

namespace Human
{
    class Human
    {
        public string Name { get; set; }
        public int Strength { get; set; } = 3;
        public int Intelligence { get; set; } = 3;
        public int Dexterity { get; set; } = 3;
        public int Health { get; set; } = 100;

        public Human(string name)
        {
            Name = name;
            
        }

        public Human(string name, int strength, int intelligence, int dexterity, int health) :this(name)
        {
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            Health = health;
        }

        public void Attack(Object victim)
        {
            var Vic = (Human) victim;
            Vic.Health -= 5 * Strength;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ATTACK! {Vic.Name} loses {5 * Strength} pts from their Health!");
            Console.WriteLine("Current Victim Stats: " + Vic.ToString() );
            Console.ForegroundColor = ConsoleColor.White;
        }
        public override string ToString()
        {
            
            return 
                $"Name: {Name}, Strength: {Strength}, Intelligence: {Intelligence}, Dexterity: {Dexterity}, Health: {Health}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var player1 = new Human("Beth");
            var player2 = new Human("Mikayla", 10, 50, 5, 20);
            Console.WriteLine(player1);
            Console.WriteLine(player2);
            player2.Attack(player1);
            
        }
    }
}
