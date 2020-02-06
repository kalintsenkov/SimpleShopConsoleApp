namespace SimpleShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Common.ValidationConstants.User;

    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(EmailMaxLength)]
        [EmailAddress]
        public string Email { get; set; }

        public decimal Balance { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
