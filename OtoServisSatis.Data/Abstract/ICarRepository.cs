using OtoServisSatis.Entities;

namespace OtoServisSatis.Data.Abstract
{
    public interface ICarRepository : IRepository<Arac>
    {
        Task<IEnumerable<Arac>> GetCustomCarsList();
        Task<Arac> GetCustomCar(int id);
    }
}

