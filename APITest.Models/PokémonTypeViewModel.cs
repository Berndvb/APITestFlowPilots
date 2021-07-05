using APITest.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace APITest.Models
{
    public class PokémonTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        public PokémonTypesEnum Type { get; set; }
    }
}
