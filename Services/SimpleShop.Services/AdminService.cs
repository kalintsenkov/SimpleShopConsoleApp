namespace SimpleShop.Services
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Data.Models;
    using Models.Admin;
    using Utilities;

    public class AdminService : BaseService, IAdminService
    {
        private readonly ShopDbContext data;
        private readonly IMapper mapper;

        public AdminService(ShopDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public AdminServiceModel FindByUsernameAndPassword(string username, string password)
            => this.data.Admins
                .Where(a => a.Username.ToLower() == username.ToLower() 
                            && a.Password == password)
                .ProjectTo<AdminServiceModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();

        public void Create(string username, string password, string name)
        {
            Validator.ValidateAdmin(username, password, name);

            var hashedPassword = this.GetSha256Hash(password);

            var admin = new Admin
            {
                Name = name,
                Username = username,
                Password = hashedPassword
            };

            this.data.Admins.Add(admin);
            this.data.SaveChanges();
        }

        public bool Exists(string username)
            => this.data.Admins.Any(a => a.Username == username);
    }
}
