namespace SimpleShop.AdminApp.Commands
{
    using Contracts;
    using IO.Contracts;
    using Services.Contracts;

    public class LoginCommand : ICommand
    {
        private readonly IConsoleReader reader;
        private readonly IConsoleWriter writer;
        private readonly IAdminSessionService adminSessionService;

        public LoginCommand(
            IConsoleReader reader,
            IConsoleWriter writer,
            IAdminSessionService adminSessionService)
        {
            this.reader = reader;
            this.writer = writer;
            this.adminSessionService = adminSessionService;
        }

        public string Execute()
        {
            if (this.adminSessionService.IsLoggedIn())
            {
                return "Please logout!";
            }

            this.writer.Write("Enter username: ");
            var username = this.reader.ReadLine();

            this.writer.Write("Enter password: ");
            var password = this.reader.ReadLine();

            var admin = this.adminSessionService.Login(username, password);

            if (admin == null)
            {
                return "Invalid username or password!";
            }

            return $"Admin {admin.Username} login successfully!";
        }
    }
}
