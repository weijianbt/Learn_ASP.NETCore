using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcTutorial.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength =3)]
        [Required]
        public string? Title { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Genre must start with at least one capital letter. And remaining characters must be alphabets.")]
        public string? Genre { get; set; }
        
        [Display(Name = "Price (RM)")]
        [Range(1,100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Display(Name ="Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$", ErrorMessage ="Rating must start with at least one capital letter.")]
        [StringLength(5)]
        [Required]
        public string? Rating { get; set; }
    }
}
