using ComicProjectFinal.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicProjectFinal.Models
{
    [Table("Brand")]
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
