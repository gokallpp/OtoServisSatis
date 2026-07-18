using Microsoft.EntityFrameworkCore;
using OtoServisSatis.Data.Abstract;
using OtoServisSatis.Entities;
using System.Linq.Expressions;

namespace OtoServisSatis.Data.Concrete
{
    public class CarRepository :Repository<Arac>, ICarRepository
    {
        public CarRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Arac> GetCustomCar(int id)
        {
            // Arac nesnesini alırken Marka gezinme özelliğini dahil edin
            return await _dbSet.AsNoTracking().Include(x => x.Marka).FirstOrDefaultAsync(c => c.Id == id);
        }

        
        public async Task<List<Arac>> GetCustomCarsList()
        {
            // Tüm araçları alırken Marka gezinme özelliğini dahil edin
            return await _dbSet.AsNoTracking().Include(x => x.Marka).ToListAsync();
        }

        public async Task<List<Arac>> GetCustomCarsList(Expression<Func<Arac, bool>> expression)
        {
            return await _dbSet.Where(expression).AsNoTracking().Include(x => x.Marka).ToListAsync();
        }
    }
}
