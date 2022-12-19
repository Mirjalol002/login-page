using OpTepaLavash.Interfaces.Common;
using OpTepaLavash.Models;

namespace OpTepaLavash.Interfaces.Repositories
{
    public interface IOrderDetailRepository : ICreateable<OrderDetail>, IDeleteable<OrderDetail>,
        IReadable<OrderDetail>, IUpdateable<OrderDetail>
    {
    }
}
