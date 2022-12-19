using Microsoft.EntityFrameworkCore;
using OpTepaLavash.DB_Constants;
using OpTepaLavash.Interfaces.Repositories;
using OpTepaLavash.Models;
#pragma warning disable
namespace OpTepaLavash.Repositories
{
    public class ProductRepository : IProductRepository
    {
        AppDbContext appDbContext = new AppDbContext();
        Product products = new Product();

        public async Task<bool> CreateAsync(Product obj)
        {
            await appDbContext.AddRangeAsync(obj);
            await appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await appDbContext.Products.FindAsync(id);
            appDbContext.Products.Remove(product);
            await appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Product>> GetAllAsync() => appDbContext.Products;


        public async Task<Product> GetAsync(int id) => await appDbContext.Products.FindAsync(id)!;

        public async Task<bool> UpdateAsync(int id, Product obj)
        {
            var product = await appDbContext.Products.FindAsync(id);
            if (product is null)
                return false;
            product.Id= obj.Id;
            product.Name= obj.Name;
            product.Price= obj.Price;
            appDbContext.Products.Update(product);
            await appDbContext.SaveChangesAsync();
            return true;
        }

    }
}
