using Application.ApplicationUserDetails.Commands.Request;
using Application.ApplicationUserDetails.Commands.Response;
using Application.ApplicationUserDetails.Handlers.CommandHandlers;
using Autofac;
using Autofac.Core;
using Core.Helpers;
using Domain.IRepositories;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Hosting;
using YourProjectNamespace.Services;

namespace Infrastructure
{
    public class AutoFacBusiness : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FavoriteRepository>().As<IFavoriteRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<ColorRepository>().As<IColorRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<SizeRepository>().As<ISizeRepository>();
            builder.RegisterType<TagRepository>().As<ITagRepository>();
            builder.RegisterType<ContactMessageRepository>().As<IContactMessageRepository>();
            builder.RegisterType<ContactRepository>().As<IContactRepository>();
            builder.RegisterType<ProductTagRepository>().As<IProductTagRepository>();
            builder.RegisterType<ProductSizeRepository>().As<IProductSizeRepository>();
            builder.RegisterType<ProductImageRepository>().As<IProductImageRepository>();
            builder.RegisterType<DescriptionRepository>().As<IDescriptionRepository>();
            builder.RegisterType<BlogRepository>().As<IBlogRepository>();
            builder.RegisterType<HomeRepository>().As<IHomeRepository>();
            builder.RegisterType<CountryRepository>().As<ICountryRepository>();
            builder.RegisterType<ProvinceRepository>().As<IProvinceRepository>();
            builder.RegisterType<AppUserRepository>().As<IAppUserRepository>();
            builder.RegisterType<CartRepository>().As<ICartRepository>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<FavoriteRepository>().As<IFavoriteRepository>();
            builder.RegisterType<ReviewRepository>().As<IReviewRepository>();
            builder.RegisterType<AppUserRoleRepository>().As<IAppUserRoleRepository>();
            builder.RegisterType<ProductColorStockRepository>().As<IProductColorStockRepository>();
            builder.RegisterType<ProductExportService>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<LoginFailureTrackerRepository>().As<ILoginFailureTrackerRepository>();
            builder.RegisterType<LoginFailureCleanupService>().As<IHostedService>().SingleInstance();
        }
    }
}