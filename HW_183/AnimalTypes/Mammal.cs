using LibraryInterfaces;

namespace HW_183.AnimalTypes
{
    class Mammal : IAnimal
    {
        public Mammal(string _order, string _family, string _genus, string _species)
        {
            Class = "Млекопитающие";
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
