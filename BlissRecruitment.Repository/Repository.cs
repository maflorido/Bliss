using BlissRecruitment.Domain;
using BlissRecruitment.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public TEntity GetById(int id, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable<TEntity>();

            if (includes != null && includes.Length > 0)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TEntity> List(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable<TEntity>();

            if (includes != null && includes.Length > 0)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query.ToList();
        }

        public IEnumerable<TEntity> ListById(IEnumerable<int> ids, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable<TEntity>();

            if (includes != null && includes.Length > 0)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query.Where(x => ids.Contains(x.Id)).ToList();
        }

        public async Task Create(TEntity entity)
        {
            await _context.AddAsync(entity);
        }
    }
}
