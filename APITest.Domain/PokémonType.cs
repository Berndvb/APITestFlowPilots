using System.Collections.Generic;


namespace APITest.Domain
{
    public class PokémonType
    {
        public int Id { get; set; }
        public EPokémonType Type { get; set; }
        public List<Pokémon> Pokémons { get; set; }
    }
}
