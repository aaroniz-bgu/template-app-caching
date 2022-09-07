﻿using MyAppRoot.AppServices.StaffServices;
using MyAppRoot.Domain.Entities;
using MyAppRoot.LocalRepository.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace MyAppRoot.LocalRepository.ServiceCollectionExtensions;

public static class IdentityServices
{
    public static void AddLocalIdentity(this IServiceCollection services)
    {
        services.AddSingleton<IUserStore<ApplicationUser>, LocalUserStore>();
        services.AddSingleton<IRoleStore<IdentityRole>, LocalRoleStore>();
        services.AddTransient<IStaffAppService, LocalStaffAppService>();
    }
}
