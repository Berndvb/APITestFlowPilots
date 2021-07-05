using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace APITest.Models
{
    public class NameViewModel
    {
        [Required]
        public string English { get; set; }
    }
}
