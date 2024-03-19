using ClassLibrary;
using System;
using System.Collections.Generic;

namespace Lab_10
{
    public class UniversalСollection
    {
        private List<Auto> autos = new List<Auto>();
        Random random = new Random();

        public void AddAuto(Auto auto)
        {
            autos.Add(auto);
        }

        // Метод для добавления нового автомобиля
        public void AddNewAuto()
        {
            bool isGenerated = false;
            while (!isGenerated)
            {
                Console.WriteLine("Выберите тип машины:");
                Console.WriteLine("1 - Легковая");
                Console.WriteLine("2 - Грузовая");
                Console.WriteLine("3 - Внедорожник");
                string answ = Console.ReadLine().Trim();
                switch(answ)
                {
                    case "1":
                        {
                            LightCars light = new LightCars();
                            light.Init();
                            autos.Add(light);
                            isGenerated = true;
                            break;
                        }
                    case "2":
                        {
                            HeavyCars heavy = new HeavyCars();
                            heavy.Init();
                            autos.Add(heavy);
                            isGenerated = true;
                            break;
                        }
                    case "3":
                        {
                            OffRoadCars offroad = new OffRoadCars();
                            offroad.Init();
                            autos.Add(offroad);
                            isGenerated = true;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        public void GenerateAutos(int count)
        {
            autos.Clear();
            for (int i = 0; i < count; i++)
            {
                int a = random.Next(0, 2);
                if (a == 0)
                {
                    LightCars light = new LightCars();
                    light.RandomInit();
                    autos.Add(light);
                }
                else if(a == 1)
                {
                    HeavyCars heavy = new HeavyCars();
                    heavy.RandomInit();
                    autos.Add(heavy);
                }
                else if(a == 2)
                {
                    OffRoadCars offRoad = new OffRoadCars();
                    offRoad.RandomInit();
                    autos.Add(offRoad);
                }
            }
        }

        // Метод для удаления автомобиля по индексу
        public void RemoveAuto(int index)
        {
            if (index >= 0 && index < autos.Count)
            {
                autos.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Ошибка: Недопустимый индекс для удаления.");
            }
        }

        // Метод для вывода информации о коллекции
        public void PrintCollection()
        {
            Console.WriteLine("Информация о коллекции автомобилей:");
            if (autos.Count > 0)
            {
                foreach (var auto in autos)
                {
                    auto.Show();
                }
            }
            else
            {
                Console.WriteLine("Коллекция пустая");
            }
        }

        // Метод для вычисления количества легковых автомобилей
        public int ReturnCountOfLights()
        {
            int count = 0;
            foreach(var light in autos)
            {
                if (light.GetType() == typeof(LightCars))
                {
                    count ++;
                }
            }
            return count;
        }

        // Метод для печати грузовых автомобилей
        public void PrintOnlyHeavyCars()
        {
            int count = 0;
            foreach(var heavy in autos)
            {
                if (heavy.GetType() == typeof(HeavyCars))
                {
                    count++;
                    heavy.Show();
                }
            }
            if(count == 0) 
            {
                Console.WriteLine("В коллекции нет грузовых машин");
            }
        }

        // Метод для вычисления, является ли автомобиль внедорожником
        public bool CheckIsOffRoad(int index)
        {
            if (autos[index].GetType() == typeof(OffRoadCars) && index >= 0 && index < autos.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Клонирование коллекции
        public object Clone()
        {
            UniversalСollection clonedCollection = new UniversalСollection();
            foreach (var auto in autos)
            {
                Auto newAuto = auto;
                clonedCollection.AddAuto(newAuto);
            }
            return clonedCollection;
        }

        // Метод для сортировки коллекции по году выпуска
        public void SortByYear()
        {
            autos.Sort((a1, a2) => a1.Year.CompareTo(a2.Year));
        }
    }
}
