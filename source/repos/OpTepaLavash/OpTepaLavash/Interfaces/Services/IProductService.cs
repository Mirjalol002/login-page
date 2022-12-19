using OpTepaLavash.Models;

namespace OpTepaLavash.Interfaces.Services
{
    public interface IProductService
    {
        public Task<Product> GetAsync(int id);
        public Task<IEnumerable<Product>> GetAllAsync();

    }
}
