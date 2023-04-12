using HW_183.AnimalTypes;
using LibraryInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HW_183
{
    interface IAnimalFactory
    {
        IAnimal CreateNewType(string type, object[] args);
    }

    class AnimalFactory : IAnimalFactory
    {
        public List<Type> AnimalTypes { get; private set; }

        public AnimalFactory()
        {
            GetAllAnimalTypes();
        }

        /// <summary>
        /// Получение всех доступных типов животных
        /// </summary>
        private void GetAllAnimalTypes()
        {
            // Получение типов из каталога "AnimalTypes" без учета типов, в названии которых присутствует Null
            AnimalTypes = Assembly.GetExecutingAssembly().GetTypes()
                   .Where(t => t.Namespace.Contains("AnimalTypes") & !t.Name.Contains("Null")).ToList();

            // Получение типов из каталога "new types" по расширению файлов
            foreach (string i in Directory.GetFiles(Directory
                                       .GetCurrentDirectory() + "\\new types")
                                       .Where(e => Path.GetExtension(e) == ".dll"))
            {
                AnimalTypes.AddRange(Assembly.LoadFrom(i).GetTypes().ToList());
            }
        }

        /// <summary>
        /// Создание экземпляра IAnimal с заданным именем типа (если указанный тип отсутствует, создается NullObject)
        /// </summary>
        /// <param name="type">Тип нового экземпляра</param>
        /// <param name="args">Набор параметров для</param>
        /// <returns></returns>
        public IAnimal CreateNewType(string type, object[] args)
        {
            foreach (var i in AnimalTypes)
                if (i.Name == type)
                    return Activator.CreateInstance(i, args) as IAnimal;
            return new NullAnimal();
        }
    }
}
