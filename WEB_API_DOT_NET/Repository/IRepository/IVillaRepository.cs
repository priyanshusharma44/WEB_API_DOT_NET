using System.Linq.Expressions;
using WEB_API_DOT_NET.Models;

namespace WEB_API_DOT_NET.Repository.IRepository
{
    public interface IVillaRepository: IRepository<Villa>
    {
       
        Task<Villa> UpdateAsync(Villa entity);
      
    }
}
     