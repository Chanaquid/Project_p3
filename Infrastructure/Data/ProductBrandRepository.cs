using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductBrandRepository : IProductBrandRepository
    {
        private readonly StoreContext _context;

        public ProductBrandRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<ProductBrand> GetProductBrandByIdAsync(int id)
        {
            return await _context.ProductBrand.FindAsync(id);
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrand.ToListAsync();
        }

        public async Task AddProductBrandAsync(ProductBrand productBrand)
        {
            await _context.ProductBrand.AddAsync(productBrand);
        }

        public void DeleteProductBrandAsync(ProductBrand productBrand)
        {
            _context.ProductBrand.Remove(productBrand);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}