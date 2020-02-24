using Company.Biz.Domain.Model;
using Company.Biz.Infrastructure.Abstractions;
using Company.Biz.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Biz.Infrastructure.Repositories
{
    public class PingRepository : IPingRepository
    {
        private readonly DummyDbContext _context;

        public PingRepository(DummyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Ping ping, CancellationToken cancellationToken)
        {
            _context.Ping.Add(ping);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task EditAsync(Ping ping, CancellationToken cancellationToken)
        {
            _context.Entry(ping).State = EntityState.Modified;

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task DeleteAsync(Ping ping, CancellationToken cancellationToken)
        {
            _context.Ping.Remove(ping);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Ping> GetByIdAsync(int id, CancellationToken cancellationToken) =>
            await _context.Ping.FirstOrDefaultAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);

        public async Task<List<Ping>> GetAll(CancellationToken cancellationToken)
        {
            IQueryable<Ping> queryable = _context.Ping.AsNoTracking();

            List<Ping> ping = await queryable
                .AsNoTracking()
                .ToListAsync(cancellationToken).ConfigureAwait(false);

            return ping;
        }

        public async Task<bool> CheckByNameAsync(string name) =>
            await _context.Ping.AnyAsync(foo => foo.Name == name).ConfigureAwait(false);

    }
}
