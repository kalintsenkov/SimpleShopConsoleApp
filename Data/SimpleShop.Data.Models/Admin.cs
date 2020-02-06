namespace SimpleShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.ValidationConstants.Admin;

    public class Admin
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }
    }
}
