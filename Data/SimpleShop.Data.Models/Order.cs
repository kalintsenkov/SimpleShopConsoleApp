namespace SimpleShop.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<ProductOrder> Products { get; set; } = new HashSet<ProductOrder>();
    }
}
