using Autofac;
using Core.Helpers;
using Domain.IRepositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.Hosting;

namespace Infrastructure
{
    public class AutoFacBusiness : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DistrictRepository>().As<IDistrictRepository>();
            builder.RegisterType<WeatherReportRepository>().As<IWeatherReportRepository>();
            //builder.RegisterType<WeatherReportService>().As<IHostedService>().SingleInstance();
        }
    }
}