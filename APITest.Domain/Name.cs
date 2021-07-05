using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace APITest.Domain
{
    public class Name
    {
        public int Id { get; set; }
        [JsonProperty("english")]
        public string English { get; set; }

        [JsonProperty("japanese")]
        public string Japanese { get; set; }

        [JsonProperty("chinese")]
        public string Chinese { get; set; }

        [JsonProperty("french")]
        public string French { get; set; }
    }
}
