namespace SimpleShop.AdminApp.IO
{
    using System;
    using Contracts;

    public class ConsoleReader : IConsoleReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
