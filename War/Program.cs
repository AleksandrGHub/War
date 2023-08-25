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
            Battlefield battlefield = new Battlefield();
            battlefield.AddSoldiers();
            battlefield.Fight();
        }
    }

    class Battlefield
    {
        private Country _firstCountry = new Country("Netherlands");
        private Country _secondCountry = new Country("Sweden");

        public void AddSoldiers()
        {
            _firstCountry.AddSoldiers();
            _secondCountry.AddSoldiers();
        }

        public void Fight()
        {

        }
    }

    class Country
    {
        private Platoon _platoon = new Platoon();

        public Country(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void AddSoldiers()
        {
            _platoon.AddSolders();
        }
    }

    class Platoon
    {
        private int _numberSolders = 20;
        private int _health = 100;
        private int _armor = 100;
        private int _damage = 10;
        private Random _random = new Random();
        private List<Soldier> _solders = new List<Soldier>();

        public void AddSolders()
        {
            for (int i = 0; i < _numberSolders; i++)
            {
                _solders.Add(GetSoldier());
            }
        }

        private Soldier GetSoldier()
        {
            int numberOptions = 3;
            int randomNumber = _random.Next(numberOptions);
            Soldier soldier = null;

            switch (randomNumber)
            {
                case 0:
                    soldier = new StrongSoldier(_health, _armor, _damage);
                    break;
                case 1:
                    soldier = new AgileSoldier(_health, _armor, _damage);
                    break;
                case 2:
                    soldier = new HardySoldier(_health, _armor, _damage);
                    break;
            }

            return soldier;
        }
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