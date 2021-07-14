using BookContactControl.Domain.Repositories;
using BookContactControl.Domain.Models;
using BookContactControl.Infraestructure.Data;
using BookContactControl.Infraestructure.Repositories;
using BookContactControl.Domain.Services;
using Microsoft.Practices.Unity;

namespace SpaUserControl.Startup
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            //Contrato(Interface) X Implementação
            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IContactRepository, ContactRepository>(new HierarchicalLifetimeManager());
            //container.RegisterType<IContactService, ContactService>(new HierarchicalLifetimeManager());

            container.RegisterType<Contact, Contact>(new HierarchicalLifetimeManager());
        }
    }
}
