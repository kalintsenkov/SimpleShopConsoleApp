namespace SimpleShop.Data.Models.Common
{
    public static class ValidationConstants
    {
        public class Admin
        {
            public const int UsernameMaxLength = 30;
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 30;
            public const int NameMaxLength = 30;
        }

        public class Category
        {
            public const int NameMaxLength = 30;
        }

        public class Product
        {
            public const int NameMaxLength = 30;
            public const int DescriptionMaxLength = 250;
        }

        public class User
        {
            public const int FirstNameMaxLength = 30;
            public const int LastNameMaxLength = 30;
            public const int UsernameMaxLength = 30;
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 30;
            public const int EmailMaxLength = 255;
        }
    }
}