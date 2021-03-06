﻿namespace SimpleShop.Services
{
    using Contracts;
    using Models.Admin;

    public class AdminSessionService : BaseService, IAdminSessionService
    {
        private readonly IAdminService adminService;

        public AdminSessionService(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        public AdminServiceModel Admin { get; private set; }

        public AdminServiceModel Login(string username, string password)
        {
            var hashedPassword = this.GetSha256Hash(password);

            var admin = this.adminService.FindByUsernameAndPassword(username, hashedPassword);

            this.Admin = admin;

            return this.Admin;
        }

        public void Logout() => this.Admin = null;

        public bool IsLoggedIn() => this.Admin != null;
    }
}
