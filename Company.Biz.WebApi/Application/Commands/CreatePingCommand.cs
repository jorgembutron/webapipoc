using Company.Biz.WebApi.Responses;
using Company.Biz.WebApi.ViewModels;
using MediatR;

namespace Company.Biz.WebApi.Application.Commands
{
    /// <summary>
    /// A Ping
    /// </summary>
    public class CreatePingCommand : IRequest<Response<PingResponseVm>>
    {
        /// <summary>
        /// Name for the Ping
        /// </summary>
        public string Name { get; set; }
    }
}
