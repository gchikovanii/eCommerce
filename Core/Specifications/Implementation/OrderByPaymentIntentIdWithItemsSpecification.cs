using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities.OrderAggregate;

namespace Core.Specifications.Implementation
{
    public class OrderByPaymentIntentIdSpecification : BaseSpecification<Order>
    {
        public OrderByPaymentIntentIdSpecification(string paymentIntentId) : 
            base( i=> i.PaymentIntentId == paymentIntentId)
        {
        }
    }
}