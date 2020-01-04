namespace SimpleShop.AdminApp.Commands
{
    using Contracts;
    using IO.Contracts;
    using Services.Contracts;

    public class GetProductQuantityCommand : ICommand
    {
        private readonly IConsoleReader reader;
        private readonly IConsoleWriter writer;
        private readonly IProductService productService;
        private readonly IAdminSessionService adminSessionService;

        public GetProductQuantityCommand(
            IConsoleReader reader,
            IConsoleWriter writer,
            IProductService productService,
            IAdminSessionService adminSessionService)
        {
            this.reader = reader;
            this.writer = writer;
            this.productService = productService;
            this.adminSessionService = adminSessionService;
        }

        public string Execute()
        {
            if (!this.adminSessionService.IsLoggedIn())
            {
                return "Please login with admin account";
            }

            this.writer.Write("Enter product name: ");
            var productName = this.reader.ReadLine();

            var product = this.productService.FindByName(productName);

            if (product == null)
            {
                return $"Product '{productName}' cannot be found.";
            }

            var productQuantity = product.Quantity;

            return $"{productName} - {productQuantity} quantity";
        }
    }
}
