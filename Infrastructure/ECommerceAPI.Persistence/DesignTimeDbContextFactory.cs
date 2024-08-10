using System;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ECommerceAPI.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ECommerceAPIDbContext>
{
    public ECommerceAPIDbContext CreateDbContext(string[] args)
    {

        DbContextOptionsBuilder<ECommerceAPIDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString());

        return new (dbContextOptionsBuilder.Options);
    }
}

//Microsoft.Extentions.Configuration json dosyalari ucun
//Microsoft.Extentions.Configuration.Json json dosyalari ucun