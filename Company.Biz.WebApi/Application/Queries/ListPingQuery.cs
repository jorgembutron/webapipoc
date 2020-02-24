using Company.Biz.WebApi.ViewModels;
using Company.Responses;
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
