using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicProjectFinal.Models
{
    [Table("CartDetails")]
    public class CartDetails
    {
        [Key]
        public int CartDetrailsId { get; set; }
        [Required]
        public int CartId { get; set; }
        [Required]
        public int ProductsId { get; set; }
        public int? Quantity { get; set; }
        public double? UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        [ForeignKey("ProductsId")]
        public Products Products { get; set; }
        public Cart Carts { get; set; }

    }
}
