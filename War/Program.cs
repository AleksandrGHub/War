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
            Soldier firstSoldier;
            Soldier secondSoldier;

            while (_firstCountry.GetCountCells() > 0 & _secondCountry.GetCountCells() > 0)
            {
                firstSoldier = _firstCountry.GetSoldier();
                secondSoldier = _secondCountry.GetSoldier();
                firstSoldier.TakeDamage(secondSoldier.Damage);
                if (firstSoldier.Health <= 0)
                {
                    _firstCountry.DeleteSoldier(firstSoldier);
                }

                if (firstSoldier == null)
                {
                }
                else
                {
                    secondSoldier.TakeDamage(firstSoldier.Damage);
                    if (secondSoldier.Health <= 0)
                    {
                        _secondCountry.DeleteSoldier(secondSoldier);
                    }
                }

                Console.Clear();
                _firstCountry.ShowInfo();
                _secondCountry.ShowInfo();
                Console.ReadKey();
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

        public void DeleteSoldier(Soldier soldier)
        {
            _platoon.DeleteSoldier(soldier);
        }

        public void ShowInfo()
        {
            Console.WriteLine("Страна " + Name);
            _platoon.ShowInfo();
            Console.WriteLine();
        }
    }

    class Platoon
    {
        private int _numberSoldiers = 10;
        private int _health = 10;
        private int _armor = 100;
        private int _damage = 1;
        private Random _random = new Random();
        private List<Soldier> _soldiers = new List<Soldier>();

        public void AddSolders()
        {
            for (int i = 0; i < _numberSoldiers; i++)
            {
                _soldiers.Add(ChooseSoldier());
            }
        }

        public void ShowInfo()
        {
            for (int i = 0; i < _soldiers.Count; i++)
            {
                Console.Write("Солдат " + i + _soldiers[i].GetType() + "   ");
                for (int j = 0; j < _soldiers[i].Health; j++)
                {
                    Console.Write("x");
                }

                Console.WriteLine();
            }
        }

        public void DeleteSoldier(Soldier soldier)
        {
            _soldiers.Remove(soldier);
        }

        public Soldier GetSoldier()
        {
            int index = _random.Next(_soldiers.Count);
            return _soldiers[index];
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
            Health -= damage;
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