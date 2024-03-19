using System;

namespace ClassLibrary
{
    public class LightCars : Auto, IInit
    {
        //Легковой: количество мест, максимальная скорость;
        private int seats;
        private int topSpeed;

        public int Seats
        {
            get { return seats; }
            set
            {
                if (value > 0)
                    seats = value;
                else
                    throw new Exception("Должно быть хоть одно сиденье.");

            }
        }

        public int TopSpeed
        {
            get { return topSpeed; }
            set
            {
                if (value > 0)
                    topSpeed = value;
                else
                    throw new Exception("Скорость не может быть отрицательной");

            }
        }

        public LightCars() : base()
        {
            seats = 0;
            topSpeed = 0;
            count++;
        }

        public LightCars(string brand, int year, string color, int cost, int clearance) : base(brand, year, color, cost, clearance)
        {
            this.Seats = seats;
            this.TopSpeed = topSpeed;
        }


        public override void Show()
        {
            Console.WriteLine("Passenger");

            base.Show();

            Console.WriteLine($"Количество мест: {seats}");
            Console.WriteLine($"Максимальная скорость: {topSpeed}");
        }

        public override void Init()
        {
            base.Init();

            Console.Write("Количество мест: ");
            seats = int.Parse(Console.ReadLine());

            Console.Write("Введите максимальную скорость: ");
            topSpeed = int.Parse(Console.ReadLine());
        }

        public override void RandomInit()
        {
            base.RandomInit();

            Seats = rnd.Next(1, 8);
            TopSpeed = rnd.Next(120, 400);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            LightCars otherPassenger = (LightCars)obj;
            return Seats == otherPassenger.Seats && TopSpeed == otherPassenger.TopSpeed;
        }

        public int PassengerCount { get; set; }

        public LightCars(IdNumber id, int passengerCount) : base(id)
        {
            PassengerCount = passengerCount;
        }

        public override object Clone()
        {
            LightCars clone = (LightCars)base.Clone();
            clone.PassengerCount = PassengerCount;
            return clone;
        }

        // Метод для получения ссылки на объект базового класса Auto
        public Auto GetBaseAutoObject()
        {
            return this;
        }

        // Свойство для получения ссылки на объект базового класса Auto
        public Auto BaseAutoObject => this;

        public override string ToString()
        {
            return $"Brand: {Brand}, Year: {Year}, Color: {Color}, " +
                $"Price: {Price}$, Clearance: {Clearance}, Seats: {Seats}, TopSpeed: {TopSpeed}";
        }
    }
}
