namespace SimpleShop.AdminApp.Commands
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandParser : ICommandParser
    {
        private const string CommandPostfix = "Command";

        private readonly IServiceProvider serviceProvider;

        public CommandParser(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommand Parse(string commandName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly
                .GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(ICommand)))
                .ToArray();

            var commandType = types
                .FirstOrDefault(t => t.Name == $"{commandName}{CommandPostfix}");

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command");
            }

            var command = this.InjectServices(commandType);

            return command;
        }

        private ICommand InjectServices(Type commandType)
        {
            var constructor = commandType
                .GetConstructors()
                .First();

            var constructorParameters = constructor
                .GetParameters()
                .Select(p => p.ParameterType)
                .ToArray();

            var services = constructorParameters
                .Select(p => serviceProvider.GetService(p))
                .ToArray();

            var command = (ICommand)constructor.Invoke(services);

            return command;
        }
    }
}
