using ProductStore.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductStore.Api.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
