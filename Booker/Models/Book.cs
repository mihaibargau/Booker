using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booker.Models
{
    public class Book
    {  
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

    }
}
