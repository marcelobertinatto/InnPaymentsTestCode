using InCommPayment.Domain.Interfaces.Repositories;
using InCommPayment.Domain.Interfaces.Services;
using InCommPayment.Domain.Model;

namespace InCommPayment.Domain.Services
{
    public class ServiceOrder : ServiceBase<Order>,IServiceOrder
    {
        public readonly IOrderRepository _orderRepository;

        public ServiceOrder(IOrderRepository orderRepository) : base(orderRepository)
        {
            _orderRepository = orderRepository;
        }
    }
}
