using System;
using System.Collections.Generic;

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
        private Country _firstCountry = new Country("Netherlands", 7);
        private Country _secondCountry = new Country("Sweden", 5);

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

                if (firstSoldier == null) { }

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
        private Platoon _platoon;

        public Country(string name, int number)
        {
            _platoon = new Platoon(number);
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
        private Random _random;
        private List<Soldier> _soldiers = new List<Soldier>();

        public Platoon(int number)
        {
            _random = new Random(number);
        }

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
                _soldiers[i].ShowInfo();
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
                    soldier = new StrongSoldier();
                    break;
                case 1:
                    soldier = new AgileSoldier();
                    break;
                case 2:
                    soldier = new HardySoldier();
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
        public Soldier()
        {
            Health = 100;
            Armor = 100;
            Damage = 10;
        }

        public float Health { get; protected set; }
        public int Armor { get; protected set; }
        public int Damage { get; protected set; }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage * (Armor - (Armor - 100) * 2) / 100;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Здоровье  {Health} / Броня  {Armor} / Урон  {Damage}");
        }
    }

    class StrongSoldier : Soldier
    {
        public StrongSoldier() : base()
        {
            Damage += 5;
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }
    }
    class AgileSoldier : Soldier
    {
        public AgileSoldier() : base()
        {
            Health += 15;
            Damage += 2;
        }
        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }
    }

    class HardySoldier : Soldier
    {
        public HardySoldier() : base()
        {
            Health += 15;
            Armor += 15;
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }
    }
}