using System.Threading.Tasks;

namespace BlissRecruitment.Domain
{
    public interface IUnitOfwork
    {
        Task Commit();
    }
}
