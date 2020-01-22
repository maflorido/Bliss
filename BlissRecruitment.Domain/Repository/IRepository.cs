using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlissRecruitment.Domain.Repository
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(int id, params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> List(params Expression<Func<TEntity, object>>[] includes);

        Task Create(TEntity entity);

        IEnumerable<TEntity> ListById(IEnumerable<int> ids, params Expression<Func<TEntity, object>>[] includes);
    }
}
