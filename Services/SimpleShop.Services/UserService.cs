﻿namespace SimpleShop.Services
{
    using System;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Data.Models;
    using Models.User;
    using Utilities;

    public class UserService : BaseService, IUserService
    {
        private readonly ShopDbContext data;
        private readonly IMapper mapper;

        public UserService(ShopDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public UserServiceModel FindByUsername(string username)
            => this.data.Users
                .Where(u => u.Username == username)
                .ProjectTo<UserServiceModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();

        public UserServiceModel FindByEmail(string email)
            => this.data.Users
                .Where(u => u.Email == email)
                .ProjectTo<UserServiceModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();

        public UserServiceModel FindByUsernameAndPassword(string username, string password)
            => this.data.Users
                .Where(u => u.Username.ToLower() == username.ToLower() 
                            && u.Password == password)
                .ProjectTo<UserServiceModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();

        public void Create(string firstName, string lastName, string username, string password, string email, decimal balance)
        {
            Validator.ValidateUser(firstName, lastName, username, password, email, balance);

            var hashedPassword = this.GetSha256Hash(password);

            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                Password = hashedPassword,
                Email = email,
                Balance = balance
            };

            this.data.Users.Add(user);
            this.data.SaveChanges();
        }

        public void AddMoney(int userId, decimal money)
        {
            var user = this.data.Users.First(u => u.Id == userId);

            if (money <= 0)
            {
                throw new ArgumentException(UserExceptionMessages.InvalidMoney);
            }

            user.Balance += money;

            this.data.SaveChanges();
        }

        public void ReduceMoney(int userId, decimal money)
        {
            var user = this.data.Users.First(u => u.Id == userId);

            // This avoids wrong cached info in DbContext about user's balance
            this.data.Entry(user).Reload();

            if (user.Balance - money < 0)
            {
                throw new ArgumentException(UserExceptionMessages.NotEnoughMoney);
            }

            user.Balance -= money;

            this.data.SaveChanges();
        }
    }
}
