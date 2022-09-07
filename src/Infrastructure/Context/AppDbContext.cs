﻿using MyAppRoot.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyAppRoot.Infrastructure.Contexts;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Add domain entities here.
    public DbSet<Office> Offices { get; set; } = null!;
}
