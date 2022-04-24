using OnlineBanking.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking.Data.Repositories
{
    public interface IRepository
    {
        List<TEntity> GetAll<TEntity>() where TEntity : class, IDomainEntity;
        TEntity GetById<TEntity>(Guid id) where TEntity : class, IDomainEntity;
        List<TEntity> GetByFilter<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IDomainEntity;
        void Insert<TEntity>(TEntity entity) where TEntity : class, IDomainEntity;
        void Update<TEntity>(TEntity entity) where TEntity : class, IDomainEntity;
        void Delete<TEntity>(TEntity entity) where TEntity : class, IDomainEntity;
        void SaveChanges();
    }
}
