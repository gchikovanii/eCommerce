using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(i => i.ShippingAddress, o => {
                o.WithOwner();
            });
            builder.Property(i => i.Status).HasConversion(
                o => o.ToString(),
                o => (OrderStatus) Enum.Parse(typeof(OrderStatus),o)
            );
            builder.HasMany(i => i.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}