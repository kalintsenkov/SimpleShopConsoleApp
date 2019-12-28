namespace SimpleShop.App.Commands
{
    using Contracts;
    using IO.Contracts;
    using Services.Contracts;

    public class LoginCommand : ICommand
    {
        private readonly IConsoleReader reader;
        private readonly IConsoleWriter writer;
        private readonly IUserSessionService userSessionService;

        public LoginCommand(
            IConsoleReader reader,
            IConsoleWriter writer,
            IUserSessionService userSessionService)
        {
            this.reader = reader;
            this.writer = writer;
            this.userSessionService = userSessionService;
        }

        public string Execute()
        {
            if (this.userSessionService.IsLoggedIn())
            {
                return "Please logout!";
            }

            this.writer.Write("Enter username: ");
            var username = this.reader.ReadLine();

            this.writer.Write("Enter password: ");
            var password = this.reader.ReadLine();

            var user = this.userSessionService.Login(username, password);

            if (user == null)
            {
                return "Invalid username or password!";
            }

            return $"User {user.Username} login successfully!";
        }
    }
}
