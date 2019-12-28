namespace SimpleShop.AdminApp.Commands
{
    using Contracts;
    using IO.Contracts;
    using Services.Contracts;

    public class AddProductCommand : ICommand
    {
        private readonly IConsoleReader reader;
        private readonly IConsoleWriter writer;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IAdminSessionService adminSessionService;

        public AddProductCommand(
            IConsoleReader reader,
            IConsoleWriter writer,
            IProductService productService,
            ICategoryService categoryService,
            IAdminSessionService adminSessionService)
        {
            this.reader = reader;
            this.writer = writer;
            this.productService = productService;
            this.categoryService = categoryService;
            this.adminSessionService = adminSessionService;
        }

        public string Execute()
        {
            if (!this.adminSessionService.IsLoggedIn())
            {
                return "Please login with admin account";
            }

            this.writer.Write("Enter product name: ");
            var name = this.reader.ReadLine();
            this.writer.Write("Enter product quantity: ");
            var quantity = int.Parse(this.reader.ReadLine());
            this.writer.Write("Enter product actual price: ");
            var actualPrice = decimal.Parse(this.reader.ReadLine());
            this.writer.Write("Enter product minimal price: ");
            var minimalPrice = decimal.Parse(this.reader.ReadLine());
            this.writer.Write("Enter category name: ");
            var categoryName = this.reader.ReadLine();
            this.writer.Write("Enter product's description: ");
            var description = this.reader.ReadLine();

            var category = this.categoryService.FindByName(categoryName);

            if (category == null)
            {
                category = this.categoryService.Create(categoryName);
            }

            var product = this.productService.Create(name, quantity, actualPrice, minimalPrice, category.Id, description);

            return $"Successfully added {product.Name}. Quantity: {product.Quantity}";
        }
    }
}
