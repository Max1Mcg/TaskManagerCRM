using EFC0re.Repositories.Interfaces;
using EFC0re.Services;
using EFC0re.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFC0re.Repositories;
using Unity.Strategies;

namespace EFC0re.DI
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IMetricsService>().To<MetricsService>().InRequestScope();
            Bind<IDataRepository>().To<DataRepository>().InRequestScope();
            Bind<ISettingsRepository>().To<SettingsRepository>().InRequestScope();
            Bind<IDataService>().To<DataService>().InRequestScope();
            Bind<ISettingsService>().To<SettingsService>().InRequestScope();

            //Bind<WebSiteContext>().ToSelf().InRequestScope();
            Bind<WebSiteContext>().ToSelf().InRequestScope();
        }
    }
}