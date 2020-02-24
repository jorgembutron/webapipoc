using AutoMapper;
using Company.Biz.Domain.Model;
using Company.Biz.WebApi.Application.Commands;
using Company.Biz.WebApi.ViewModels;

namespace Company.Biz.WebApi.Profiles
{
    public class PingMappingProfile : Profile
    {
        public PingMappingProfile()
        {
            CreateMap<CreatePingCommand, Ping>();

            CreateMap<Ping, PingResponseVm>();
        }
    }
}
