using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Pizzeria.DAL.Data;

namespace Pizzeria.WebUI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterInstance<DataContext>(new DataContext());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}