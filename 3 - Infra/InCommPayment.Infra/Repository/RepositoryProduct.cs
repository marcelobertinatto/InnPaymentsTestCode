using InCommPayment.Domain.Interfaces;
using InCommPayment.Domain.Interfaces.Repositories;
using InCommPayment.Domain.Model;
using InCommPayment.Infra.Context;

namespace InCommPayment.Infra.Repository
{
    public class RepositoryProduct : RepositoryBase<Product>, IProductRepository
    {
        public readonly DBContext _dbContext;
        public readonly IUnitOfWork _unitOfWork;

        public RepositoryProduct(DBContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }
    }
}
