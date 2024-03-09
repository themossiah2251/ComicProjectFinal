using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicProjectFinal.Models
{
    [Table("Cart")]
    public class Cart
    {
        public int Id { get; set; }



        [Required]
        public string? UserId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<CartDetails> CartDetails { get; set; }
        public string? CartItems { get; set; }
    }
}
