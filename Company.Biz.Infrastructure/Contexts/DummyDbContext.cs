using Company.Biz.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Company.Biz.Infrastructure.Contexts
{
    public class DummyDbContext : DbContext
    {
        public DummyDbContext(DbContextOptions<DummyDbContext> options) : base(options)
        {

        }

        private readonly string _databaseName;

        public DummyDbContext(string databaseName)
        {
            _databaseName = databaseName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_databaseName != null)
                optionsBuilder.UseSqlServer($"Filename={_databaseName}");
        }

        public DbSet<Ping> Ping { get; set; }
        public DbSet<Pong> Pong { get; set; }
    }
}
