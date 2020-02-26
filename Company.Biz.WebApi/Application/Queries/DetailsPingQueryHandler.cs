using AutoMapper;
using Company.Biz.Domain.Model;
using Company.Biz.Infrastructure.Abstractions;
using Company.Biz.WebApi.Responses;
using Company.Biz.WebApi.ViewModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Biz.WebApi.Application.Queries
{
    public class DetailsPingQueryHandler : IRequestHandler<DetailsPingQuery, Response<PingResponseVm>>
    {
        private readonly IMapper _mapper;
        private readonly IPingRepository _repository;

        public DetailsPingQueryHandler(IMapper mapper, IPingRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<PingResponseVm>> Handle(DetailsPingQuery request, CancellationToken cancellationToken)
        {
            Ping ping = await _repository.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

            if (ping == null)
                return new Response<PingResponseVm>(Result.NotFound);

            return new Response<PingResponseVm>(Result.Ok)
            {
                Data = _mapper.Map<Ping, PingResponseVm>(ping)
            };
        }
    }
}
