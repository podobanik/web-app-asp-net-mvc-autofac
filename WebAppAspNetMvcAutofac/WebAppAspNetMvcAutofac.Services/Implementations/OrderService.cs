using Common.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAppAspNetMvcAutofac.DataModel;

namespace WebAppAspNetMvcAutofac.Services.Abstractions
{
    public class OrderService : IOrderService
    {
        private readonly Lazy<IRepository<Order>> _orderRepository;

        public OrderService(Lazy<IRepository<Order>> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public List<Order> GetEntities()
        {
            return _orderRepository.Value.GetQuery().ToList();
        }

        public Order Create()
        {
            return new Order();
        }
        public void Create(Order model)
        {
            _orderRepository.Value.Add(model);
            _orderRepository.Value.SaveChanges();
        }
        public void Delete(int id)
        {
            var order = _orderRepository.Value.FirstOrDefault(x => x.Id == id);
            if (order == null)
                throw new Exception("Order not found");

            _orderRepository.Value.Delete(order);
            _orderRepository.Value.SaveChanges();
        }
        public Order Edit(int id)
        {
            var order = _orderRepository.Value.FirstOrDefault(x => x.Id == id);
            if (order == null)
                throw new Exception("Order not found");

            return order;
        }
        public void Edit(Order model)
        {
            var order = _orderRepository.Value.FirstOrDefault(x => x.Id == model.Id);
            if (order == null)
                throw new Exception("Order not found");

            MappingOrder(model, order);

            _orderRepository.Value.Update(order);
            _orderRepository.Value.SaveChanges();
        }

        private void MappingOrder(Order sourse, Order destination)
        {
            destination.Procedure = sourse.Procedure;
            destination.Description = sourse.Description;
        }
    }
}
