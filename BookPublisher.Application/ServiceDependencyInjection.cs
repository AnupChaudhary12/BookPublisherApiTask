using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPublisher.Application.Interfaces.ServiceInterfaces;
using BookPublisher.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookPublisher.Application
{
    public static class ServiceDependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IBookService, BookService>();

        }
    }
}
