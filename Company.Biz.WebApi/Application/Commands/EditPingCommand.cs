using MediatR;

namespace Company.Biz.WebApi.Application.Commands
{
    public class EditPingCommand : IRequest<bool>
    {
        public string Name { get; set; }

        public int Id { get; set; }
    }
}
