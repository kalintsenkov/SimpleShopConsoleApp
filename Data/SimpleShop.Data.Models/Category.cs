namespace SimpleShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static ValidationConstants.Category;

    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
