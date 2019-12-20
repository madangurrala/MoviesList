using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Director { get; set; }
        public string Production { get; set; }

    }
}
