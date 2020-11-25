using System.Web.Mvc;
using TanmiahDatabase.Services;
using Unity;
using Unity.Mvc5;

namespace TanmiahDatabase
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IBannerService, BannerService>();
            container.RegisterType<ICreateBanner, CreateBanner>();
            container.RegisterType<IReadBanner, ReadBanner>();
            container.RegisterType<IEditBanner, EditBanner>();
            container.RegisterType<IDeleteBanner, DeleteBanner>();

            container.RegisterType<IBreadcrumbServices, BreadcrumbServices>();
            container.RegisterType<IReadCrumb, ReadCrumb>();
            container.RegisterType<IEditCrumb, EditCrumb>();


            container.RegisterType<ICardServices, CardServices>();
            container.RegisterType<ICreateCard, CreateCard>();
            container.RegisterType<IReadCard, ReadCard>();
            container.RegisterType<IEditCard, EditCard>();
            container.RegisterType<IDeleteCard, DeleteCard>();

            container.RegisterType<IDescriptionServices, DescriptionServices>();
            container.RegisterType<ICreateDescription, CreateDescription>();
            container.RegisterType<IReadDescription, ReadDescription>();
            container.RegisterType<IEditDescription, EditDescription>();
            container.RegisterType<IDeleteDescription, DeleteDescription>();

            container.RegisterType<IListingServices, ListingServices>();
            container.RegisterType<ICreateList, CreateList>();
            container.RegisterType<IReadList, ReadList>();
            container.RegisterType<IEditList, EditList>();
            container.RegisterType<IDeleteList, DeleteList>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}