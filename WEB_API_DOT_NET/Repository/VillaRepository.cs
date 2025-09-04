using System.Linq.Expressions;
using WEB_API_DOT_NET.Data;
using WEB_API_DOT_NET.Models;
using WEB_API_DOT_NET.Repository.IRepository;

namespace WEB_API_DOT_NET.Repository
{
    public class VillaRepository : IVillaRepository
    {
        private ApplicationDbContext _db;

        public VillaRepository(ApplicationDbContext db) { _db = db; }
        public async Task Create(Villa entity)
        {

         await _db.Villas.AddAsync(entity);
         await Save();
        }

        public Task<Villa> Get(Expression<Func<Villa>> filter = null, bool tracked = true)
        {
            throw new NotImplementedException(); 
        }

        public Task<List<Villa>> GetAll(Expression<Func<Villa>> filter = null)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(Villa entity)
        {
            _db.Villas.Remove(entity);
            await Save();
        }

        public async Task Save()
        {
           _db.SaveChangesAsync();
        }
    }
}
