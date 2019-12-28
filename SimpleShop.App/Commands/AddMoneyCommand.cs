namespace SimpleShop.App.Commands
{
    using Contracts;
    using IO.Contracts;
    using Services.Contracts;

    public class AddMoneyCommand : ICommand
    {
        private readonly IConsoleReader reader;
        private readonly IConsoleWriter writer;
        private readonly IUserService userService;
        private readonly IUserSessionService userSessionService;

        public AddMoneyCommand(
            IConsoleReader reader,
            IConsoleWriter writer,
            IUserService userService,
            IUserSessionService userSessionService)
        {
            this.reader = reader;
            this.writer = writer;
            this.userService = userService;
            this.userSessionService = userSessionService;
        }

        public string Execute()
        {
            if (!this.userSessionService.IsLoggedIn())
            {
                return "You are not logged in!";
            }

            this.writer.Write("Enter money: ");
            var money = decimal.Parse(this.reader.ReadLine());

            var user = this.userSessionService.User;

            this.userService.AddMoney(user.Id, money);

            return $"You successfully added ${money} to your balance";
        }
    }
}
