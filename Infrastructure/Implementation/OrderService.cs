using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Specifications.Abstraction;
using Infrastructure.Abstraction;

namespace Infrastructure.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IUnityOfWork _unitOfWork;

        public OrderService(IBasketRepository basketRepository, IUnityOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _basketRepository = basketRepository;
        }
        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            //get basket
            var basket = await _basketRepository.GetBasketAsync(basketId);
            //get items 
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                 var productItem = await _unitOfWork.Repositoryy<Product>().GetByIdAsync(item.Id);
                var itemOrdered = new ProctItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }
            var deliveryMethod = await _unitOfWork.Repositoryy<DeliveryMethod>().GetByIdAsync(deliveryMethodId);
            var subtotal = items.Sum(item => item.Price * item.Quantity);
            //create order
            var order = new Order(items,buyerEmail,shippingAddress,deliveryMethod,subtotal);
            _unitOfWork.Repositoryy<Order>().Add(order);
            var results = await _unitOfWork.Complete();
            if(results <= 0)
                return null;
            await _basketRepository.DelteBasketAsync(basketId);    
            return order;
        }

        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            throw new NotImplementedException();
        }
    }
}