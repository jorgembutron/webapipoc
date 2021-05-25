using AutoMapper;
using Company.Biz.Domain.Model;
using Company.Biz.WebApi.Application.Commands;
using Company.Biz.WebApi.ViewModels;

namespace Company.Biz.WebApi.Profiles
{
    /// <summary>
    /// 
    /// </summary>
    public class PingMappingProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public PingMappingProfile()
        {
            CreateMap<CreatePingCommand, Ping>();

            CreateMap<Ping, PingResponseVm>();
        }
    }
}
