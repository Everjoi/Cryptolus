using Autofac;
using Cryptolus.Application.Common.Interfaces;
using Cryptolus.Application.Common.Interfaces.Repositories;
using Cryptolus.Infrastructure.Services;
using Cryptolus.Persistant.Data.Context;
using Cryptolus.Persistant.Repository;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptolus.Persistant.ModuleContainer
{
    public class CryptolusModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<MemoryCache>().As<IMemoryCache>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CryptolusContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<PostRepository>().As<IPostRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CoinInfoService>().As<ICoinInfoService>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
