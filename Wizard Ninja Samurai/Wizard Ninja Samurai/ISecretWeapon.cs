using System;
using System.Net;

namespace Wizard_Ninja_Samurai
{
    public interface ISecretWeapon
    {

        void Attack(object victim);
    }

    public class Fireball : ISecretWeapon
    {
        public void Attack(object victim)
        {
            var affect = new Random().Next(20, 51);
            Human enemy = (Human)victim;
            enemy.Health -= affect;
            Console.WriteLine($"FIREBALL!! {enemy.Name} just lost {affect} health points!");
        }
    }

    class DeathBlow : ISecretWeapon
    {
        public void Attack(object victim)
        {
            Human enemy = (Human)victim;
            if (enemy.Health < 50)
            {
                (victim as Human).Health = 0;
                Console.WriteLine($"DEATHBLOW! {enemy.Name}'s health is now at 0!");
            }
            else
            {
                Console.WriteLine($"DEATHBLOW! {enemy.Name} is healty and escaped the wrath of the DeathBlow this time!");
            }
        }
    }

    class ShockWave : ISecretWeapon
    {
        public void Attack(object victim)
        {
            var enemy = (Human) victim;

            (victim as Human).Health -= 10;
            Console.WriteLine($"SHOCKWAVE! {enemy.Name}'s health is now at 0!");


            var imp = this;
        }


    }
}

