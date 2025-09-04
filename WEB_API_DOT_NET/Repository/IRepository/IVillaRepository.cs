using System.Linq.Expressions;
using WEB_API_DOT_NET.Models;

namespace WEB_API_DOT_NET.Repository.IRepository
{
    public interface IVillaRepository
    {
        Task<List<Villa>> GetAll(Expression<Func<Villa>> filter = null);
        Task<Villa> Get(Expression<Func<Villa>> filter = null, bool tracked = true);
        Task Create(Villa entity);
        Task Remove(Villa entity);

        Task Save();
    }
}
