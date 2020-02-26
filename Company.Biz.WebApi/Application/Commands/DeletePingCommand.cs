using Company.Biz.WebApi.Responses;
using MediatR;

namespace Company.Biz.WebApi.Application.Commands
{
    public class DeletePingCommand : IRequest<Response>
    {
        public DeletePingCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}