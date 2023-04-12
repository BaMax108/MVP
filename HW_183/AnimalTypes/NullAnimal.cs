using LibraryInterfaces;

namespace HW_183.AnimalTypes
{
    class NullAnimal : IAnimal
    {
        public NullAnimal()
        {
            Class = "Неизвестный подтип";
            Order = "Неизвестный отряд";
            Family = "Неизвестное семейство";
            Genus = "Неизвестный род";
            Species = "Неизвестный вид";
        }

        public string Class { get; }
        public string Order { get; }
        public string Family { get; }
        public string Genus { get; }
        public string Species { get; }
    }
}
