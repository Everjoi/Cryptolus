using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptolus.Persistant.Data.Context;
using Microsoft.EntityFrameworkCore;
using Cryptolus.Persistant.ModuleContainer;

namespace Cryptolus.Persistant.Extension
{
    public static class ServiceCollectionExtension
    {
        public static void AddPersistenceLayer(this IServiceCollection services,IConfiguration configuration,IHostBuilder host)
        {
            services.AddDbContext(configuration);
            host.AddRepositories();
        }


        public static void AddDbContext(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<CryptolusContext>(options =>
               options.UseSqlServer(connectionString,
                   builder => builder.MigrationsAssembly(typeof(CryptolusContext).Assembly.FullName)));
        }


        private static void AddRepositories(this IHostBuilder builder)
        {
            builder.UseServiceProviderFactory(new AutofacServiceProviderFactory()).
                ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new CryptolusModule());
                });
        }
    }
}
