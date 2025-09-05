using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WEB_API_DOT_NET.Data;
using WEB_API_DOT_NET.Models;
using WEB_API_DOT_NET.Repository.IRepository;

namespace WEB_API_DOT_NET.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private ApplicationDbContext _db;


        public VillaRepository(ApplicationDbContext db):base(db) { _db = db; }
       
        public async Task<Villa> UpdateAsync(Villa villa)
        {
            villa.UpdatedDate = DateTime.Now;
            _db.Update(villa);
            await _db.SaveChangesAsync();
            return villa;
        }

     
    }
}
