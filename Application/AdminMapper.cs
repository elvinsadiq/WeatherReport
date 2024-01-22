using Application.ApplicationUserDetails.Commands.Request;
using Application.ApplicationUserDetails.Queries.Response;
using Application.AppUserRoleDetails.Commands.Request;
using Application.AppUserRoleDetails.Queries.Response;
using Application.BlogDetails.Commands.Request;
using Application.BlogDetails.Queries.Response;
using Application.CategoryDetails.Commands.Request;
using Application.CategoryDetails.Queries.Response;
using Application.CheckoutDetails.Commands.Request;
using Application.CheckoutDetails.CountryDetails.Commands.Request;
using Application.CheckoutDetails.CountryDetails.Queries.Response;
using Application.CheckoutDetails.ProvinceDetails.Commands.Request;
using Application.CheckoutDetails.ProvinceDetails.Queries.Response;
using Application.CheckoutDetails.Queries.Response;
using Application.ColorDetails.Commands.Request;
using Application.ColorDetails.Queries.Response;
using Application.Commands.Request;
using Application.ContactDetails.Commands.Request;
using Application.ContactDetails.Queries.Response;
using Application.ContactMessageDetails.Commands.Request;
using Application.ContactMessageDetails.Queries.Response;
using Application.DescriptionDetails.Commands.Request;
using Application.DescriptionDetails.Queries.Response;
using Application.FavoriteDetails.Commands.Request;
using Application.FavoriteDetails.Queries.Response;
using Application.GetProductDetails.Queries.Response;
using Application.HomeDetails.Commands.Request;
using Application.HomeDetails.Queries.Response;
using Application.LoginFailureTrackerDetails.Commands.Request;
using Application.LoginFailureTrackerDetails.Queries.Response;
using Application.NewProductDetails.Queries.Response;
using Application.ProductDescriptionDetails.Queries.Response;
using Application.ProductDetails.Commands.Request;

using Application.ProductDetails.ProductModelDetail;
using Application.ProductDetails.Queries.Response;
using Application.ProductPageDetails.Queries.Response;
using Application.RelatedCategoryProductDetails.Queries.Response;
using Application.RelatedProductsDetails.Queries.Response;
using Application.ReviewDetails.Commands.Request;
using Application.ReviewDetails.Queries.Response;
using Application.SizeDetails.Commands.Request;
using Application.SizeDetails.Queries.Response;
using Application.TagDetails.Commands.Request;
using Application.TagDetails.Queries.Response;
using AutoMapper;
using Core.Helpers;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application
{
    public class AdminMapper : Profile
    {
        private readonly IHttpContextAccessor _httpAccessor;
        public AdminMapper(IHttpContextAccessor httpAccessor)
        {
            _httpAccessor = httpAccessor;

            CreateMap<Product, GetAllProductQueryResponse>()
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.ProductTags.Select(pt => new TagResponse { Id = pt.Tag.Id, TagName = pt.Tag.TagName }).ToList()))
            .ForMember(dest => dest.Colors, opt => opt.MapFrom(src => src.ProductImages
            .GroupBy(pi => pi.Color)
            .Select(group => new ColorResponse
            {
                Id = group.Key.Id,
                ColorHexCode = group.Key.ColorHexCode,
                ImageFiles = group.Select(pi => $"{RequestExtensions.BaseUrl(_httpAccessor.HttpContext)}/{pi.Image}").ToList()
            }).ToList()))
            .ForMember(dest => dest.Sizes, opt => opt.MapFrom(src => src.ProductSizes.Select(ps => new SizeResponse { Id = ps.Size.Id, SizeName = ps.Size.SizeName }).ToList()));

            CreateMap<Product, GetByIdProductQueryResponse>().ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.ProductTags.Select(pt => new TagResponse { Id = pt.Tag.Id, TagName = pt.Tag.TagName }).ToList()))
            .ForMember(dest => dest.Colors, opt => opt.MapFrom(src => src.ProductImages
            .GroupBy(pi => pi.Color)
            .Select(group => new ColorResponse
            {
                Id = group.Key.Id,
                ColorHexCode = group.Key.ColorHexCode,
                ImageFiles = group.Select(pi => $"{RequestExtensions.BaseUrl(_httpAccessor.HttpContext)}/{pi.Image}").ToList()
            }).ToList()))
            .ForMember(dest => dest.Sizes, opt => opt.MapFrom(src => src.ProductSizes.Select(ps => new SizeResponse { Id = ps.Size.Id, SizeName = ps.Size.SizeName }).ToList()));


            CreateMap<Product, GetProductQueryResponse>()
            .ForMember(dest => dest.ImageFiles, opt => opt.MapFrom(src => src.ProductImages.Any() ? src.ProductImages.Select(pi => $"{RequestExtensions.BaseUrl(_httpAccessor.HttpContext)}/{pi.Image}").Take(1) : new List<string>()));

            CreateMap<CreateProductCommandRequest, Product>();
            CreateMap<UpdateProductCommandRequest, Product>();

            CreateMap<Product, GetRelatedProductsQueryResponse>().ForMember(dest => dest.ImageFiles, opt => opt.MapFrom(src => src.ProductImages.Any() ? src.ProductImages.Select(pi => $"{RequestExtensions.BaseUrl(_httpAccessor.HttpContext)}/{pi.Image}").ToList() : new List<string>()));
            CreateMap<Product, GetByIdProductPageQueryResponse>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.ProductTags.Select(pt => new TagResponse { Id = pt.Tag.Id, TagName = pt.Tag.TagName }).ToList()))
            .ForMember(dest => dest.Colors, opt => opt.MapFrom(src => src.ProductImages
            .GroupBy(pi => pi.Color)
            .Select(group => new ColorResponse
            {
                Id = group.Key.Id,
                ColorHexCode = group.Key.ColorHexCode,
                ImageFiles = group.Select(pi => $"{RequestExtensions.BaseUrl(_httpAccessor.HttpContext)}/{pi.Image}").ToList()
            }).ToList()))
            .ForMember(dest => dest.Sizes, opt => opt.MapFrom(src => src.ProductSizes.Select(ps => new SizeResponse { Id = ps.Size.Id, SizeName = ps.Size.SizeName }).ToList()));


            CreateMap<Product, CartDetails.AddToCartDetails.ProductModelDetail.ProductResponse>().ForMember(dest => dest.ImageFile, opt => opt.MapFrom(src => src.ProductImages.Any() ? src.ProductImages.Select(pi => $"{RequestExtensions.BaseUrl(_httpAccessor.HttpContext)}/{pi.Image}").ToList() : new List<string>()));

            CreateMap<Category, CategoryResponse>();
            CreateMap<Category, GetAllCategoryQueryResponse>();
            CreateMap<Category, GetByIdCategoryQueryResponse>();
            CreateMap<CreateCategoryCommandRequest, Category>();
            CreateMap<UpdateCategoryCommandRequest, Category>();
            CreateMap<Category, GetAllCategoriesForBlogResponse>()
            .ForMember(dest => dest.BlogCount, opt => opt.MapFrom(src => src.Blogs.Count));

            CreateMap<Description, GetByIdProductDescriptionQueryResponse>().ForMember(dest => dest.ImageFiles, opt => opt.MapFrom(src => src.DescriptionImages.Any() ? src.DescriptionImages.Select(pi => $"{RequestExtensions.BaseUrl(_httpAccessor.HttpContext)}/{pi.Image}").ToList() : new List<string>()));
            CreateMap<Description, GetDescriptionQueryResponse>().ForMember(dest => dest.ImageFiles, opt => opt.MapFrom(src => src.DescriptionImages.Any() ? src.DescriptionImages.Select(pi => $"{RequestExtensions.BaseUrl(_httpAccessor.HttpContext)}/{pi.Image}").ToList() : new List<string>()));


            CreateMap<CreateDescriptionCommandRequest, Description>();
            CreateMap<UpdateDescriptionCommandRequest, Description>();

            CreateMap<Size, GetAllSizeQueryResponse>();
            CreateMap<Size, GetByIdSizeQueryResponse>();
            CreateMap<CreateSizeCommandRequest, Size>();
            CreateMap<UpdateSizeCommandRequest, Size>();

            CreateMap<Color, GetAllColorQueryResponse>();
            CreateMap<Color, GetByIdColorQueryResponse>();
            CreateMap<CreateColorCommandRequest, Color>();
            CreateMap<UpdateColorCommandRequest, Color>();

            CreateMap<Tag, GetAllTagQueryResponse>();
            CreateMap<Tag, GetByIdTagQueryResponse>();
            CreateMap<CreateTagCommandRequest, Tag>();
            CreateMap<UpdateTagCommandRequest, Tag>();

            CreateMap<AppUser, GetAllAppUserQueryResponse>();
            CreateMap<AppUser, GetByIdAdminUserQueryResponse>();
            CreateMap<AppUser, GetByIdAppUserQueryResponse>();
            CreateMap<AppUser, GetUserResponse>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.AppUserRole));
            CreateMap<CreateAppUserCommandRequest, AppUser>();
            CreateMap<UpdateAppUserCommandRequest, AppUser>();

            CreateMap<Home, GetAllHomeQueryResponse>() // Convert Home to GetAllHomeQueryResponse
            .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.HomeImages.Any() ? src.HomeImages
            .Select(pi => $"{RequestExtensions.BaseUrl(_httpAccessor.HttpContext)}/{pi.ImageUrl}").ToList() : new List<string>()));
            CreateMap<Home, GetByIdHomeQueryResponse>()
            .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.HomeImages.Any() ? src.HomeImages
            .Select(pi => $"{RequestExtensions.BaseUrl(_httpAccessor.HttpContext)}/{pi.ImageUrl}").ToList() : new List<string>()));
            CreateMap<CreateHomeCommandRequest, Home>();
            CreateMap<UpdateHomeCommandRequest, Home>();

            CreateMap<Contact, GetAllContactQueryResponse>();
            CreateMap<CreateContactCommandRequest, Contact>();
            CreateMap<UpdateContactCommandRequest, Contact>();

            CreateMap<ContactMessage, GetAllContactMessageQueryResponse>();
            CreateMap<ContactMessage, GetByIdContactMessageQueryResponse>();
            CreateMap<CreateContactMessageCommandRequest, ContactMessage>();
            CreateMap<UpdateContactMessageCommandRequest, ContactMessage>();

            CreateMap<AppUser, AdminInfoResponse>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.AppUserRole != null ? new AppUserRole { RoleName = src.AppUserRole.RoleName } : null));


            CreateMap<Blog, GetAllBlogQueryResponse>()
            .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.BlogImages.Any() ? src.BlogImages
            .Select(pi => $"{RequestExtensions.BaseUrl(_httpAccessor.HttpContext)}/{pi.ImageUrl}").ToList() : new List<string>()));
            CreateMap<Blog, GetByIdBlogQueryResponse>()
            .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.BlogImages.Any() ? src.BlogImages
            .Select(pi => $"{RequestExtensions.BaseUrl(_httpAccessor.HttpContext)}/{pi.ImageUrl}").ToList() : new List<string>()));
            CreateMap<CreateBlogCommandRequest, Blog>();
            CreateMap<UpdateBlogCommandRequest, Blog>();

            CreateMap<Blog, GetAllBlogForUserQueryResponse>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate.ToString("dd MMM yyyy HH:mm")))
            .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.BlogImages.Any() ? src.BlogImages
            .Select(pi => $"{RequestExtensions.BaseUrl(_httpAccessor.HttpContext)}/{pi.ImageUrl}").Take(1) : new List<string>()))
            .ForMember(dest => dest.AdminInfo, opt => opt.MapFrom(src =>
            new AdminInfoResponse
            {
                Id = src.User.AppUserRole.Id != null ? src.User.AppUserRole.Id : 0,
                RoleName = src.User.AppUserRole.RoleName
            }
            ));
            CreateMap<Blog, GetAllCategoriesForBlogResponse>();
            CreateMap<Blog, BlogImageResponse>().ForMember(dest => dest.ImageFile, opt => opt.MapFrom(src => src.BlogImages.Any() ? src.BlogImages
            .Select(pi => $"{RequestExtensions.BaseUrl(_httpAccessor.HttpContext)}/{pi.ImageUrl}").ToList() : new List<string>()));
            CreateMap<Blog, GetAllRecentPostsQueryResponse>().ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.BlogImages.Any() ? src.BlogImages
            .Select(pi => $"{RequestExtensions.BaseUrl(_httpAccessor.HttpContext)}/{pi.ImageUrl}").ToList() : new List<string>()));



            CreateMap<Blog, BlogImageResponse>().ForMember(dest => dest.ImageFile, opt => opt.MapFrom(src => src.BlogImages.Any() ? src.BlogImages
            .Select(pi => $"{RequestExtensions.BaseUrl(_httpAccessor.HttpContext)}/{pi.ImageUrl}").ToList() : new List<string>()));
            CreateMap<Blog, GetAllRecentPostsQueryResponse>().ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.BlogImages.Any() ? src.BlogImages
            .Select(pi => $"{RequestExtensions.BaseUrl(_httpAccessor.HttpContext)}/{pi.ImageUrl}").ToList() : new List<string>()));

            CreateMap<Country, GetAllCountryQueryResponse>();
            CreateMap<Country, CountryResponse>();
            CreateMap<Country, GetByIdCountryQueryResponse>();
            CreateMap<CreateCountryCommandRequest, Country>();
            CreateMap<UpdateCountryCommandRequest, Country>();

            CreateMap<AppUserRole, AdminInfoResponse>();

            CreateMap<Province, GetAllProvinceQueryResponse>();
            CreateMap<Province, ProvinceResponse>();
            CreateMap<Province, GetByIdProvinceQueryResponse>();
            CreateMap<Province, GetRelatedProvinceQueryResponse>();
            CreateMap<CreateProvinceCommandRequest, Province>();
            CreateMap<UpdateProvinceCommandRequest, Province>();

            CreateMap<Order, GetAllOrderQueryResponse>();
            CreateMap<Order, GetByIdOrderQueryResponse>();
            CreateMap<CreateOrderCommandRequest, Order>();

            CreateMap<AddToFavoriteCommandRequest, Favorite>();
            CreateMap<FavoriteResponse, Favorite>();
            CreateMap<Favorite, GetFavoritesByUserIdQueryResponse>()
            .ForMember(dest => dest.Favorites, opt => opt.MapFrom(src => src));

            CreateMap<Review, GetAllReviewQueryResponse>();
            CreateMap<Review, GetByIdReviewQueryResponse>();
            CreateMap<CreateReviewCommandRequest, Review>();
            CreateMap<UpdateReviewCommandRequest, Review>();

            CreateMap<Product, GetNewProductsQueryResponse>().ForMember(dest => dest.ImageFiles, opt => opt.MapFrom(src => src.ProductImages.Any() ? src.ProductImages.Select(pi => $"{RequestExtensions.BaseUrl(_httpAccessor.HttpContext)}/{pi.Image}").Take(1) : new List<string>()));

            CreateMap<AppUserRole, GetAllAppUserRoleQueryResponse>();
            CreateMap<AppUserRole, GetByIdAppUserRoleQueryResponse>();
            CreateMap<CreateAppUserRoleCommandRequest, AppUserRole>();
            CreateMap<UpdateAppUserRoleCommandRequest, AppUserRole>();

            CreateMap<Product, GetRelatedCategoryProductQueryResponse>().ForMember(dest => dest.ImageFiles, opt => opt.MapFrom(src => src.ProductImages.Any() ? src.ProductImages.Select(pi => $"{RequestExtensions.BaseUrl(_httpAccessor.HttpContext)}/{pi.Image}").ToList() : new List<string>()));

            CreateMap<LoginFailureTracker, GetAllLoginFailureTrackerQueryResponse>();
            CreateMap<LoginFailureTracker, GetByIdLoginFailureTrackerQueryResponse>();
            CreateMap<CreateLoginFailureTrackerCommandRequest, LoginFailureTracker>();
            CreateMap<UpdateLoginFailureTrackerCommandRequest, LoginFailureTracker>();
        }
    }
}