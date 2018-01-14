namespace Wizard_Ninja_Samurai
{
    public class Ninja : Human
    {
        public Ninja(string name, ISecretWeapon weapon):base(name, weapon)
        {
            Dexterity = 175;
            
        }

        public void Steal(Human victim)
        {
            victim.Health -= 10;
            Health += 10;
        }
        public void GetAway(Human victim)
        {
            Health -= 15;
        }

 
    }
}