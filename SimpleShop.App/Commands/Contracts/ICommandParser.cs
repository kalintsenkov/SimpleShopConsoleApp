namespace SimpleShop.App.Commands.Contracts
{
    public interface ICommandParser
    {
        ICommand Parse(string commandName);
    }
}
