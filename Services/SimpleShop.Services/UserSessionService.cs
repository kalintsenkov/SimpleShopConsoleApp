namespace SimpleShop.Services
{
    using Contracts;
    using Models.User;

    public class UserSessionService : BaseService, IUserSessionService
    {
        private readonly IUserService userService;

        public UserSessionService(IUserService userService)
        {
            this.userService = userService;
        }

        public UserServiceModel User { get; private set; }

        public UserServiceModel Login(string username, string password)
        {
            var hashedPassword = this.GetSha256Hash(password);

            var user = this.userService.FindByUsernameAndPassword(username, hashedPassword);

            this.User = user;

            return this.User;
        }

        public bool IsLoggedIn() => this.User != null;

        public void Logout() => this.User = null;
    }
}
