using BlissRecruitment.Domain;
using BlissRecruitment.Domain.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlissRecruitment.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TEntity> List()
        {
            return _context.Set<TEntity>().ToList();
        }

        public async Task Create(TEntity entity)
        {
            await _context.AddAsync(entity);
        }
    }
}
