using InCommPayment.Application.Interfaces;
using InCommPayment.Domain.Interfaces.Services;

namespace InCommPayment.Application.Services
{
    public class AppServiceBase<T> : IAppServiceBase<T> where T : class
    {
        public readonly IServiceBase<T> _appServiceBase;

        public AppServiceBase(IServiceBase<T> appServiceBase)
        {
            _appServiceBase = appServiceBase;
        }
        public void Add(T entity)
        {
            _appServiceBase.Add(entity);
        }

        public void AddAll(List<T> entities)
        {
            _appServiceBase.AddAll(entities);
        }

        public async Task<T> Get(string id)
        {
            return await _appServiceBase.Get(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _appServiceBase.GetAll();
        }
    }
}
