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
            _dbSet = _context.Set<T>();
        }

         

        public void Add(T entity)
        {
            _dbSet.Add(entity);// Yeni bir nesneyi ekler    
        }

        public async Task AddAsync(T entity)// Yeni bir nesneyi asenkron olarak ekler
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)// Belirtilen nesneyi siler
        {
            _dbSet.Remove(entity);
        }

        public T Find(int id)// Belirtilen id'ye sahip nesneyi bulur
        {
            return _dbSet.Find(id);
        }

        public async Task<T> FindAsync(int id)// Belirtilen id'ye sahip nesneyi asenkron olarak bulur
        {
            return await _dbSet.FindAsync(id);
        }

        public T Get(Expression<Func<T, bool>> expression)// Belirtilen koşula uyan ilk nesneyi döndürür veya null döndürür
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public List<T> GetAll()// Tüm nesneleri liste olarak döndürür
        {
            return _dbSet.ToList(); // Tüm nesneleri liste olarak döndürür
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)// Belirtilen koşula uyan nesneleri liste olarak döndürür
        {
            return _dbSet.Where(expression).ToList();
        }

        public async Task<List<T>> GetAllAsync()// Tüm nesneleri asenkron olarak liste olarak döndürür
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
