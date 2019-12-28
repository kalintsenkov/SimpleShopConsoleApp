namespace SimpleShop.App.Commands
{
    using Contracts;
    using Services.Contracts;

    public class LogoutCommand : ICommand
    {
        private readonly IUserSessionService userSessionService;

        public LogoutCommand(IUserSessionService userSessionService)
        {
            this.userSessionService = userSessionService;
        }

        public string Execute()
        {
            if (!this.userSessionService.IsLoggedIn())
            {
                return "You are not logged in!";
            }

            this.userSessionService.Logout();

            return "You successfully logged out!";
        }
    }
}
