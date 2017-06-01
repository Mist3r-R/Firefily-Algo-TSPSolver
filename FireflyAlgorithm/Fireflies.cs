using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireflyAlgorithm
{
    public class Fireflies
    {
        List<City> bestPath; //Хранит в себе лучший путь
        int bestPath_cost;
        int n;
        List<List<City>> Population; //Список популяции светлячков
        List<int> LightIntensities; //Яркость светлячков
        Heurisctic heuristic;
        Random rnd = new Random();
        List<City> previousPath; //Предыдущее решение
        private Object thislock = new Object();


        public event EventHandler IterationPassed;
        public virtual void OnIterationPassed()
        {
            if(IterationPassed != null)
            {
                IterationPassed(this, EventArgs.Empty);
            }
        }
        public Fireflies(List<City> Solution)
        {
            previousPath = new List<City>(Solution);
        }
        /// <summary>
        /// Возвращает полную длину получаемого тура
        /// </summary>
        /// <param name="path">запрашиваемый тур</param>
        /// <returns></returns>
        int SinglePathCost(List<City> path)
        {
            int sum = 0;
            path.Add(path[0]);
            for(int i =0; i < path.Count - 1; i++)
            {
                sum += City.getDestination(path[i], path[i + 1]);
            }
            return sum;
        }
        /// <summary>
        /// Основная функция алгоритма
        /// Используется для определения яркости светлячка
        /// </summary>
        /// <param name="individual">Светлячок, яркость которого определяется</param>
        /// <returns></returns>
        int F(List<City> individual)
        {
            return SinglePathCost(new List<City>(individual));
        }
        /// <summary>
        /// Метод определения яркости особей из начальной популяции
        /// </summary>
        void DetermineInitialLightIntensities()
        {
            foreach(List<City> x in Population)
            {
                LightIntensities.Add(F(x));
            }
        }
        /// <summary>
        /// Метод для определения яркости особей в новой популяции
        /// </summary>
        /// <param name="pop">Новая популяция</param>
        void DetermineTempLI(List<List<City>> pop)
        {
            LightIntensities.Clear();
            foreach (List<City> x in pop)
            {
                LightIntensities.Add(F(x));
            }
        }
        /// <summary>
        /// Проверяет тур на оптимальность
        /// </summary>
        /// <param name="index">Индекс проверяемого тура</param>
        void CheckIfBestSolution(int index)
        {
            int new_cost = LightIntensities[index];
            if (new_cost < bestPath_cost)
            {
                bestPath = Population[index];
                bestPath_cost = new_cost;
            }
        }
        /// <summary>
        /// Работает с полученной в ходе итерации популяции
        /// Принимает ее на вход и возвращает исходную популяцию из 10 лучших особей,
        /// с которой будет работать алгоритм на следующей итерации
        /// </summary>
        /// <param name="temp">Популяция, в которой будет осуществлен поиск</param>
        void FindNewPopulation(List<List<City>> temp)
        {
            List<List<City>> pop = new List<List<City>>(temp);
            List<int> li = new List<int>(LightIntensities);
            List<List<City>> tmp = new List<List<City>>();
            for (int i=0; i<10; i++)
            {
                int index = li.IndexOf(li.Min());
                tmp.Add(pop[index]);
                pop.RemoveAt(index);
                li.RemoveAt(index);
            }
            Population.Clear();
            Population = new List<List<City>>(tmp);
            LightIntensities.Clear();
            DetermineInitialLightIntensities();
        }
        /// <summary>
        /// Ищет лучшее решение в популяции
        /// </summary>
        void FindGlobalOptimum()
        {
            int index = LightIntensities.IndexOf(LightIntensities.Min());
            CheckIfBestSolution(index);
        }
        /// <summary>
        /// Возвращает перестановку, сгенерированную произвольно
        /// Используется при создании исходных решений
        /// </summary>
        /// <param name="count">Длина перестановки</param>
        /// <param name="cities">Элементы перестановки</param>
        /// <returns></returns>
        List<City> RandomPermutation(int count, List<City> cities)
        {
            List<City> perm = new List<City>();
            List<bool> isadded = new List<bool>();
            for(int i=0; i<count; i++)
            {
                isadded.Add(false);
            }
            int n = 0;
            while (n < count)
            {
                int index = rnd.Next(0, count);
                if (isadded[index] == false)
                {
                    perm.Add(cities[index]);
                    isadded[index] = true;
                    n++;
                }
            }

            return perm;
        }
        /// <summary>
        /// Генерирует исходные решения
        /// </summary>
        /// <param name="Cities">Список точек TSP</param>
        void GenerateInitialPopulation(List<City> Cities)
        {
            if (previousPath.Count > 0)
            {
                var tasks = new List<Task>();
                for (int i = 0; i < 5; i++)
                {
                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        var randPerm = RandomPermutation(Cities.Count, Cities);
                        lock (thislock)
                        {
                            Population.Add(randPerm);
                            OnIterationPassed();
                        }
                    }));

                }
                for (int i = 5; i < 9; i++)
                {
                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        var neighbour = heuristic.NearestNeighbour(Cities);
                        lock (thislock)
                        {
                            Population.Add(neighbour);
                            OnIterationPassed();
                        }
                    }));
                }
                Task.WaitAll(tasks.ToArray());
                Population.Add(previousPath);
                OnIterationPassed();
            }
            else
            {
                var tasks = new List<Task>();
                for (int i = 0; i < 5; i++)
                {
                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        var randPerm = RandomPermutation(Cities.Count, Cities);
                        lock (thislock)
                        {
                            Population.Add(randPerm);
                            OnIterationPassed();
                        }
                    }));
                    
                }
                for (int i = 5; i < 10; i++)
                {
                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        var neighbour = heuristic.NearestNeighbour(Cities);
                        lock (thislock)
                        {
                            Population.Add(neighbour);
                            OnIterationPassed();
                        }
                    }));   
                }
                Task.WaitAll(tasks.ToArray());
            }
        }
        /// <summary>
        /// Расстояние Хэмминга между двумя перестановками
        /// Возвращает список, где позициям, отличающимся,
        /// соответствует знаечение true, а для одинаковых - false
        /// </summary>
        /// <param name="a">Более яркий светлячок</param>
        /// <param name="b">Менее яркий светлячок</param>
        /// <returns></returns>
        List<bool> HammingDistanceInfo(List<City> a, List<City> b)
        {
            List<bool> difference = new List<bool>();
            for(int i = 0; i<a.Count; i++)
            {
                if (a[i] != b[i])
                {
                    difference.Add(true);
                } else
                {
                    difference.Add(false);
                }
            }

            return difference;
        }
        /// <summary>
        /// Подсчитывает расстояние между двумя светлячками, используя расстояние Хэмминга
        /// </summary>
        /// <param name="a">Более яркий светлячок</param>
        /// <param name="b">Менее яркий светлячок</param>
        /// <returns></returns>
        int HammingDistance(List<City> a, List<City> b)
        {
            List<bool> difference = HammingDistanceInfo(a, b);
            int n = 0;
            foreach (bool val in difference)
            {
                if (val) n++;
            }
            return n;
        }
        /// <summary>
        /// Функция привлекательности светлячка
        /// </summary>
        /// <param name="index">Индекс светлячка</param>
        /// <param name="r">Расстояние</param>
        /// <returns>Возвращает число, равное привлекательности светлячка</returns>
        double I(int index, int r)
        {
            return LightIntensities[index] * Math.Exp(-1.0 * 0.1 * r * r);
        }
        /// <summary>
        /// Функция движения светлячка
        /// </summary>
        /// <param name="Firefly">Светлячок</param>
        /// <param name="L">Шаг движения</param>
        /// <returns>Возвращает светлячка, полученного в результате движения старого</returns>
        List<City> MoveFirefly(List<City> Firefly, int L)
        {
            List<City> temp = new List<City>(Firefly);
            int random_index = rnd.Next(0, Firefly.Count);

            if (random_index + L < Firefly.Count)
            {
                temp.Reverse(random_index, L + 1);
            }
            else //consider whether leaving or deleting this part 
            {
                int els_to_move = (random_index + L) - Firefly.Count + 1;
                for (int i = 0; i < els_to_move; i++)
                {
                    temp.Add(temp[0]);
                    temp.RemoveAt(0);
                }
                temp.Reverse(random_index - els_to_move, L + 1);
                for (int i = 0; i < els_to_move; i++)
                {
                    temp.Insert(0, temp[temp.Count - 1]);
                    temp.RemoveAt(temp.Count - 1);
                }
            }

            return temp;
        }
        /// <summary>
        /// Метод поиска самого яркого светлячка
        /// </summary>
        /// <param name="index">Индекс особи, для которой осуществляется поиск</param>
        /// <returns>Возвращает найденного светлячка или же null, если светлячок не видит более яркой особи, чем он сам</returns>
        List<City> GetTheBrightestFirefly(int index)
        {
            List<City> temp = new List<City>();
            for (int i = 0; i < Population.Count; i++)
            {
                int r = HammingDistance(Population[i], Population[index]);

                if (I(i, r) > I(index, r))
                {
                    temp = Population[i];
                }
            }
            return temp;
        }
        List<City> Get_the_brightest_firefly_2(int index)
        {
            List<City> temp = new List<City>();
            double temp_I = -1;
            for (int i = 0; i < Population.Count; i++)
            {
                int r = HammingDistance(Population[i], Population[index]);

                if (I(i, r) > I(index, r))
                {
                    if(I(i,r)>temp_I)
                    {
                        temp = Population[i];
                    }
                }
            }
            return temp;
        }
        /// <summary>
        /// Главный метод класса. Запускает алгоритм светлячков.
        /// </summary>
        /// <param name="Points">Список городов TSP</param>
        /// <returns>Возвращает лучший найденный путь по завершению работы алгоритма</returns>
        public List<City> start(List<City> Points)
        {
            bestPath = new List<City>();
            heuristic = new Heurisctic();
            LightIntensities = new List<int>();
            Population = new List<List<City>>();
            List<List<City>> temp = new List<List<City>>();
            OnIterationPassed();

            bestPath = RandomPermutation(Points.Count, Points);
            bestPath_cost = SinglePathCost(new List<City>(bestPath));
            GenerateInitialPopulation(Points);
            DetermineInitialLightIntensities();
            n = 0;
            while (n < 500)
            {
                FindGlobalOptimum();
                Parallel.For(0, 10, (i) =>
                  {
                      List<City> f = GetTheBrightestFirefly(i);
                      if (f.Count != 0)
                      {
                          int r = HammingDistance(Population[i], f);
                          int L = rnd.Next(2, r);
                          for (int j = 0; j < 8; j++)
                          {
                              List<City> fnew = MoveFirefly(Population[i], L);
                              lock (thislock)
                              {
                                  temp.Add(fnew);
                              }
                          }
                      }
                      else
                      {
                          int r = Population[i].Count;
                          int L = rnd.Next(2, r);
                          for (int j = 0; j < 8; j++)
                          {
                              List<City> fnew = MoveFirefly(Population[i], L);
                              lock (thislock)
                              {
                                  temp.Add(fnew);
                              }
                          }
                      }
                  });
                temp.Add(bestPath);
                DetermineTempLI(temp);
                FindNewPopulation(temp);
                temp.Clear();
                n++;
                OnIterationPassed();
            }
           // Find_global_optimum();
            return bestPath;
        }
        
    }
}
