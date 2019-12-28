namespace SimpleShop.Services.Models.User
{
    public class UserServiceModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public decimal Balance { get; set; }
    }
}
