using LibraryInterfaces;
using System.Collections.ObjectModel;

namespace HW_183.UI
{
    interface IView
    {
        ObservableCollection<IAnimal> AnimalsList { get; }

    }
}
