namespace SimpleShop.AdminApp.Commands
{
    using System;
    using Contracts;

    public class ExitCommand : ICommand
    {
        public string Execute()
        {
            Environment.Exit(0);

            return string.Empty;
        }
    }
}
