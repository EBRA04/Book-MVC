using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AIC.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Please Enter your name")]
        [MinLength(3)]
        [Column(TypeName = "NVarChar(30)")]
        public string? Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Prompt = "YYYY/MM/DD")]
        [DisplayFormat(DataFormatString = "dd.MM.yyyy")]
        public DataType Birthday { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        [Compare(nameof(Email), ErrorMessage = " Does not match ")]
        public string? EmailConfirmation { get; set; }
        [Phone]
        public string? Phone { get; set; }
        public EGender Gernder { get; set; }
        public IEnumerable<AuthorShip>? AuthorShips { get; set; }
    }
}
