using System.Linq;
using System;
using ClassLibrary;

namespace Lab_10
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Auto dialClock = new Auto();
            Random random = new Random();
            Auto[] vehicles = new Auto[20];
            for (int i = 0; i < vehicles.Length; i++)
            {
                int num = random.Next(4);
                if (num == 0)
                {
                    vehicles[i] = new LightCars();
                    vehicles[i].RandomInit();
                }
                else if (num == 1)
                {
                    vehicles[i] = new HeavyCars();
                    vehicles[i].RandomInit();
                }
                else if (num == 2)
                {
                    vehicles[i] = new OffRoadCars();
                    vehicles[i].RandomInit();
                }
                else
                {
                    vehicles[i] = dialClock;
                    vehicles[i].RandomInit();
                }
            }

            Console.WriteLine("Созданные объекты:");
            foreach (Auto vehicle in vehicles)
            {
                if (vehicle.GetType() == typeof(DialClock))
                {
                    vehicle.Show();
                    Console.WriteLine(DialClock.GetObjectCount());
                }
                else
                {
                    vehicle.Show();
                }
                Console.WriteLine();
            }

            MostExpensiveOffroad(vehicles);
            AveragePassengerSpeed(vehicles);
            TotalCost(vehicles);

            Console.WriteLine();
            Console.WriteLine($"Количество объектов Passenger: {LightCars.GetObjectCount()}");
            Console.WriteLine($"Количество объектов Truck: {HeavyCars.GetObjectCount()}");
            Console.WriteLine($"Количество объектов Off_road: {OffRoadCars.GetObjectCount()}");
            Console.WriteLine($"Количество объектов DialClock: {DialClock.GetObjectCount()}");
            Console.WriteLine();

            Console.WriteLine("Элементы массива до сортировки:");
            foreach (Auto vehicle in vehicles)
            {
                vehicle.Show();
            }
            Console.WriteLine();

            // сортировка
            Array.Sort(vehicles);

            Console.WriteLine("Элементы массива после сортировки:");
            foreach (Auto vehicle in vehicles)
            {
                vehicle.Show();
            }

            // поиск по году
            int searchYear = 1990;

            int index = Array.BinarySearch(vehicles, new Auto { Year = searchYear });

            if (index >= 0)
            {
                Console.WriteLine($"Автомобиль {searchYear} года выпуска, найден в массиве на позиции {index}");
            }
            else
            {
                Console.WriteLine($"Автомобиль {searchYear} года выпуска, не найден в массиве");
            }

            Console.WriteLine();
            Console.WriteLine("Массив #2");
            Console.WriteLine();

            Console.WriteLine("Элементы массива до сортировки:");
            foreach (Auto vehicle in vehicles)
            {
                vehicle.Show();
            }
            Console.WriteLine();

            // сортировка
            Array.Sort(vehicles);

            Console.WriteLine("Элементы массива после сортировки:");
            foreach (Auto vehicle in vehicles)
            {
                vehicle.Show();
            }

            int searchCost = 50000;

            int index1 = Array.BinarySearch(vehicles, new Auto { Year = searchYear });

            if (index >= 0)
            {
                Console.WriteLine($"Автомобиль за {searchCost}$, найден в массиве на позиции {index1}");
            }
            else
            {
                Console.WriteLine($"Автомобиль за {searchCost}$, не найден в массиве");
            }


            IdNumber id = new IdNumber(123);
            Auto originalAuto = new Auto(id);

            // Клонирование объекта
            Auto clonedAuto = (Auto)originalAuto.Clone();

            // Изменение номера у клонированного объекта
            clonedAuto.id.Number = 456;

            Console.WriteLine("Исходный объект:");
            Console.WriteLine(originalAuto);

            Console.WriteLine("Клонированный объект (после изменения номера):");
            Console.WriteLine(clonedAuto);

            // Поверхностное копирование
            Auto shallowCopyAuto = (Auto)originalAuto.ShallowCopy();

            // Изменение номера у поверхностной копии
            shallowCopyAuto.id.Number = 789;

            Console.WriteLine("Исходный объект:");
            Console.WriteLine(originalAuto);

            Console.WriteLine("Поверхностная копия (после изменения номера):");
            Console.WriteLine(shallowCopyAuto);
            Console.ReadLine();
        }

        private static void MostExpensiveOffroad(Auto[] vehicles)
        {
            OffRoadCars mostExpensiveOffroad = null;
            int maxCost = 0;

            foreach (var vehicle in vehicles)
            {
                if (vehicle is OffRoadCars && vehicle.Price > maxCost)
                {
                    mostExpensiveOffroad = (OffRoadCars)vehicle;
                    maxCost = vehicle.Price;
                }
            }

            if (mostExpensiveOffroad != null)
            {
                Console.WriteLine("Самый дорогой внедорожник:");
                mostExpensiveOffroad.Show();
            }
            else
            {
                Console.WriteLine("Нет внедорожников в массиве.");
            }
        }

        private static void AveragePassengerSpeed(Auto[] vehicles)
        {
            var passengerVehicles = vehicles.Where(v => v is LightCars).Select(v => (LightCars)v);
            double averageSpeed = 0;
            int count = 0;

            foreach (var vehicle in passengerVehicles)
            {
                averageSpeed += vehicle.TopSpeed;
                count++;
            }

            if (count > 0)
            {
                averageSpeed /= count;
                Console.WriteLine($"Средняя скорость легковых автомобилей: {averageSpeed}");
            }
            else
            {
                Console.WriteLine("В массиве нет легковых автомобилей.");
            }
        }

        private static void TotalCost(Auto[] vehicles)
        {
            int totalCost = 0;

            foreach (var vehicle in vehicles)
            {
                totalCost += vehicle.Price;
            }

            Console.WriteLine($"Суммарная стоимость всех автомобилей: {totalCost}");
        }
    }
}