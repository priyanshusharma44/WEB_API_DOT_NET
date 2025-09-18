using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WEB_API_DOT_NET.Data;
using WEB_API_DOT_NET.Models;
using WEB_API_DOT_NET.Repository.IRepository;

namespace WEB_API_DOT_NET.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private ApplicationDbContext _db;


        public VillaNumberRepository(ApplicationDbContext db):base(db) { _db = db; }
       
        public async Task<VillaNumber> UpdateAsync(VillaNumber villa)
        {
            villa.UpdatedDate = DateTime.Now;
            _db.VillaNumbers.Update(villa);
            await _db.SaveChangesAsync();
            return villa;
        }
    }
}
