using MediatR;

namespace Company.Biz.WebApi.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class DeletePingCommand : IRequest<bool>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public DeletePingCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}