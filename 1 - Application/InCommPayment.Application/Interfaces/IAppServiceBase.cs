using InCommPayment.Domain.Interfaces.Repositories;

namespace InCommPayment.Application.Interfaces
{
    public interface IAppServiceBase<T>
    {
        void Add(T entity);
        void AddAll(List<T> entities);
        Task<T> Get(string id);
        Task<List<T>> GetAll();
    }
}
