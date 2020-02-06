namespace SimpleShop.Services
{
    using System.Security.Cryptography;
    using System.Text;

    public abstract class BaseService
    {
        protected string GetSha256Hash(string password)
        {
            var crypt = new SHA256Managed();
            var hashedPassword = new StringBuilder();
            var crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));

            foreach (var theByte in crypto)
            {
                hashedPassword.Append(theByte.ToString("x2"));
            }

            return hashedPassword.ToString().TrimEnd();
        }
    }
}