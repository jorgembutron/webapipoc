using Company.Biz.WebApi.ViewModels;
using Company.Responses;
using MediatR;

namespace Company.Biz.WebApi.Application.Queries
{

    public class DetailsPingQuery : IRequest<Response<PingResponseVm>>
    {
        public DetailsPingQuery(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
