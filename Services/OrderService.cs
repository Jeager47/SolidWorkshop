using SolidWorkshop.Models;
using SolidWorkshop.Repositories;
using SolidWorkshop.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidWorkshop.Services
{
    public class OrderService
    {
        private readonly List<Order> _orders = new();
        private readonly IOrderRepository _repository;
        private readonly IPriceCalculator _priceCalculator;

        public OrderService(IOrderRepository repository, IPriceCalculator priceCalculator)
        {
            _repository = repository;
            _priceCalculator = priceCalculator;
        }

        public IEnumerable<Order> GetOrders() => _orders;

        public Order CreateOrder(string customerName, List<OrderItem> items)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentException("El nombre del cliente es obligatorio");

            if (items == null || items.Count == 0)
                throw new ArgumentException("Debe haber al menos un ítem en el pedido");

            var order = new Order
            {
                Id = _orders.Count + 1,
                CustomerName = customerName,
                Items = items,
                Total = _priceCalculator.CalculateTotal(items)
            };

            _orders.Add(order);
            _repository.Save(_orders);
            return order;
        }
    }

}
