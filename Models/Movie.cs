using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        [Range(1,100, ErrorMessage = "The field Number in Stock must be between 1 and 100.")]
        [Display(Name = "Number in stock")]
        [Required]
        public int NumberInStock { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public byte NumberAvailable { get; set; }
    }
    
}