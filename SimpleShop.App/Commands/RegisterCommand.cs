namespace SimpleShop.App.Commands
{
    using Contracts;
    using IO.Contracts;
    using Services.Contracts;

    public class RegisterCommand : ICommand
    {
        private readonly IConsoleReader reader;
        private readonly IConsoleWriter writer;
        private readonly IUserService userService;

        public RegisterCommand(
            IConsoleReader reader, 
            IConsoleWriter writer, 
            IUserService userService)
        {
            this.reader = reader;
            this.writer = writer;
            this.userService = userService;
        }

        public string Execute()
        {
            this.writer.Write("Enter first name: ");
            var firstName = this.reader.ReadLine();
            this.writer.Write("Enter last name: ");
            var lastName = this.reader.ReadLine();
            this.writer.Write("Enter username: ");
            var username = this.reader.ReadLine();
            this.writer.Write("Enter password: ");
            var password = this.reader.ReadLine();
            this.writer.Write("Enter email: ");
            var email = this.reader.ReadLine();
            this.writer.Write("Enter balance: ");
            var balance = decimal.Parse(this.reader.ReadLine());

            var existingUsername = this.userService.FindByUsername(username);
            var existingEmail = this.userService.FindByEmail(email);

            if (existingUsername != null)
            {
                return $"Username '{username}' already exists. Please try something else.";
            }

            if (existingEmail != null)
            {
                return $"Email '{email}' already exists. Please try something else.";
            }

            this.userService.Create(firstName, lastName, username, password, email, balance);

            return $"User {username} registered successfully. You can now login with your username and password.";
        }
    }
}
