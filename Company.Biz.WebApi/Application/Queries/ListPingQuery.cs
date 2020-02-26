using Company.Biz.WebApi.Responses;
using Company.Biz.WebApi.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace Company.Biz.WebApi.Application.Queries
{
    public class ListPingQuery : IRequest<Response<List<PingResponseVm>>>
    {
        public ListPingQuery()
        {
        }
    }
}
