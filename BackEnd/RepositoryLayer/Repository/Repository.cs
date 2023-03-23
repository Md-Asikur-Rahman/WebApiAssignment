using DomainLayer.Data;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repository.Interfaces;

namespace RepositoryLayer.Repository
{
    public class Repository <T>   : IRepository<T> where T : class
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private DbSet<T> entities;
        public Repository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
            entities = _employeeDbContext.Set<T>();

        }
        public  IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T GetByID(int id)
        {
            return entities.Find(id);
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _employeeDbContext.SaveChanges();
        }
        public void DeleteByID(int id)
        {
            var entity = entities.Find(id);

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _employeeDbContext.SaveChanges();
        }
        public void Update(T entity) { 
            if (entity == null) 
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            _employeeDbContext.SaveChanges();
        }
       
    }
}
