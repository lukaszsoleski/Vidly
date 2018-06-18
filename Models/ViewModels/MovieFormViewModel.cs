using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models.ViewModels
{
    public class MovieFormViewModel
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime? ReleaseDate { get; set; }
        [Range(1, 100, ErrorMessage = "The field Number in Stock must be between 1 and 100.")]
        [Display(Name="Number in stock")]
        [Required]
        public int? NumberInStock { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        public Genre Genre { get; set; }


        public IEnumerable<Genre> Genres { get; set; }
        public string Title
        {
            get {

                return (Id != 0) ? "Edit" : "Add";
                        
            }

        }
        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}