using System;

namespace ClassLibrary
{
    public class OffoadCars : Auto, IInit
    {
        //Внедорожник: полный привод (логическое поле), тип бездорожья;
        private bool fourWD;
        private string roadType;

        public bool FourWD
        {
            get { return fourWD; }
            set { fourWD = value; }
        }

        public string PathType
        {
            get { return roadType; }
            set { roadType = value; }
        }

        public OffoadCars() : base()
        {
            fourWD = true;
            roadType = "асфальт";
            count++;
        }

        public OffoadCars(string brand, int year, string color, int cost, int clearance, string pathType) : base(brand, year, color, cost, clearance)
        {
            this.FourWD = fourWD;
            this.PathType = pathType;
        }

        public override void Show()
        {
            Console.WriteLine("Off_road");

            base.Show();

            Console.WriteLine("Полный привод: " + (fourWD ? "Да" : "Нет"));
            Console.WriteLine($"Тип бездорожья: {roadType}");
        }

        public override void Init()
        {
            base.Show();

            Console.WriteLine("Введите информацию о машине:");

            Console.Write("Есть ли полный привод (true/false): ");
            bool.TryParse(Console.ReadLine(), out fourWD);

            Console.Write("Введите тип дороги (гравий/асфальт/грунт/снег/болото): ");
            roadType = Console.ReadLine();
        }

        public override void RandomInit()
        {
            base.RandomInit();

            Random rnd = new Random();

            fourWD = rnd.Next(2) == 1;

            string[] pathTypes = { "грунт", "асфальт", "гравий", "снег", "болото" };
            roadType = pathTypes[rnd.Next(0, pathTypes.Length)];
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            OffoadCars otherOff_road = (OffoadCars)obj;
            return FourWD == otherOff_road.FourWD && PathType == otherOff_road.PathType;
        }

        public int OffRoadCount { get; set; }
        public OffoadCars(IdNumber id, int offRoadCount) : base(id)
        {
            OffRoadCount = offRoadCount;
        }

        public override object Clone()
        {
            OffoadCars clone = (OffoadCars)base.Clone();
            clone.OffRoadCount = OffRoadCount;
            return clone;
        }
    }
}