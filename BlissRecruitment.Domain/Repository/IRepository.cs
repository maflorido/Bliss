using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlissRecruitment.Domain.Repository
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(int id);

        IEnumerable<TEntity> List();

        Task Create(TEntity entity);
    }
}
