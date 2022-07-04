using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications.Implementation
{
    public class ProductWithFiltersCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersCountSpecification(ProductSpecParams productParams) : base(
            i => (string.IsNullOrEmpty(productParams.Search) || i.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.BrandId.HasValue || i.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || i.ProductTypeId == productParams.TypeId))
        {

        }
    }
}