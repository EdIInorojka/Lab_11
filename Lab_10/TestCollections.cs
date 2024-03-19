using ClassLibrary;
using System;
using System.Collections.Generic;

namespace Lab_10
{
    public class TestCollections
    {
        // Коллекции
        public List<LightCars> collection1;
        public List<string> collection2;
        public Dictionary<Auto, LightCars> collection3;
        public Dictionary<string, LightCars> collection4;

        // Конструктор класса
        public TestCollections(int numberOfElements)
        {
            // Инициализация коллекций
            collection1 = new List<LightCars>();
            collection2 = new List<string>();
            collection3 = new Dictionary<Auto, LightCars>();
            collection4 = new Dictionary<string, LightCars>();

            // Генерация элементов и заполнение коллекций
            for (int i = 0; i < numberOfElements; i++)
            {
                LightCars lightCar = new LightCars();
                lightCar.RandomInit();

                // Добавление в коллекции
                collection1.Add(lightCar);
                collection2.Add(lightCar.ToString());
                collection3.Add(lightCar.BaseAutoObject, lightCar);
                collection4.Add(lightCar.BaseAutoObject.ToString(), lightCar);
            }
        }

        // Метод для измерения времени поиска элемента в коллекции
        private TimeSpan MeasureSearchTime(Action searchAction)
        {
            int iterations = 10; // Количество итераций для усреднения времени
            TimeSpan totalTime = TimeSpan.Zero;

            for (int i = 0; i < iterations; i++)
            {
                // Начинаем замер времени
                DateTime startTime = DateTime.Now;

                // Выполняем действие поиска
                searchAction();

                // Завершаем замер времени и добавляем к общему времени
                DateTime endTime = DateTime.Now;
                totalTime += endTime - startTime;
            }

            // Возвращаем среднее время поиска
            return TimeSpan.FromTicks(totalTime.Ticks / iterations);
        }

        // Метод для поиска элемента в коллекции1 (List<LightCat>)
        private void SearchInCollection1(LightCars element)
        {
            collection1.Contains(element);
        }

        // Метод для поиска элемента в коллекции2 (List<string>)
        private void SearchInCollection2(string element)
        {
            collection2.Contains(element);
        }

        // Метод для поиска элемента в коллекции3 (Dictionary<Auto, LightCat>)
        private void SearchInCollection3(LightCars element)
        {
            collection3.ContainsValue(element);
        }

        // Метод для поиска элемента в коллекции4 (Dictionary<string, LightCat>)
        private void SearchInCollection4(LightCars element)
        {
            collection4.ContainsValue(element);
        }

        // Метод для измерения времени поиска элемента в коллекции1 (List<LightCat>)
        public TimeSpan MeasureSearchTimeInCollection1(LightCars element)
        {
            return MeasureSearchTime(() => SearchInCollection1(element));
        }

        // Метод для измерения времени поиска элемента в коллекции2 (List<string>)
        public TimeSpan MeasureSearchTimeInCollection2(string element)
        {
            return MeasureSearchTime(() => SearchInCollection2(element));
        }

        // Метод для измерения времени поиска элемента в коллекции3 (Dictionary<Auto, LightCat>)
        public TimeSpan MeasureSearchTimeInCollection3(LightCars element)
        {
            return MeasureSearchTime(() => SearchInCollection3(element));
        }

        // Метод для измерения времени поиска элемента в коллекции4 (Dictionary<string, LightCat>)
        public TimeSpan MeasureSearchTimeInCollection4(LightCars element)
        {
            return MeasureSearchTime(() => SearchInCollection4(element));
        }
    }

}
