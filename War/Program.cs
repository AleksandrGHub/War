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
        private Random _random = new Random();

        public void AddSoldiers()
        {
            _firstCountry.AddSoldiers();
            _secondCountry.AddSoldiers();
        }

        public void Fight()
        {
            while (_firstCountry.GetCountCells() > 0 & _secondCountry.GetCountCells() > 0)
            {
                _firstCountry.GetSoldier().TakeDamage(_secondCountry.GetSoldier().Damage);

            }

            if (_firstCountry.GetCountCells() == 0)
            {
                Console.WriteLine("Страна " + _secondCountry.Name + " победила!");
            }

            else
                if (_secondCountry.GetCountCells() == 0)
            {
                Console.WriteLine("Страна " + _firstCountry.Name + " победила!");
            }
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

        public int GetCountCells()
        {
            return _platoon.GetCountCells();
        }

        public Soldier GetSoldier()
        {
            return _platoon.GetSoldier();
        }
    }

    class Platoon
    {
        private int _numberSoldiers = 2;
        private int _health = 100;
        private int _armor = 100;
        private int _damage = 10;
        private Random _random = new Random();
        private List<Soldier> _soldiers = new List<Soldier>();

        public void AddSolders()
        {
            for (int i = 0; i < _numberSoldiers; i++)
            {
                _soldiers.Add(ChooseSoldier());
            }
        }

        public void DeleteSoldier(int number)
        {
            _soldiers.RemoveAt(number);
        }

        public Soldier GetSoldier()
        {
            return _soldiers[_random.Next(_soldiers.Count)];
        }

        private Soldier ChooseSoldier()
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

        public int GetCountCells()
        {
            return _soldiers.Count;
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

        public void TakeDamage(int damage)
        {
            Damage -= damage;
        }
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