using Company.Biz.Domain.Model;
using Company.Biz.Infrastructure.Contexts;
using Company.Biz.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Company.Integration.Tests.Repositories
{
    public class PingRepositoryShould
    {
        [Fact]
        public async Task CreatePing_AndReturn_NewId()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<DummyDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            //Act
            int pingId = await AddAPingAsync(builder.Options);

            await using (var context = new DummyDbContext(builder.Options))
            {
                var repository = new PingRepository(context);

                Ping ping = await repository.GetByIdAsync(pingId, CancellationToken.None);

                //Assert
                Assert.Equal(ping.Id, pingId);
            };
        }

        private async Task<int> AddAPingAsync(DbContextOptions<DummyDbContext> options)
        {
            //C# 8 :)
            await using var context = new DummyDbContext(options);

            var repository = new PingRepository(context);
            var ping = new Ping();
            await repository.AddAsync(ping, CancellationToken.None).ConfigureAwait(false);
            return ping.Id;
        }
    }
}
