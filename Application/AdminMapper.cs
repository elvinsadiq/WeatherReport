using Application.DistrictDetails.Commands.Request;
using Application.DistrictDetails.Queries.Response;
using AutoMapper;
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

            CreateMap<District, GetAllDistrictQueryResponse>();
            CreateMap<District, GetByIdDistrictQueryResponse>();
            CreateMap<CreateDistrictCommandRequest, District>();
            CreateMap<UpdateDistrictCommandRequest, District>();
        }
    }
}