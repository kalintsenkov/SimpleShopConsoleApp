namespace SimpleShop.Services.Utilities
{
    public class ProductExceptionMessages
    {
        public const string NameCannotBeEmpty
            = "Product name cannot be null or whitespace.";

        public const string InvalidNameLength
            = "Product name cannot be more than {0} characters.";

        public const string InvalidQuantity
            = "Product quantity cannot be zero or negative number.";

        public const string InvalidPrice
            = "Product price cannot be zero or negative number.";

        public const string InvalidMinimalPrice
            = "Product minimal price cannot be zero or negative number.";

        public const string InvalidDiscountPercentage
            = "Discount percentage must be between 0 and 100 %";

        public const string NotEnoughPieces
            = "We don't have {0} pieces of {1}";
    }
}
