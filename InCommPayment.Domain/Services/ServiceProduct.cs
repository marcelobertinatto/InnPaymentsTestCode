using InCommPayment.Domain.Interfaces.Repositories;
using InCommPayment.Domain.Interfaces.Services;
using InCommPayment.Domain.Model;

namespace InCommPayment.Domain.Services
{
    public class ServiceProduct : ServiceBase<Product>, IServiceProduct
    {
        public readonly IProductRepository _productRepository;

        public ServiceProduct(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }
    }
}
