using BlissRecruitment.Domain;
using System.Threading.Tasks;

namespace BlissRecruitment.Repository
{
    public class UnitOfwork : IUnitOfwork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfwork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();

        }
    }
}
