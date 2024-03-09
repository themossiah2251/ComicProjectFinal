using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicProjectFinal.Models
{
    [Table("OrderStatus")]
    public class OrderStatus
    {
        [Key]
        public int OrderStatusId { get; set; }
        public int? StatusId { get; set; }
       


        [Required,MaxLength(50)]
        public string? StatusName { get; set; }
    }
    public enum OrderStatuses
    {
        Pending = 1,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }
}
