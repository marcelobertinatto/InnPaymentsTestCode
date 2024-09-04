namespace InCommPayment.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        void AddAll(List<T> entities);
        Task<T> Get(string id);
        Task<List<T>> GetAll();

    }
}
