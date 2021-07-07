using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace APITest.Domain
{
    public class DummyPokémon
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("type")]
        public List<string> Type { get; set; }

        [JsonProperty("base")]
        public BaseStats Stats { get; set; }

        [JsonIgnore]
        public string SpriteUrl { get; set; }

        [JsonIgnore]
        public string ThumbnailUrl { get; set; }
    }
}
