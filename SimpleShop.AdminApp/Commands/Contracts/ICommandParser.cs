namespace SimpleShop.AdminApp.Commands.Contracts
{
    public interface ICommandParser
    {
        ICommand Parse(string commandName);
    }
}
