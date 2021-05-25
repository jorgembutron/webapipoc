using MediatR;

namespace Company.Biz.WebApi.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class EditPingCommand : IRequest<bool>
    {
        public string Name { get; set; }

        public int Id { get; set; }
    }
}
