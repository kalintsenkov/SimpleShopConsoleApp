namespace SimpleShop.AdminApp.Core
{
    using System;
    using System.Text;
    using Commands.Contracts;
    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IConsoleReader reader;
        private readonly IConsoleWriter writer;
        private readonly ICommandParser commandParser;

        public Engine(
            IConsoleReader reader, 
            IConsoleWriter writer, 
            ICommandParser commandParser)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
        }

        public void Run()
        {
            while (true)
            {
                var menuMessages = this.GetMenuMessages();

                this.writer.WriteLine(menuMessages);

                this.writer.Write("Enter command: ");
                var commandName = this.reader.ReadLine();

                try
                {
                    var command = this.commandParser.Parse(commandName);

                    var message = command.Execute();

                    this.writer.ClearConsole();
                    this.writer.WriteLine(message);
                }
                catch (ArgumentException ae)
                {
                    this.writer.ClearConsole();
                    this.writer.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    this.writer.ClearConsole();
                    this.writer.WriteLine(ioe.Message);
                }
                catch (Exception)
                {
                    this.writer.ClearConsole();
                    this.writer.WriteLine("Something went wrong... Please try again.");
                    break;
                }
            }
        }

        private string GetMenuMessages()
        {
            var sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("--< ADMIN MODE >--");
            sb.AppendLine("Possible commands:");
            sb.AppendLine("-- Login");
            sb.AppendLine("-- Register");
            sb.AppendLine();
            sb.AppendLine("-- ListProducts");
            sb.AppendLine("-- ListBlackFridayProducts");
            sb.AppendLine("-- AddProduct");
            sb.AppendLine("-- EditProductPrice");
            sb.AppendLine("-- EditProductMinimalPrice");
            sb.AppendLine("-- IncreaseProductQuantity");
            sb.AppendLine("-- DeleteProduct");
            sb.AppendLine("-- StartBlackFriday");
            sb.AppendLine("-- StopBlackFriday");
            sb.AppendLine("-- GetProductQuantity");
            sb.AppendLine();
            sb.AppendLine("-- Logout");
            sb.AppendLine("-- Exit");
            sb.AppendLine();

            return sb.ToString().TrimEnd();
        }
    }
}
