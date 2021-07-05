using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace APITest.Domain
{
    public class BaseStats
    {
        public int Id { get; set; }
        [JsonProperty("HP")]
        public long Hp { get; set; }

        [JsonProperty("Attack")]
        public long Attack { get; set; }

        [JsonProperty("Defense")]
        public long Defense { get; set; }

        [JsonProperty("Sp. Attack")]
        public long SpAttack { get; set; }

        [JsonProperty("Sp. Defense")]
        public long SpDefense { get; set; }

        [JsonProperty("Speed")]
        public long Speed { get; set; }
    }
}
