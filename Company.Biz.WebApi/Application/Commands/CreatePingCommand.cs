using Company.Biz.WebApi.ViewModels;
using Company.Responses;
using MediatR;

namespace Company.Biz.WebApi.Application.Commands
{
    public class CreatePingCommand : IRequest<Response<PingResponseVm>>
    {
        public string Name { get; set; }
    }
}
