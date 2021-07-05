using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace APITest.Models
{
    public class BaseStatsViewModel
    {
        [Required]
        public long Hp { get; set; }

        [Required]
        public long Attack { get; set; }

        [Required]
        public long Defense { get; set; }

        [Required]
        public long SpAttack { get; set; }

        [Required]
        public long SpDefense { get; set; }

        [Required]
        public long Speed { get; set; }
    }
}
