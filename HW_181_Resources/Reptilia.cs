using LibraryInterfaces;

namespace HW_181_Resources
{
    public class Reptilia : IAnimal
    {
        public Reptilia(string _order, string _family, string _genus, string _species)
        {
            Class = "Пресмыкающиеся";
            Order = _order;
            Family = _family;
            Genus = _genus;
            Species = _species;
        }

        public string Class { get; }
        public string Order { get; private set; }
        public string Family { get; private set; }
        public string Genus { get; private set; }
        public string Species { get; private set; }
    }
}
