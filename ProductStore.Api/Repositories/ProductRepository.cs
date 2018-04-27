using Microsoft.EntityFrameworkCore;
using ProductStore.Api.Contexts;
using ProductStore.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductStore.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductStoreContext _context;

        public ProductRepository(ProductStoreContext context)
        {
            this._context = context;
        }

        public async Task CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var delete = await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
            if (delete != null)
            {
                _context.Products.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
