using Company.Biz.Domain.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Biz.Infrastructure.Abstractions
{
    public interface IPingRepository
    {
        Task AddAsync(Ping ping, CancellationToken cancellationToken);

        Task EditAsync(Ping ping, CancellationToken cancellationToken);

        Task DeleteAsync(Ping ping, CancellationToken cancellationToken);

        Task<Ping> GetByIdAsync(int id, CancellationToken cancellationToken);

        Task<List<Ping>> GetAllAsync(CancellationToken cancellationToken);

        Task<bool> CheckByNameAsync(string name);
    }
}
