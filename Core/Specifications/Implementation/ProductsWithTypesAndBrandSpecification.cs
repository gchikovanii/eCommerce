using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications.Implementation
{
    public class ProductsWithTypesAndBrandSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandSpecification()
        {
            AddInclude(i => i.ProductType);
            AddInclude(i => i.ProductBrand);
        }

        public ProductsWithTypesAndBrandSpecification(int id) : base(i => i.Id == id)
        {
            AddInclude(i => i.ProductType);
            AddInclude(i => i.ProductBrand);
        }
    }
}