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
            int maxNumberSoldiers;
            int numberFirstCounrySoldiers;
            int numberSecondCounrySoldiers;
            Soldier firstSoldier;
            Soldier secondSoldier;

            while (_firstCountry.GetCountCells() > 0 & _secondCountry.GetCountCells() > 0)
            {
                numberFirstCounrySoldiers = _firstCountry.GetCountCells();
                numberSecondCounrySoldiers = _secondCountry.GetCountCells();
                Console.Clear();
                Console.WriteLine("Нажмите любую кнопу для следующего хода.");
                _firstCountry.ShowInfo();
                _secondCountry.ShowInfo();

                if (numberFirstCounrySoldiers >= numberSecondCounrySoldiers)
                {
                    maxNumberSoldiers = numberFirstCounrySoldiers;
                }
                else
                {
                    maxNumberSoldiers = numberSecondCounrySoldiers;
                }

                for (int i = 0; i < maxNumberSoldiers; i++)
                {
                    firstSoldier = _firstCountry.GetSoldier();
                    secondSoldier = _secondCountry.GetSoldier();
                    Attack(firstSoldier, secondSoldier.Damage);

                    if (firstSoldier.Health <= 0)
                    {
                        _firstCountry.DeleteSoldier(firstSoldier);
                    }
                    else
                    {
                        Attack(secondSoldier, firstSoldier.Damage);

                        if (secondSoldier.Health <= 0)
                        {
                            _secondCountry.DeleteSoldier(secondSoldier);
                        }
                    }
                }

                Console.ReadKey();
            }

            if (_firstCountry.GetCountCells() == 0)
            {
                Console.Clear();
                _firstCountry.ShowInfo();
                _secondCountry.ShowInfo();
                Console.WriteLine("Страна " + _secondCountry.Name + " победила!");
            }
            else

            if (_secondCountry.GetCountCells() == 0)
            {
                Console.Clear();
                _firstCountry.ShowInfo();
                _secondCountry.ShowInfo();
                Console.WriteLine("Страна " + _firstCountry.Name + " победила!");
            }
        }

        private void Attack(Soldier soldier, float damage)
        {
            soldier.TakeDamage(damage);
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
            Console.WriteLine("Страна " + Name + ". Осталось " + GetCountCells() + " воинов.");
            _platoon.ShowInfo();
            Console.WriteLine();
        }
    }

    class Platoon
    {
        private int _numberSoldiers = 5;
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

        public int GetCountCells()
        {
            return _soldiers.Count;
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
    }

    class Soldier
    {
        private float _basicArmor = 100;

        public Soldier()
        {
            Health = 100;
            Armor = 100;
            Damage = 10;
        }

        public float Health { get; protected set; }
        public float Armor { get; protected set; }
        public float Damage { get; protected set; }

        public virtual void TakeDamage(float damage)
        {
            Health -= damage * (Armor - (Armor - _basicArmor) * 2) / _basicArmor;
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

        public override void TakeDamage(float damage)
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
        public override void TakeDamage(float damage)
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

        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }
    }
}