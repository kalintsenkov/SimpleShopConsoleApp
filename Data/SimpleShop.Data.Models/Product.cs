namespace SimpleShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static ValidationConstants.Product;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal MinimalPrice { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public bool IsOnBlackFriday { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<ProductOrder> Orders { get; set; } = new HashSet<ProductOrder>();
    }
}
