namespace SimpleShop.App.IO.Contracts
{
    public interface IConsoleWriter
    {
        void Write(object obj);

        void WriteLine(object obj);

        void WriteLine();

        void ClearConsole();
    }
}
