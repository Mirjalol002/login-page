using Microsoft.EntityFrameworkCore;
using OpTepaLavash.DB_Constants;
using OpTepaLavash.Interfaces.Repositories;
using OpTepaLavash.Models;
using OpTepaLavash.ViewModels;

namespace OpTepaLavash.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        AppDbContext appDbContext = new AppDbContext();
        Order orders = new Order();
        public async Task<bool> CreateAsync(OrderViewModel obj)
        {
            await appDbContext.Orders.AddAsync(orders);
            await appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var order = await appDbContext.Orders.FindAsync(id);
            appDbContext.Orders.Remove(order!);
            await appDbContext.SaveChangesAsync();
            return true;
        }
#pragma warning disable

        public async Task<IQueryable<Order>> GetAllAsync() =>  appDbContext.Orders;

        public async Task<Order> GetAsync(int id) => await appDbContext.Orders.FindAsync(id);
# pragma warning restore
        public async Task<bool> UpdateAsync(int id, Order obj)
        {
            var order = await appDbContext.Orders.FindAsync(id);
            if (order is null)
                return false;
            order.Id = obj.Id;
            order.Employee = obj.Employee;
            order.EmployeeId = obj.EmployeeId;
            order.Client = obj.Client;
            order.ClinetId = obj.ClinetId;
            order.DateTime = obj.DateTime;
            order.TableNumber = obj.TableNumber;
            appDbContext.Orders.Update(order);
            await appDbContext.SaveChangesAsync();
            return true;
        }
    }
}
