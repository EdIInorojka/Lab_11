using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Auto : IInit, IComparable<Auto>, IComparer<Auto>
    {
        //Автомобиль: бренд, год выпуска, цвет, стоимость, дорожный просвет;
        protected string brand;
        protected int year;
        protected string color;
        protected int price;
        protected int clearance;
        protected static int count = 0;
        public IdNumber id;

        protected static Random rnd = new Random();

        public string Brand
        {
            get => brand;

            set { brand = value; }
        }

        public int Year
        {
            get => year;
            set
            {
                if (value > 1885)
                    year = value;
                else
                    throw new Exception("Первый автомобиль появился в 1885.");

            }
        }

        public string Color
        {
            get => color;
            set { color = value; }
        }

        public int Price
        {
            get => price;
            set
            {
                if (value > 0)
                    price = value;
                else
                    throw new Exception("Цена не может быть отрицательной.");
            }
        }

        public int Clearance
        {
            get => clearance;
            set
            {
                if (value > 0)
                    clearance = value;
                else
                    throw new Exception("Клиренс не может быть отрицательным.");
            }
        }

        // конструкторы
        public Auto()
        {
            brand = string.Empty;
            year = 0;
            color = string.Empty;
            price = 0;
            clearance = 0;
            count++;
        }
        // конструктор для явных
        public Auto(string brand, int year, string color, int cost, int clearance)
        {
            this.Brand = brand;
            this.Year = year;
            this.Color = color;
            this.Price = cost;
            this.Clearance = clearance;
        }
        // конструктор копирования
        public Auto(Auto Cars)
        {
            brand = Cars.Brand;
            year = Cars.Year;
            color = Cars.Color;
            price = Cars.Price;
            clearance = Cars.Clearance;
        }

        public Auto(IdNumber id)
        {
            this.id = new IdNumber(id);
        }

        public static int GetObjectCount()
        {
            return count;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Cost: {Price}$");
            Console.WriteLine($"Clearance: {Clearance}");
        }

        public virtual void Init()
        {
            Console.WriteLine("Введите информацию о объекте:");

            Console.Write("Введите бренд: ");
            brand = Console.ReadLine();

            Console.Write("Введите год: ");
            year = int.Parse(Console.ReadLine());

            Console.Write("Введите цвет: ");
            color = Console.ReadLine();

            Console.Write("Введите стоимость: ");
            price = int.Parse(Console.ReadLine());

            Console.Write("Введите клиренс: ");
            clearance = int.Parse(Console.ReadLine());
        }

        public virtual void RandomInit()
        {

            string[] brands = { "Toyota", "Honda", "Audi", "Mercedes-benz", "BMW", "Porsche" };
            brand = brands[rnd.Next(0, brands.Length)];

            year = rnd.Next(1885, 2024);

            string[] colors = { "Red", "Blue", "Green", "Black", "White" };
            color = colors[rnd.Next(0, colors.Length)];

            price = rnd.Next(10000, 1000000);

            clearance = rnd.Next(20, 300);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Auto otherCar = (Auto)obj;
            return Brand == otherCar.Brand && Year == otherCar.Year && Color == otherCar.Color &&
                Price == otherCar.Price && Clearance == otherCar.Clearance;
        }

        public int CompareTo(Auto other)
        {
            if (other == null)
                return 1;
            // сортировка по году в порядке возрастания
            return this.Year.CompareTo(other.Year);
        }

        public int CompareToPrice(Auto other)
        {
            if (other == null)
                return 1;
            // сортировка по году в порядке возрастания
            return this.Price.CompareTo(other.Price);
        }

        public int Compare(Auto x, Auto y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;

            return x.Year.CompareTo(y.Year);
        }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        public virtual object Clone()
        {
            return new Auto(new IdNumber(id.Number));
        }

        public class IdNumber
        {
            public int Number
            {
                get { return number; }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Номер не должен быть отрицательным.");
                    }
                    number = value;
                }
            }

            private int number;

            public IdNumber(int number)
            {
                Number = number;
            }

            // конструктор копирования
            public IdNumber(IdNumber id)
            {
                Number = id.Number;
            }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;

                IdNumber other = (IdNumber)obj;
                return Number == other.Number;
            }

            public override string ToString()
            {
                return Number.ToString();
            }
        }

        public virtual string ToString()
        {
            return $"Brand: {Brand}, Year: {Year}, Color: {Color}, Price: {Price}$, Clearance: {Clearance}";
        }
    }
}
