﻿using Microsoft.EntityFrameworkCore;
using System;
using ECommerceAPI.Application.Abstractions;
using ECommerceAPI.Persistence.Concretes;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Persistence.Repositories;

namespace ECommerceAPI.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceService(this IServiceCollection services)
    {
        services.AddDbContext<ECommerceAPIDbContext>(options =>
                options.UseNpgsql(Configuration.ConnectionString()),ServiceLifetime.Singleton);

        services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
        services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
        services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();
        services.AddSingleton<IProductReadRepository, ProductReadRepository>();
        services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
        services.AddSingleton<IOrderReadRepository, OrderReadRepository>();

 }
}

