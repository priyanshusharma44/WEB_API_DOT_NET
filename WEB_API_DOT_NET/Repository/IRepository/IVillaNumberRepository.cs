using System.Linq.Expressions;
using WEB_API_DOT_NET.Models;

namespace WEB_API_DOT_NET.Repository.IRepository
{
    public interface IVillaNumberRepository: IRepository<VillaNumber>
    {
       
        Task<VillaNumber> UpdateAsync(VillaNumber entity);
      
    }
}
     