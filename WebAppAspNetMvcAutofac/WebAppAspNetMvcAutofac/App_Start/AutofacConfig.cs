using Autofac;
using Autofac.Integration.Mvc;
using Common.Autofac.Modules;
using Common.Entity;
using Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebAppAspNetMvcAutofac.DataModel;
using WebAppAspNetMvcAutofac.Services.Abstractions;

namespace WebAppAspNetMvcAutofac
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();


            builder.RegisterType<GosuslugiContext>().AsSelf().InstancePerHttpRequest();
            builder.RegisterModule(new ModuleRegisterBaseRepository<IDataContext, GosuslugiContext>());
            builder.RegisterControllers(typeof(MvcApplication).Assembly);


            builder.RegisterType<ClientService>().As<IClientService>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<CitizenshipService>().As<ICitizenshipService>();
            builder.RegisterType<ClientTypeService>().As<IClientTypeService>();
            builder.RegisterType<AvailableDocumentService>().As<IAvailableDocumentService>();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
