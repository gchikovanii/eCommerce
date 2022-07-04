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
        public ProductsWithTypesAndBrandSpecification(ProductSpecParams productParams) : base(
            i => (string.IsNullOrEmpty(productParams.Search) || i.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.BrandId.HasValue || i.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || i.ProductTypeId == productParams.TypeId))
        {
            AddInclude(i => i.ProductType);
            AddInclude(i => i.ProductBrand);
            AddOrderBy(i => i.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex -1),productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(i => i.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(i => i.Price);
                        break;
                    default:
                        AddOrderBy(i => i.Name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandSpecification(int id) : base(i => i.Id == id)
        {
            AddInclude(i => i.ProductType);
            AddInclude(i => i.ProductBrand);
        }
    }
}