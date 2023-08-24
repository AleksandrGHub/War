using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Battlefield
    {

    }

    class Soldier
    {
        public Soldier(int health, int armor, int damage)
        {
            Health = health;
            Armor = armor;
            Damage = damage;
        }

        public int Health { get; private set; }
        public int Armor { get; private set; }
        public int Damage { get; private set; }
    }

    class StrongSoldier : Soldier
    {
        public StrongSoldier(int health, int armor, int damage) : base(health, armor, damage) { }
    }

    class AgileSoldier : Soldier
    {
        public AgileSoldier(int health, int armor, int damage) : base(health, armor, damage) { }
    }

    class HardySoldier : Soldier
    {
        public HardySoldier(int health, int armor, int damage) : base(health, armor, damage) { }
    }
}