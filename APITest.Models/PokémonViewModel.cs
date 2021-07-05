using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APITest.Models
{
    public class PokémonViewModel
    {
        public long Id { get; set; }

        [Required]
        public NameViewModel Name { get; set; }

        [Required]
        public List<string> Type { get; set; }

        [Required]
        public BaseStatsViewModel Stats { get; set; }
    }
}
