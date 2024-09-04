using InCommPayment.Application.Interfaces;
using InCommPayment.Domain.Interfaces.Services;
using InCommPayment.Domain.Model;

namespace InCommPayment.Application.Services
{
    public class AppServiceProduct : AppServiceBase<Product>, IAppServiceProduct
    {
        public readonly IServiceProduct _appServiceProduct;

        public AppServiceProduct(IServiceProduct appServiceProduct) : base(appServiceProduct)
        {
            _appServiceProduct = appServiceProduct;
        }
    }
}
