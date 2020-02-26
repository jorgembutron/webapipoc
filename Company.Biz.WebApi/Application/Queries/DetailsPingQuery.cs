using Company.Biz.WebApi.Responses;
using Company.Biz.WebApi.ViewModels;
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
