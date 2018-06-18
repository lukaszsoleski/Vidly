using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models
{
    public class Genre
    {
        [Key]
        [Display(Name="Movie Genre")]
        public int GenreId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
    }
}