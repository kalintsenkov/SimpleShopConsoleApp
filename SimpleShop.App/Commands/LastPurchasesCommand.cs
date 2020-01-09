namespace SimpleShop.App.Commands
{
    using System.Linq;
    using System.Text;
    using Contracts;
    using Services.Contracts;

    public class LastPurchasesCommand : ICommand
    {
        private readonly IUserSessionService userSessionService;
        private readonly IProductOrderService productOrderService;

        public LastPurchasesCommand(
            IUserSessionService userSessionService, 
            IProductOrderService productOrderService)
        {
            this.userSessionService = userSessionService;
            this.productOrderService = productOrderService;
        }

        public string Execute()
        {
            if (!this.userSessionService.IsLoggedIn())
            {
                return "You are not logged in!";
            }

            var userId = this.userSessionService.User.Id;

            var lastPurchases = this.productOrderService
                .LastPurchases(userId)
                .ToArray();

            if (!lastPurchases.Any())
            {
                return "You did not buy any products!";
            }

            var totalPrice = lastPurchases.Sum(p => p.ProductPrice * p.Quantity);

            var sb = new StringBuilder();

            foreach (var purchase in lastPurchases)
            {
                sb.AppendLine($"{purchase.OrderId}. {purchase.ProductName} <-> {purchase.Quantity} pieces <-> {purchase.ProductPrice:F2}$ each.");
            }

            sb.AppendLine($"Total spent: {totalPrice:F2}$");

            return sb.ToString().TrimEnd();
        }
    }
}
