namespace SimpleShop.Services.Utilities
{
    using System;
    using Data.Models.Common;

    public static class Validator
    {
        public static void ValidateUser(
            string firstName, 
            string lastName, 
            string username, 
            string password, 
            string email, 
            decimal balance)
        {
            if (firstName.Length > ValidationConstants.User.FirstNameMaxLength)
            {
                throw new ArgumentException(
                    string.Format(
                        UserExceptionMessages.InvalidFirstNameLength,
                        ValidationConstants.User.FirstNameMaxLength));
            }

            if (lastName.Length > ValidationConstants.User.LastNameMaxLength)
            {
                throw new ArgumentException(
                    string.Format(
                        UserExceptionMessages.InvalidLastNameLength,
                        ValidationConstants.User.LastNameMaxLength));
            }

            if (username.Length > ValidationConstants.User.UsernameMaxLength)
            {
                throw new ArgumentException(
                    string.Format(
                        UserExceptionMessages.InvalidUsernameLength,
                        ValidationConstants.User.UsernameMaxLength));
            }

            if (password.Length < ValidationConstants.User.PasswordMinLength 
                || password.Length > ValidationConstants.User.PasswordMaxLength)
            {
                throw new ArgumentException(
                    string.Format(
                        UserExceptionMessages.InvalidPasswordLength,
                        ValidationConstants.User.PasswordMinLength,
                        ValidationConstants.User.PasswordMaxLength));
            }

            if (email.Length > ValidationConstants.User.EmailMaxLength)
            {
                throw new ArgumentException(
                    string.Format(
                        UserExceptionMessages.InvalidEmailLength,
                        ValidationConstants.User.EmailMaxLength));
            }

            if (balance <= 0)
            {
                throw new ArgumentException(
                    UserExceptionMessages.InvalidBalance);
            }
        }

        public static void ValidateAdmin(string username, string password, string name)
        {
            if (username.Length > ValidationConstants.Admin.UsernameMaxLength)
            {
                throw new ArgumentException(
                    string.Format(
                        AdminExceptionMessages.InvalidUsernameLength,
                        ValidationConstants.Admin.UsernameMaxLength));
            }

            if (password.Length < ValidationConstants.Admin.PasswordMinLength 
                || password.Length > ValidationConstants.Admin.PasswordMaxLength)
            {
                throw new ArgumentException(
                    string.Format(
                        AdminExceptionMessages.InvalidPasswordLength,
                        ValidationConstants.Admin.PasswordMinLength,
                        ValidationConstants.Admin.PasswordMaxLength));
            }

            if (name.Length > ValidationConstants.Admin.NameMaxLength)
            {
                throw new ArgumentException(
                    string.Format(
                        AdminExceptionMessages.InvalidNameLength,
                        ValidationConstants.Admin.NameMaxLength));
            }
        }

        public static void ValidateCategory(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    CategoryExceptionMessages.NameCannotBeNullOrEmpty);
            }

            if (name.Length > ValidationConstants.Category.NameMaxLength)
            {
                throw new ArgumentException(
                    string.Format(
                        CategoryExceptionMessages.InvalidNameLength,
                        ValidationConstants.Category.NameMaxLength));
            }
        }

        public static void ValidateProduct(string name, int quantity, decimal price, decimal minimalPrice)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    ProductExceptionMessages.NameCannotBeEmpty);
            }

            if (name.Length > ValidationConstants.Product.NameMaxLength)
            {
                throw new ArgumentException(
                    string.Format(
                        ProductExceptionMessages.InvalidNameLength,
                        ValidationConstants.Product.NameMaxLength));
            }

            if (quantity <= 0)
            {
                throw new ArgumentException(
                    ProductExceptionMessages.InvalidQuantity);
            }

            if (price <= 0)
            {
                throw new ArgumentException(
                    ProductExceptionMessages.InvalidPrice);
            }

            if (minimalPrice <= 0)
            {
                throw new ArgumentException(
                    ProductExceptionMessages.InvalidMinimalPrice);
            }

            if (price < minimalPrice)
            {
                throw new ArgumentException(
                    ProductExceptionMessages.ActualPriceCannotBeLessThanMinimalPrice);
            }
        }
    }
}
