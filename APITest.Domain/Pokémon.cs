using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        [JsonConverter(typeof(StringEnumConverter))]
        public List<EPokémonType> Type { get; set; }

        [JsonProperty("base")]
        public BaseStats Stats { get; set; }

        [JsonIgnore]
        public string SpriteUrl { get; set; }

        [JsonIgnore]
        public string ThumbnailUrl { get; set; }
    }
}
