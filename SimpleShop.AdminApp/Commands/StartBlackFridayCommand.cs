namespace SimpleShop.AdminApp.Commands
{
    using Contracts;
    using IO.Contracts;
    using Services.Contracts;

    public class StartBlackFridayCommand : ICommand
    {
        private readonly IConsoleReader reader;
        private readonly IConsoleWriter writer;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IAdminSessionService adminSessionService;

        public StartBlackFridayCommand(
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

            this.writer.Write("Enter a name for the category you want Black Friday for: ");
            var categoryName = this.reader.ReadLine();
            this.writer.Write("Enter discount percentage: ");
            var discountPercentage = decimal.Parse(this.reader.ReadLine());

            var category = this.categoryService.FindByName(categoryName);

            if (category == null)
            {
                return $"Category '{categoryName}' cannot be found.";
            }

            this.productService.StartBlackFridayByCategory(category.Id, discountPercentage);

            return $"Successfully started Black Friday campaign. {discountPercentage}% OFF on {categoryName}!";
        }
    }
}
