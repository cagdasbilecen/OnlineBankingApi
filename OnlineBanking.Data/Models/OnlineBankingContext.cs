using Microsoft.EntityFrameworkCore;
using OnlineBanking.Data;

namespace OnlineBanking.Data.Models
{
    public class OnlineBankingContext: DbContext
    {

        private static readonly string defaultSchema = "dbo";

        #region Constructors

        public OnlineBankingContext()
        {

        }
        public OnlineBankingContext(DbContextOptions<OnlineBankingContext> options)
        :base(options)
        {

        }
        #endregion

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class, IDomainEntity
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(defaultSchema);
            modelBuilder.Entity<Customer>();
            modelBuilder.Entity<Account>();
            modelBuilder.Entity<Transaction>();
            modelBuilder.Entity<ErrorMessage>();
            base.OnModelCreating(modelBuilder);
        }

    }
}
