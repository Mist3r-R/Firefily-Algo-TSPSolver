using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireflyAlgorithm
{
    public class Heurisctic
    {
        Random rnd = new Random();
        /// <summary>
        /// Проверяет, все ли города в списке были использованы
        /// </summary>
        /// <param name="Cities">Список городов</param>
        /// <returns>true - если использованы все и false в противном случае</returns>
        bool AllCitiesAdded(List<bool> Cities)
        {
            foreach (bool x in Cities)
            {
                if (!x) return false;
            }
            return true;
        }
        /// <summary>
        /// Заполняет список заданным значением (true или false)
        /// Список отражает информацию о городах - были ли они использованы или нет
        /// </summary>
        /// <param name="list">Список, куда будет занесена информация</param>
        /// <param name="len">Длина списка</param>
        /// <param name="value">Значение, отражающее информацию о городе</param>
        /// <returns>Заполненный список</returns>
        List<bool> InitListWithValue(List<bool> list, int len, bool value)
        {
            for (int i = 0; i < len; i++)
            {
                list.Add(value);
            }
            return list;
        }
        /// <summary>
        /// Поиск решения методом ближайшего соседа
        /// </summary>
        /// <param name="Cities">Список городов TSP</param>
        /// <returns></returns>
        public List<City> NearestNeighbour(List<City> Cities)
        {
            List<City> Solution = new List<City>();
            List<bool> IsCityAdded = new List<bool>();
            int firstCityIndex = 0;
            City lastCityAdded;

            IsCityAdded = InitListWithValue(IsCityAdded, Cities.Count, false);

            firstCityIndex = rnd.Next(0, Cities.Count);

            Solution.Add(Cities[firstCityIndex]);
            lastCityAdded = Cities[firstCityIndex];
            IsCityAdded[firstCityIndex] = true;

            while (!AllCitiesAdded(IsCityAdded))
            {
                int bestDistance = int.MaxValue;
                int tmpDistance = 0;
                int bestCityIndex = 0;

                for (int i = 0; i < Cities.Count; i++)
                {
                    if (IsCityAdded[i] == false)
                    {
                        tmpDistance = City.getDestination(Cities[i], lastCityAdded);
                        if (tmpDistance < bestDistance)
                        {
                            bestDistance = tmpDistance;
                            bestCityIndex = i;
                        }
                    }
                }
                Solution.Add(Cities[bestCityIndex]);
                lastCityAdded = Cities[bestCityIndex];
                IsCityAdded[bestCityIndex] = true;
            }

            return Solution;
        }
    }
}
