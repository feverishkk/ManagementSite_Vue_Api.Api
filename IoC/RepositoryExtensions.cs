using Application.Interfaces;
using Application.Interfaces.GetItems;
using Application.Services;
using Application.Services.GetItems;
using CommonDatabase.DapperHelperContext.Interfaces;
using CommonDatabase.DapperHelperContext.Servcies;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositoryExtensions(this IServiceCollection service)
        {
            service.AddTransient<ICommonBeltRepository, CommonBeltRepository>();
            service.AddTransient<ICommonArmorRepository, CommonArmorRepository>();
            service.AddTransient<ICommonOneHandSwordRepository, CommonOneHandSwordRepository>();

            service.AddTransient<IApplicationUserRepository, ApplicationUserRepository>();
            service.AddTransient<ICustomerRepository, CustomerRepository>();
            service.AddTransient<IManagerRepository, ManagerRepository>();

            service.AddTransient<IWeaponRepository, WeaponRepository>();
            service.AddTransient<IArmorRepository, ArmorRepository>();
            service.AddTransient<IBootsRepository, BootsRepository>();
            service.AddTransient<IBeltRepository, BeltRepository>();
            service.AddTransient<ICapeRepository, CapeRepository>();
            service.AddTransient<IEarRingRepository, EarRingRepository>();
            service.AddTransient<IGlobeRepository, GlobeRepository>();
            service.AddTransient<IGuardRepository, GuardRepository>();
            service.AddTransient<IHelmetRepository, HelmetRepository>();
            service.AddTransient<INecklessRepository, NecklessRepository>();
            service.AddTransient<IRingOneRepository, RingOneRepository>();
            service.AddTransient<IRingTwoRepository, RingTwoRepository>();
            service.AddTransient<ITShirtRepository, TShirtRepository>();

            service.AddTransient<ILogRepository, LogRepository>();
            service.AddTransient<IChartRepository, ChartRepository>();

            return service;
        }
    }
}
