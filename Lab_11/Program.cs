using System.Linq;
using System;
using ClassLibrary;
using System.Collections.Generic;

namespace Lab_10
{
    public class Program
    {
        public static UniversalСollection unCollection = new UniversalСollection();
        public static GeneralizedCollection<Auto> gnCollection = new GeneralizedCollection<Auto>();

        public static void Main(string[] args)
        {
            string answ = "";
            while (answ != "4")
            {
                Console.WriteLine("Выберите, с какой коллекцией хотите работать:");
                Console.WriteLine("1 - Универсальная коллекция");
                Console.WriteLine("2 - Обобщённая коллекция");
                Console.WriteLine("3 - Задание 3");
                Console.WriteLine("4 - Закончить работу");
                answ = Console.ReadLine().Trim();
                switch (answ)
                {
                    case "1":
                        {
                            StartUniversalLogic();
                            break;
                        }
                    case "2":
                        {
                            StartGeneralizedLogic();
                            break;
                        }
                    case"3":
                        {
                            Task3();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        public static void StartUniversalLogic()
        {
            bool isWorking = true;
            while(isWorking)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Добавить в коллекцию рандомные данные");
                Console.WriteLine("2 - Добавить элемент в коллекцию");
                Console.WriteLine("3 - Удалить элемент из коллекции");
                Console.WriteLine("4 - Вывод коллекции на экран");
                Console.WriteLine("5 - Вывод кол-ва легковых машин");
                Console.WriteLine("6 - Вывод только грузовых автомобилей");
                Console.WriteLine("7 - Проверка, является ли элемент коллекции внедорожником");
                Console.WriteLine("8 - Клонирование коллекции");
                Console.WriteLine("9 - Сортировка коллекции по году выпуска");
                Console.WriteLine("0 - Закончить работу с типом коллекций");
                string answ = Console.ReadLine().Trim();
                switch(answ)
                {
                    case "1":
                        {
                            bool isCorrect = false;
                            int count = 0;
                            while (!isCorrect)
                            {
                                Console.WriteLine("Введите кол-во объектов");
                                isCorrect = int.TryParse(Console.ReadLine(), out count);
                                if (!isCorrect)
                                {
                                    Console.WriteLine("Значение неверное");
                                }
                            }
                            unCollection.GenerateAutos(count);
                            break;
                        }
                    case "2":
                        {
                            unCollection.AddNewAuto();
                            Console.WriteLine("Объект добавлен");
                            break;
                        }
                    case "3":
                        {
                            bool isCorrect = false;
                            int index = 0;
                            while (!isCorrect)
                            {
                                Console.WriteLine("Введите индекс для удаления");
                                isCorrect = int.TryParse(Console.ReadLine(), out index);
                                if (!isCorrect)
                                {
                                    Console.WriteLine("Значение неверное");
                                }
                            }
                            unCollection.RemoveAuto(index);
                            break;
                        }
                    case "4":
                        {
                            unCollection.PrintCollection();
                            break;
                        }
                    case "5":
                        {
                            int count = unCollection.ReturnCountOfLights();
                            Console.WriteLine($"Количество легковых машин в коллекции = {count}");
                            break;
                        }
                    case "6":
                        {
                            unCollection.PrintOnlyHeavyCars();
                            break;
                        }
                    case "7":
                        {
                            bool isCorrect = false;
                            int index = 0;
                            while (!isCorrect)
                            {
                                Console.WriteLine("Введите индекс для проверки");
                                isCorrect = int.TryParse(Console.ReadLine(), out index);
                                if (!isCorrect)
                                {
                                    Console.WriteLine("Значение неверное");
                                }
                            }
                            bool a = unCollection.CheckIsOffRoad(index);
                            if ( a )
                            {
                                Console.WriteLine("Автомобиль является внедорожником");
                            }
                            else
                            {
                                Console.WriteLine("Автомобиль не является внедорожником");
                            }
                            break;
                        }
                    case "8":
                        {
                            UniversalСollection clonedCollection = new UniversalСollection();
                            clonedCollection = (UniversalСollection)unCollection.Clone();
                            clonedCollection.PrintCollection();
                            break;
                        }
                    case "9":
                        {
                            unCollection.SortByYear();
                            Console.WriteLine("Коллекция отсортирована");
                            break;
                        }
                    case "0":
                        {
                            isWorking = false;  
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        private static void StartGeneralizedLogic()
        {
            bool isWorking = true;
            while (isWorking)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Добавить в коллекцию рандомные данные");
                Console.WriteLine("2 - Добавить элемент в коллекцию");
                Console.WriteLine("3 - Удалить элемент из коллекции");
                Console.WriteLine("4 - Вывод коллекции на экран");
                Console.WriteLine("5 - Вывод кол-ва легковых машин");
                Console.WriteLine("6 - Вывод только грузовых автомобилей");
                Console.WriteLine("7 - Проверка, является ли элемент коллекции внедорожником");
                Console.WriteLine("8 - Клонирование коллекции");
                Console.WriteLine("9 - Сортировка коллекции по году выпуска");
                Console.WriteLine("0 - Закончить работу с типом коллекций");
                string answ = Console.ReadLine().Trim();
                switch (answ)
                {
                    case "1":
                        {
                            bool isCorrect = false;
                            int count = 0;
                            while (!isCorrect)
                            {
                                Console.WriteLine("Введите кол-во объектов");
                                isCorrect = int.TryParse(Console.ReadLine(), out count);
                                if (!isCorrect)
                                {
                                    Console.WriteLine("Значение неверное");
                                }
                            }
                            gnCollection.GenerateAutos(count);
                            break;
                        }
                    case "2":
                        {
                            gnCollection.AddNewAuto();
                            Console.WriteLine("Объект добавлен");
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Удаляется последний элемент");
                            gnCollection.RemoveAuto();
                            break;
                        }
                    case "4":
                        {
                            gnCollection.PrintCollection();
                            break;
                        }
                    case "5":
                        {
                            int count = gnCollection.ReturnCountOfLights();
                            Console.WriteLine($"Количество легковых машин в коллекции = {count}");
                            break;
                        }
                    case "6":
                        {
                            gnCollection.PrintOnlyHeavyCars();
                            break;
                        }
                    case "7":
                        {
                            Console.WriteLine("Проверяется первый элемент");
                            bool a = gnCollection.CheckIsOffRoad();
                            if (a)
                            {
                                Console.WriteLine("Автомобиль является внедорожником");
                            }
                            else
                            {
                                Console.WriteLine("Автомобиль не является внедорожником");
                            }
                            break;
                        }
                    case "8":
                        {
                            GeneralizedCollection<Auto> clonedCollection = new GeneralizedCollection<Auto>();
                            clonedCollection = (GeneralizedCollection<Auto>)gnCollection.Clone();
                            clonedCollection.PrintCollection();
                            break;
                        }
                    case "9":
                        {
                            gnCollection.SortByYear();
                            Console.WriteLine("Коллекция отсортирована");
                            break;
                        }
                    case "0":
                        {
                            isWorking = false;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        private static void Task3()
        {
            int numberOfElements = 1000; // Число элементов в коллекциях

            // Создаем объект класса TestCollections
            TestCollections testCollections = new TestCollections(numberOfElements);

            // Создаем элементы для поиска: первый, центральный, последний и отсутствующий
            LightCars firstElement = testCollections.collection1[0];
            LightCars middleElement = testCollections.collection1[numberOfElements / 2];
            LightCars lastElement = testCollections.collection1[numberOfElements - 1];
            LightCars nonExistentElement = new LightCars(); // Просто создаем новый объект

            // Измеряем время поиска элементов в коллекциях
            double timeInCollection1First = testCollections.MeasureSearchTimeInCollection1(firstElement).TotalMilliseconds;
            double timeInCollection1Middle = testCollections.MeasureSearchTimeInCollection1(middleElement).TotalMilliseconds;
            double timeInCollection1Last = testCollections.MeasureSearchTimeInCollection1(lastElement).TotalMilliseconds;
            double timeInCollection1NonExistent = testCollections.MeasureSearchTimeInCollection1(nonExistentElement).TotalMilliseconds;

            double timeInCollection2First = testCollections.MeasureSearchTimeInCollection2(firstElement.ToString()).TotalMilliseconds;
            double timeInCollection2Middle = testCollections.MeasureSearchTimeInCollection2(middleElement.ToString()).TotalMilliseconds;
            double timeInCollection2Last = testCollections.MeasureSearchTimeInCollection2(lastElement.ToString()).TotalMilliseconds;
            double timeInCollection2NonExistent = testCollections.MeasureSearchTimeInCollection2(nonExistentElement.ToString()).TotalMilliseconds;

            double timeInCollection3First = testCollections.MeasureSearchTimeInCollection3(firstElement).TotalMilliseconds;
            double timeInCollection3Middle = testCollections.MeasureSearchTimeInCollection3(middleElement).TotalMilliseconds;
            double timeInCollection3Last = testCollections.MeasureSearchTimeInCollection3(lastElement).TotalMilliseconds;
            double timeInCollection3NonExistent = testCollections.MeasureSearchTimeInCollection3(nonExistentElement).TotalMilliseconds;

            double timeInCollection4First = testCollections.MeasureSearchTimeInCollection4(firstElement).TotalMilliseconds;
            double timeInCollection4Middle = testCollections.MeasureSearchTimeInCollection4(middleElement).TotalMilliseconds;
            double timeInCollection4Last = testCollections.MeasureSearchTimeInCollection4(lastElement).TotalMilliseconds;
            double timeInCollection4NonExistent = testCollections.MeasureSearchTimeInCollection4(nonExistentElement).TotalMilliseconds;

            // Выводим результаты
            Console.WriteLine("Время поиска элементов в коллекциях (в миллисекундах):");
            Console.WriteLine($"Коллекция 1 (List<LightCat>): " +
                $"Первый элемент: {timeInCollection1First}, " +
                $"Средний элемент: {timeInCollection1Middle}, " +
                $"Последний элемент: {timeInCollection1Last}, " +
                $"Отсутствующий элемент: {timeInCollection1NonExistent}");
            Console.WriteLine($"Коллекция 2 (List<string>): " +
                $"Первый элемент: {timeInCollection2First}, " +
                $"Средний элемент: {timeInCollection2Middle}, " +
                $"Последний элемент: {timeInCollection2Last}, " +
                $"Отсутствующий элемент: {timeInCollection2NonExistent}");
            Console.WriteLine($"Коллекция 3 (Dictionary<Auto, LightCat>): " +
                $"Первый элемент: {timeInCollection3First}, " +
                $"Средний элемент: {timeInCollection3Middle}, " +
                $"Последний элемент: {timeInCollection3Last}, " +
                $"Отсутствующий элемент: {timeInCollection3NonExistent}");
            Console.WriteLine($"Коллекция 4 (Dictionary<string, LightCat>): " +
                $"Первый элемент: {timeInCollection4First}, " +
                $"Средний элемент: {timeInCollection4Middle}, " +
                $"Последний элемент: {timeInCollection4Last}, " +
                $"Отсутствующий элемент: {timeInCollection4NonExistent}");
            Console.WriteLine("Время в миллисекундах");
        }
    }
}