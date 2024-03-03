using System;

namespace ClassLibrary
{
    public class HeavyCars : Auto, IInit
    {
        //Грузовой автомобиль: грузоподъёмность.
        private int liftingCapacity;

        public int LiftingCapacity
        {
            get { return liftingCapacity; }
            set
            {
                if (value > 0)
                    liftingCapacity = value;
                else
                    throw new Exception("Грузоподъемность не может быть отрицательной.");

            }
        }

        public HeavyCars() : base()
        {
            liftingCapacity = 0;
        }

        public HeavyCars(string brand, int year, string color, int cost, int clearance) : base(brand, year, color, cost, clearance)
        {
            this.liftingCapacity = liftingCapacity;
        }

        public override void Show()
        {
            Console.WriteLine("Truck");

            base.Show();

            Console.WriteLine($"Грузоподъемность: {liftingCapacity}");
        }

        public override void Init()
        {
            base.RandomInit();

            Console.WriteLine("Введите информацию о машине:");

            Console.Write("Грузоподъемность: ");
            liftingCapacity = int.Parse(Console.ReadLine());

        }

        public override void RandomInit()
        {
            base.RandomInit();

            Random rand = new Random();

            liftingCapacity = rand.Next(800, 4000);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            HeavyCars otherTruck = (HeavyCars)obj;
            return liftingCapacity == otherTruck.liftingCapacity;
        }


        public int HeavyCarsCount { get; set; }
        public HeavyCars(IdNumber id, int heavyCarsCount) : base(id)
        {
            HeavyCarsCount = heavyCarsCount;
        }

        public override object Clone()
        {
            HeavyCars clone = (HeavyCars)base.Clone();
            clone.HeavyCarsCount = HeavyCarsCount;
            return clone;
        }
    }
}
