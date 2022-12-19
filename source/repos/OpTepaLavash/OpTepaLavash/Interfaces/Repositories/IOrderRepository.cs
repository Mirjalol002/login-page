using OpTepaLavash.Interfaces.Common;
using OpTepaLavash.Models;
using OpTepaLavash.ViewModels;

namespace OpTepaLavash.Interfaces.Repositories
{
    public interface IOrderRepository : ICreateable<OrderViewModel>, IDeleteable<Order>,
        IUpdateable<Order>, IReadable<Order>
    {
    }
}
