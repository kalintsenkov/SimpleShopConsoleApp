namespace SimpleShop.App.Commands
{
    using Contracts;
    using IO.Contracts;
    using Services.Contracts;

    public class BuyProductCommand : ICommand
    {
        private readonly IConsoleReader reader;
        private readonly IConsoleWriter writer;
        private readonly IUserSessionService userSessionService;
        private readonly IProductService productService;
        private readonly IProductOrderService productOrderService;

        public BuyProductCommand(
            IConsoleReader reader,
            IConsoleWriter writer,
            IUserSessionService userSessionService,
            IProductService productService,
            IProductOrderService productOrderService)
        {
            this.reader = reader;
            this.writer = writer;
            this.userSessionService = userSessionService;
            this.productService = productService;
            this.productOrderService = productOrderService;
        }

        public string Execute()
        {
            if (!this.userSessionService.IsLoggedIn())
            {
                return "You are not logged in!";
            }

            this.writer.Write("Enter product name: ");
            var productName = this.reader.ReadLine();

            this.writer.Write("Enter quantity: ");
            var quantity = int.Parse(this.reader.ReadLine());

            var product = this.productService.FindByName(productName);
            var user = this.userSessionService.User;

            if (product == null)
            {
                return $"Product '{productName}' cannot be found.";
            }

            this.productOrderService.Create(product.Id, user.Id, quantity, product.Price);

            return $"You successfully bought {quantity} pieces of {productName}. Total price: {quantity * product.Price:F2}$";
        }
    }
}
