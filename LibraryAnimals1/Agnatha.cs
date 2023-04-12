using LibraryInterfaces;

namespace LibraryAnimals1 
{
    public class Agnatha : IAnimal
    {
        public Agnatha(string _order, string _family, string _genus, string _species)
        {
            Class = "Бесчелюстные";
            Order = _order;
            Family = _family;
            Genus = _genus;
            Species = _species;
        }

        public string Class { get; private set; }
        public string Order { get; private set; }
        public string Family { get; private set; }
        public string Genus { get; private set; }
        public string Species { get; private set; }
    }
}
