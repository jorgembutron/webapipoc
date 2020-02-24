using Company.Responses;
using MediatR;

namespace Company.Biz.WebApi.Application.Commands
{
    public class EditPingCommand : IRequest<Response>
    {
        public string Name { get; set; }

        public int Id { get; set; }
    }
}
