﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPublisher.Application;
using BookPublisher.Application.Interfaces.RepositoryInterfaces;
using BookPublisher.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookPublisher.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddAutoMapper(typeof(ServiceDependencyInjection).Assembly);

            return services;
        }
    }
}
