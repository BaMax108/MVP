using LibraryInterfaces;
using System.Collections.ObjectModel;

namespace HW_183.Models
{
    interface IModel
    {
        string[] AnimalTypes { get; }
        ObservableCollection<IAnimal> AnimalsList { get; }

        void AddAnimal(IAnimal animal);

        void CreateAnimal(string type, object[] args);

        void CreateAnimals();

        void Edit(string type, object[] args, int index);

        void Remove(int index);

        void GenerateMoreAnimals(int count);

        void SaveToTxt();

        void SaveToExcel();

        void SaveToCSV();
    }
}
