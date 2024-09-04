using InCommPayment.Domain.Interfaces;
using InCommPayment.Domain.Interfaces.Repositories;
using InCommPayment.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace InCommPayment.Infra.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public readonly DBContext _dbContext;
        public readonly IUnitOfWork _unitOfWork;

        public RepositoryBase(DBContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }
        public void Add(T entity)
        {
            _dbContext.Add(entity);
            _unitOfWork.CommitAsync();
        }

        public void AddAll(List<T> entities)
        {
            _dbContext.AddRangeAsync(entities);
            _unitOfWork.CommitAsync();
        }

        public async Task<T> Get(string id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
    }
}
