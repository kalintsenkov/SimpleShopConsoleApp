namespace SimpleShop.AdminApp.Commands
{
    using Contracts;
    using IO.Contracts;
    using Services.Contracts;

    public class RegisterCommand : ICommand
    {
        private readonly IConsoleReader reader;
        private readonly IConsoleWriter writer;
        private readonly IAdminService adminService;

        public RegisterCommand(
            IConsoleReader reader, 
            IConsoleWriter writer, 
            IAdminService adminService)
        {
            this.reader = reader;
            this.writer = writer;
            this.adminService = adminService;
        }

        public string Execute()
        {
            this.writer.Write("Enter name: ");
            var name = this.reader.ReadLine();
            this.writer.Write("Enter username: ");
            var username = this.reader.ReadLine();
            this.writer.Write("Enter password: ");
            var password = this.reader.ReadLine();

            var isUsernameAlreadyExists = this.adminService.Exists(username);

            if (isUsernameAlreadyExists)
            {
                return $"Username '{username}' already exists. Please try something else.";
            }

            this.adminService.Create(username, password, name);

            return $"Admin {username} registered successfully. You can now login with your username and password.";
        }
    }
}
