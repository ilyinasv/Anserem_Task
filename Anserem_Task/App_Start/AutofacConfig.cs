using Anserem_Task.Controllers;
using Anserem_Task.Models;
using Anserem_Task.Repository;
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anserem_Task.App_Start
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();//creating container instance                                 
            //var config = GlobalConfiguration.Configuration;
            builder.RegisterType<HomeController>().InstancePerRequest();

            //register new type matching           
            builder.RegisterType<SellingRepository>().As<ISellingRepository>().InstancePerRequest();
            builder.RegisterType<SaleContext>().InstancePerRequest();


            var container = builder.Build(); //creation of a new container
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));// set the dependency resolver to be Autofac.
        }
    }
}