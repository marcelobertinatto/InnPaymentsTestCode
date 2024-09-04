using InCommPayment.Domain.Interfaces;
using InCommPayment.Infra.Context;

namespace InCommPayment.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DBContext _dbContext;

        public UnitOfWork(DBContext dbContext) 
        {
            _dbContext = dbContext; 
        }

        public void CommitAsync()
        {
           _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
           _dbContext.DisposeAsync();
        }
    }
}
