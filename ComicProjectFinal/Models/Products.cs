
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicProjectFinal.Models
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public int ProductsId { get; set; }
            [Required]

            public int? BrandId { get; set; }
            [Required]
            public string? BrandName { get; set; }
            public string? CategoryName { get; set; }
            
            public int CategoryId { get; set; }


            public string? ProductName { get; set; }
            public double? Price { get; set; }
          public string? Images { get; set; }

        public Category Categories { get; set; }
        public Brand Brands { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }

        public List<CartDetails> CartDetails { get; set; }

    }
    }



