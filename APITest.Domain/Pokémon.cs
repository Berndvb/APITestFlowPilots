using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace APITest.Domain
{
    public class Pokémon
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("type")]
<<<<<<< HEAD
        public List<PokémonType> Type { get; set; }
=======
        public List<EPokémonType> Type { get; set; }
>>>>>>> parent of a6f9865 (chris2)

        [JsonProperty("base")]
        public BaseStats Stats { get; set; }

        [JsonIgnore]
        public string SpriteUrl { get; set; }

        [JsonIgnore]
        public string ThumbnailUrl { get; set; }
    }
}
