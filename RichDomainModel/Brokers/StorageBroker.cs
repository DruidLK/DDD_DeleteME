using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RichDomainModel.Domain;

namespace RichDomainModel.Brokers
{
    public sealed class StorageBroker : DbContext
    {
        public StorageBroker(DbContextOptions options)
            : base(options)
        { }

        public DbSet<PaymentRequest> PaymentRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
