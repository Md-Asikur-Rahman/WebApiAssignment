namespace RepositoryLayer.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        void  Add(T employee);
        void Update(T employee);
        void DeleteByID(int id);      
    }
}
