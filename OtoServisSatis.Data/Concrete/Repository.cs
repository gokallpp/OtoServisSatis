using Microsoft.EntityFrameworkCore;
using OtoServisSatis.Data.Abstract;
using OtoServisSatis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Data.Concrete
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new() 
    {
        internal DatabaseContext _context;
        internal DbSet<T> _dbSet;

        public Repository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>(); // DbSet<T> nesnesini alır ve _dbSet alanına atar
        }

         

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T Find(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> FindAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression); // Belirtilen koşula uyan ilk nesneyi döndürür veya null döndürür
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList(); // Tüm nesneleri liste olarak döndürür
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).ToList(); // Belirtilen koşula uyan nesneleri liste olarak döndürür
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        } 

        public Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefaultAsync(expression);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
