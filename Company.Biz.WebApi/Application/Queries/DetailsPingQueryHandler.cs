using AutoMapper;
using Company.Biz.Domain.Model;
using Company.Biz.Infrastructure.Abstractions;
using Company.Biz.WebApi.Exceptions;
using Company.Biz.WebApi.Resources;
using Company.Biz.WebApi.ViewModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Biz.WebApi.Application.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class DetailsPingQueryHandler : IRequestHandler<DetailsPingQuery, PingResponseVm>
    {
        private readonly IMapper _mapper;
        private readonly IPingRepository _repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        public DetailsPingQueryHandler(IMapper mapper, IPingRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PingResponseVm> Handle(DetailsPingQuery request, CancellationToken cancellationToken)
        {
            Ping ping = await _repository.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

            if (ping == null)
                throw new NotFoundException(string.Format(Messages.PingNotFound, request.Id));

            return _mapper.Map<Ping, PingResponseVm>(ping);
        }
    }
}
