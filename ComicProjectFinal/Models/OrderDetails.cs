using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicProjectFinal.Models
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        [ForeignKey("Products")]
        public int ProductsId { get; set; }
        [Required]
        public int? Quantity { get; set; }
        public double? UnitPrice { get; set; }
       
        public Products Products { get; set; }
        public Orders Orders { get; set; }
    }
}
