using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Data
{
    public class ProductRepsitory : IProductRepository
    {
        private readonly StoreContext context;


        public ProductRepsitory(StoreContext context)
        {
            this.context = context;

        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
                        return await context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await context.ProductTypes.ToListAsync();
        }
    }
}