using OtoServisSatis.Entities;
using System.Linq.Expressions;

namespace OtoServisSatis.Data.Abstract
{
    public interface ICarRepository : IRepository<Arac>
    {
        Task<List<Arac>> GetCustomCarsList();
        Task<List<Arac>> GetCustomCarsList(Expression<Func<Arac, bool>> expression);
        Task<Arac> GetCustomCar(int id);
    }
}

