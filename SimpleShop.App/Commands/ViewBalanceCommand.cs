namespace SimpleShop.App.Commands
{
    using Contracts;
    using Services.Contracts;

    public class ViewBalanceCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly IUserSessionService userSessionService;

        public ViewBalanceCommand(
            IUserService userService, 
            IUserSessionService userSessionService)
        {
            this.userService = userService;
            this.userSessionService = userSessionService;
        }

        public string Execute()
        {
            if (!this.userSessionService.IsLoggedIn())
            {
                return "You are not logged in!";
            }

            var username = this.userSessionService.User.Username;

            var user = this.userService.FindByUsername(username);

            var balance = user.Balance;

            return $"Your balance is {balance:F2}";
        }
    }
}
