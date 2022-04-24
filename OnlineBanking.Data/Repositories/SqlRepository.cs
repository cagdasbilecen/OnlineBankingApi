using OnlineBanking.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking.Data.Repositories
{
    public class SqlRepository : IRepository
    {
        private readonly OnlineBankingContext context;

        public SqlRepository(OnlineBankingContext context)
        {
            this.context = context;
        }

        public List<TEntity> GetAll<TEntity>() where TEntity : class, IDomainEntity
        {
            return context.Set<TEntity>().OrderBy(r => r.CreatedDate).ToList();
        }

        void IRepository.Delete<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
            //TODO
        }

        public TEntity GetById<TEntity>(Guid id) where TEntity : class, IDomainEntity
        {
            return context.Set<TEntity>().SingleOrDefault(s => s.Id == id);
        }

        public List<TEntity> GetByFilter<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IDomainEntity
        {
            return context.Set<TEntity>().Where(predicate).OrderBy(r => r.CreatedDate).ToList();
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : class, IDomainEntity
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }

            var now = DateTime.UtcNow;

            entity.CreatedDate = now;
            entity.UpdatedDate = now;
            context.Set<TEntity>().Add(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class, IDomainEntity
        {
            entity.UpdatedDate = DateTime.UtcNow;
        }
        public void SaveChanges()
        {
            context.SaveChanges();
           
        }
    }
}
