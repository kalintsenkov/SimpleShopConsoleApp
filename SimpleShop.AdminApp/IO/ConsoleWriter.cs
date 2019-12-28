namespace SimpleShop.AdminApp.IO
{
    using System;
    using Contracts;

    public class ConsoleWriter : IConsoleWriter
    {
        public void Write(object obj) => Console.Write(obj);

        public void WriteLine(object obj) => Console.WriteLine(obj);

        public void WriteLine() => Console.WriteLine();

        public void ClearConsole() => Console.Clear();
    }
}