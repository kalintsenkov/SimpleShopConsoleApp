namespace SimpleShop.AdminApp.Commands
{
    using Contracts;
    using Services.Contracts;

    public class LogoutCommand : ICommand
    {
        private readonly IAdminSessionService adminSessionService;

        public LogoutCommand(IAdminSessionService adminSessionService)
        {
            this.adminSessionService = adminSessionService;
        }

        public string Execute()
        {
            if (!this.adminSessionService.IsLoggedIn())
            {
                return "You are not logged in!";
            }

            this.adminSessionService.Logout();

            return "You successfully logged out!";
        }
    }
}
