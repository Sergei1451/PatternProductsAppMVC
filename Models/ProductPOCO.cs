using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatternProduct.Models
{
    public class ProductPOCO
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 6)]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string? CategoryProduct { get; set; }
        [Range(1,100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(10)]
        [Required]
        public string? Rating { get; set; }
    }
}
