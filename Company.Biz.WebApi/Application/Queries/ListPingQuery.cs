using Company.Biz.WebApi.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace Company.Biz.WebApi.Application.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class ListPingQuery : IRequest<List<PingResponseVm>>
    {
        /// <summary>
        /// 
        /// </summary>
        public ListPingQuery()
        {
        }
    }
}
