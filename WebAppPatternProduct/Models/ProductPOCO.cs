using System.ComponentModel.DataAnnotations;

namespace WebAppPatternProduct.Models
{
    public class ProductPOCO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? CategoryProduct { get; set; }
        public decimal Price { get; set; }
    }
}
