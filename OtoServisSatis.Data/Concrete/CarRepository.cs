using Microsoft.EntityFrameworkCore;
using OtoServisSatis.Data.Abstract;
using OtoServisSatis.Entities;

namespace OtoServisSatis.Data.Concrete
{
    internal class CarRepository : Repository<Arac>, ICarRepository
    {
        public CarRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Arac> GetCustomCar(int id)
        {
            // Arac nesnesini alırken Marka gezinme özelliğini dahil edin
            return await _dbSet.AsNoTracking().Include(x => x.Marka).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Arac>> GetCustomCarsList()
        {
            // Tüm araçları alırken Marka gezinme özelliğini dahil edin
            return await _dbSet.AsNoTracking().Include(x => x.Marka).ToListAsync();
        }

        
    }
}
