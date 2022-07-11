using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities.OrderAggregate;

namespace Core.Specifications.Implementation
{
    public class OrderWithItemsAndOrderingSpecification : BaseSpecification<Order>
    {
        public OrderWithItemsAndOrderingSpecification(string email) : base(i => i.BuyerEmail == email)
        {
            AddInclude(i => i.OrderItems);
            AddInclude(i => i.DeliveryMethod);
            AddOrderByDescending(i => i.OrderDate);
        }

        public OrderWithItemsAndOrderingSpecification(int id,string email) : base(i => i.Id == id
        && i.BuyerEmail == email)
        {
            AddInclude(i => i.OrderItems);
            AddInclude(i => i.DeliveryMethod);
        }
    }
}