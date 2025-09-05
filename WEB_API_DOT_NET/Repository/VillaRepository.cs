using Microsoft.EntityFrameworkCore;
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
        public async Task CreateAsync(Villa entity)
        {
         await _db.Villas.AddAsync(entity);
         await SaveAsync();
        }

        public async Task<Villa> GetAsync(Expression<Func<Villa,bool>> filter = null, bool tracked = true)
        {

            IQueryable<Villa> query = _db.Villas;
            if(!tracked)
            {
                query= query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();

        }

        public async Task<List<Villa>> GetAllAsync(Expression<Func<Villa,bool>> filter = null)
        {
            IQueryable<Villa> query = _db.Villas;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task RemoveAsync(Villa entity)
        {
            _db.Villas.Remove(entity);
            await SaveAsync();
        }
        public async Task UpdateAsync(Villa villa)
        {
            _db.Update(villa);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
           _db.SaveChangesAsync();
        }
    }
}
