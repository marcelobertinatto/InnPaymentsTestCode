using InCommPayment.Domain.Interfaces.Repositories;
using InCommPayment.Domain.Interfaces.Services;

namespace InCommPayment.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        public readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public void AddAll(List<T> entities)
        {
            _repository.AddAll(entities);
        }

        public async Task<T> Get(string id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
