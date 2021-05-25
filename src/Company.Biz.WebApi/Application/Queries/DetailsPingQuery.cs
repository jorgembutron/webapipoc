using Company.Biz.WebApi.ViewModels;
using MediatR;

namespace Company.Biz.WebApi.Application.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class DetailsPingQuery : IRequest<PingResponseVm>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public DetailsPingQuery(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
