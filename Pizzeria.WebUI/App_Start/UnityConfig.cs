using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Pizzeria.DAL.Data;
using Pizzeria.DAL.Repository;
using Pizzeria.DAL.Models;
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
            container.RegisterInstance<IUnitOfWork>(new UnitOfWork(new DataContext()));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}