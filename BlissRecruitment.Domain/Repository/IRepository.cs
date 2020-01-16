namespace BlissRecruitment.Domain.Repository
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(int id);

        void Save(TEntity entity);
    }
}
