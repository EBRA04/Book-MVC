using System.ComponentModel.DataAnnotations;

namespace AIC.Models
{
    public class AuthorShip
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublishDate { get; set; }
        public ERole Role { get; set; }
        public Author? Author { get; set; }
        public Book? Book { get; set; }
    }
}
