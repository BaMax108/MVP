using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using LibraryInterfaces;

namespace HW_183.Saving
{
    class SaveToTxt
    {
        /// <summary>
        /// Сохранение данных
        /// </summary>
        /// <param name="listAnimals"></param>
        public void Save(ObservableCollection<IAnimal> listAnimals)
        {
            if (listAnimals[0] == null) return;

            StreamWriter file = new StreamWriter ($"ListAnimals_{ DateTime.Now.ToString("yyyyMMdd-HHmmss")}.txt", append: true, Encoding.Default);
            
            // Запись в первую строку всех наименований полей из первого элемента коллекциии
            foreach (PropertyInfo prop in listAnimals[0].GetType().GetProperties())
                file.Write(prop.Name.ToString() + ";");
            file.WriteLine();

            // Построчная запись всех элементов коллекции listAnimals
            foreach (var line in listAnimals)
            {
                foreach (PropertyInfo prop in line.GetType().GetProperties())
                    file.Write(prop.GetValue(line, null).ToString() + ";");
                file.WriteLine();
            }

            file.Dispose();
        }
    }
}
