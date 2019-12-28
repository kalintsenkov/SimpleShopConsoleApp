namespace SimpleShop.AdminApp.Commands
{
    using System.Linq;
    using Contracts;
    using Services.Contracts;

    public class StopBlackFridayCommand : ICommand
    {
        private readonly IProductService productService;
        private readonly IAdminSessionService adminSessionService;

        public StopBlackFridayCommand(
            IProductService productService,
            IAdminSessionService adminSessionService)
        {
            this.productService = productService;
            this.adminSessionService = adminSessionService;
        }

        public string Execute()
        {
            if (!this.adminSessionService.IsLoggedIn())
            {
                return "Please login with admin account";
            }

            var products = this.productService.GetAllBlackFridayProducts();

            if (!products.Any())
            {
                return "There are zero Black Friday products.";
            }

            this.productService.StopBlackFriday();

            return "Black Friday campaign was stopped successfully. You might want to update products actual prices";
        }
    }
}
