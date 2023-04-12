using HW_183.Saving;
using LibraryInterfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HW_183.Models
{
    class Model : IModel
    {
        AnimalFactory f = new AnimalFactory();

        public string[] AnimalTypes { get; private set; }
        public ObservableCollection<IAnimal> AnimalsList { get; private set; }

        public Model()
        {
            AnimalsList = new ObservableCollection<IAnimal>();
            AnimalTypes = new string[f.AnimalTypes.Count];
            for (int i = 0; i < AnimalTypes.Length; i++)
            {
                AnimalTypes[i] = f.AnimalTypes[i].Name;
            }
            Array.Sort(AnimalTypes);
        }

        /// <summary>
        /// Добавление элемета IAnimal в существующую коллекцию
        /// </summary>
        /// <param name="animal"></param>
        public void AddAnimal(IAnimal animal)
        {
            if (animal != null) AnimalsList.Add(animal);
        }

        /// <summary>
        /// Создание элемента IAnimal на основе указанного типа и набора параметров
        /// </summary>
        /// <param name="type">Тип нового элемента</param>
        /// <param name="args">Набор параметров</param>
        public void CreateAnimal(string type, object[] args)
        {
            AddAnimal(f.CreateNewType(type, args));
        }

        /// <summary>
        /// Заполнение коллекции AnimalsList на основе существующего репозитория
        /// </summary>
        public void CreateAnimals()
        {
            foreach (var e in new Repository().AnimalDictionary)
                CreateAnimal(e.Value, e.Key);
        }

        /// <summary>
        /// Генерация дополнительных элементов коллекции
        /// </summary>
        /// <param name="count"></param>
        public void GenerateMoreAnimals(int count)
        {
            // Временный список коллекций IAnimal для параллельного добавления новых эклемпляров
            List<List <IAnimal>> lists = new List<List<IAnimal>>();

            List<Task> tasks = new List<Task>();
            foreach(var at in f.AnimalTypes)
            {
                tasks.Add(new Task (() => 
                {
                    List<IAnimal> list = new List<IAnimal>() { };
                    for (int i = 1; i <= count; i++)
                    {
                        list.Add(f.CreateNewType(at.Name,
                            new object[] { $"Отряд {i}", $"Семейство {i}", $"Род {i}", $"Вид {i}" }));
                    }
                    lists.Add(list);
                }));
            }
            Parallel.ForEach(tasks, task => task.Start());
            Task.WaitAll(tasks.ToArray());

            foreach (List<IAnimal> list in lists)
                foreach(IAnimal element in list) AnimalsList.Add(element);
        }

        /// <summary>
        /// Изменение элемента с указанным индексом
        /// </summary>
        /// <param name="type">Тип элемента</param>
        /// <param name="args">Набор параметров</param>
        /// <param name="index">Индекс элемента</param>
        public void Edit(string type, object[] args, int index)
        {
            AnimalsList[index] = f.CreateNewType(type, args);
        }

        /// <summary>
        /// Удаление элемента с указанным индексом
        /// </summary>
        /// <param name="index">Индекс элемента</param>
        public void Remove(int index)
        {
            AnimalsList.RemoveAt(index);
        }

        /// <summary>
        /// Сохранение в формат txt
        /// </summary>
        public void SaveToTxt()
        {
            new SaveToTxt().Save(AnimalsList);
        }

        /// <summary>
        /// Сохранение в формат xlsx
        /// </summary>
        public void SaveToExcel()
        {
            new SaveToExcel().Save(AnimalsList);
        }

        /// <summary>
        /// Сохранение в формат csv
        /// </summary>
        public void SaveToCSV()
        {
            new SaveToCsv().Save(AnimalsList);
        }
    }
}