using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Application
{
    public class AdminMapper : Profile
    {
        private readonly IHttpContextAccessor _httpAccessor;
        public AdminMapper(IHttpContextAccessor httpAccessor)
        {
            _httpAccessor = httpAccessor;
        }
    }
}