using InCommPayment.Application.Interfaces;
using InCommPayment.Domain.Interfaces.Services;
using InCommPayment.Domain.Model;

namespace InCommPayment.Application.Services
{
    public class AppServiceOrder : AppServiceBase<Order>, IAppServiceOrder
    {
        public readonly IServiceOrder _serviceOrder;

        public AppServiceOrder(IServiceOrder serviceOrder) : base(serviceOrder)
        {
            _serviceOrder = serviceOrder;
        }
    }
}
