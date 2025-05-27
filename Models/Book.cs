using System.ComponentModel.DataAnnotations;

namespace AIC.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Please enter book title")]
        public string? Title { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        [DataType(DataType.Currency)]

        public double Price { get; set; }

        public EGenres Genres { get; set; }

        public IEnumerable<AuthorShip>? AuthorShips { get; set; }
    }
}
