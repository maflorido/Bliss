using System.Threading.Tasks;

namespace BlissRecruitment.Domain.Repository
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(int id);

        Task Save(TEntity entity);
    }
}
