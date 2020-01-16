using BlissRecruitment.Domain.Repository;
using System;

namespace BlissRecruitment.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
    {
        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
