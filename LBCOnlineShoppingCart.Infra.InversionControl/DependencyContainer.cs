using LBCOnlineShoppingCart.Application.Interfaces;
using LBCOnlineShoppingCart.Application.Services;
using LBCOnlineShoppingCart.Domain.Interfaces;
using LBCOnlineShoppingCart.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBCOnlineShoppingCart.Infra.InversionControl
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //CleanArchitecture.Application
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IAdminService, AdminService>();


            //CleanArchitecture.Domain.Interfaces | CleanArchitecture.Infra.Data.Repositories
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
        }
    }
}
