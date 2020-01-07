namespace SimpleShop.Services.Utilities
{
    public class UserExceptionMessages
    {
        public const string InvalidFirstNameLength
            = "First name cannot be more than {0} characters";

        public const string InvalidLastNameLength
            = "Last name cannot be more than {0} characters";

        public const string InvalidUsernameLength
            = "Username cannot be more than {0} characters";

        public const string InvalidPasswordLength
            = "Password must be between {0} and {1} characters";

        public const string InvalidEmailLength
            = "Email cannot be more than {0} characters";

        public const string InvalidBalance
            = "Balance must be more than zero.";

        public const string InvalidMoney
            = "Money must be more than $0";

        public const string NotEnoughMoney
            = "Sorry, you don't have enough money! Please add money in your balance.";
    }
}
