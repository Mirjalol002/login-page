using Microsoft.EntityFrameworkCore;
using OpTepaLavash.DB_Constants;
using OpTepaLavash.Interfaces.Repositories;
using OpTepaLavash.Models;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace OpTepaLavash.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        AppDbContext appDbContext = new AppDbContext();

        OrderDetail orders = new OrderDetail();

        public async Task<bool> CreateAsync(OrderDetail obj)
        {
            await appDbContext.OrderDetails.AddAsync(obj);
            await appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var order = await appDbContext.OrderDetails.FindAsync(id);
            appDbContext.Remove(orders);
            await appDbContext.SaveChangesAsync();
            return true;
        }

        //OrderDe tailni Get qiganda FirstOrdefault(...).Include(o => o.Product) dsizi
        //public async Task<IQueryable<OrderDetail>> GetAllAsyinc(Expression<Func<OrderDetail, Boolean>> expression = null) => await .GetAll(expression).Include(p => p.Product).ToListAsync();

#pragma warning disable


        public async Task<IQueryable<OrderDetail>> GetAllAsync()
            => appDbContext.OrderDetails;



        public async Task<OrderDetail> GetAsync(int id)
            => await appDbContext.OrderDetails.FindAsync(id);


        //public async Task<OrderDetail> GetAsyinc(int id) =>
        //     await appDbContext.OrderDetails.FindAsync(id).Include(x => x.Product);

# pragma warning restore
        public async Task<bool> UpdateAsync(int id, OrderDetail obj)
        {
            var orderDetail = await appDbContext.OrderDetails.FindAsync(id);
            if (orderDetail is null)
                return false;
            orderDetail.Id = obj.Id;
            orderDetail.Order = obj.Order;
            orderDetail.OrderId = obj.OrderId;
            orderDetail.Product = obj.Product;
            orderDetail.ProductId = obj.ProductId;

            appDbContext.OrderDetails.Update(orderDetail);
            await appDbContext.SaveChangesAsync();
            return true;

        }
    }
}
