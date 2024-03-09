using ComicProjectFinal.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicProjectFinal.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(100)]
        public string? CategoryName { get; set; }
        public int DropDown { get; set; }

        public List<Products> Products { get; set; }
    }
}
